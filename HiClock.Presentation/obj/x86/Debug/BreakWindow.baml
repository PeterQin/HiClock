   M S B A M L   `   `   `  ����  HiClock.Presentation&     HiClock.Presentation.BreakWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   N JCommon.Presentation, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null#comhttp://common.hiclock.com  5   	   T PWpfApplicationFramework, Version=2.5.0.400, Culture=neutral, PublicKeyToken=null)wafhttp://waf.codeplex.com/schemas  5   	     � Title$  Please take a break��5   	   $	��350��6%   $	��525��62      
HiClockIco � Icon# [  6>    � WindowState$ Normal=�5   	    � WindowStartupLocation$ Manual=�6    � Topmost .  � WindowStyle$
 None=�5      
���   � � 
ResizeMode$ NoResize=�6>    � 	Resources 5	       �� MergedDictionaries	 �� Source�� 5
   
    5      �� 5      $C	 =/Common.Presentation;Component/Resources/CommonResources.xaml?�6%   %    5      .��5      � 
 � ColumnDefinitions
 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   � -   5         �Name$ gridMain��5       � RowDefinitions 5      �� 5      $��* �6    �� 5      $
��auto �6    .+�5      �� -   5         ��Name$	 img��5   2   $��0��6   $��2��6!   9  3System.Waf.Presentation.Commands.SingleEventBinding   	EventName$ MouseLeftButtonUp��6?   $��0��5      $��3��6�      Command 5   t   �� *NextImageCommand+��5   $   �� *CurrentImage.FullName+ �� Mode$ OneWay=�  StrToImageConver �� 	Converter# [  � ContextMenu 5      �� 5      .@�5      m� $
��Next��6#    m� Command 61   �� *NextImageCommand+$ OneWay=�m� 5      $
��Back��6#    61   �� *PreviousImageCommand+$ OneWay=�m� 5       $
��Exit��6#    61   �� *CloseBreakCommand+$ OneWay=�5!      5#      � 5$      $��1��6   
 5%      �� 5&      $��1* �6'   �� 5'      $
��auto �6'   �� 5(      $��1* �6'   .+�5*      �� $��1��6   $��0,0,0,-3q�6)   $��1q�6;   ���	#FF322D2D J� Opacity$	 0.9Q�6f   ��5+      �� 5,       �� 
StartPoint$ 0.5,0&�6.    �� EndPoint$ 0.5,1&�6A   .��5-      �  � Offset$ 0Q�6+    � Color$ White��66   � 5.      $	 0.5Q�6+   $
 Gold��68   5/      ._�51      � $��21q�6    52      �� 53      $��* �6,   �� 54      $
��auto �6,   .+�56      � $��0��6   
 57      �� 58   "   $
��auto �63   �� 59   "   $
��auto �63   �� 5:   "   $��* �63   .+�5<      r� -   5         r�Name$ media��5<   +    r� LoadedBehavior$ Manual=�6:   $��0��6R    r� Volume 6b   ��  �� Path$ Value� �� ElementName$ sliderVolume��6�   �� 5=      $��1��6)   $	��150��69   $��0,6,0,0q�6E   .+�5>   "   �� 
�������$��14(�6�   $��Center=�6�   $
��Bold"�6�   $��WrapWithOverflow=�6�   ��6,   �� *'%CurrentMusic.FileNameWithoutExtention+$ OneWay=�6�   �� 5?   "   $��21,6,0,0q�6,   
�������$��11(�6�   $��Center=�6�   $��WrapWithOverflow=�6�   ��6>   �� *CurrentMusic.Artists+$ OneWay=�6�   5@      �� 5A      $��2��6)    �� Orientation$ 
Horizontal=�69   .+�5B   "   �� 
�������$��Center=�6e     ButtonControlTemplateRound#��[ 6�   ��6<   �� *PreviousMusicCommand+��5C   &   �� 5D   *     BackPng#��[ 60   $��36��6R   $��3q�6]   5F   #   �� 5G   "   -   5         ��Name$ btnPlay��5G   )   
�������#��[ 6M   ��5H   &   �� 5I   *     PlayPng#��[ 60   $��48��6R   $��3q�6]   5K   #   �� 5L   "   
�������$��Center=�6a   #��[ 6|   ��6<   �� *NextMusicCommand+��5M   &   �� 5N   *     NextPng#��[ 60   $��36��6R   $��3q�6]   5P   #   �� 5Q   "   -   5        $ 	btnVolume��5Q   )   
�������$��Center=�6O   #��[ 6j   ��5R   &   �� 5S   *     	VolumePng#��[ 60   $��36��6T   $��3q�6_   5U   #   � 5V   "   -   5          �Name$  popup��5V   (   $��Right=�67   ! � 	StaysOpen! .  " � VerticalOffset$" 3��6[   .��5W   &   � 
�������$��36��6=   .+�5X   *   �� -   5        # ��Name$# sliderVolume��5X   =   $ � Maximum$$ 1Q�61   $��Center=�6S   % � Minimum$% 0Q�6n   & � Value$	& 0.5Q�6z   
�������$	��125��6�   ' �� Orientation$' 
Horizontal=�6�   ( �� IsSelectionRangeEnabled( . ) �� SelectionEnd) 6�   �� *Value+$ OneWay=�* �� RelativeSource* �� *Self+5Y   '   5Z   #   5[      5\      �� 5]      -   5        $# sliderMediaProcess��5]   .   $��1��6!   $��0,12,0,0q�6J   ( . $% 0Q�6{   ) 6�   �� *Value+$ OneWay=�* �� *Self+5^      5_      5`      5a      5b      5c      