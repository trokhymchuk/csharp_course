   M S B A M L   `   `   `  ����J  Ftrokhymchuk_wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:KMA_ProgrammingCsharp2024KMA_ProgrammingCsharp2024  5   	   ,    &ProgrammingCsharp2024.Views.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:KMA_ProgrammingCsharp2024     5   	     � Title$  
MainWindow��5   	   $	��250��6   $	��320��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   �� 5      $��* �6   6)    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   .+�5   
   �� $��0��6   $��0��6!   $
��Left=�61   $��10,10, 0, 0q�6L   First name:6n   �� 5   
   -   5        $��NameTextBox��5      $��0��6%   $��2��62   $��Stretch=�6C   $��0,10, 10, 5q�6w   ��6a   �� *Name+6�   �� 5   
   $��1��6   $��0��6!   $
��Left=�61   $��10,10, 0, 0q�6L   
Last name:6m   �� 5   
   -   5        $��LastNameTextBox��5      $��1��6)   $��2��66   $��Stretch=�6G   $��0,10, 10, 5q�6   ��6e   �� *
LastName+6�   �� 5   
   $��2��6   $��0��6!   $
��Left=�61   $��10,10, 0, 0q�6L   Email:6i   �� 5   
   -   5        $��EmailTextBox��5      $��2��6&   $��2��63   $��Stretch=�6D   $��0,10, 10, 5q�6y   ��6b   �� *Email+6�   �� 5   
   $��3��6   $��0��6!   $
��Left=�61   $
��10,0q�6L   Enter your birth date:6r   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��DatePickerInput��5      $��3��6,   $��2��69   $
��Left=�6I      SelectedDate 6d   �� *	BirthDate+6�   �� 5   
   -   5        $��CalculateButton��5      $��4��6(   $��2��65   $��30��6I   $��10, 0q�6U   ��6d   �� *CalculateCommand+.��6�   	Calculate6�   5      5      