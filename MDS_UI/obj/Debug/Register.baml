   M S B A M L   `   `   `  ����A  =MDS_UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MDS_UIMDS_UI  5   	       MDS_UI.Register   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   &commentnuget_package for design  5   	    localclr-namespace:MDS_UI  5   	     � Title$  Register��5
   	    � SizeToContent$ WidthAndHeight=�6    � WindowStartupLocation$ CenterScreen=�69    � WindowStyle$ 
ToolWindow=�6^    � 
ResizeMode$ NoResize=�6w   .��5      � $��10 10 10 10q�6   ��5   
   �� 5       �� 
StartPoint$ 0.1,0&�6"    �� EndPoint$ 0.9,1&�65   .��5      �  � Color$ 	CadetBlue��6    � Offset$ 1Q�61   � 5      $ 	AliceBlue��6   $ 0Q�61   5      .+�5   
   �� $	��400��6   $	��Top=�6   	 �� CornerRadius$	 	0 0 180 0��66   
���   �._�5      �� 
 �� Orientation$
 
Horizontal=�6   .+�5      �� $	��350��6   .+�5      �� $��Images/donate.jpg��6   $	��300��67   $	��300��6C   $	��Top=�6P   $��30q�6h   $
��Fill=�6t   5      �� 5      $	��380��6   .+�5      �� $��20 20q�6!   .+�5      �� $��User Registration��6$   $��10q�6=   
������� �� TextAlignment$ Center=�6\   $��32(�6s   $��New Times Roman)�6�   �� 5      $
 
Horizontal=�6%   $��5q�6>   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Accessibility=�66   $��25��6K   $��25��6V   
�������6b   �� 5      -   5         ��Name$ 
userTypeId��5   '   $
��10 0q�6;   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Enter UserType��6I   
�������$	��250��6�   
�������.@�5    "   �� 
���   �.��6B   NGO6G   �� 5!   "   
���   �.��6B   	Donator6K   5"      5#      �� 5$      $
 
Horizontal=�6%   $��5q�6>   .+�5%        $
 User=�66   $��25��6B   $��25��6M   
�������6Y   �� 5&      -   5         ��Name$ userId��5&   &   $
��10 0q�66   $ Enter User ID��6D   
�������$	��250��6�   
������� �� 
CaretBrush
 ����� �� SelectionBrush
 ��� �6�   5'      �� 5(      $
 
Horizontal=�6%   $��5q�6>   .+�5)        $
 User=�66   $��25��6B   $��25��6M   
�������6Y   �� 5*      -   5        $ userName��5*   &   $
��10 0q�68   $ Enter User Name��6F   
�������$	��250��6�   
�������
 �����
 ��� �6�   5+      �� 5,      $
 
Horizontal=�6%   $��5q�6>   .+�5-        $
 Lock=�66   $��25��6B   $��25��6M   
�������6Y   G� 5.      -   5         G�Name$ password��5.   *   $
��10 0q�6<   $ 
**********��6J   
�������$	��250��6�   
������� G� 
CaretBrush
 ����� G� SelectionBrush
 ��� �6�   5/      �� 50      $
 
Horizontal=�6%   $��5q�6>   .+�51        $
 Lock=�66   $��25��6B   $��25��6M   
�������6Y   G� 52      -   5        $ 
repassword��52   *   $
��10 0q�6>   $ 
**********��6L   
�������$	��250��6�   
�������
 �����
 ��� �6�   53      �� 54      $
 
Horizontal=�6%   $��5q�6>   .+�55        $ AddressMarker=�66   $��25��6K   $��25��6V   
�������6b   �� 56      -   5        $ address��56   &   $
��10 0q�68   $ Enter Address��6F   
�������$	��250��6�   
�������
 �����
 ��� �6�   57      �� 58      $��5q�6%   $��40��60   .+�59      �� -   5         ��Name$ buttonRegisterUser��5;   y   $	��200��59   %   $��Center=�61   $��40��6N      MaterialDesignRaisedButton#��[  6Z   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 20��5:   %   $��2q�6S   
���  ��
������
���   �$
��Bold"�5;   P    � ToolTip$ RegisterUser��6b   $��Join to Serve��6�   5<      5>      5?      �� 5@      $��70��6   .+�5A      �� -   5        $ 
buttonExit��5B   .   $	��1 1q�5A       & "MaterialDesignFloatingActionButton#��[ 6*   $ Logout��5B      ��5A   f   Z� .��5C        $ Logout=�62   
�������$��15��6S   $��15��6^   5D      5E      5F      5G      5H      5I      