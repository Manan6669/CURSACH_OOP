   M S B A M L   `   `   `  ����C  ?Kursovoi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:KursovoiKursovoi  5   	       Kursovoi.LogIn   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Kursovoi     5   	     � Title$  Prelib��5   	   $	��350��6   $	��400��6&    � WindowState$ Normal=�62   $��Stretch=�6G    � SizeToContent$ Width=�6l   ���	#FF060606 � WindowStyle$ SingleBorderWindow=�6�    � 
ResizeMode$ NoResize=�6�   .��5
      �  � RowDefinitions 5   
   �� 5      $	��130 �6   �� 5      $��60 �6   �� 5      $��40 �6   �� 5      $	��120 �6   .+�5   
   �� -   5        $��Вход��5      $
��Left=�6    $��	80,10,0,0q�6;   $��2��6N   $	��Top=�6[   $	��230��6s   $��30��6      buttonStyle2#���   6�   6�   �� 5   
   -   5        $��Регистрация��5      $
��Left=�6'   $��	80,10,0,0q�6B   $��3��6U   $	��Top=�6b   $	��230��6z   $��30��6�   #���   6�   6�   �� 5   
   $	��231��6   $��47��6"   $��
80,57,89,6q�6/   $��0��6C    �� Orientation$ 
Horizontal=�6P   ���	#FF1B1B1B.+�5      �� $��Логин :��6   $��46��6'   $
��Left=�63   $��
10,13,0,15q�6N     TextBlockImageStyle#���  6b   �� 5      -   5         ��Name$
 User��5      $	��143��6$   $��20��60   $��	20 0 0 0 q�6<     	LogInText#���  6O   .��6�   ��5      �� 5       �� Path$ 
UsersLoqin�6   	 �� NotifyOnValidationError$
	 True��60   
 �� ValidationRules
 5      5  /System.Windows.Controls.DataErrorValidationRule  5      5      .��5       5      5      �� 5   
   $��47��6   $��	80,7,90,6q�6"   $	��230��65   $��1��6A   $ 
Horizontal=�6N   ���	#FF1B1B1B.+�5       �� $��Пароль :��6   $��60��6(   $
��Left=�64   $��
10,13,0,15q�6O   #���  6c   G� 5!      -   5         G�Name$ Password��5!      $	��143��6,   $��20��68   $��5 0 0 0 q�6D    G� SelectionTextBrush
 �����
����������	#FF1B1B1B��6V   Z�  G� SelectionBrush 6m   Z� 6�   5"      5#      5$      