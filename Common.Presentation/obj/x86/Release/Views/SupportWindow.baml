   M S B A M L   `   `   `  ���� N  JCommon.Presentation, Version=1.0.0.3, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Common.Presentation.ConvertersCommon.Presentation.Converters  -    'Common.Presentation.Views.SupportWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ?conver,clr-namespace:Common.Presentation.Converters     -     � Title$  HiClock Support��$	��500��$	��650��   BaseBackground#��[    
HiClockIco � Icon# [  � WindowStartupLocation$ CenterScreen=� � 	Resources  �� MergedDictionaries �� Source@   :Common.Presentation.Converters.EmptyTextToBooleanConverter  NullTxtConver��  �� $C =/Common.Presentation;Component/Resources/CommonResources.xaml?�%   &	         .��� .+��  � RowDefinitions �� $
��auto ��� $
��auto ��� $��* �.+��� $��0��  HeaderBackground#��[ ._���   HeaderForeground#��[ .��� $��12q� � ColumnDefinitions �� $
��auto ��� $��* � �� $
��auto ��� $
��auto �.+��� $��0��$��0��$��2��$��60��$��60��  ErrorPng#��[ $��6,0,12,0q��� $4��.HiClock has encountered an unhandle exception.��$��15(�$��Center=�$
��Bold"�$��1��$��0���� $��1��$��1��$��0,6,0,0q�.+��� $=��7Do you want to send more information about the problem?���� $M��GAdditional details about what went wrong can help us create a solution.���� $��1��
���   �$��0��$��0q��� -    ��Name$ borderEmail��$��2��._�� $��15q� �� $
��auto ��� $��* ��� $
��auto �.+�� $��0�� 	 �� 
TargetType
 �� Property �� Value��%1   '��       �� "	 ��.��� 
 � ��$ Center=� �� $
��auto ��� $��* � �� $
��auto ��� $
��auto ��� $
��auto �.+��� $��Your E-Mail: ��$��0��$��0���� -    ��Name$ txtMail��$��1��$��0���� $��	Subject: ��$��0��$��1���� -   $ 
txtSubject��$��1��$��1���� $��To Support: ��$��0��$��2���� -   $ 
txtSupport�� �� 
IsReadOnly . $��1��$��2���� -   $ txtMailContent��$��1��$
��Auto=�$
��Auto=�� -    �Name$ gridActionControl��$��2�� �� $��* ��� $
��auto ��� $
��auto ��� $
��auto �.+��� -    ��Name$ btnSend��$��_Send��$��1��$��2��{���  �� Path$
 Text� �� ElementName$ txtMail�� �� Mode$ OneWay=� �� 	Converter# [ �� -	   $ btnCopy��$��_Copy��$��2��$��2���� -
   $ btnClose��$��_Close��$��3��$��2������ "	 ��  ButtonBaseStyle �� BasedOn# [ .��� 
 � ��$ 6,6,3,6q�� -   $ borderProgress��$y�	Collapsed=�.+�� 
������� J� Opacity$	 0.8Q��  �� $��* ��� $
��auto ��� $��* � �� $��* ��� $
��auto ��� $��* �.+��� $��1��$��1��$��0q�  ProgressContainerBackground#��[  �� CornerRadius$ 1��$ 1Q�._��� $��39q�$��1q�  ProgressBorderBrush1#��[ $ 1��._��� $��1q� 	 ProgressBorderBrush2#��[	 $ 1��._��� $��1q� 
 ProgressBorderBrush3#��[
 ._��   ProgressBackground#��[  � IsIndeterminate . $��0q�  ProgressForeground#��[ 