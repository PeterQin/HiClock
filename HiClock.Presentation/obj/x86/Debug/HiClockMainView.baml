   M S B A M L   `   `   `  ����  HiClock.Presentation*   $HiClock.Presentation.HiClockMainView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      N JCommon.Presentation, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null#comhttp://common.hiclock.com  5      ���	#FFFBFEFF  � 	Resources  5
       �� MergedDictionaries �� Source   TextBoxTimeStyle �� 
TargetType �� Property �� Value�� 5   
    5      �� 5      $C =/Common.Presentation;Component/Resources/CommonResources.xaml?�6%   %�   &	        �� 5      " ��6-   .�5      ��  � ��
 �����6/   �� 5       � ��
 �/���6/   �� 5       � ��$ 30��6-   5      5      .��5      �� .@�5   
   �� $��Timer��6   .��5      � ���	#FFE5E5E5.+�5      � $��20q�6    � RowDefinitions 5      �� 5      $
��auto �6(   �� 5      $
��auto �6(   �� 5      $
��auto �6(   �� 5      $
��auto �6(   �� 5      $��1* �6(   �� 5       $
��auto �6(   .+�5#      ��  �� Orientation$ 
Horizontal=�6!   $��0��6:   $��10q�6G   .+�5$      �� $��0��6$   $��Remind in every ��64   $��Center=�6L   �� 5%      -   5         ��Name$ 	txtRemind��5%   "   $��Center=�65   #��[  6P   	 �� 
CaretBrush
	 �/�����6z   �� *BreakReminder+
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ Explicit=�  StrToDoubleConver �� 	Converter# [ 6�   �� 5&      $�� hours��6$   $��Center=�62   5'      �� 5)      $ 
Horizontal=�6!   $��1��6:   $��10q�6G   .+�5*      �� $��0��6$   $��Break duration in ��64   $��Center=�6N   �� 5+      -   5        $ txtDuration��5+   "   $��Center=�67   #��[  6R   
	 �/�����6|   �� *BreakDuration+$
 TwoWay=�$ Explicit=�# [ 6�   �� 5,      $�� minutes��6$   $��Center=�64   5-      �� 5/      $ 
Horizontal=�6!   $��2��6:   $��10q�6G   .+�50      �� $��0��6$   $��Change picture in every ��64   $��Center=�6T   �� 51      -   5        $ txtChangePictureSpan��51   "   $��Center=�6@   #��[  6[   
	 �/�����6�   �� *ChangePictureSpan+$
 TwoWay=�$ Explicit=�# [ 6  �� 52      $�� seconds��6$   $��Center=�64   53      �� 55      $��Reminder Text��6   $��3��66   $��0,12,0,0q�6C   $y�	Collapsed=�6U   .��56      �� -   5        $ txtRemindText��56   "   ��69   �� *
RemindText+$
 TwoWay=�$ Explicit=�57      � 59      $��6��6    � ColumnDefinitions 5:      �� 5;      $��* �6/   �� 5<      $
��auto �6/   �� 5=      $
��auto �6/   .+�5?      �� -   5        $��_Save��5?   !    �� 	IsDefault . $��1��6B   $��6q�6R   $��75��6]   $��Right=�6h   6�   �� 5@      $��_Cancel��6!    �� IsCancel .  $��6q�6D   $��2��6O   $��75��6_   $��Right=�6j   ��6�   �� *ExitSettingCommand+5A      5B      5C      5D      �� 5E   
   $��Theme��6   .��5F      � ���	#FFE5E5E5.+�5G      � $��20q�6    5H      �� 5I      $��1* �6(   �� 5J      $��1* �6(   �� 5K      $
��auto �6(   .+�5N      �� $��0��6   $��0q�6,   $��0,6,0,0q�68   ��5O      �� 5P      $��Music...��6%   $��2��68   $��Right=�6H   ��6d   �� *BrowseMusicCommand+$
 OneWay=�.��5R      �� ��6)   �� *	MusicView+5S      �� 5U      $��1��6   $��0q�6,   $��0,6,0,0q�68   ��5V      �� 5W      $��Image...��6%   ��68   �� *BrowseImageCommand+$
 OneWay=�.��5Y      �� $��0q�6G   $��0q�6R   ��6)   �� *	ImageView+6R   5Z      � 5\      $��2��6    5]      �� 5^      $��* �6/   �� 5_      $
��auto �6/   �� 5`      $
��auto �6/   .+�5b      �� -   5        $��_Save��5b   !    . $��1��6B   $��6q�6R   $��75��6]   $��Right=�6h   6�   �� 5c      $��_Cancel��6!    .  $��6q�6D   $��2��6O   $��75��6_   $��Right=�6j   ��6�   �� *ExitSettingCommand+5d      5e      5f      5g      5h      5j      