   M S B A M L   `   `   `  ����C  ?Kursovoi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:KursovoiKursovoi  5   	       Kursovoi.WindowMainAdmin   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Kursovoi     5   	     � Title$  Prelib��5	   	    � WindowStartupLocation$ CenterScreen=�6    � SizeToContent$ WidthAndHeight=�6=    � WindowState$ 	Maximized=�6\   ���	#FF060606$
��1164��6�   $	��700��6�    � WindowStyle$ SingleBorderWindow=�6�    � 
ResizeMode$ NoResize=�6�   .��5      � $
��1164��6   $��0,0,0,0q�6    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6   .+�5   
   �� .+�5      � $��51��6   ���	#FFBD6CB6 � ColumnDefinitions 5      �� 5      $	��150 �6'   �� 5      $	��740 �6'   �� 5      $	��130 �6'   �� 5      $	��130 �6'   .+�5      �� -   5        $��0��5      $��PRELIB��6)   $��Segoe UI)�6:      buttonStyle#��[  6P   $
��Bold"�6u   6�   �� 5      -   5        $��2��5      #��[  6)   .��5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� $	����6$     
buttonIcon#��[ 64   �� 5      $��Кабинет��6$     TextBlockStyle#��[ 63   $
��Bold"�6[   5      5      �� 5       -   5        $��3��5       	 J� RenderTransformOrigin$	 0.547,0.547&�6)   #��[  6M   $
��Left=�6r   $	��130��6�   .��5!      �� $ 
Horizontal=�6!   .+�5"      �� $	����6$   #��[ 64   �� 5#      $��
Выход��6$   #��[ 61   $
��Bold"�6Y   5$      5%      5&      5'       � 5)   
   -   5        
  �Name$
 	MainFrame��5)        � NavigationUIVisibility$ Hidden=�6#   $��Frame��6C   $��1��6S   $��	0,32,0,30q�6`     � Source$ CatalogAdmin.xaml?�6s   5*      5,      5-      