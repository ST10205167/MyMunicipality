   M S B A M L   `   `   `  ����I  EMyMunicipality, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MyMunicipalityMyMunicipality  5   	   )    #MyMunicipality.ServiceRequestStatus   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:MyMunicipality     5   	     � Title$  Service Request Status��5   	   $	��600��6(   $	��900��65   ���	#FFF7F7F7 � 
ResizeMode$ 	CanResize=�6X   .��5	      � .+�5   
   "   MyMunicipality.NavigationBar  $	��Top=�6   � 5   
   $��20,83,20,20q�6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $��* �6     � ColumnDefinitions 5      �� 5      $	��200 �6#   �� 5      $��* �6#   .+�5      �� $��0��6   $��2��6"   ���	#FF28965A �� CornerRadius$ 8��6M    �� Padding$ 10q�6^   $��0,0,0,10q�6k   ._�5      �� $��Requested Services��6   $��24(�66   $
��Bold"�6D   
�������$��Center=�5      $��Center=�69   5      �� 5      $��1��6   $��0��6&   ���	#FFF7F7F7$��0,0,10,0q�6M   $��Stretch=�6_   $��Stretch=�6{   .+�5      �� -   5        $��Search For Request��5      $
��5,10q�66   $	��180��6D   ���	#FF28965A
�������6z   �� 5      -   5        $��	Card View��5      $
��5,10q�6-   $	��180��6;   ���	#FF28965A
�������6q   �� 5      -   5         ��Name$ ListView��5      $��	List View��6+   $
��5,10q�6?   $	��180��6M   ���	#FF28965A
�������6�   �� 5       -   5        $��Request a Service��5       $
��5,20q�65   $	��180��6C   ���	#FF28965A
�������6y   5!       � 5#      -   5          �Name$ 	MainFrame��5#      $��1��6'   $��1��64   $��0q�6D     � NavigationUIVisibility$ Hidden=�6O   5$      5%      5&      