   M S B A M L   `   `   `  ����L  HSeverstalTestTask, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:SeverstalTestTaskSeverstalTestTask  5   	   "    SeverstalTestTask.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:SeverstalTestTask     5   	   -   5          � Title$  Заметки��5   	   $	��460��6   $	��800��6&    � 
ResizeMode$ CanMinimize=�62   .��5	      � ���	#FFE4E0E0 � RowDefinitions 5
   
   �� 5      $	��41* �6   �� 5      $
��393* �6    � ColumnDefinitions 5   
   �� 5      $��6* �6   �� 5      $	��19* �6   .+�5   
   �� 
���   �$��1q�6%   $��
10,4,10,26q�69   $��1��6M   $��0��6Z   ._�5      �� -   5         ��Name$ 	ListNotes��5      $��Center=�6)   6M   5      �� 5   
   
���   �$��1q�6%   $��10,10,106,1q�69   $��0��6N   $��0��6[   ._�5      �� -   5         ��Name$ CreateButton��5      $��Создать��6+   $
��Left=�6=   $��74��6X   6c   5      �� 5   
   
���   �$��1q�6%   $��106,10,10,1q�69   $��0��6N   $��0��6[   ._�5      �� -   5        $ DeleteButton��5      $��Удалить��6+   6=   5      �� 5   
   
���   �$��1q�6%   $��1��69   $��	0,4,10,26q�6I   $��1��6\   ._�5      �� -   5         ��Name$ NoteText��5      $y�Hidden=�6,   . �5      /� .T�5      J� -   5         J�Name$ 	MainParag��5       .*�63   .*�5      �� $� ��6   5       5!      5"      5#      �� 5$   
   -   5        $ 
SaveButton��5$      $��30��6%   $��30��60   $��Bottom=�6<   $
��Left=�6W   $�� ��6r   $��1��6�   ��5%      �� 5&       �� ImageSource$ /Pictures/save.png��6   	 j� Stretch$	 Uniform=�6>   
 j� TileMode$

 None=�6P   5(      �� 5)   
   $��Right=�6   $��Bottom=�60    �� Padding$ 5q�6K   $��1��6W   $
��Wrap=�6d    �� TextAlignment$ Center=�6x   $	��171��6�   $��1��6�   �� 6�   $�Created by NyaEvil | ��6�   �� 6�   -   5         ��Name$ gitlink��5)   �   $ ��https://github.com/NyaEvil?�6�   .�6A  �� $�GitHub��6E  6V  6b  5+      5,      