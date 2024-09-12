#!/usr/bin/env python
# coding: utf-8

# In[1]:


import tensorflow as tf
from tensorflow.keras import datasets, layers, models
import numpy as np
from sklearn.model_selection import train_test_split
from sklearn.metrics import accuracy_score, precision_score, recall_score, f1_score
import matplotlib.pyplot as plt


# In[2]:


# завантажив CIFAR-10 із keras
(x_train, y_train), (x_test, y_test) = datasets.cifar10.load_data()


# In[3]:


# вибрав перші 4 класи
selected_classes = [0, 1, 2, 3]
train_filter = np.isin(y_train, selected_classes).flatten()
test_filter = np.isin(y_test, selected_classes).flatten()


# In[4]:


x_train, y_train = x_train[train_filter], y_train[train_filter]
x_test, y_test = x_test[test_filter], y_test[test_filter]


# In[5]:


# Нормалізація даних

x_train, x_test = x_train / 255.0, x_test / 255.0


# In[6]:


# кожна мітка переводиться в бінарний вектор
y_train = tf.keras.utils.to_categorical(y_train, len(selected_classes))
y_test = tf.keras.utils.to_categorical(y_test, len(selected_classes))


# In[7]:


# поділ навчальної вибірки у співвідношенні 80:20
x_train, x_test, y_train, y_test = train_test_split(x_train, y_train, test_size=0.2, random_state=42)


# In[8]:


# Виведення кількості зразків у всьому наборі
print(f'Кількість зразків у навчальній вибірці: {x_train.shape[0]}')
print(f'Кількість зразків у тестовій вибірці: {x_test.shape[0]}')


# In[9]:


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
    
    # компіляція моделі
    model.compile(optimizer='adam',
                  loss='categorical_crossentropy',
                  metrics=['accuracy'])
    return model


# In[10]:


# Пасивне навчання 


# модель тренується на всьому доступному наборі даних
print("Passive Learning:")
model_passive = create_model()
history_passive = model_passive.fit(x_train, y_train, epochs=5, batch_size=64, validation_data=(x_test, y_test))


# In[11]:


# оцінка моделі на навчальній вибірці accuracy, precision, повноти (recall), та f1-score
y_train_pred = model_passive.predict(x_train)
y_train_pred_classes = np.argmax(y_train_pred, axis=1)
y_train_true = np.argmax(y_train, axis=1)

metrics_passive_train = {
    "accuracy": accuracy_score(y_train_true, y_train_pred_classes),
    "precision": precision_score(y_train_true, y_train_pred_classes, average='weighted'),
    "recall": recall_score(y_train_true, y_train_pred_classes, average='weighted'),
    "f1_score": f1_score(y_train_true, y_train_pred_classes, average='weighted')
}


# In[12]:


# оцінка моделі на тестовій вибірці
y_test_pred = model_passive.predict(x_test)
y_test_pred_classes = np.argmax(y_test_pred, axis=1)
y_test_true = np.argmax(y_test, axis=1)

metrics_passive_test = {
    "accuracy": accuracy_score(y_test_true, y_test_pred_classes),
    "precision": precision_score(y_test_true, y_test_pred_classes, average='weighted'),
    "recall": recall_score(y_test_true, y_test_pred_classes, average='weighted'),
    "f1_score": f1_score(y_test_true, y_test_pred_classes, average='weighted')
}


# In[13]:


# Виведення результатів
print(f" Passive Learning Training Set: Accuracy={metrics_passive_train['accuracy']:.4f}, Precision={metrics_passive_train['precision']:.4f}, Recall={metrics_passive_train['recall']:.4f}, F1-Score={metrics_passive_train['f1_score']:.4f}")
print(f" Passive Learning Test Set: Accuracy={metrics_passive_test['accuracy']:.4f}, Precision={metrics_passive_test['precision']:.4f}, Recall={metrics_passive_test['recall']:.4f}, F1-Score={metrics_passive_test['f1_score']:.4f}")


# In[14]:


# Активне навчання

# !!! 10 : 20(тестових) : 70 ✅

# на кожній ітерації вибираються найбільш невпевнені зразки для подальшого навчання моделі,
# щоб модель зосередилася на найважчих прикладах, покращуючи ефективність навчання


