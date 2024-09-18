#!/usr/bin/env python
# coding: utf-8

# In[1]:


import tensorflow as tf
from tensorflow.keras import datasets, layers, models
import numpy as np
from sklearn.model_selection import train_test_split
from sklearn.metrics import accuracy_score, precision_score, recall_score, f1_score
import matplotlib.pyplot as plt
import time 


# In[2]:


# використав CIFAR-10 із keras
(x_train, y_train), (x_test, y_test) = datasets.cifar10.load_data()


# In[3]:


# вибрав перші 4 класи
selected_classes = [0, 1, 2, 3]
train_filter = np.isin(y_train, selected_classes).flatten()
test_filter = np.isin(y_test, selected_classes).flatten()

x_train, y_train = x_train[train_filter], y_train[train_filter]
x_test, y_test = x_test[test_filter], y_test[test_filter]


# In[4]:


# Нормалізація даних

# пікселі в зображеннях мають діапазон [0, 255] тому нормалізація переводить ці значення на [0, 1]
x_train, x_test = x_train / 255.0, x_test / 255.0

# кожна мітка перетворюється в бінарний вектор для зручності роботи з моделлю
y_train = tf.keras.utils.to_categorical(y_train, len(selected_classes))
y_test = tf.keras.utils.to_categorical(y_test, len(selected_classes)) 

# поділ навчальної вибірки у співвідношенні 80:20
x_train_initial, x_pool, y_train_initial, y_pool = train_test_split(x_train, y_train, test_size=0.8, random_state=42)


# In[5]:


# Модель
def create_model():
    model = models.Sequential([
        layers.Conv2D(32, (3, 3), activation='relu', input_shape=(32, 32, 3)),
        layers.MaxPooling2D((2, 2)),
        layers.Conv2D(64, (3, 3), activation='relu'),
        layers.MaxPooling2D((2, 2)),
        layers.Conv2D(64, (3, 3), activation='relu'),
        layers.Flatten(),
        layers.Dense(64, activation='relu'),
        layers.Dense(len(selected_classes), activation='softmax')
    ])
    model.compile(optimizer='adam', loss='categorical_crossentropy', metrics=['accuracy'])
    return model


# In[6]:


# МЕТОДИ ВІДБОРУ ЗА НЕВИЗНАЧЕНІСТЮ ДЛЯ АКТИВНОГО НАВЧАННЯ

#Метод найменшої впевненості (Least Confidence) — це стратегія вибору зразків для активного навчання, 
#яка спрямована на відбір зразків, у яких модель найменш впевнена в своєму прогнозі. 
#Основна ідея полягає в тому, що модель отримає найбільшу користь від додаткових міток для тих зразків, 
#де її прогнози є найменш точними або впевненими.
def least_confidence(predictions):
    return -np.max(predictions, axis=1)


# In[7]:


#Метод межового відбору (Margin Sampling) — це стратегія активного навчання, яка спрямована на вибір зразків, 
#для яких модель має найбільшу невизначеність щодо двох найбільш імовірних класів. На відміну від методу найменшої впевненості,
#де аналізується лише ймовірність найімовірнішого класу, межовий відбір фокусується на різниці 
#між ймовірностями двох провідних класів.
def margin_sampling(predictions):
    sorted_pred = np.sort(predictions, axis=1)
    return sorted_pred[:, -1] - sorted_pred[:, -2]


# In[8]:


#Метод відношення впевненостей (Ratio Confidence) — це підхід до активного навчання, 
#який вибирає зразки на основі відношення ймовірностей двох найбільш ймовірних класів, які модель прогнозує. 
#Він подібний до методу межового відбору, але замість різниці між двома провідними класами використовується їхнє відношення.
def ratio_confidence(predictions):
    sorted_pred = np.sort(predictions, axis=1)
    return sorted_pred[:, -1] / sorted_pred[:, -2]


# In[9]:


#Метод ентропії (Entropy) — це стратегія активного навчання, яка базується на вимірюванні ентропії прогнозів моделі 
#для кожного зразка. Ентропія — це показник невизначеності або розподілу ймовірностей між класами. 
#Чим більше значення ентропії, тим більша невпевненість моделі щодо належності зразка до певного класу.
def entropy(predictions):
    return -np.sum(predictions * np.log(predictions + 1e-10), axis=1)


# In[10]:


