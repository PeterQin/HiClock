   M S B A M L   `   `   `  ����H  DBookLibrary, Version=2.5.0.400, Culture=neutral, PublicKeyToken=nullq=clr-namespace:Waf.BookLibrary.Library.Presentation.Converters/Waf.BookLibrary.Library.Presentation.Converters  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089T PWpfApplicationFramework, Version=2.5.0.400, Culture=neutral, PublicKeyToken=null   InvalidControlBrush  �� Color  HeaderTextBrush �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value �� RelativeSource �� PathB   <System.Waf.Presentation.Converters.ValidationErrorsConverter	    Default
 �� 	Converter(  "System.Windows.Controls.DatePicker&   System.Windows.Controls.DataGrid  TextCellElementStyle  TextCellEditingStyle �� Binding �� Value  HeaderLabel �� BasedOn�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      )wafhttp://waf.codeplex.com/schemas  5      Cc=clr-namespace:Waf.BookLibrary.Library.Presentation.Converters  5      %	  &	        &	 !     '�� B     '�� �     '�� (    7   '  �    '�� �    '	� �    '  H    &	 �    &	     'm� �    (�� 8    5Q      *ToolBar.ButtonStyleKey+)&	 �    7��7  �� 5      $  #E5B8B7��62   �� 5      $  #003399��6.   �� 5      " ��6   .�5   
   ��  � ��$ 	11,11,0,0q�6#   5      �� 5      " ��6   .�5   
   ��  � ��$ 75��6%   �� 5   
    � ��$ 23��6&   �� 5   
    � ��$ 	11,11,0,0q�6#   5      �� 5      " ��6   .�5   
   ��  � ��$ 25��6&   �� 5   
    � ��$	 100��6%   �� 5   
    � ��$ 	11,11,0,0q�6#   �� 5   
    � ��$
 Left=�60   �� 5   
    �@=�ErrorTemplate 5      �� 5      5       5   
   P� 5        �@=�HasError . . �5!      ��  � ��8   6/   �� 5"       �@�ToolTip 6,   ��  �� *Self+$ (Validation.Errors)�#
 Z	 5$      5&      �� 5(      "  6   .�5)   
   ��  � ��$ 25��6&   �� 5*   
    � ��$	 100��6%   �� 5+   
    � ��$ 	11,11,0,0q�6#   �� 5,   
    � ��$
 Left=�60   5-      �� 5/      " ��6   .�50   
   ��  � ��$ 	11,11,0,0q�6#   51      �� 53      " 	�6   .�54   
   ��  � ��$ 	11,11,0,0q�6#   55      �� 57      "  6   .�58   
   ��  �@ AutoGenerateColumns .  60   �� 59   
    �@ CanUserAddRows .  6+   �� 5:   
    �@ CanUserReorderColumns .  62   �� 5;   
    �@ HeadersVisibility$ Column=�6.   �� 5<   
     �@ HorizontalGridLinesBrush
 �����65   �� 5=   
    �@ VerticalGridLinesBrush
 �����63   5>      �� 5@      " ��6)   .�5A   
   ��  �@��Padding$ 4,2,4,3q�6$   5B      �� 5D      " ��6)   .�5E   
   ��  � ��$ 0q�6,   �� 5F   
    � ��$ 2,2,2,3q�6$   5G      �� 5I      " m�6    5J   
   �� 5K       6   �� *	IsEnabled+ �� *Self+	 False6^   .a�5L      ��  �@J�Opacity$	 0.6Q�6,   5M      5O      �� 5Q      " ��66    5R   
   �� 5S       6   �� *	IsEnabled+ �� *Self+	 False6^   .a�5T      ��  �@J�Opacity$
 0.35Q�6,   5U      5W      �� 5Y      " ��6    8   .�5Z   
   ��  � ��$
 Bold"�6'   �� 5[   
    � ��8  6'   5\      5^      