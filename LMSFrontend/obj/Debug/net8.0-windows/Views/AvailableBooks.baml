   M S B A M L   `   `   `  ����F  BLMSFrontend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:LMSFrontend.ViewsLMSFrontend.Views  5   	   =#clr-namespace:LMSFrontend.ViewModelLMSFrontend.ViewModel  5   	   R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35dAclr-namespace:System.Collections.ObjectModel;assembly=WindowsBaseSystem.Collections.ObjectModel 5   	   &     LMSFrontend.Views.AvailableBooks   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:LMSFrontend.Views     5   	   9	viewModel#clr-namespace:LMSFrontend.ViewModel     5   	   QsysAclr-namespace:System.Collections.ObjectModel;assembly=WindowsBase     5   	     � Title$  AvailableBooks��5
   	   $	��450��6    $	��800��6-    � WindowState$ 	Maximized=�5   	    � WindowStyle$ SingleBorderWindow=�5   	    � 
ResizeMode$ NoResize=�5   	   .��5      � ���#F5F5F5.+�5   
   �� $k��eC:\Programmer\CYPHERON TECHNOLOGIES\repos\LMS\LMSFrontend\Images\high-angle-education-day-concept.jpg��6   $��UniformToFill=�5       J� Opacity$	 0.7Q�5      � 5   
    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      � $��0��6   $��Center=�5      $��50q�5      .+�5       �� $��📚 AVAILABLE BOOKS��6   $��35(�5!      $
��Bold"�5"      ���#FF7518$��Center=�5$      5%      � 5(      $��1��6   $��Center=�5)      $	��758��5*      .+�5+      �� ���#FFF5EE �� CornerRadius$ 10��5,      $��0q�5-       �� Padding$ 10q�5.      ���#D3D3D3$��1q�50       J� Effect 52      3  -System.Windows.Media.Effects.DropShadowEffect  53      	   
BlurRadius$	 8Q�6+   
   ShadowDepth$
 3Q�54   +      Opacity$	 0.3Q�55   +   ._�58      �� .+�59      �  � ColumnDefinitions 5;      �� 5<   "   $
��Auto �63   �� 5=   "   $
��Auto �63   �� 5>   "   $
��Auto �63   �� 5?   "   $
��Auto �63   .+�5A      ��  �� Orientation$ 
Horizontal=�6)   ���#F28C28$	��700��5C   )   $��Center=�5D   )   $��Center=�5E   )   .+�5G   "   �� $��Center=�6,   $��0��5H   ,   $��
BOOK TITLE��5I   ,   $
��Bold"�5J   ,   $	��200��5K   ,   ���#FFFFFF$��20q�5M   ,   $��15(�5N   ,   �� 5P   "   $��Center=�6,   $��1��5Q   ,   $��AUTHOR��5R   ,   $
��Bold"�5S   ,   $	��150��5T   ,   ���#FFFFFF$��
10 20 0 10q�5V   ,   $��15(�5W   ,   �� 5Y   "   $��Center=�6,   $��2��5Z   ,   $��AVAILABLE COPIES��5[   ,   $
��Bold"�5\   ,   $	��150��5]   ,   ���#FFFFFF$��-20 20 20 20q�5_   ,   $��15(�5`   ,   �� 5b   "   $��Center=�6,   $��3��5c   ,   $��ACTION��5d   ,   $
��Bold"�5e   ,   $��85��5f   ,   ���#FFFFFF$��20 20 20 20q�5h   ,   $��15(�5i   ,   5j      5k      �� 5o      $��0 5 40 5q�5q   "   ���#FFF5EE$��0q�5s   "   $��Center=�5t   "   $��Center=�5u   "   ��5o   "   �� *AvailableBooks+ �� SelectedItem 5p   "   �� *SelectedBook+��5v      �� 5w   "   .R�5x   &   �� 
�������$ 3q�5y   -   $ 5��5z   -   ���#FFD580$��1q�5|   -   ._�5~   *   �  5   .   �� 5�   2   $	��200 �6C   �� 5�   2   $	��150 �6C   �� 5�   2   $	��100 �6C   �� 5�   2   $
��Auto �6C   .+�5�   .   �� $��0��68   $��Center=�5�   8   $
��Left=�5�   8   $��15(�5�   8   $��Medium"�5�   8   $��10q�5�   8   ��5�   8   �� *	BookTitle+5�   8   �� 5�   .   $��1��68   $��Center=�5�   8   $
��Left=�5�   8   $��15(�5�   8   $��Medium"�5�   8   ��5�   8   �� *Author+5�   8   �� 5�   .   $��2��68   $��Center=�5�   8   $
��Left=�5�   8   $��15(�5�   8   $��Medium"�5�   8   $��
70 20 0 20q�5�   8   ��5�   8   �� *AvailableCopies+5�   8   �� 5�   .   $��BORROW��65   ���#FF7518$	��130��5�   5   $��3��5�   5   $��30��5�   5   $
��Left=�5�   5   $��Center=�5�   5   $��14(�5�   5   $
��Bold"�5�   5   $��30q�5�   5    � OverridesDefaultStyle$
 True��5�   5   ��5�   5   �� *DataContext.BorrowCommand+ �� RelativeSource ��  �� AncestorType
 Window��5�   5   ��  � FocusVisualStyle 5�   5   Z� ��5�   6   �� 5�   :    �� 
TargetType" ��6@   .�5�   :   ��  �� Property � �� �� Value �#FF75186W   �� 5�   :    � ��
 �����6W   �� 5�   :    � �� �#FF5F1F6X   �� 5�   :    � ��$ 2q�6\   �� 5�   :    �@J�RenderTransformOrigin$ 0.5,0.5&�6b   �� 5�   :    � �� 5�   B   �� 5�   F    �� 
TargetType" ��6V   .R�5�   J   ��  ��Name$ border��6Q   #��z��5�   Q   #��z��5�   Q   #��z��5�   Q   $ 5��5�   Q   $ 5q�5�   Q    J� RenderTransformOrigin$ 0.5,0.5&�5�   Q   z�5�   N   �� 5�   R   scaleTransform�� �� ScaleX$ 1Q�5�   a    �� ScaleY$ 1Q�5�   a   ._�5�   N   �� #��z��6X   #��z��5�   X   #��z��5�   X   #��z��5�   X   $��Center=�5�   X   $��Center=�5�   X   5�   K    �� Triggers 5�   J   P� 5�   N    P� Property �@J�IsMouseOver P� Value$
 True��6m   . �5�   R   ��  �� 
TargetName$ border��6Y    � �� �#FF5F1F6�    N� EnterActions 5�   R   �� 5�   V   .��5�   Z   �� .��5�   ^   W�   �� 
TargetName$  scaleTransform��6n   ! �� TargetProperty$! ScaleX�5�   n   	" W� To" 1.055�   n   # g� Duration$# 0:0:0.3D�5�   n   W� 5�   ^   $  scaleTransform��6n   $! ScaleY�5�   n   " 1.055�   n   $# 0:0:0.3D�5�   n   5�   [   5�   W   $ N� ExitActions$ 5�   R   �� 5�   V   .��5�   Z   �� .��5�   ^   W� $  scaleTransform��6n   $! ScaleX�5�   n   " 15�   n   $# 0:0:0.3D�5�   n   W� 5�   ^   $  scaleTransform��6n   $! ScaleY�5�   n   " 15�   n   $# 0:0:0.3D�5�   n   5�   W   5�   S   5�   K   5�   C   5�   ;   5�   7   5�   /   5�   +   5�   '   5�   #   5�      5�      5�      5�      5�      5      5     