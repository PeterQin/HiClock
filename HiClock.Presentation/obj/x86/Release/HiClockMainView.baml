   M S B A M L   `   `   `  ����   HiClock.Presentation*   $HiClock.Presentation.HiClockMainView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     N JCommon.Presentation, Version=1.0.0.3, Culture=neutral, PublicKeyToken=null#comhttp://common.hiclock.com  4xctk)http://schemas.xceed.com/wpf/xaml/toolkit  ���	#FF676767  � 	Resources   �� MergedDictionaries �� Source   TextBoxTimeStyle �� 
TargetType �� Property �� Value  NobodyButtonStyle  GridSplitStyle  TabContentGridStyle  GridSplitTextStyle  TabHeaderImageStyle  TabHeaderStackPanelStyle  TabItemTextStyle �� 
TargetType ��Name �� Triggers	 P� Property
 P� Value �� 
TargetName J� SnapsToDevicePixels-  'System.Windows.Input.KeyboardNavigation   TabNavigation � ColumnDefinitions �Name � RowDefinitions �� CornerRadius K� IsItemsHost K� ZIndex   TabIndex   DirectionalNavigation �� SelectedContent �� SelectedContentTemplate" �� SelectedContentStringFormat �� ContentStringFormat  FrequencyDataTemplate �� Mode ��Name �� Triggers �� Value �� Binding��  �� $C =/Common.Presentation;Component/Resources/CommonResources.xaml?��� $M G/Common.Presentation;Component/Resources/WPF Themes/ExpressionDark.xaml?�%�  &	        &	 N    &	     &	 X    &	 �    &	 �    &	 �    &	     '�� [    '�� x    '�� l    &	 �    �� " ��.���  � �� �	#FF1D1A1A��  � �� �	#FF14E614��  � �� �	#FF01F9E3��  � ��$ 1q���  �@��
CaretBrush �	#FF14E614��  � ��$ 45����  � ��$
 Bold"���  � ��$ 15(���  � ��$ 25����  � ��$ 6,0,6,0q���  � ��$ Center=���  � ��$ Center=��� " ��.���  � ��
 ���� ��  � ��$ 0q���  � ��
 ���� ��  � �� �	#FF9966CC��  � ��$
 Bold"���  � ��$ 20(���  � ��$ 23����  � ��$ 23���� " �.���  � �� �	#FF9966CC��  � ��$ 2���� " �.���  � �� �	#FF595959�� " ��.���  � ��$ 18(���  � ��
 ������� " ��.���  � ��$ 36���� " ��.���  � ��$ 52���� " ��.���  � ��
 �������  � ��$ Center=���  � ��$
 Bold"��� " ��.���  � ��
 ���� ��  � �� �� " ��.R��� $ PART_Border��#��z��$��1q�$��2q�._��� $ PART_Border2��#��z��$��1q�._��� $ PART_Border3��#��z��$��1q�._��� $��Header��$��2q� P� 	 �@��
IsSelected
 . . ��� $ PART_Border�� � �� �	#FF797979�� $ PART_Border�� � �� �	#FF515151�� $ PART_Border2�� � �� �	#FF404040�� $ PART_Border3�� � �� �	#FF464646P� 	 �@J�IsMouseOver
 . . ��� $ PART_Border�� � �� �	#FF797979�� " ��.���  � ��$ 3q���  � ��$ 3q���  � �� �� " ��.R�� }�.  . $ Local=� �� $ ColumnDefinition0���� $ ColumnDefinition1��$��0 � �� $ RowDefinition0��$
��Auto ��� $ RowDefinition1��$��* �.+��� $ HeaderBorder�����	#FF676767$��1q�$ 0�����	#FF676767._��� $��HeaderPanel�� . $ 1��$ 1��$��0��$��0��$��3q�� $��ContentPanel��$ 2��$ Local=�$ 	Contained=�$��0��$��1��.+��� #��z��#��z��$��0q�$ 0��#��z��._��� $��PART_SelectedContentHost��#��z #��z # z $��SelectedContent��# z  P� 	 �@��TabStripPlacement$
 Bottom=�. ��� $ HeaderPanel�� � ��$ 1���� $ ContentPanel�� � ��$ 0���� $ RowDefinition0�� � ��$ * ��� $ RowDefinition1�� � ��$
 Auto ��� $ HeaderBorder�� � ��$ 0,5,0,0q�P� 	 �@��TabStripPlacement$

 Left=�. ��� $ HeaderPanel�� � ��$ 0���� $ ContentPanel�� � ��$ 0���� $ HeaderPanel�� � ��$ 0���� $ ContentPanel�� � ��$ 1���� $ ColumnDefinition0�� � ��$
 Auto ��� $ ColumnDefinition1�� � ��$ * ��� $ RowDefinition0�� � ��$ * ��� $ RowDefinition1�� � ��$ 0 ��� $ HeaderBorder�� � ��$ 0,0,5,0q�P� 	 �@��TabStripPlacement$
 Right=�. ��� $ HeaderPanel�� � ��$ 0���� $ ContentPanel�� � ��$ 0���� $ HeaderPanel�� � ��$ 1���� $ ContentPanel�� � ��$ 0���� $ ColumnDefinition0�� � ��$ * ��� $ ColumnDefinition1�� � ��$
 Auto ��� $ RowDefinition0�� � ��$ * ��� $ RowDefinition1�� � ��$ 0 ��� $ HeaderBorder�� � ��$ 5,0,0,0q�P� 	 � {�
 .  . ��� # � �� � ���� " ��.���  � ��$ Center=���  � ��
 ������� .R��  �� $
��auto ��� $��* �.+��� $��0������ *	Frequency+$ OneWay=��� $ 	txtTimeIn��$��1�� �� $ InSecond�� �� *TimeIn+a��� $ 	txtTimeIn�� � ��$  Second���� $ InMinute�� �� *TimeIn+a��� $ 	txtTimeIn�� � ��$  minute���� $ InHour�� �� *TimeIn+a��� $ 	txtTimeIn�� � ��$  hour��.���  �� $��* ��� $
��auto � �� $
��AUTO ��� $��* �.+��� $��0��$��2��$��0��$��2��$��0q����	#FFD2FFF1 �� SelectedIndex �� *CurrentSelectedTabIndex+$ TwoWay=�.@��� ���� #��[ .+���  	 ThemePng#��[	 #��[ �� $��Settings��#��[ .��� #��[ .+�� $��12q� �� $��1* ��� $��1* ��� $��1* �.+�� $��0�� �� $
��auto ��� $��* �.+��� $��0��.+��� $��Alarm Setting��#��[ $��Bottom=�� $��1��$��21,6,0,0q� �� $
��auto ��� $
��auto ��� $
��auto � �� $
��auto ��� $
��auto ��� $��* �.+��� $��Alarm Frequency: ��$��0��$��0���� $��0��$��1��$	��100��#��[ ���� *Root.AlarmFrequencyList+$ OneWay=�  �� SelectedItem  �� *Root.SelectedFrequency+$ TwoWay=�! �� UpdateSourceTrigger$! PropertyChanged=��� $��Alarm Duration: ��$��1��$��0���� $��0,6,0,0q�$��1��$��1��$	��100��#��[ ���� *Root.DurationList+$ OneWay=�  �� *Root.SelectedDuration+$ TwoWay=�$! PropertyChanged=�� $��1�� �� $
��auto ��� $��* �.+��� $��0��.+��� $��Theme��#��[ $��Bottom=�� $��1��$��21,6,0,0q� �� $
��auto ��� $
��auto ��� $
��auto � �� $
��auto ��� $
��auto ��� $��* �.+��� -   " ��Name$" chkRadio��$��0��$��0��$��Listen to the radio: ��# d� 	IsChecked# �� *Root.TurnOnRadio+$ TwoWay=�$! PropertyChanged=��� $	��250��$��0��$��1������ *Root.RadioUri+$ TwoWay=�$! PropertyChanged=�{��� *	IsChecked+$ OneWay=�$ �� ElementName$$ chkRadio���� $��Image Location: ��$��1��$��0���� $	��250��$��0,6,0,0q�$��1��$��1������ *Root.ImageLocation+$ TwoWay=�$! PropertyChanged=��� $ ��Refresh screen frequency: ��$��2��$��0���� $	��250��$��0,6,0,0q�$��2��$��1��$	��100��#��[ ���� *Root.RefreshFrequencyList+$ OneWay=�  �� *Root.RefreshScreenFrequency+$ TwoWay=�$! PropertyChanged=�� $��2��$��0,12,0,0q� �� $
��auto ��� $��* �.+��� $��0��.+��� $��General��#��[ $��Bottom=�� $��1��$��21,6,0,0q�.+��� $��0��$��0��$	��100��$��Start with system��$	��Top=�# �� *Root.IsAutoStart+$ TwoWay=�$! PropertyChanged=����� *SetAutoStartCommand+$ OneWay=��� ���� #��[ .+���  
 AboutPng#��[
 #��[ �� $��About��#��[ .��� #��[ .+�� $��12q�.+��� ���� *	AboutView+$ OneWay=��� $��0��$��1��$��15q�% �� Orientation$% 
Horizontal=�.+��� $��48��  HiClock#��[ �� $��3,0,0,0q����	#FF1297FB$��Bottom=�$
��Bold"��� $�Hiclock���� �� $�v�� �� ��� *CurrentVersion+$ OneWay=