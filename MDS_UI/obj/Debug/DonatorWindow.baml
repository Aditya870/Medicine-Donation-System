   M S B A M L   `   `   `  ����A  =MDS_UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MDS_UIMDS_UI  5   	       MDS_UI.DonatorWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5       localclr-namespace:MDS_UI  5   	   -   5          � Title$  DonatorWindow��5	   	   $	��450��6   $	��800��6,    � WindowStartupLocation$ CenterScreen=�68    � WindowStyle$ 
ToolWindow=�6]    � SizeToContent$ WidthAndHeight=�6v    � 
ResizeMode$ NoResize=�6�   .��5
      � ��5   
   �� 5       �� 
StartPoint$ 0.1,0&�6"    �� EndPoint$ 0.9,1&�65   .��5      �  � Color$ 	CadetBlue��6    � Offset$ 1Q�61   � 5      $ 	AliceBlue��6   $ 0Q�61   5      .+�5   
   �� $	��400��6   $	��Top=�6   	 �� CornerRadius$	 	0 0 180 0��66   
���   �._�5      �� 
 �� Orientation$
 
Horizontal=�6   .+�5      �� $	��350��6   .+�5      �� $��Images/donate.jpg��6   $	��300��67   $	��300��6C   $	��Top=�6P   $��30q�6h   $
��Fill=�6t   5      �� 5      $	��350��6   .+�5      �� $��20 20q�6!   .+�5      �� $��Donation Details��6$   $��5q�6<   
������� �� TextAlignment$ Center=�6Z   $��38(�6q   $��New Times Roman)�6   �� 5      $
 
Horizontal=�6%   $��10q�6>   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 User=�66   $��25��6B   $��25��6M   
�������6Y   �� 5      -   5         ��Name$ userName��5   &   $
��10 0q�68   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Enter User ID��6F   
�������$	��250��6�   
������� �� 
CaretBrush
 ����� �� SelectionBrush
 ��� �6�   5      �� 5      $
 
Horizontal=�6%   $��10q�6>   .+�5        $ IdentificationCard=�66   $��25��6P   $��25��6[   
�������6g   �� 5       -   5        $ medicineName��5    &   $
��10 0q�6<   $ Medicine Name��6J   
�������$	��250��6�   
�������
 �����
 ��� �6�   5!      �� 5"      $
 
Horizontal=�6%   $��10q�6>   .+�5#        $ IdentificationCard=�66   $��25��6P   $��25��6[   
�������6g   �� 5$      -   5        $ medicineManufacturer��5$   &   $
��10 0q�6D   $ Medicine Manufacturer��6R   
�������$	��250��6�   
�������
 �����
 ��� �6�   5%      �� 5&      $
 
Horizontal=�6%   $��10q�6>   .+�5'        $ Numbers=�66   $��25��6E   $��25��6P   
�������6\   �� 5(      -   5        $ medicineQty��5(   &   $
��10 0q�6;   $ Enter Quantity��6I   
�������$	��250��6�   
�������
 �����
 ��� �6�   5)      �� 5*      $
 
Horizontal=�6%   $��10q�6>   .+�5+        $ IdCard=�66   $��25��6D   $��25��6O   
�������6[   �� 5,      -   5        $ batchNumber��5,   &   $
��10 0q�6;   $ Enter Batch Number��6I   
�������$	��250��6�   
�������
 �����
 ��� �6�   5-      �� 5.      $
 
Horizontal=�6%   $��10q�6>   .+�5/        $ 	DateRange=�66   $��25��6G   $��25��6R   
�������6^   (  "System.Windows.Controls.DatePicker  50      -   5          Name$ 
expiryDate��50   )   $
��10 0q�6=   $ Enter Expiry Date��6K   
�������$	��250��6�   
������� � DataContext$ MMM-YYYY��6�   51      �� 53      $��5q�6%   $��40��60   .+�54      �� -   5         ��Name$ donation��56   `   $��Center=�54   %   $	��200��6B   $��40��6N      MaterialDesignRaisedButton#��[  6Z   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 20��55   %   $��2q�6S   
���  ��
���  ��
�������$
��Bold"�56   M   $��Contribute To Society��6�   57      58      5:      5;      �� 5<      $	��100��6   .+�5=      �� -	   5        $ 
buttonExit��5>   -   $��10 20q�5=       & "MaterialDesignFloatingActionButton#��[ 6,    � ToolTip$ Close��5>      ��5=   h   Z� .��5?        $ Logout=�62   
�������$��15��6S   $��15��6^   5@      5A      5B      5C      5D      5E      