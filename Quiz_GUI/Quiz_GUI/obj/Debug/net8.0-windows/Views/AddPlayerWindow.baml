   M S B A M L   `   `   `  ����C  ?Quiz_GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Quiz_GUI.HelpersQuiz_GUI.Helpers  5   	   $    Quiz_GUI.Views.AddPlayerWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   2helpersclr-namespace:Quiz_GUI.Helpers     5   	     � Title$  
Add Player��5   	   $	��600��6   $	��400��6)    � WindowStartupLocation$ CenterScreen=�65    � 	Resources 5         RoundedButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%  &	        �� 5	   
   " ��6+   .�5
      ��  � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5   !   #��z��5   !   $ 8��5   !   ._�5      �� $��Center=�6/   $��Center=�5   /   #��z��5   /   5      5      5      5      5      .��5      � .+�5   
   �� ���	#AAFFFFFF$ 10��6(    �� Padding$ 20q�6:   $��10q�6G   ._�5      �� .+�5      �� $��Add New Player��6   $��20(�5       $
��Bold"�6   ���#333333$��Center=�5!   %   $��0,0,0,20q�6B   �� 5$      -   5        	 ��Name$	 UsernameTextBox��5$      $   Quiz_GUI.Helpers.TextBoxHelper
   Placeholder$
 Username��5%      $	��0,5q�5&      $��14(�6   $��8q�6)   �� 5'      -   5         ��Name$ UsernameError��5'      
���  ��$��12(�68   $��0,2,0,10q�6F   �� 5*      -   5        $	 EmailTextBox��5*      $
 Email��5+      $	��0,5q�5,      $��14(�6   $��8q�6)   �� 5-      -   5        $ 
EmailError��5-      
���  ��$��12(�65   $��0,2,0,10q�6C   �� 50      -   5        $	 FullNameTextBox��50      $
 	Full Name��51      $	��0,5q�52      $��14(�6   $��8q�6)   �� 53      -   5        $ FullNameError��53      
���  ��$��12(�68   $��0,2,0,10q�6F   �� 56      -   5        $	 RankTextBox��56      $

 Rank��57      $	��0,5q�58      $��14(�6   $��8q�6)   �� 59      -   5        $ 	RankError��59      
���  ��$��12(�64   $��0,2,0,10q�6B   �� 5<      -	   5        $	 ScoreTextBox��5<      $
 Score��5=      $	��0,5q�5>      $��14(�6   $��8q�6)   �� 5?      -
   5        $ 
ScoreError��5?      
���  ��$��12(�65   $��0,2,0,10q�6C   �� 5B      -   5        $	��Add��5B      ���#4CAF50
�������$
��Bold"�5F      $��0,20,0,0q�5G      $��10q�5H      $��Stretch=�5I      #��[  5J      5K      5M      5N      5O      