# функція для відбору зразків, які найбільш невпевнені
def select_samples(uncertainty_scores, num_samples):
    return np.argsort(uncertainty_scores)[:num_samples]


# In[11]:


# підготовка для активного навчання
num_iterations = 5
strategies = {
    "Least Confidence": least_confidence,
    "Margin Sampling": margin_sampling,
    "Ratio Confidence": ratio_confidence,
    "Entropy": entropy
}


# In[12]:


# для зберігання результатів
metrics_per_strategy = {key: [] for key in strategies}
time_per_strategy = {key: [] for key in strategies} 


# In[13]:


# Активне навчання
for strategy_name, strategy_function in strategies.items():
    print(f"\n--- Активне навчання за стратегією: {strategy_name} ---")
    
    # Початкова модель
    model = create_model()
    model.fit(x_train_initial, y_train_initial, epochs=5, batch_size=64, validation_data=(x_test, y_test), verbose=0)
    
    # Оцінка на початку
    initial_accuracy = model.evaluate(x_test, y_test, verbose=0)[1]
    print(f"Точність на початку: {initial_accuracy:.4f}")
    
    # Початковий набір для навчання
    x_current_train = x_train_initial
    y_current_train = y_train_initial
    
    for iteration in range(num_iterations):
        print(f"\nІтерація {iteration + 1}/{num_iterations}")
        
        # Початок вимірювання часу
        start_time = time.time()

        # Прогнозування на поточному пулі
        predictions = model.predict(x_pool)
        
        # Оцінка невизначеності для кожного зразка
        uncertainty_scores = strategy_function(predictions)
        
        # Визначення розміру query_size як 15% від поточного пулу
        query_size = int(0.15 * len(x_pool))
        
        # Вибір найбільш невпевнених зразків
        selected_indices = select_samples(uncertainty_scores, query_size)
        
        # Вибірка нових зразків для тренування
        x_query = x_pool[selected_indices]
        y_query = y_pool[selected_indices]
        
        # Оновлення поточного набору даних для тренування
        x_current_train = np.concatenate([x_current_train, x_query])
        y_current_train = np.concatenate([y_current_train, y_query])
        
        # Видалення відібраних зразків з пулу
        x_pool = np.delete(x_pool, selected_indices, axis=0)
        y_pool = np.delete(y_pool, selected_indices, axis=0)
        
        # Повторне тренування моделі на оновлених даних
        model.fit(x_current_train, y_current_train, epochs=5, batch_size=64, validation_data=(x_test, y_test), verbose=0)
        
        # Оцінка на тестовому наборі
        test_accuracy = model.evaluate(x_test, y_test, verbose=0)[1]
        metrics_per_strategy[strategy_name].append(test_accuracy)
        
        # Кінець вимірювання часу
        end_time = time.time()
        iteration_time = end_time - start_time
        time_per_strategy[strategy_name].append(iteration_time)  # Збереження часу
        
        print(f"Точність після виконання ітерації {iteration + 1}: {test_accuracy:.4f}")
        print(f"Тривалість виконання ітерації {iteration + 1}: {iteration_time:.2f} секунд")


# In[14]:


# Налаштування стилю графіків
plt.style.use('seaborn-darkgrid')

# Порівняння результатів
plt.figure(figsize=(10, 6))

for strategy_name, accuracies in metrics_per_strategy.items():
    plt.plot(range(1, num_iterations + 1), accuracies, label=strategy_name,
             marker='o', linestyle='--', linewidth=2)

plt.title('Порівняння стратегій активного навчання', fontsize=16, fontweight='bold')
plt.xlabel('Ітерація', fontsize=12)
plt.ylabel('Точність', fontsize=12)
plt.legend(loc='best', framealpha=0.8)
plt.grid(True, linestyle=':', linewidth=0.7)
plt.show()

# Виведення часу для кожної стратегії
plt.figure(figsize=(10, 6))

for strategy_name, times in time_per_strategy.items():
    plt.plot(range(1, num_iterations + 1), times, label=strategy_name,
             marker='s', linestyle='-', linewidth=2)

plt.title('Час виконання для кожної стратегії', fontsize=16, fontweight='bold')
plt.xlabel('Ітерація', fontsize=12)
plt.ylabel('Час (секунди)', fontsize=12)
plt.legend(loc='best', framealpha=0.8)
plt.grid(True, linestyle=':', linewidth=0.7)
plt.show()


# In[ ]:




