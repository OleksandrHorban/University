   M S B A M L   `   `   `  ����E  AMVVM_Pet_2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:MVVM_Pet_2.ViewMVVM_Pet_2.View  5   	   ;"clr-namespace:MVVM_Pet_2.ViewModelMVVM_Pet_2.ViewModel  5   	   )    #MVVM_Pet_2.View.AddEditClientWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:MVVM_Pet_2.View     5   	   1vm"clr-namespace:MVVM_Pet_2.ViewModel     5   	   -   5          �Name$  addEditClientWindow��5
   	    � Title$  ��5	   	   $	��320��6   $	��400��6    � DataContext 5      7  1MVVM_Pet_2.ViewModel.AddEditClientWindowViewModel  5   
    � 	Resources 5       �� 
TargetType �� Property �� Value��%  '��       '�� n     �� 5   
   " ��6   .�5      ��  � ��$ 5q�6'   �� 5       � ��$ Right=�64   5      �� 5   
   " ��6   .�5      ��  � ��$ 4q�6'   �� 5       � ��$	 260��6&   �� 5       � ��$
 Left=�64   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      .+�5"   
   �� $��5q�6   .+�5#      �� $��ПІБ��6   �� 5$      $��№ телефон��6   �� 5%      $��Email��6   �� 5&      $��Адреса��6   �� 5'      $��ID тваринки��6   �� 5(      $��Інформація��6   5)      �� 5+   
   $��1��6   $��5q�6%   .+�5,      �� ��6   �� *
FullName+�� 5-      ��6   �� *Phone+�� 5.      ��6   �� *Email+�� 5/      ��6   �� *	Address+�� 51      $��4q�52      $	��260��6   $��20��6(   $
��Left=�64   ��53      �� *Pets+ �� SelectedItem 54      �� *selectedPet+	 �� Mode$	 TwoWay=���55      �� 56      .R�57      �� 
 �� Orientation$
 
Horizontal=�6%   .+�58      �� $��30��6<   ��6(   �� *Id+6<   �� 59      $��70��6B   ��6(   �� *
Passport+6B   �� 5:      $	��250��6A   ��6(   �� *	PetName+6A   5;      5<      5>      �� 5@      $��5q�6=   $	��260��6H   $
��Left=�6T   $	��100��6o   ��6   �� *Info+��6,   Z� 6o   5A      �� 5C   
   $��1��6   .+�5D      �� -   5         ��Name$ createButton��5D      $��Створити��6+    �� 	IsDefault . $��60��6�    �� Bottom$ 10��6�    �� Right$	 165��6�   ��6O   �� *CreateClientCommand+��6w   ��  �� ElementName$ addEditClientWindow��6�   �� 5E      -   5        $ 
editButton��5E      $��Редагувати��6)   $��85��6�   $ 10��6�   $ 70��6�   ��6>   �� *EditClientCommand+��6d   �� $ addEditClientWindow��6�   �� 5F      $��Відміна��6    �� IsCancel . $��50��67   $ 10��6B   $ 10��6U   5G      5H      5I      