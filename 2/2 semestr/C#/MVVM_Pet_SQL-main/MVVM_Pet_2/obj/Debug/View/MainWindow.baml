   M S B A M L   `   `   `  ����E  AMVVM_Pet_2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:MVVM_Pet_2
MVVM_Pet_2  5   	       MVVM_Pet_2.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:MVVM_Pet_2     5   	     � Title$  
MainWindow��5   	   $	��250��6   $	��300��6)    � WindowStartupLocation$ CenterScreen=�65    � 	Resources 5
       �� 
TargetType �� Property �� Value �� Triggers �� Binding �� ElementName	 �� Path
 �� Value��%�  '�       '�� �     �� 5   
   " �6   �5      �� 5       � ��
 �����6/    5      �� 5       6   �� $ buttonTablePets��$	 	IsEnabled�
 True6^   .a�5      ��  � �� �	#FF00A3FC63   5      5      �� 5   
   " ��6    5      �� 5       6   �� $ buttonTablePets��$	 	IsEnabled�
 True6^   .a�5      ��  � y�$ Hidden=�63   5      5      5      .��5       �  � RowDefinitions 5!   
   �� 5"      $
��auto �6   �� 5#       � ColumnDefinitions 5%   
   �� 5&      �� 5'      .+�5*   
   �� -   5         ��Name$ buttonTablePets��5*      $��0��6*   $%��Таблиця тваринок��5,      $��50��6,   $��3q�68   {�5*   :   �� *ButtonPetsIsEnabled+��5+      �� *OpenPetsWindow+5,   8   �� 5-   
   $��1��6   $%��Таблиця клієнтів��5/      $��50��6,   $��3q�68   {�5-   !   �� *ButtonClientsIsEnabled+��5.      �� *OpenClientsWindow+5/   8   �� 52   
   -   5         ��Name$ 
stackPanel��52      $��1��6)   $	��200��66   $��2��53      $��10 20 10 10q�6)    K� ZIndex$ 1��54      .+�55      �� $��
Логін��6   $��3q�6%   �� 56      $��3q�6V   ��6   �� *	LoginText+ �� UpdateSourceTrigger$ PropertyChanged=�6V   �� 57      $��Пароль��6   $��3q�6&   G� 58      -   5        $��PasswordBox��58      $��3q�6-   �� 59       �� 	IsDefault . $��10q�6|   $��Вхід��6�   $��80��6�   ��6   �� *LoginCommand+��66   �� $ PasswordBox��6�   5:      �� 5<   
   $��1��6   $	��200��6%   $��2��61   
�������$��
10 0 10 10q�5=   .   $��WELCOME!��5>      $��Center=�6(   $��40(�5?      $��Center=�6&   $��DemiBold"�5@      $ 0��6.   5A      5B      5C      