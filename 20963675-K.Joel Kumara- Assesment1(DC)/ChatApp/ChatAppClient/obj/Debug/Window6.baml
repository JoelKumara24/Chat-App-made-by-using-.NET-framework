   M S B A M L   `   `   `  ����H  DChatAppClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ChatAppClientChatAppClient  5   	       ChatAppClient.Window6   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:ChatAppClient     5   	     � Title$  Window6��5   	   $	��450��6   $	��800��6&   .��5	      � .+�5   
   �� -   5         ��Name$ directMsgBut��5      $��Direct Message��6'   $
��Left=�6@   $	��Top=�6[   $	��120��6s   $��
591,42,0,0q�6   6�   �� 5   
   $��
Chat Room:��6   $
��Left=�6%   $	��Top=�6@   $��	10,10,0,0q�6X   �� 5   
   -   5         ��Name$ ChatRoomNameTextBlock��5      $
��Left=�63   $	��Top=�6N   $��	90,10,0,0q�6f   �� 5   
   -   5        $��Leave��5      $
��Left=�6!   $	��Top=�6<   $��75��6T   $��500,350,0,0q�6_   6t   �� 5   
   -   5         ��Name$ ChatBox��5      $
��Left=�6'   $	��Top=�6B   $	��400��6Z   $	��248��6f   $��	10,42,0,0q�6s    �� IsDocumentEnabled . . �5      /� .T�5      J� .*�6   .*�5   O   5      5      5      �� 5   
   -   5        $ userBox��5      $
��Left=�6'   $	��Top=�6B   $	��155��6Z   $	��248��6f   $��
420,42,0,0q�6s    . . �5!      /� .T�5"      J� .*�6   .*�5#   O   5$      5%      5&      �� 5(   
   -   5         ��Name$ MessageTextBox��5(      $
��Left=�6*   $	��Top=�6E   $	��300��6]   $��
10,300,0,0q�6i   �� 5)   
   -   5        $
��Send��5)      $
��Left=�6    $	��Top=�6;   $��75��6S   $��20��6^   $��320,300,0,0q�6j   6   �� 5*   
   -   5        $��Attach File��5*      $
��Left=�6'   $	��Top=�6B   $��75��6Z   $��20��6e   $��408,300,0,0q�6q   6�   �� 5+   
   -	   5        $ DMButton��5+      $y�	Collapsed=�6#   $	��DMs��6:   $
��Left=�6H   $��
26,323,0,0q�6c   $	��Top=�6w   $��73��6�   6�   �� 5,   
   -
   5        $ 	DMButton2��5,      $
��DM 2��6$   $y�	Collapsed=�64   $
��Left=�6K   $��101,323,0,0q�6f   $	��Top=�6{   $��73��6�   6�   �� 5-   
   -   5        $ 	DMButton3��5-      $
��DM 3��6$   $y�	Collapsed=�64   $
��Left=�6K   $��176,323,0,0q�6f   $	��Top=�6{   $��73��6�   6�   �� 5.   
   -   5        $ 	DMButton4��5.      $
��DM 4��6$   $y�	Collapsed=�64   $
��Left=�6K   $��251,323,0,0q�6f   $	��Top=�6{   $��73��6�   6�   �� 5/   
   -   5        $ 	DMButton5��5/      $
��DM 5��6$   $y�	Collapsed=�64   $
��Left=�6K   $��326,323,0,0q�6f   $	��Top=�6{   $��73��6�   6�   51      52      