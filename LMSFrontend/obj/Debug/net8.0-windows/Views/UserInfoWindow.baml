   M S B A M L   `   `   `  ����F  BLMSFrontend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:LMSFrontend.ViewsLMSFrontend.Views  5   	   &     LMSFrontend.Views.UserInfoWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:LMSFrontend.Views     5   	     � Title$  UserInfoWindow��5   	   $	��450��6    $	��800��6-    � WindowState$ 	Maximized=�5	   	    � WindowStyle$ SingleBorderWindow=�5
   	    � 
ResizeMode$ NoResize=�5   	   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5    
   �� $��Enter Your Name:��6   $��0��6,   $��0��69   $��5q�6I   $��Center=�6T   �� 5!   
   $��0��5"      $��1��6   $��5q�6/   $	��200��6:   ��5!      �� *
UserName+ �� UpdateSourceTrigger$ PropertyChanged=�5"   :   �� 5%   
   $��Enter Your Email:��6   $��1��6-   $��0��6:   $��5q�6J   $��Center=�6U   �� 5&   
   $��1��5'      $��1��6   $��5q�6/   $	��200��6:   ��5&      �� *Email+$ PropertyChanged=�5'   :   �� 5*   
   $��Confirm Borrow��6   
���   �
�������$��Medium"�5-      $��2��5/      $��0��6   $��2��6.   $��10q�50      $	��200��6   $��Center=�6)   ��5.      �� *ConfirmBorrowCommand+50   )   51      52      