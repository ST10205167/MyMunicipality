   M S B A M L   `   `   `  ����I  EMyMunicipality, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MyMunicipalityMyMunicipality  5   	   (    "MyMunicipality.EventsAnnouncements   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:MyMunicipality     5   	     � Title$  EventsAnnouncements��5   	   $	��600��6%   $	��900��62   ���	#FFF7F7F7 � 
ResizeMode$ 	CanResize=�6U   .��5	      � .+�5   
   "   MyMunicipality.NavigationBar  $	��Top=�6   �� 5   
   ���	#FF28965A �� CornerRadius$ 8��6(    �� Padding$ 10q�69   $��0,74,0,0q�6F   $��64��6X   $	��Top=�6d   ._�5      �� $$��LOCAL EVENTS AND ANNOUNCEMENTS��6   $��28(�6>   $
��Bold"�6L   
�������$��Center=�5      $��Center=�6-   5      �� 5   
    �� Orientation$ 
Horizontal=�6   $��Center=�6.   $	��Top=�6K   $��	0,166,0,0q�6c   .+�5      �� -   5         ��Name$ searchTextBox��5      $	��300��6-   $��30��69   $��16(�6E   $��0,0,10,0q�6S   ���	#FFF0F0F06e   �� 5      -   5         ��Name$ categoryComboBox��5      $	��200��61   $��30��6=   $��16(�6I   ���	#FFF0F0F0���	#FF666666$��0,0,10,0q�6�   .@�5      �� $��
Sanitation��6   �� 5      $��Roads��6   �� 5      $��	Utilities��6   �� 5      $��Other��6   5      �� 5      -   5         ��Name$ SearchButton��5      $��Search��6+   $	��100��6<   $��30��6H   ���	#FF28965A
�������6~   5      � 5   
   $��50,261,50,24q�6    � ColumnDefinitions 5      �� 5       $��3* �6#   �� 5!      .+�5#      �� $��0��6   $
��Auto=�6+   $��	0,0,20,37q�6N   .��5$      �� -   5        	 ��Name$	 eventsPanel��5$      5%      5&      �� 5(      $��1��6   $��10,0,0,0q�6)   .+�5)      �� $��Announcements��6   $��24(�60   $
��Bold"�6>   ���	#FF333333$��0,0,0,10q�6g   �� 5*      -   5        $	 announcementsPanel��5*      5+      5,      5.      �� 50   
   -   5        $ DisplayRecommendedEvents��50      $��545,0,211,20q�64   $��Bottom=�6J   ���	#FF28965A
�������$	��100��6�   $��30��6�   $��Recommandations��6�   52      �� 53   
   -   5        $ AddEvent��53      $��	Add Event��6#   $��411,0,345,20q�67   $	��100��6M   $��30��6Y   ���	#FF28965A
�������$��Bottom=�6�   �� 54   
   -   5        $ 	AllEvents��54      $��
All Events��6$   $��30��69   $��289,0,511,20q�6E   $��Bottom=�6[   $	��100��6v   ���	#FF28965A
�������6�   55      56      