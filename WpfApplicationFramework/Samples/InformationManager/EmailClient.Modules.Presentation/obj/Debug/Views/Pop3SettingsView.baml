   M S B A M L   `   `   `  ����t  pWaf.InformationManager.EmailClient.Modules.Applications, Version=2.5.0.400, Culture=neutral, PublicKeyToken=null��clr-namespace:Waf.InformationManager.EmailClient.Modules.Applications.ViewModels;assembly=Waf.InformationManager.EmailClient.Modules.ApplicationsBWaf.InformationManager.EmailClient.Modules.Applications.ViewModels  5      ; 7Waf.InformationManager.EmailClient.Modules.PresentationT   NWaf.InformationManager.EmailClient.Modules.Presentation.Views.Pop3SettingsView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      T PWpfApplicationFramework, Version=2.5.0.400, Culture=neutral, PublicKeyToken=null)wafhttp://waf.codeplex.com/schemas  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      �vm�clr-namespace:Waf.InformationManager.EmailClient.Modules.Applications.ViewModels;assembly=Waf.InformationManager.EmailClient.Modules.Applications  5      $
��Left=�5	      $	��Top=�6    .��5      � $��	0,0,11,11q�6     � ColumnDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $1��+Create account: Internet Email (POP3, SMTP)��6   $��0��6F   $��0��6V   $��2��6c      HeaderLabel#��[  5      $��
11,11,0,11q�65   �� 5   
   $��POP3 server��6   $��0��6&   $��1��66   �� 5   
   -   5         ��Name$ serverPathBox��5      $	��150��5    ,   $��1��68   $��1��6H   ��5   )   �� *Model.Pop3ServerPath+ �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnExceptions .  �� ValidatesOnDataErrors .  �� NotifyOnValidationError . 5    H   �� 5"   
   $��	User name��6   $��0��6$   $��2��64   $��	22,11,0,0q�6A   �� 5#   
   $	��150��5$   ,   $��1��68   $��2��6H   ��5#      �� * Model.Pop3UserCredits.UserName+$ PropertyChanged=� .  .  . 5$   H   �� 5&   
   $��Password��6   $��0��6#   $��3��63   $��	22,11,0,0q�6@   G� 5'   
   -   5        $	��150��5'   6   $��1��6B   $��3��6R   �� 5*   
   $��SMTP server��6   $��0��6&   $��4��66   $��	11,22,0,0q�6C   �� 5+   
   $��1��5,   ,   $	��150��6<   $��4��6H   $��	11,22,0,0q�6U   ��5+      �� *Model.SmtpServerPath+$ PropertyChanged=� .  .  . 5,   U   �� 5.   
   $��	User name��6   $��0��6$   $��5��64   $��	22,11,0,0q�6A   �� 5/   
   $	��150��52      $��1��6   $��5��6.   ��5/      �� * Model.SmtpUserCredits.UserName+$ PropertyChanged=� .  .  . {�51      �� *UseSameUserCredits+?  9System.Waf.Presentation.Converters.InvertBooleanConverter   Default �� 	Converter# Z 52   .   �� 54   
   $��Password��6   $��0��6#   $��6��63   $��	22,11,0,0q�6@   G� 55   
   -   5        	 G�Name$	 smtpPassword��55      $	��150��57      $��1��6"   $��6��62   {�56      �� *UseSameUserCredits+# Z 57   2   �� 59   
   $;��5Use same user name and password as for my POP3 server��6   $��1��5:      $��7��6#   
 d� 	IsChecked
 59   S   �� *UseSameUserCredits+5:   #   5;      5<      