# In[15]:


num_iterations = 5  # кількість ітерацій активного навчання

# ініціалізація невикористаного набору даних
x_pool = x_train
y_pool = y_train

metrics_active = {
    "train_accuracy": [],
    "train_precision": [],
    "train_recall": [],
    "train_f1_score": [],
    "test_accuracy": [],
    "test_precision": [],
    "test_recall": [],
    "test_f1_score": []
}


# In[16]:


for i in range(num_iterations):
    print(f"\nActive Learning Iteration {i + 1}/{num_iterations}")
    
    model_passive = create_model()
    model_passive.fit(x_pool, y_pool, epochs=5, batch_size=64, validation_data=(x_test, y_test))
    
    y_pool_pred = model_passive.predict(x_pool)
        
    uncertainty = -np.max(y_pool_pred, axis=1)  
    
    # Зразки з найвищою невпевненістю
    # вибираються для подальшого навчання.
    
    # обчислення розміру вибірки як 10% від поточного розміру пулу
    query_size = int(0.1 * len(x_pool))
    
    # np.argsort повертає індекси зразків, відсортовані за невпевненістю
    uncertain_samples_idx = np.argsort(uncertainty)[:query_size]  # найменш впевнені прогнози

    x_query = x_pool[uncertain_samples_idx]
    y_query = y_pool[uncertain_samples_idx]

    # навчання на нових даних
    model_passive.fit(x_query, y_query, epochs=5, batch_size=64, validation_data=(x_test, y_test))
    
    # видалення використаних зразків
    x_pool = np.delete(x_pool, uncertain_samples_idx, axis=0)
    y_pool = np.delete(y_pool, uncertain_samples_idx, axis=0)

    # оцінка після кожної ітерації 
    y_train_pred = model_passive.predict(x_train)
    y_train_pred_classes = np.argmax(y_train_pred, axis=1)
    y_train_true = np.argmax(y_train, axis=1)

    metrics_active["train_accuracy"].append(accuracy_score(y_train_true, y_train_pred_classes))
    metrics_active["train_precision"].append(precision_score(y_train_true, y_train_pred_classes, average='weighted'))
    metrics_active["train_recall"].append(recall_score(y_train_true, y_train_pred_classes, average='weighted'))
    metrics_active["train_f1_score"].append(f1_score(y_train_true, y_train_pred_classes, average='weighted'))

    print(f"Iteration {i + 1}: Active Learning Train Accuracy={metrics_active['train_accuracy'][-1]:.4f}, Train Precision={metrics_active['train_precision'][-1]:.4f}, Train Recall={metrics_active['train_recall'][-1]:.4f}, Train F1-Score={metrics_active['train_f1_score'][-1]:.4f}")
    
    # Оцінка моделі на тестовій вибірці
    y_test_pred = model_passive.predict(x_test)
    y_test_pred_classes = np.argmax(y_test_pred, axis=1)
    y_test_true = np.argmax(y_test, axis=1)

    metrics_active["test_accuracy"].append(accuracy_score(y_test_true, y_test_pred_classes))
    metrics_active["test_precision"].append(precision_score(y_test_true, y_test_pred_classes, average='weighted'))
    metrics_active["test_recall"].append(recall_score(y_test_true, y_test_pred_classes, average='weighted'))
    metrics_active["test_f1_score"].append(f1_score(y_test_true, y_test_pred_classes, average='weighted'))
    
    print(f"Iteration {i + 1}: Active Learning Test Accuracy={metrics_active['test_accuracy'][-1]:.4f}, Test Precision={metrics_active['test_precision'][-1]:.4f}, Test Recall={metrics_active['test_recall'][-1]:.4f}, Test F1-Score={metrics_active['test_f1_score'][-1]:.4f}")


# In[17]:


# Підготовка даних для графіків
iterations = list(range(1, num_iterations + 1))


# In[21]:


#Графік для навчальної вибірки
plt.figure(figsize=(14, 6))

