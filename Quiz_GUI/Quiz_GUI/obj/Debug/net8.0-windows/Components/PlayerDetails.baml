   M S B A M L   `   `   `  ����C  ?Quiz_GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Quiz_GUI.ComponentsQuiz_GUI.Components  5      9!clr-namespace:Quiz_GUI.ViewModelsQuiz_GUI.ViewModels  6>   '    !Quiz_GUI.Components.PlayerDetails   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Quiz_GUI.Components     5      8
viewmodels!clr-namespace:Quiz_GUI.ViewModels     6>   .��5	      � .+�5
   
   ��    BorderPrimary#��[  5      $��1q�5        J� SnapsToDevicePixels$
  True��5       �� CornerRadius$ 5��5      ._�5      �  � IsSharedSizeScope$
 True��6    � RowDefinitions 5      �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$   �� 5      $
��auto �6$   .+�5      �� $��0��5      $��16(�5       �� Padding$ 
20 10 0 10q�5      $
��Bold"�5      ��5      �� *
UserName+� 5       $��1��6    � ColumnDefinitions 5!      �� 5"      $
��auto �6+    z� SharedSizeGroup$ Label��68   �� 5#      $
��auto �6+   .+�5&      �� $��0��5'      $
��Bold"�5(      $ 20 8 0 8q�5)      $��Total marks��5*      �� 5+      $��1��5,      $ 20 8 0 8q�5-      ��5.      �� *Score+5/      � 51      $��2��6    52      �� 53      $
��auto �6+   $ Label��68   �� 54      $
��auto �6+   .+�57      �� $��0��58      $
��Bold"�59      $ 	20 10 0 8q�5:      $
��Rank��5;      �� 5<      $��1��5=      $ 	20 10 0 8q�5>      ��5?      �� *Rank+5@      � 5B      $��3��6    5C      �� 5D      $
��auto �6+   $ Label��68   �� 5E      $
��auto �6+   .+�5H      �� $��0��5I      $
��Bold"�5J      $ 	20 10 0 8q�5K      $��Email��5L      �� 5M      $��1��5N      $ 	20 10 0 8q�5O      ��5P      �� *Email+5Q      � 5S      $��4��6    5T      �� 5U      $
��auto �6+   $ Label��68   �� 5V      $
��auto �6+   .+�5Y      �� $��0��5Z      $
��Bold"�5[      $ 	20 10 0 8q�5\      $��	Full Name��5]      �� 5^      $��1��5_      $ 	20 10 0 8q�5`      ��5a      �� *
FullName+5b      � 5d      $��5��6   $��
0,25,0,-25q�6$    5e      �� 5f      $
��auto �6+   $ Label��68   �� 5g      $
��auto �6+   �� 5h      $
��auto �6+   �� 5i      $
��auto �6+   �� 5j      $
��auto �6+   �� 5k      $
��auto �6+   .+�5o      �� $��4��5p      $��Delete��5q      ���#FF3B30
�������$
��Bold"�5t      $
��10 5q�5u      $��10,5,0,5q�5v      $��Center=�5w      $��Center=�5x      ��5y      �� *DeletePlayerCommand+�� 5}      $��5��6   $��Change��5~      ���#007AFF
�������$
��Bold"�5�      $
��10 5q�5�      $��10,5,0,5q�5�      $��Center=�5�      $��Center=�5�      ��5�      �� *ChangePlayerCommand+5�      5�      5�      5�      5�      