   M S B A M L   `   `   `  ����  
MVVM_Pet_2     MVVM_Pet_2.View.PetsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  
PetsWindow��5   	   $	��450��6   $	��800��6)    � WindowStartupLocation$ CenterScreen=�65    � 	Resources 5	       �� 
TargetType �� Property �� Value��%�   '��       '�� p     �� 5
   
   " ��6   .�5      ��  � ��
 � ���6+   �� 5       � ��
 �   �6,   5      �� 5   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � ��$	 100��6&   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Фільтр��6   $��5q�6&   �� 5      $	��200��6W   $��5q�6c   ��6   �� *
FilterText+ �� UpdateSourceTrigger$ PropertyChanged=�6c   �� 5      $��
Новий��6   $��5q�6%   ��60   �� *OpenCreatePetWindowCommand+�� 5      $��Редагувати��6   $��5q�6*   ��65   �� *OpenEditPetWindowCommand+�� 5      $��Видалити��6   $��5q�6(   ��63   �� *DeletePetCommand+5      �� 5    
   $��0��6   .+�5!      �� $!��Наші улюбленці��6   $��Italic$�6-   $
��Bold"�6@   	 �� Right$	 5��6R   

 �� Top$
 0��6c   5"      �� 5#   
   -   5         ��Name$ listViewPets��5#      $��1��6N   $��5q�6[    �� SelectedItem 6)   �� *SelectedPet+��5$      �� *	AllPets+$ PropertyChanged=� �� View 5%      �� 5&      .P�5'      �� $��Id��6%    �� Width$
 auto��6Z    �� DisplayMemberBinding 61   ��  �� Path$ Id�6Z   �� 5(      $��№ Паспорта��6%   $	 100��6h    69   �� $ Passport�6h   �� 5)      $��Кличка��6%   $	 100��6c    65   �� $ PetName�6c   �� 5*      $��Тип��6%   $ 80��6`    62   �� $ PetType�6`   �� 5+      $#��Дата народження��6%   $
 auto��6�    6>   �� *DateOfBirth+ �� StringFormat$ 
dd.MM.yyyy��6�   �� 5,      $��Вік��6%   $
 auto��6\    62   �� $	 Age�6\   �� 5-      $��Порода��6%   $	 150��6a    65   �� $ Breed�6a   �� 5.      $��
Колір��6%   $	 100��6`    64   �� $ Color�6`   �� 5/      $!��Доп.інформація��6%   $	 500��6h    6=   �� $
 Info�6h   50      52      53      54      