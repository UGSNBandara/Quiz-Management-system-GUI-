   M S B A M L   `   `   `  ����C  ?Quiz_GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Quiz_GUI.ComponentsQuiz_GUI.Components  5      '    !Quiz_GUI.Components.PlayerDetails   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Quiz_GUI.Components     5      .��5	      � .+�5
   
   ��    BorderPrimary#��[  5      $��1q�5        J� SnapsToDevicePixels$
  True��5       �� CornerRadius$ 5��5      ._�5      � .+�5      � ��5      �� 5       �� 
TargetType" �6    .�5      ��  �� Property � y� �� Value$ 	Collapsed=�6;    �� Triggers 5      �� 5   "    �� Binding 6.   �� *HasSelectedPlayer+ �� Value	 False6T   .a�5   &   ��  � y�$ Visible=�6C   5   #   5      .+�5      �� $��20(�5      ���#044d0a$��DemiBold"�5      $��WrapWithOverflow=�5      $q��kPlease Select A Player to See Their Details



Developer : Sulitha Nulaksha
Computer Engineer Undergraduate��5        �� TextAlignment$ Center=�5!      $��Center=�5"      $��Center=�5#      5$      � 5&      	 � IsSharedSizeScope$
	 True��6   ��5'      �� 5(      " �6    .�5)      ��  � y�$ 	Collapsed=�6;    5*      �� 5+   "    6.   �� *HasSelectedPlayer+ True6T   .a�5,   &   ��  � y�$ Visible=�6C   5-   #   5/      
 � RowDefinitions
 51      �� 52      $
��auto �6(   �� 53      $
��auto �6(   �� 54      $
��auto �6(   �� 55      $
��auto �6(   �� 56      $
��auto �6(   �� 57      $
��auto �6(   .+�5:      �� 
�������$ 10��5<       �� Padding$ 10q�5=      $��20 20 20 10q�5>      ._�5?      �� .+�5@      �� $��0��5A   !   $��16(�5B   !    �� Padding$ 
20 10 0 10q�5C   !   $
��Bold"�5D   !   ��5E   !   �� *
UserName+� 5G      $��1��6#    � ColumnDefinitions 5H   "   �� 5I   &   $
��auto �67    z� SharedSizeGroup$ Label��6D   �� 5J   &   $
��auto �67   .+�5L   "   �� $��0��5M   %   $
��Bold"�5N   %   $ 20 8 0 8q�5O   %   $��Total marks��5P   %   �� 5Q   "   $��1��5R   %   $
��Bold"�5S   %   $ 20 8 0 8q�5T   %   ��5U   %   �� *Score+5V      � 5X      $��2��6#    5Y   "   �� 5Z   &   $
��auto �67   $ Label��6D   �� 5[   &   $
��auto �67   .+�5]   "   �� $��0��5^   %   $
��Bold"�5_   %   $ 	20 10 0 8q�5`   %   $
��Rank��5a   %   �� 5b   "   $��1��5c   %   $
��Bold"�5d   %   $ 	20 10 0 8q�5e   %   ��5f   %   �� *Rank+5g      � 5i      $��3��6#    5j   "   �� 5k   &   $
��auto �67   $ Label��6D   �� 5l   &   $
��auto �67   .+�5n   "   �� $��0��5o   %   $
��Bold"�5p   %   $ 	20 10 0 8q�5q   %   $��Email��5r   %   �� 5s   "   $��1��5t   %   $
��Bold"�5u   %   $ 	20 10 0 8q�5v   %   ��5w   %   �� *Email+5x      � 5z      $��4��6#    5{   "   �� 5|   &   $
��auto �67   $ Label��6D   �� 5}   &   $
��auto �67   .+�5   "   �� $��0��5�   %   $
��Bold"�5�   %   $ 	20 10 0 8q�5�   %   $��	Full Name��5�   %   �� 5�   "   $��1��5�   %   $
��Bold"�5�   %   $ 	20 10 0 8q�5�   %   ��5�   %   �� *
FullName+5�      5�      5�      � 5�      $��5��6   .+�5�      ��  �� Orientation$ 
Horizontal=�6%   $��Right=�6>   $��Center=�6Z   .+�5�      �� $��Edit Player��5�   !     CommonButtonStyle1#��[ 5�   !   ���#1e3bf7
�������$��10q�5�   !   ��5�   !   �� *EditCommand+5�   !   �� 5�      $��Delete��5�   !   #��[ 5�   !   ���#f73e1e
�������$��10q�5�   !   ��5�   !   �� *DeleteCommand+5�   !   5�      5�      5�      5�      5�      5�      5�      