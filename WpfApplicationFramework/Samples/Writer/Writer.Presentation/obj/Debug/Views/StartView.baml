   M S B A M L   `   `   `  ����C  ?Writer, Version=2.5.0.400, Culture=neutral, PublicKeyToken=nullW0clr-namespace:Waf.Writer.Presentation.Converters"Waf.Writer.Presentation.Converters  5      W0clr-namespace:Waf.Writer.Presentation.Properties"Waf.Writer.Presentation.Properties  5      W0clr-namespace:Waf.Writer.Presentation.DesignData"Waf.Writer.Presentation.DesignData  5      -    'Waf.Writer.Presentation.Views.StartView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      >c0clr-namespace:Waf.Writer.Presentation.Converters     5      >p0clr-namespace:Waf.Writer.Presentation.Properties     5      ?dd0clr-namespace:Waf.Writer.Presentation.DesignData     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5          >�Name$  	startView��5   7   .��5      � ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$ 0.5,1.5&�63   .��5      �  � Color$ White��6    � Offset$ 0Q�6-   � 5      $ 	#FFDCE1F5��6   $ 0.662Q�61   � 5      $ 	#FFAFBFF8��6   $ 1Q�61   5       � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5!   
   �� 2   ,Waf.Writer.Presentation.Properties.Resources   	StartPage#��Z 6   $��18(�6;   $��	22,11,0,0q�6I   �� 5"   
      RecentFiles#��Z 6   $��14(�6=   $��	50,11,0,0q�6K   $��Bottom=�6^   $��1��6y   �� 5$   
   -   5        	 ��Name$	 	newButton��5$      $	��100��6O   $��50��6[   $��	33,22,0,0q�6g   $��1��6z   
 � UseLayoutRounding
 . ��6$   �� *FileService.NewCommand+.��5%      ��  �� Orientation$ 
Horizontal=�6   .+�5&      ��    NewImage#��[  6#   �� 5'      
   New#��Z 6   $��3q�6=   5(      5)      �� 5+   
   $	��100��6=   $��50��6I   $��	33,22,0,0q�6U   $��2��6h   
 . ��6   �� *FileService.OpenCommand+.��5,      �� $ 
Horizontal=�6   .+�5-      ��   	OpenImage#��[ 6#   �� 5.         Open#��Z 6   $��3q�6>   5/      50      �� 52   
   |�.  $��1��6h   $��1��6x   $��3��6�   $��55,22,22,22q�6�   ��6   �� *(&FileService.RecentFileList.RecentFiles+��53      �� 54      .R�55      ]� $��0,0,0,15q�6     � ContextMenu 56      �� 57      .@�58   "   m� -   5           OpenFileMenu#��Z 58   +   6X   m� 59   "   -   5           PinFileMenu#��Z 59   +   ��5:   &   �� 5;   *    �� 
TargetType" m�60    �� Triggers 5<   .   �� 5=   2    �� Binding 6>   �� *
IsPinned+ �� Value True6[   .a�5>   6   ��  �� Property � y� �� Value$ 	Collapsed=�6S   5?   3   5A   +   5C   #   m� 5D   "   -   5           UnpinFileMenu#��Z 5D   +   ��5E   &   �� 5F   *   " m�60    5G   .   �� 5H   2    6>   �� *
IsPinned+	 False6[   .a�5I   6   ��  � y�$ 	Collapsed=�6S   5J   3   5L   +   5N   #   m� 5O   "   -   5           RemoveFileMenu#��Z 5O   +   6Z   5P      .+�5S      d� 
   Pin#��Z 6F   $
��Left=�6k    d� 	IsChecked 6'   �� *
IsPinned+6k   �� 5T      $��CharacterEllipsis=�6$    �� Padding$
 11,3q�6E    � ToolTip 6T   �� *Path+�� 5U       �� Command 6(   �� *%#DataContext.FileService.OpenCommand+ �� ElementName$ 	startView�� �� CommandParameter 6w   �� *Path+.�6�   .�5V   "   �� �6&   �� *Path+>   8Waf.Writer.Presentation.Converters.MenuFileNameConverter    Default! �� 	Converter#! Z  " �� Mode$" OneWay=�5W      5X      5Y      5Z      5\      5]      5^      