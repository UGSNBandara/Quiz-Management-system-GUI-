   M S B A M L   `   `   `  ����C  ?Quiz_GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Quiz_GUI.HelpersQuiz_GUI.Helpers  5   	       Quiz_GUI.Views.Login   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   2helpersclr-namespace:Quiz_GUI.Helpers     5   	     � Title$  Login��5   	   $	��600��5   	   $	��500��5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5	   	    � 	Resources 5         RoundedButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%  &	        �� 5   
   " ��6+   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5   !   #��z��5   !   $ 8��5   !   ._�5      �� $��Center=�6/   $��Center=�5   /   #��z��5   /   5      5      5      5      5      .��5      � ��5!   
   �� 5"      	 �� ImageSource$	 	back1.jpg��6   
 j� Stretch$
 UniformToFill=�61   .+�5&   
   �� ���	#AAFFFFFF$ 10��6(    �� Padding$ 20q�6:   $	��300��6G   $��Center=�6S   $��Center=�6n   ._�5'      �� .+�5)      �� $��Login��6   $��24(�5*      $
��Bold"�5+      ���#333333$��Center=�5-      $��0,0,0,20q�5.      �� 51      -   5        $��UsernameTextBox��51      $   Quiz_GUI.Helpers.TextBoxHelper   Placeholder$ Username��52      $
��0,10q�53      $��14(�54      $��8q�55      G� 58      -   5        $��PasswordBox��58      $ Password��59      $
��0,10q�5:      $��14(�5;      $��8q�5<      �� 5?      -   5        $��LoginButton��5?      $��Login��5@      ���#4CAF50
�������$
��Bold"�5D      $��0,20,0,0q�5E      $��10q�5F      #��[  5G      �� 5J      -   5        $��RegisterButton��5J      $��Register��5K      ���#2196F3
�������$
��Bold"�5O      $��0,10,0,0q�5P      $��10q�5Q      #��[  5R      5S      5T      5U      5V      