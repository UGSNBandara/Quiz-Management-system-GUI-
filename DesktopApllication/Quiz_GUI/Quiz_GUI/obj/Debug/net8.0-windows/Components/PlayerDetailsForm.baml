   M S B A M L   `   `   `  ����C  ?Quiz_GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Quiz_GUI.ComponentsQuiz_GUI.Components  5      +    %Quiz_GUI.Components.PlayerDetailsForm   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Quiz_GUI.Components     5      .��5	      � $��10q�6   .+�5
   
   �� 
�������$��1q�6$     �� CornerRadius$  10��68    �� Padding$ 10q�6J   
�������._�5      �  � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $��* �6$   �� 5      $
��Auto �6$   .+�5      �� $��Add New Player��6   $��20(�5      $
��Bold"�5      $��Center=�5      $��0,0,0,10q�5      �� 5      $��1��6   .+�5      ��  �� Orientation$ 
Horizontal=�6!   $	��0,5q�6:   .+�5      �� $��	Username:��6$   $��80��65   $��Center=�6@   �� 5      -   5         ��Name$ UsernameTextBox��5   "   $	��200��6;   $��Center=�6G   5      �� 5       $ 
Horizontal=�6!   $	��0,5q�6:   .+�5!      �� $��Email:��6$   $��80��62   $��Center=�6=   �� 5"      -   5        $ EmailTextBox��5"   "   $	��200��68   $��Center=�6D   5#      �� 5%      $ 
Horizontal=�6!   $	��0,5q�6:   .+�5&      �� $��
Full Name:��6$   $��80��66   $��Center=�6A   �� 5'      -   5        $ FullNameTextBox��5'   "   $	��200��6;   $��Center=�6G   5(      �� 5*      $ 
Horizontal=�6!   $	��0,5q�6:   .+�5+      �� $��Rank:��6$   $��80��61   $��Center=�6<   �� 5,      -   5        $ RankTextBox��5,   "   $	��200��67   $��Center=�6C   5-      �� 5/      $ 
Horizontal=�6!   $	��0,5q�6:   .+�50      �� $��Score:��6$   $��80��62   $��Center=�6=   �� 51      -   5        $ ScoreTextBox��51   "   $	��200��68   $��Center=�6D   52      53      �� 56      $��2��6   $ 
Horizontal=�6*   $��Right=�6C   $��0,10,0,0q�6_   .+�57      �� $
��Save��6   $��14(�6,   $��80��6:   $��40��6E   $��0,0,5,0q�6q   ��6Q   �� *SaveCommand+6q   �� 58      $��Cancel��6   $��80��6.   $��40��69   $��5,0,0,0q�6g   ��6E   �� *CancelCommand+6g   59      5:      5;      5<      5=      