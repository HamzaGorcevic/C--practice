   M S B A M L   `   `   `  ����I  ESchoolSchedule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SchoolScheduleSchoolSchedule  5   	       SchoolSchedule.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:SchoolSchedule     5   	     � Title$  
MainWindow��5	   	   $	��600��6   $
��1300��6)    � DataContext 5   	   ��  �� RelativeSource �� *Self+ � 	Resources 5       �� 
TargetType �� Property �� Value��%�  '��       '�� 0    �� 5   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � ��$
 Bold"�6+   �� 5       � ��
 ���� 6,   �� 5       � ��$ Right=�64   �� 5       � ��$ 0 0 10 0q�6'   �� 5       � ��$	 130��6'   �� 5       � ��$ 60��6(   5      �� 5   
   " ��6   .�5      ��  � ��$	 170��6&   �� 5       � ��$ 45��6'   �� 5       � ��$ 5q�6(   �� 5       � ��$ 21(�6)   �� 5       � ��$ Segoe UI)�6+   �� 5       � ��
 �OO/�6+   �� 5       � ��$ Center=�69   �� 5        � ��$ Center=�6;   5"      5#      .��5&      �  � RowDefinitions 5'   
   �� 5(      $	��100 �6   �� 5)      $
��auto �6   .+�5,   
   �� $��Center=�6   $��Center=�61   $��53(�6O   $��
ExtraBlack"�6^   
�����p�$��Cascadia Code SemiBold)�6�   CLASS SCHEDULE6�   �� 5-   
    �� CornerRadius$ 9��6   	 �� Padding$	 5q�6"   $	��130��6.   $��45��6:   $
��Left=�6F   $
��25 0q�6a   
����� �._�5.      �� -   5        
 ��Name$
 btnLogin��5.      $��Login��6'   $��Center=�67   $��Center=�6S   $��20(�6p   
������ 6�   50      �� 51   
   -   5         ��Name$ cbDays��51       �� SelectedIndex$ 0��6#   $��Right=�6b   $��0 0 25 0q�6   $��Bahnschrift SemiBold)�6�   ���	#FF52DAEB.@�53   
   �� $
��Week��6   �� 55   
   $��Monday��6   �� 56   
   $��Tuesday��6   �� 57   
   $��	Wednesday��6   �� 58   
   $��Thursday��6   �� 59   
   $��Friday��6   5;      � 5<   
   -   5         �Name$ gridSchedule��5<      $��1��6B    � ColumnDefinitions 5=      �� 5>      $	��30* �6#   �� 5?      $	��30* �6#   �� 5@      $	��30* �6#   �� 5A      $	��30* �6#   �� 5B      $	��30* �6#   5D      5I      5K      