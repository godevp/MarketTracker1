   M S B A M L   `   `   `  ���� L  HSteamPriceTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MarketTracker1MarketTracker1      MarketTracker1.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:MarketTracker1       � Title$  SteamPriceTracker��$
��950 ��$
��1080�����#cecdca � 	Resources    
RobotoFont   BooleanToVisibilityConverter  LowestPriceLabelStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius  MedianPriceLabelStyle  RoundedTextBoxStyle ��Name��%�  &	        &	 4     &	 9     &	 �     &	     *�.*/SteamPriceTracker;component/Fonts/#Roboto)��� �� " ��.���  � �� �� " ��.R�� .+��� ���#a3a8e6$��25��$ 8��._��� $��Center=��� " ��.���  � �� �� " ��.R�� .+��� ���#9dcdb3$��25��$ 8��._��� $��Center=��� " ��.���  � �� �� " ��.R��� #��z��
���   �$	��0.7q�$ 8��._��� $ PART_ContentHost��$��0q�.���  � RowDefinitions �� $��50 ��� $
��Auto ��� $��* �.+��  �� $��50 ��� $
��Auto ��� $��* �.+��� 	 �� Orientation$	 
Horizontal=�$��0��$
��Left=�$��5,0,0,0q�.+��� $��Bank: ��$��Center=�#��[  �� $	��100��$��25��$��5,0,0,0q�
�������
���   �$	��0.7q�$ 8��._��� -   
 ��Name$
 BankTextBox��
������ $��0q�$��Center=�#��[  �� $	 
Horizontal=�$��0��$��Right=�$��0,0,5,0q�.+��� -   $	��Add��$	��200��$��29�����#50FF76$��0,0,10,0q�#��[  ���� " ��.R���  ��Name$ border��#��z��
���   �$	��0.7q�$ 8��._��� $��Center=�$��Center=� �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  �� 
TargetName$ border�� � �� �	#B350FF76�� -   $��Update��$	��200��$��29��
�������#��[  ���� " ��.R��� $ border��#��z��
���   �$	��0.7q�$ 8��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� $ border�� � �� �	#B3A9A9A9� $��1�����#cecdca � ColumnDefinitions �� $��50 ��� $	��200 ��� $	��120 ��� $	��100 ��� $	��100 �.+��� $�� ��$��0��#��[  �� $��  Name��$��1��#��[  �� $��  Amount��$��2��#��[  �� $��  Lowest Price��$��3��#��[  �� $��  Median Price��$��4��#��[  �� $��2�����#cecdca���� *LineElements+���� .R��  �� $��50 ��� $	��200 ��� $	��120 ��� $	��100 ��� $	��100 ��� $	��160 ��� $��75 ��� $��75 ��� $��75 �.+��� $	 Vertical=�$��0��$��Center=�.+��� $��UpButton��-   $��15��$��15��$��0,0,0,-1q�#��[  ���� ���� " ��.R�F� "����@KL ��� ���� ��� р�� @KL 	
���   ��� $��
DownButton��-   $��15��$��15��$��0,-1,0,0q�#��[  ���� ���� " ��.R�F� "����@KL @KL ���� @KL р�� ��� 	
���   ��� $��1��$	��175��$
��Left=�$��Center=�$��0,0,3,0q�#��[ $��22��#��[  ���� *Name+�� $
��Left=�$��85��$��2��$��Center=�$��3,0,3,0q�#��[ $��22��#��[  ���� *Amount+ �� UpdateSourceTrigger$ PropertyChanged=��� #��[ $��Stretch=�$��3��$��Center=�$��3,0,3,0q�#��[  ���� *LowestPrice+�� #��[ $��Stretch=�$��4��$��Center=�$��3,0,0,0q�#��[  ���� *MedianPrice+�� $��5��$��Center=�$��0,0,6,0q�$��22��#��[  ���� *Link+.������ " ��.���  � �� �� " ��.R��� $ border��#��z��
���   �$	��0.7q�$ 8��._��� $ PART_ContentHost��$��0q� �� Triggers ��  �� Binding �� *
IsEditMode+ �� Value True.a���  � y�$ Visible=���  �� *
IsEditMode+	 False.a���  � y�$ 	Collapsed=�.���� -   $
��Edit��$��20��
���   �
�������$��6��$��Center=�$��0,0,3,0q�#��[  ���� ���� " ��.R��� $ border��#��z��
���   �$	��0.7q�$ 8��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� $ border�� � �� �	#B7000000�� -   $
��Open��$��20��
���   �
�������$��7��$��Center=�$��3,0,3,0q�#��[  ���� *Link+���� " ��.R��� $ border��#��z��
���   �$	��0.7q�$ 8��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� $ border�� � �� �	#B7000000�� -   $��Delete��$��20��
���  ��
�������$��8��$��Center=�$��3,0,0,0q�#��[  ���� " ��.R��� $ border��#��z��
���   �$	��0.7q�$ 8��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� $ border�� � �� �	#B7FF0000