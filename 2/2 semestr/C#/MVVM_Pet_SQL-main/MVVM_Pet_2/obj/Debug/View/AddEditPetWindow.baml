   M S B A M L   `   `   `  ����E  AMVVM_Pet_2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:MVVM_Pet_2.ViewMVVM_Pet_2.View  5   	   ;"clr-namespace:MVVM_Pet_2.ViewModelMVVM_Pet_2.ViewModel  5   	   &     MVVM_Pet_2.View.AddEditPetWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:MVVM_Pet_2.View     5   	   1vm"clr-namespace:MVVM_Pet_2.ViewModel     5   	   -   5          �Name$  addEditPetWindow��5
   	    � Title$  ��5	   	   $	��400��6   $	��420��6    � DataContext 5      4  .MVVM_Pet_2.ViewModel.AddEditPetWindowViewModel  5   
    � 	Resources 5       �� 
TargetType �� Property �� Value��%  '��       '�� n     �� 5   
   " ��6   .�5      ��  � ��$ 5q�6'   �� 5       � ��$ Right=�64   5      �� 5   
   " ��6   .�5      ��  � ��$ 4q�6'   �� 5       � ��$	 260��6&   �� 5       � ��$
 Left=�64   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      .+�5    
   �� $��5q�6   .+�5!      �� $��№ паспорта��6   �� 5"      $��Кличка��6   �� 5#      $��Тип��6   �� 5$      $#��Дата народження��6   �� 5%      $��Вік��6   �� 5&      $��Порода��6   �� 5'      $��
Колір��6   �� 5(      $"��Доп. інформация��6   5)      �� 5*   
   $��1��6   $��5q�6%   .+�5+      �� ��6   �� *PetPassport+�� 5,      ��6   �� *	PetName+�� 5-      ��6   �� *	PetType+(  "System.Windows.Controls.DatePicker  50      $��4 0 4 4q�6A   $
��Left=�51      $	��260��64      SelectedDateFormat$ Short=�52      	   DisplayDate$	 
12/01/2015��64   
   DisplayDateStart$
 
12/01/2015X�6M      SelectedDate 50      �� *PetDateOfBirth+52   M   �� 54      ��6   �� *PetAge+�� 55      ��6   �� *
PetBreed+�� 56      ��6   �� *
PetColor+�� 57      $��5q�6@   $	��260��6K   $
��Left=�6W   $	��100��6r   ��6   �� *	PetInfo+��6/   Z� 6r   58      �� 59   
   $��1��6   .+�5:      �� -   5         ��Name$ createButton��5:      $��Створити��6+    �� 	IsDefault . $��60��6�    �� Bottom$ 10��6�    �� Right$	 165��6�   ��6O   �� *CreatePetCommand+��6t   ��  �� ElementName$ addEditPetWindow��6�   �� 5;      -   5        $ 
editButton��5;      $��Редагувати��6)   $��85��6�   $ 10��6�   $ 70��6�   ��6>   �� *EditPetCommand+��6a   �� $ addEditPetWindow��6�   �� 5<      $��Відміна��6    �� IsCancel . $��50��67   $ 10��6B   $ 10��6U   5=      5>      5?      