# Accuracy
plt.subplot(1, 4, 1)
plt.plot(iterations, metrics_active["train_accuracy"], 'g^-', label='Active Learning', markerfacecolor='none')
plt.axhline(y=metrics_passive_train['accuracy'], color='m', linestyle='--', label='Passive Learning')
plt.title('Training Accuracy Over Iterations', fontsize=14)
plt.xlabel('Iteration Number', fontsize=12)
plt.ylabel('Accuracy Score', fontsize=12)
plt.legend()
plt.grid(True)

# Precision
plt.subplot(1, 4, 2)
plt.plot(iterations, metrics_active["train_precision"], 'c--o', label='Active Learning', markerfacecolor='none')
plt.axhline(y=metrics_passive_train['precision'], color='y', linestyle='-.', label='Passive Learning')
plt.title('Training Precision Over Iterations', fontsize=14)
plt.xlabel('Iteration Number', fontsize=12)
plt.ylabel('Precision Score', fontsize=12)
plt.legend()
plt.grid(True)

# Recall
plt.subplot(1, 4, 3)
plt.plot(iterations, metrics_active["train_recall"], 'b-.s', label='Active Learning', markerfacecolor='none')
plt.axhline(y=metrics_passive_train['recall'], color='orange', linestyle=':', label='Passive Learning')
plt.title('Training Recall Over Iterations', fontsize=14)
plt.xlabel('Iteration Number', fontsize=12)
plt.ylabel('Recall Score', fontsize=12)
plt.legend()
plt.grid(True)

# F1-Score
plt.subplot(1, 4, 4)
plt.plot(iterations, metrics_active["train_f1_score"], 'r:*', label='Active Learning', markerfacecolor='none')
plt.axhline(y=metrics_passive_train['f1_score'], color='purple', linestyle='-', label='Passive Learning')
plt.title('Training F1-Score Over Iterations', fontsize=14)
plt.xlabel('Iteration Number', fontsize=12)
plt.ylabel('F1-Score', fontsize=12)
plt.legend()
plt.grid(True)

plt.tight_layout()
plt.show()


# In[22]:


# Графік для тестової вибірки
plt.figure(figsize=(14, 6))

# Accuracy
plt.subplot(1, 4, 1)
plt.plot(iterations, metrics_active["test_accuracy"], 'g^-', label='Active Learning', markerfacecolor='none')
plt.axhline(y=metrics_passive_test['accuracy'], color='m', linestyle='--', label='Passive Learning')
plt.title('Test Accuracy Over Iterations', fontsize=14)
plt.xlabel('Iteration Number', fontsize=12)
plt.ylabel('Accuracy Score', fontsize=12)
plt.legend()
plt.grid(True)

# Precision
plt.subplot(1, 4, 2)
plt.plot(iterations, metrics_active["test_precision"], 'c--o', label='Active Learning', markerfacecolor='none')
plt.axhline(y=metrics_passive_test['precision'], color='y', linestyle='-.', label='Passive Learning')
plt.title('Test Precision Over Iterations', fontsize=14)
plt.xlabel('Iteration Number', fontsize=12)
plt.ylabel('Precision Score', fontsize=12)
plt.legend()
plt.grid(True)

# Recall
plt.subplot(1, 4, 3)
plt.plot(iterations, metrics_active["test_recall"], 'b-.s', label='Active Learning', markerfacecolor='none')
plt.axhline(y=metrics_passive_test['recall'], color='orange', linestyle=':', label='Passive Learning')
plt.title('Test Recall Over Iterations', fontsize=14)
plt.xlabel('Iteration Number', fontsize=12)
plt.ylabel('Recall Score', fontsize=12)
plt.legend()
plt.grid(True)

# F1-Score
plt.subplot(1, 4, 4)
plt.plot(iterations, metrics_active["test_f1_score"], 'r:*', label='Active Learning', markerfacecolor='none')
plt.axhline(y=metrics_passive_test['f1_score'], color='purple', linestyle='-', label='Passive Learning')
plt.title('Test F1-Score Over Iterations', fontsize=14)
plt.xlabel('Iteration Number', fontsize=12)
plt.ylabel('F1-Score', fontsize=12)
plt.legend()
plt.grid(True)

plt.tight_layout()
plt.show()


# In[ ]:




