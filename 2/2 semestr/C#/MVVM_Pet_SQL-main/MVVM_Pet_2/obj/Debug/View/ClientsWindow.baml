   M S B A M L   `   `   `  ����E  AMVVM_Pet_2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:MVVM_Pet_2.ViewMVVM_Pet_2.View  5   	   ;"clr-namespace:MVVM_Pet_2.ViewModelMVVM_Pet_2.ViewModel  5   	   #    MVVM_Pet_2.View.ClientsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:MVVM_Pet_2.View     5   	   1vm"clr-namespace:MVVM_Pet_2.ViewModel     5   	     � Title$  
PetsWindow��5	   	   $	��450��6   $	��800��6)    � WindowStartupLocation$ CenterScreen=�65    � 	Resources 5       �� 
TargetType �� Property �� Value��%�   '��       '�� p     �� 5   
   " ��6   .�5      ��  � ��
 ��d�6+   �� 5       � ��
 �   �6,   5      �� 5   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � ��$	 100��6&   5      5       � DataContext 5      1  +MVVM_Pet_2.ViewModel.ClientsWindowViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5       �� $��Фільтр��6   $��5q�6&   �� 5!      $	��200��6W   $��5q�6c   ��6   �� *
FilterText+	 �� UpdateSourceTrigger$	 PropertyChanged=�6c   �� 5"      $��
Новий��6   $��5q�6%   ��60   �� *OpenCreateClientWindowCommand+�� 5#      $��Редагувати��6   $��5q�6*   ��65   �� *OpenEditClientWindowCommand+�� 5$      $��Видалити��6   $��5q�6(   ��63   �� *DeleteClientCommand+5%      �� 5&   
   $��0��6   .+�5'      �� $��Клієнти��6   $��Italic$�6&   $
��Bold"�69   
 �� Right$
 5��6K   
 �� Top$ 0��6\   5(      �� 5)   
   $��1��6;   $��5q�6H    �� SelectedItem 6   �� *SelectedClient+��5*      �� *
AllClients+$	 PropertyChanged=� �� View 5+      �� 5,      .P�5-      �� $��Id��6%    �� Width$ 35��6Z    �� DisplayMemberBinding 61   ��  �� Path$ Id�6Z   �� 5.      $��ПІБ��6%   $
 auto��6a    62   �� $ FullName�6a   �� 5/      $��№ телефона��6%   $
 auto��6e    69   �� $ Phone�6e   �� 50      $��Email��6%   $
 auto��6`    64   �� $ Email�6`   �� 51      $��Адреса��6%   $	 200��6c    65   �� $ Address�6c   �� 52      $��PetId��6%   $ 35��6`    64   �� $ PetId�6`   �� 53      $!��Доп.інформація��6%   $	 250��6h    6=   �� $
 Info�6h   54      56      57      58      