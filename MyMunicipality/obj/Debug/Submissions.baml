   M S B A M L   `   `   `  ����I  EMyMunicipality, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MyMunicipalityMyMunicipality  5   	        MyMunicipality.Submissions   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:MyMunicipality     5   	     � Title$  Submitted Issues��5   	   $	��600��6"   $	��900��6/   ���	#FFF7F7F7 � 
ResizeMode$ 	CanResize=�6R   .��5	      � .+�5   
   "   MyMunicipality.NavigationBar  $	��Top=�6   � 5   
   $��20,170,20,10q�6    � ColumnDefinitions 5      �� 5      $	��145 �6#   �� 5       � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $��* �6    �� 5      $
��Auto �6    .+�5      �� ���	#FF28965A �� CornerRadius$ 8��6,    �� Padding$ 10q�6=   $��
0,-103,0,0q�6J   $��64��6^   $	��Top=�6j   $��2��6�   ._�5      �� $��REPORTED ISSUES��6   $��28(�63   $
��Bold"�6A   
�������$��Center=�5      $��Center=�69   5      �� 5      
�������$ 10��6(   $��0,0,0,20q�6:   $ 10q�6L   $��2��6Y   $��1��6m    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ Black��6'      
BlurRadius$ 10Q�65   	   ShadowDepth$	 5Q�6E   
   Opacity$	
 0.5Q�6U   ._�5!      �� -   5         ��Name$ submissionsListView��5!      $��Stretch=�68    �� View 5"      �� 5#      .P�5$      �� $��ID��6-    �� Width$ 50��6^    �� DisplayMemberBinding 69   �� *Key+6^   �� 5%      $��Location��6-   $	 100��6i    6?   �� *
Location+6i   �� 5&      $��Category��6-   $	 100��6i    6?   �� *
Category+6i   �� 5'      $��Description��6-   $	 200��6o    6B   �� *Description+6o   �� 5(      $��
Attachment��6-   $	 200��6A    �� CellTemplate 5)   "   �� 5*   &   .R�5+   *   ��  �� Orientation$ 
Horizontal=�65   .+�5,   .   �� $��50��6Y   $��50��6d   $��5q�6p   ��64   �� *AttachmentPreview+6p   �� 5-   .   $��Center=�6X   $��5q�6s   ��68   �� *AttachmentName+6s   5.   +   5/   '   51      �� 52      $��Actions��6-   $	 120��6>    53   "   �� 54   &   .R�55   *   �� $ 
Horizontal=�65   $��Center=�6N   .+�56   .   �� -   5        $
��Edit��56   5   $��50��6D   $��5q�6O   ���#FFA726
�������
 � Tag 57   a   �� *Key+�� 58   .   -   5        $��Delete��58   5   $��50��6F   $��5q�6Q   ���#E53935
������� 59   c   �� *Key+5:   +   5;   '   5=      5>      5@      5A      �� 5D      -   5         ��Name$ AddIssue��5D      $��Add New Issue��6'   $��2��6?   $��2��6L   $��Center=�5E      $��Center=�62   $	��150��5F      $��45��6!   ���	#FF28965A
�������$
��Bold"�6W   5G      5H      5I      5J      