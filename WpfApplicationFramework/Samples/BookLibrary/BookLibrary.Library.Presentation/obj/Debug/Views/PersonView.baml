   M S B A M L   `   `   `  ����H  DBookLibrary, Version=2.5.0.400, Culture=neutral, PublicKeyToken=nullq=clr-namespace:Waf.BookLibrary.Library.Presentation.Properties/Waf.BookLibrary.Library.Presentation.Properties  5      a ]Waf.BookLibrary.Library.Applications, Version=2.5.0.400, Culture=neutral, PublicKeyToken=null�kclr-namespace:Waf.BookLibrary.Library.Applications.ViewModels;assembly=Waf.BookLibrary.Library.Applications/Waf.BookLibrary.Library.Applications.ViewModels 5      ;    5Waf.BookLibrary.Library.Presentation.Views.PersonView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Kp=clr-namespace:Waf.BookLibrary.Library.Presentation.Properties     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      T PWpfApplicationFramework, Version=2.5.0.400, Culture=neutral, PublicKeyToken=null)wafhttp://waf.codeplex.com/schemas  5      tvmkclr-namespace:Waf.BookLibrary.Library.Applications.ViewModels;assembly=Waf.BookLibrary.Library.Applications  5      $	��250��5
      $	��122��6   .  (System.Waf.Presentation.ValidationHelper    	IsEnabled  . {�6$   �� *	IsEnabled+   IsValid 5   +   �� *	IsValid+ �� Mode$ OneWayToSource=�.��5      � $��	0,0,22,11q�6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� ?   9Waf.BookLibrary.Library.Presentation.Properties.Resources   FirstnameMenu#��Z 6   $��0��6k   $��0��6{    �� Target 6?   ��  �� ElementName$ firstnameBox��6{   �� 5   
   -   5         ��Name$ firstnameBox��5      	 �� 	MaxLength$	 30��5      $��1��6!   $��2��61   $��	11,11,0,0q�6E   $��Stretch=�6X   ��5   (   �� *Person.Firstname+
 �� UpdateSourceTrigger$
 PropertyChanged=� �� ValidatesOnExceptions .  �� ValidatesOnDataErrors .  �� NotifyOnValidationError . 5   X   �� 5   
      Lastname#��Z 6   $��0��6:   $��1��6J   �� 5    
   $	 30��5"      $��1��6!   $��1��61   $��2��6>   $��Stretch=�6R   ��5       �� *Person.Lastname+$
 PropertyChanged=� .  .  . 5"   R   �� 5$   
      Email#��Z 6   $��0��67   $��2��6G   �� 5%   
   $		 100��5'      $��1��6"   $��2��62   $��Stretch=�6?   ��5%      �� *Person.Email+$
 PropertyChanged=� .  .  . 5'   ?   �� 5(   
      
EmailImage#��[  6_      NewEmailMessage � ToolTip# Z 5)      $��25��6B   $��7,11,0,0q�6P   $��2��6b   $��2��6r    � UseLayoutRounding . ��5(      �� *CreateNewEmailCommand+��6;   �� *Person+5*      5+      5,      