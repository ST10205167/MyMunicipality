   M S B A M L   `   `   `  ����I  EMyMunicipality, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MyMunicipalityMyMunicipality  5   	   #    MyMunicipality.ServiceRequest   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:MyMunicipality     5   	     � Title$  Submit Service Request��5   	   ���	#FFF7F7F7$	��900��6?   $	��600��6K   .��5
      � ���#F4F4F4.+�5   
   "   MyMunicipality.NavigationBar  $	��Top=�6   �� 5   
   ���	#FF28965A �� CornerRadius$ 8��6(    �� Padding$ 10q�69   $��
20,70,20,0q�6F   $��60��6Z   $	��Top=�6f   ._�5      �� $��SUBMIT SERVICE REQUEST��6   $��28(�66   $
��Bold"�6D   
�������$��Center=�5      $��Center=�65   5      �� 5   
   $
��Auto=�6   $��20,140,20,20q�6:   .��5      �  � ColumnDefinitions 5      �� 5      $��1* �6'   �� 5      $��1* �6'    � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $��* �6$   �� 5      $
��Auto �6$   .+�5       �� 
�������$ 10��6,   $ 20q�6>   ���#D3D3D3$��1q�6a   $��2��6u   ._�5!      �� .+�5"      �� -   5         ��Name$ ErrorMessage��5"   $   
���  ��$y�	Collapsed=�6K   $��14(�6b   $��0,0,0,10q�6p   $ ��Please fill in all fields.��6�   $��Center=�6�   �� 5$      $
��Auto��6%   $
��0,10q�62   .+�5%      �� $��	Location:��6(   $��16(�69   $��SemiBold"�6G   ���#5556]   �� 5&      -   5         ��Name$ txtLocation��5&   &   $	��0,5q�6;   $��8q�6H   ���#D3D3D3$��1q�6j   5'      �� 5)      $
��Auto��6%   $
��0,10q�62   .+�5*      �� $��	Category:��6(   $��16(�69   $��SemiBold"�6G   ���#5556]   �� 5+      -   5         ��Name$ txtCategory��5+   '   $	��0,5q�6<   $��8q�6I   ���#D3D3D3$��1q�6k   .@�5,   "   �� $��Water��6/   �� 5-   "   $��Electricity��6/   �� 5.   "   $��Roads��6/   �� 5/   "   $��
Sanitation��6/   �� 50   "   $��Parks��6/   �� 51   "   $��Lighting��6/   �� 52   "   $��Other��6/   53      54      �� 56      $
��Auto��6%   $
��0,10q�62   .+�57      �� $��Description:��6(   $��16(�6<   $��SemiBold"�6J   ���#5556`   �� 58      -   5        $ txtDescription��58   &   $	��0,5q�6>   $��8q�6K   ���#D3D3D3$��1q�6m    �� TextWrapping$
 Wrap=�6�   	 �� AcceptsReturn	 . $��55��6�   59      �� 5;      -   5        
 ��Name$
 AttachButton��5;   !   $��Attach File��67   $��40��6M   $
��0,10q�6Y   ���#4CAF50
�������$��SemiBold"�6�   6�   �� 5=       �� Orientation$ 
Horizontal=�6%   $��Center=�6>   .+�5>      �� -   5         ��Name$ AttachmentPreview��5>   $   $	��100��6?   $	��100��6K   $��10q�6X   $y�	Collapsed=�6d   �� 5?      -   5        $ AttachmentName��5?   (   $��Center=�6@   $
��10,0q�6[   5@      5A      5B      �� 5D      $ 
Horizontal=�6   $��Center=�66   $��4��6S   $��2��6`   $��0,20,0,0q�6t   .+�5E      �� -   5        $��Submit Request��5E      $	��120��6R   $��40��6^   $
��10,0q�6j   ���#4CAF50
�������$��SemiBold"�6�   �� 5F      -	   5        $
��Done��5F      $	��100��6?   $��40��6K   ���#F44336
�������$��SemiBold"�6   5G      5H      5I      5J      5K      