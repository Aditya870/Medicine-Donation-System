   M S B A M L   `   `   `  ����A  =MDS_UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MDS_UIMDS_UI  5   	       MDS_UI.NgoWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   &commentnuget_package for design  5   	    localclr-namespace:MDS_UI  5   	     � Title$  
NGO Window��5
   	    � WindowStartupLocation$ CenterScreen=�6    � WindowStyle$ 
ToolWindow=�6A    � SizeToContent$ WidthAndHeight=�6Z    � 
ResizeMode$ NoResize=�6y   .��5      �� -   5        $��Tabs_Cs��5       �� TabStripPlacement$	 Top=�6    
���   �$��10 10 10 10q�6M   .@�5   
   �� -   5        $��Claim Medicine��5      $	��490��6+    �� 
IsSelected . 
�������$
��Bold"�6y   $��18(�6�   $	��1 1q�6�   .��5      � ��5      �� 5       �� 
StartPoint$ 0.1,0&�6*    �� EndPoint$ 0.9,1&�6=   .��5      � 	 � Color$	 	CadetBlue��6'   
 � Offset$
 1Q�69   � 5      $	 	AliceBlue��6'   $
 0Q�69   5      .+�5      �� $	��500��6   $	��Top=�6&    �� CornerRadius$ 	0 0 180 0��6>   
���   �._�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� $
��Auto=�6'   $
��Auto=�6J   .��5      �� $	��900��6)   
����  �.+�5   "   � .+�5   &   &   System.Windows.Controls.DataGrid  -   5        $��grdMedicine��5   /   $	��880��6B   $	��490��6N      AutoGenerateColumns .     Columns 5   *   0  *System.Windows.Controls.DataGridTextColumn  5    .   ,  &System.Windows.Controls.DataGridColumn   Header$ Medicine��6A      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6_   �� *MedicineName+  5"   .   $ Status��6A   $	 100 6Q    6]   �� *MedicineStatus+  5$   .   $	 Qty��6A   $	 100 6N    6Z   �� *MedicineQty+  5&   .   $ Manufacturer��6A   $	 200 6W    6c   �� *MedicineManufacturer+  5'   .   $ BatchNumber��6A   $	 200 6V    6b   �� *BatchNumber+  5(   .   $ 
ExpiryDate��6A   $	 150 6U    6a   �� *
ExpiryDate+5,   '   5-   #   5.      5/      �� 50      $	��270��6%   $��60,10,0,200q�61   .+�51      �� $	��5 5q�6)   .+�52   "   �� $��
Claim Form��6,   $��5q�6>   
������� �� TextAlignment$ Center=�6\   $��32(�6s   $��New Times Roman)�6�   �� 53   "   $ 
Horizontal=�6-   $��5q�6F   .+�54   &   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 User=�6>   $��25��6J   $��25��6U   
�������6a   �� 55   &   -   5         ��Name$ ngoID��55   .   $	��5 0q�6=   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Enter NGO ID��6J   
�������$	��250��6�   
������� �� 
CaretBrush
 ����� �� SelectionBrush
 ��� �6�   56   #   �� 57   "   $ 
Horizontal=�6-   $��5q�6F   .+�58   &     $ Medicine=�6>   $��25��6N   $��25��6Y   
�������6e   �� 59   &   -   5        $ batchNumber��59   .   $	��5 0q�6C   $ Medicine Batch Number��6P   
�������$	��250��6�   
�������
 �����
 ��� �6�   5:   #   �� 5<   "   $��5q�6-   $��40��68   .+�5=   &   �� -   5         ��Name$ buttonClaimForm��5?   b   $	��200��5=   -   $��Center=�69   $��40��6V      MaterialDesignRaisedButton#��[  6b   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 20��5>   %   $��2q�6S   
���  ��
������
���   �$
��Bold"�5?   P   $��Claim��6�   5@   #   5B      5C      �� 5D      $��45��6%   .+�5E      �� -   5        $ 
buttonExit��5F   .   $	��1 1q�5E   %    & "MaterialDesignFloatingActionButton#��[ 62    � ToolTip$ Logout��5F      ��5E   n   Z� .��5G   "     $ Close=�6:   
�������$��25��6Z   $��25��6e   5H      5I      5J      5K      5L      5M      �� 5O   
   -   5        $��Claim Status��5O      $	��400��6)    . 
�������$
��Bold"�6y   $��18(�6�   $	��1 1q�6�   .��5Q      � ��5R      �� 5S      $ 0.1,0&�6*   $ 0.9,1&�6=   .��5T      � $	 	AliceBlue��6'   $
 1Q�69   � 5U      $
	 Aqua��6'   $
 0Q�64   5V      .+�5Y      �� $	��500��6   $	��Top=�6&   $ 	0 0 180 0��6>   
���   �._�5Z      �� $ 
Horizontal=�6!   .+�5[      �� $
��Auto=�6'   $
��Auto=�6J   .��5\      �� $	��900��6)   
����  �.+�5^   "   � .+�5_   &     -	   5        $��grdClaimStatus��5_   /   $	��880��6E   $	��490��6Q    .   5a   *     5c   .   $ Ngo ID��6A   $	 200 6Q    6]   �� *NgoId+  5d   .   $ BatchNumber��6A   $	 300 6V    6b   �� *BatchNumber+  5e   .   $ 
Claim Date��6A   $	 300 6U    6a   �� *	ClaimDate+5h   '   5i   #   5j      5k      �� 5l      $	��270��6%   $��	60,10,0,0q�61   .+�5m      �� $��10 150 10 10q�6)   .+�5n   "   �� $��Claim Status��6,   $��5q�6@   
�������$ Center=�6^   $��32(�6u   $��New Times Roman)�6�   �� 5o   "   $ 
Horizontal=�6-   $��5q�6F   .+�5p   &     $
 User=�6>   $��25��6J   $��25��6U   
�������6a   �� 5q   &   -
   5        $ 	txt_ngoId��5q   .   $	��5 0q�6A   $ Enter Ngo ID��6N   
�������$	��250��6�   
�������
 �����
 ��� �6�   5r   #   �� 5u   "   $��5q�6-   .+�5v   &   �� -   5        $ buttonClaimStatus��5x   ]   $	��200��5v   -   $��Center=�69   $��60��6V   #��[  6b   $ 20��5w   %   $��2q�6S   
���  ��
�������
���   �$
��Bold"�5x   K   $��View Claim By Ngo Id��6�   5y   #   5{      5|      �� 5}      $��60��6%   .+�5~      �� -   5        $ buttonExit1��5   .   $	��1 1q�5~   %   #��[ 62   $ Logout��5      ��5~   n   Z� .��5�   "     $ Logout=�6:   
�������$��25��6[   $��25��6f   5�      5�      5�      5�      5�      5�      �� 5�   
   -   5        $ ��Complaints and Suggestions��5�      $
��auto��66    . 
�������$
��Bold"�6�   $��18(�6�   $	��1 1q�6�   .��5�      � ��5�      �� 5�      $ 0.1,0&�6*   $ 0.9,1&�6=   .��5�      � $		 Red��6'   $
 1Q�63   � 5�      $	 Yellow��6'   $
 0Q�66   5�      .+�5�      �� $	��400��6   $	��Top=�6&   $ 	0 0 180 0��6>   
���   �._�5�      �� $ 
Horizontal=�6!   $	��800��6:   .+�5�      �� .+�5�      �� $��20 20q�6)   .+�5�   "   �� $ ��Complaints and Suggestions��6,   $��10q�6N   
�������$ Center=�6m   $��32(�6�   $��New Times Roman)�6�   �� 5�   "   $��Center=�6-   $ 
Horizontal=�6J   $��5q�6c   .+�5�   &     $
 User=�6>   $��25��6J   $��25��6U   
�������6a   �� 5�   &   -   5        $ ngoId��5�   .   $
��10 0q�6=   $ Enter Ngo ID��6K   
�������$	��500��6�   
�������
 �����
 ��� �6�   5�   #   �� 5�   "   $��Center=�6-   $ 
Horizontal=�6J   $��5q�6c   .+�5�   &     $ IdCard=�6>   $��25��6L   $��25��6W   
�������6c   �� 5�   &   -   5        $ ngoName��5�   .   $
��10 0q�6?   $ Enter NGO Name��6M   
�������$	��500��6�   
�������
 �����
 ��� �6�   5�   #   �� 5�   "   $��Center=�6-   $ 
Horizontal=�6J   $��5q�6c   .+�5�   &     $ PrinterPreview=�6>   $��25��6T   $��25��6_   
�������6k   �� 5�   &   -   5        $ 	Complaint��5�   .   $
��10 0q�6A   $ Enter Complaint��6O   
�������$	��500��6�   
�������
 �����
 ��� �6�   5�   #   �� 5�   "   $��Center=�6-   $ 
Horizontal=�6J   $��5q�6c   .+�5�   &     $ AddressMarker=�6>   $��25��6S   $��25��6^   
�������6j   �� 5�   &   -   5        $ Suggestions��5�   .   $
��10 0q�6D   $ Enter Suggestions��6R   
�������$	��500��6�   
�������
 �����
 ��� �6�   5�   #   �� 5�   "   $��5q�6-   $��40��68   .+�5�   &   �� -   5        $ buttonComplaint��5�   f   $	��200��5�   -   $��Center=�69   $��40��6V   #��[  6b   $ 20��5�   %   $��2q�6S   
���  ��
������
�������$
��Bold"�5�   T   $��Submit��6�   5�   #   5�      5�      �� 5�      $��70��6%   .+�5�      �� -   5        $ buttonExit2��5�   .   $	��1 1q�5�   %   #��[ 62   $ Logout��5�      ��5�   n   Z� .��5�   "     $ Logout=�6:   
�������$��15��6[   $��15��6f   5�      5�      5�      5�      5�      5�      5�      5�      