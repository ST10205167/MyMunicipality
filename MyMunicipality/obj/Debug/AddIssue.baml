   M S B A M L   `   `   `  ����I  EMyMunicipality, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MyMunicipalityMyMunicipality  5   	       MyMunicipality.AddIssue   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:MyMunicipality     5   	     � Title$  Report an Issue��5   	   ���	#FFF7F7F7$	��900��68   $	��600��6D   .��5
      � ���#F4F4F4.+�5   
   "   MyMunicipality.NavigationBar  $	��Top=�6   �� 5   
   ���	#FF28965A �� CornerRadius$ 8��6(    �� Padding$ 10q�69   $��
20,70,20,0q�6F   $��60��6Z   $	��Top=�6f   ._�5      �� $��REPORT AN ISSUE��6   $��28(�6/   $
��Bold"�6=   
�������$��Center=�5      $��Center=�65   5      �� 5   
   $
��Auto=�6   $��20,140,20,20q�6:   .��5      �  � ColumnDefinitions 5      �� 5      $��1* �6'   �� 5      $��1* �6'    � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $��* �6$   �� 5      $
��Auto �6$   .+�5"      �� 
�������$ 10��6,   $ 20q�6>   ���#D3D3D3$��1q�6a   $��2��6u   ._�5#      �� .+�5%      �� -   5         ��Name$ ErrorMessage��5%   $   
���  ��$y�	Collapsed=�6K   $��14(�6b   $��0,0,0,10q�6p   $ ��Please fill in all fields.��6�   $��Center=�6�   �� 5(      $
��Auto��6%   $
��0,10q�62   .+�5)      �� $��	Location:��6(   $��16(�69   $��SemiBold"�6G   ���#5556]   �� 5*      -   5         ��Name$ LocationTextBox��5*   &   $	��0,5q�6?   $��8q�6L   ���#D3D3D3$��1q�6n   5+      �� 5.      $
��Auto��6%   $
��0,10q�62   .+�5/      �� $��	Category:��6(   $��16(�69   $��SemiBold"�6G   ���#5556]   �� 50      -   5         ��Name$ CategoryComboBox��50   '   $	��0,5q�6A   $��8q�6N   ���#D3D3D3$��1q�6p   .@�51   "   �� $��
Sanitation��6/   �� 52   "   $��Roads��6/   �� 53   "   $��	Utilities��6/   �� 54   "   $��Other��6/   55      56      �� 59      $
��Auto��6%   $
��0,10q�62   .+�5:      �� $��Description:��6(   $��16(�6<   $��SemiBold"�6J   ���#5556`   �� 5;      -   5        $ DescriptionTextBox��5;   &   $	��0,5q�6B   $��8q�6O   ���#D3D3D3$��1q�6q    �� TextWrapping$
 Wrap=�6�   	 �� AcceptsReturn	 . $��55��6�   5<      �� 5?      -   5        
 ��Name$
 AttachButton��5?   !   $��Attach��67   $��40��6H   $
��0,10q�6T   ���#4CAF50
�������$��SemiBold"�6�   6�   �� 5B       �� Orientation$ 
Horizontal=�6%   $��Center=�6>   .+�5C      �� -   5         ��Name$ AttachmentPreview��5C   $   $	��100��6?   $	��100��6K   $��10q�6X   $y�	Collapsed=�6d   �� 5D      -   5        $ AttachmentName��5D   (   $��Center=�6@   $
��10,0q�6[   5E      5F      5G      �� 5J      $ 
Horizontal=�6   $��Center=�66   $��4��6S   $��2��6`   $��0,20,0,0q�6t   .+�5K      �� -   5        $��	Add Issue��5K      $	��100��6N   $��40��6Z   $
��10,0q�6f   ���#4CAF50
�������$��SemiBold"�6�   �� 5L      -	   5        $
��Done��5L      $	��100��6E   $��40��6Q   ���#F44336
�������$��SemiBold"�6�   5M      5N      5O      5P      5Q      