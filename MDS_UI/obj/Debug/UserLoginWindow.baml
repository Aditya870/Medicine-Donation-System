   M S B A M L   `   `   `  ����A  =MDS_UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MDS_UIMDS_UI  5   	       MDS_UI.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	    localclr-namespace:MDS_UI  5   	     � Title$  UserLoginWindow��5	   	    � WindowStartupLocation$ CenterScreen=�6"    � WindowStyle$ 
ToolWindow=�6H    � SizeToContent$ WidthAndHeight=�6a    � 
ResizeMode$ NoResize=�6�   .��5
      � ��5   
   �� 5       �� 
StartPoint$ 0.1,0&�6"    �� EndPoint$ 0.9,1&�65   .��5      �  � Color$ 	CadetBlue��6    � Offset$ 1Q�61   � 5      $ 	AliceBlue��6   $ 0Q�61   5      .+�5   
   �� $	��400��6   $	��Top=�6   	 �� CornerRadius$	 	0 0 180 0��66   
���   �._�5      �� 
 �� Orientation$
 
Horizontal=�6   .+�5      �� $	��350��6   .+�5      �� $��Images/donate.jpg��6   $	��300��67   $	��300��6C   $	��Top=�6P   $��30q�6h   $
��Fill=�6t   5      �� 5      $	��350��6   .+�5      �� $��20 40q�6!   .+�5      �� $��
User Login��6$   $��20q�66   
������� �� TextAlignment$ Center=�6U   $��38(�6l   $��New Times Roman)�6z   �� 5      $
 
Horizontal=�6%   $��10q�6>   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 User=�66   $��25��6B   $��25��6M   
�������6Y   �� 5      -   5         ��Name$ 
txt_userId��5   &   $
��10 0q�6:   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Enter UserID��6H   
�������$	��250��6�   
������� �� 
CaretBrush
 ����� �� SelectionBrush
 ��� �6�   5      �� 5      $
 
Horizontal=�6%   $��10q�6>   .+�5        $
 Lock=�66   $��25��6B   $��25��6M   
�������6Y   G� 5       -   5         G�Name$ txt_password��5    *   $
��10 0q�6@   $ 
**********��6N   
�������$	��250��6�   
������� G� 
CaretBrush
 ����� G� SelectionBrush
 ��� �6�   5!      �� 5"      $��5q�6%   $��40��60   .+�5#      �� -   5         ��Name$ ButtonLogin��5%   l   $��Center=�5#   %   $	��100��6B   $��40��6N      MaterialDesignRaisedButton#��[  6Z   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 20��5$   %   $��2q�6S   
���  ��
�������
����  �$
��Bold"�5%   J    � ToolTip$ Login��6\   $��Login��6�   5&      5'      �� 5(      $��5q�6%   $��40��60   .+�5)      �� -   5        $ buttonRegister��5+   u   $	��100��5)   %   $��Center=�61   $��40��6N   #��[  6Z   $ 20��5*   %   $��2q�6S   
���  ��
������
���   �$
��Bold"�5+   P   $ Register��6b   $��Register��6�   5,      5.      5/      �� 50      $	��100��6   .+�51      �� -   5        $ 
buttonExit��52   -   $��10 20q�51       & "MaterialDesignFloatingActionButton#��[ 6,   $ Close��52      ��51   h   Z� .��53        $ Close=�62   
�������$��15��6R   $��15��6]   54      55      56      57      58      59      