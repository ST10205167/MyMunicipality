   M S B A M L   `   `   `  ����I  EMyMunicipality, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:MyMunicipality.UserControlsMyMunicipality.UserControls  5      =#clr-namespace:MyMunicipality.ModelsMyMunicipality.Models  5      I)clr-namespace:MyMunicipality.UserControlsMyMunicipality.UserControls  5      ;    5MyMunicipality.UserControls.ServiceRequestListControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      ;local)clr-namespace:MyMunicipality.UserControls     5      6models#clr-namespace:MyMunicipality.Models     5      8uc)clr-namespace:MyMunicipality.UserControls     5      .��5      � .+�5   
   �� 
�������  �� CornerRadius$  10��6$   $��0,0,0,20q�66    �� Padding$ 10q�6H    J� Effect 5	      3  -System.Windows.Media.Effects.DropShadowEffect  5
         Color$ Black��6#      
BlurRadius$ 10Q�61      ShadowDepth$ 5Q�6A      Opacity$	 0.5Q�6Q   ._�5      �� -   5         ��Name$ ServiceRequestsListView��5      $��Stretch=�68    �� View 5      �� 5      .P�5      �� $��ID��6)   	 �� Width$	 50��6Y   
 �� DisplayMemberBinding
 65   �� *Id+6Y   �� 5      $��Location��6)   $		 100��6e   
 6;   �� *
Location+6e   �� 5      $��Category��6)   $		 100��6e   
 6;   �� *
Category+6e   �� 5      $��Description��6)   $		 200��6k   
 6>   �� *Description+6k   �� 5      $��
Attachment��6)   $		 200��6=    �� CellTemplate 5      �� 5   "   .R�5   &   ��  �� Orientation$ 
Horizontal=�61   .+�5   *   �� $��50��6U   $��50��6`   $��5q�6l   ��60   �� *AttachmentPreview+6l   �� 5   *   $��Center=�6T   $��5q�6o   ��64   �� *AttachmentName+6o   5   '   5   #   5      5      5      5       5!      5"      