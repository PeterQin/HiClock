   M S B A M L   `   `   `  ����t  pWaf.InformationManager.EmailClient.Modules.Applications, Version=2.5.0.400, Culture=neutral, PublicKeyToken=null��clr-namespace:Waf.InformationManager.EmailClient.Modules.Applications.ViewModels;assembly=Waf.InformationManager.EmailClient.Modules.ApplicationsBWaf.InformationManager.EmailClient.Modules.Applications.ViewModels  5      ; 7Waf.InformationManager.EmailClient.Modules.PresentationX   RWaf.InformationManager.EmailClient.Modules.Presentation.Views.ExchangeSettingsView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      �vm�clr-namespace:Waf.InformationManager.EmailClient.Modules.Applications.ViewModels;assembly=Waf.InformationManager.EmailClient.Modules.Applications     5      $
��Left=�5      $	��Top=�6    .��5
      � $��	0,0,11,11q�6     � ColumnDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $/��)Create account: Microsoft Exchange Server��6   $��0��6D   $��0��6T   $��2��6a      HeaderLabel#��[  6u   $��
11,11,0,11q�6�   �� 5   
   $��Exchange server��6   $��0��6*   $��1��6:   �� 5   
   -   5         ��Name$ serverPathBox��5      $	��150��5   ,   $��1��68   $��1��6H   ��5   )   �� *Model.ServerPath+ �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnExceptions .  �� ValidatesOnDataErrors .  �� NotifyOnValidationError . 5   H   �� 5   
   $��	User name��6   $��0��6$   $��2��64   �� 5   
   $��1��5   ,   $	��150��6<   $��2��6H   ��5      �� *Model.UserName+$ PropertyChanged=� .  .  . 5   H   5      5      