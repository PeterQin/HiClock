   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      H DBookLibrary, Version=2.5.0.400, Culture=neutral, PublicKeyToken=nullq=clr-namespace:Waf.BookLibrary.Library.Presentation.Converters/Waf.BookLibrary.Library.Presentation.Converters 5      q=clr-namespace:Waf.BookLibrary.Library.Presentation.Properties/Waf.BookLibrary.Library.Presentation.Properties 5      a ]Waf.BookLibrary.Library.Applications, Version=2.5.0.400, Culture=neutral, PublicKeyToken=null�kclr-namespace:Waf.BookLibrary.Library.Applications.ViewModels;assembly=Waf.BookLibrary.Library.Applications/Waf.BookLibrary.Library.Applications.ViewModels 5
      9   3Waf.BookLibrary.Library.Presentation.Views.BookView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      6sys&clr-namespace:System;assembly=mscorlib     5      Kc=clr-namespace:Waf.BookLibrary.Library.Presentation.Converters     5      Kp=clr-namespace:Waf.BookLibrary.Library.Presentation.Properties     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      T PWpfApplicationFramework, Version=2.5.0.400, Culture=neutral, PublicKeyToken=null)wafhttp://waf.codeplex.com/schemas  5	      tvmkclr-namespace:Waf.BookLibrary.Library.Applications.ViewModels;assembly=Waf.BookLibrary.Library.Applications  5
      $	��250��5      $	��270��6   .  (System.Waf.Presentation.ValidationHelper    	IsEnabled  . {�6$   �� *	IsEnabled+   IsValid 5   +   �� *	IsValid+ �� Mode$ OneWayToSource=�.��5      � $��	0,0,22,11q�6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5!   
   �� ?  9Waf.BookLibrary.Library.Presentation.Properties.Resources   	TitleMenu#��Z 6   $��0��6c   $��0��6s    �� Target 6;   ��  �� ElementName$ titleBox��6s   �� 5"   
   -   5         ��Name$ titleBox��5"      	 �� 	MaxLength$		 100��5$      $��1��6"   $��2��62   $��	11,11,0,0q�6F   $��Stretch=�6Y   ��5"   $   �� *
Book.Title+
 �� UpdateSourceTrigger$
 PropertyChanged=� �� ValidatesOnExceptions .  �� ValidatesOnDataErrors .  �� NotifyOnValidationError . 5$   Y   �� 5&   
      Author#��Z 6   $��0��68   $��1��6H   �� 5'   
   $		 100��5)      $��1��6"   $��1��62   $��2��6?   $��Stretch=�6S   ��5'      �� *Book.Author+$
 PropertyChanged=� .  .  . 5)   S   �� 5+   
      	Publisher#��Z 6   $��0��6;   $��2��6K   �� 5,   
   $		 100��5.      $��1��6"   $��2��62   $��2��6?   $��Stretch=�6S   ��5,      �� *Book.Publisher+$
 PropertyChanged=� .  .  . 5.   S   �� 50   
      PublishDate#��Z 6   $��0��6=   $��3��6M   (  "System.Windows.Controls.DatePicker  51   
   $��1��6?   $��3��6O   $��2��6\   $��Stretch=�6p      SelectedDate 6   �� *Book.PublishDate+6p   �� 53   
      Isbn#��Z 6   $��0��66   $��4��6F   �� 54   
   $	 14��56      $��1��6!   $��4��61   $��2��6>   $��Stretch=�6R   ��54      �� *	Book.Isbn+$
 PropertyChanged=� .  .  . 56   R   �� 58   
      Language#��Z 6   $��0��6:   $��5��6J   �� 59   
   $��1��5:   :   $��5��6J   $��2��6W   ��59      ��    LanguageValues �� Source# [   �� SelectedItem 5:      �� *Book.Language+��5;      �� 5<      .R�5=      �� ��6    �� O  IWaf.BookLibrary.Library.Presentation.Converters.LanguageToStringConverter   Default �� 	Converter# Z 5>      5@      �� 5B   
      Pages#��Z 6   $��0��67   $��6��6G   �� 5C   
   $��1��5D   O   $��6��6_   $��2��6l   $��Stretch=�5E      ��5C      �� *
Book.Pages+$
 PropertyChanged=� .  .  . 5E      �� 5G   
      LendTo#��Z 6   $��0��68   $��7��6H   �� 5H   
    �� 
IsReadOnly . $��Stretch=�6$   $��1��6B   $��7��6R   .��6_   ��5I      `� 5J       �� StringFormat$ {0} {1}��6   .1�5K      ��  �� Path$ Book.LendTo.Firstname�6   �� 5L      $ Book.LendTo.Lastname�6   5M      .��5N      5O      �� 5P   
      
MoreButton#��Z 6U   $��25��5Q      $��7,11,0,0q�6   $��2��61   $��7��6A   ��5P      �� *LendToCommand+��63   �� *Book+5Q   A   5R      5T      