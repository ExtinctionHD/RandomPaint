   M S B A M L   `   `   `  ����@  <Paint, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PaintPaint  5   	       Paint.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Paint     5   	   -   5          � Title$  Paint��5   	   $
��1280��5	   	   $	��720��5
   	   .��5      � -   5        $��grMain��5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   � -   5         �Name$ grShapeButtons��5      $
��auto��5      $
��Left=�5      $��50, 10q�5       � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5      $
��Auto �6#   �� 5       $
��Auto �6#   �� 5!      $
��Auto �6#   �� 5"      $
��Auto �6#   �� 5#      $
��Auto �6#   .+�5&      	� -   5         	�Name$ 	rectangle��5&      $��0��5'      $��	Rectangle��5(       d� 	IsChecked$
 TrueY�5)      5*      	� 5+      -   5        $ ellipse��5+      $��1��5,      $��Ellipse��5-      5.      	� 5/      -   5        $ 	triangleR��5/      $��2��50      $��Right Triangle��51      52      	� 53      -   5        $ 	triangleI��53      $��3��54      $��Isosceles Triangle��55      56      	� 57      -   5        $ pentagon��57      $��4��58      $��Pentagon��59      5:      	� 5;      -	   5        $ hexagon��5;      $��5��5<      $��Hexagon��5=      5>      	� 5?      -
   5        $
 star��5?      $��6��5@      $
��Star��5A      5B      	� 5C      -   5        $ randomShape��5C      $��7��5D      $��Random��5E      5F      5G      � 5I   
   -   5        $ grSystemButtons��5I      $
��auto��5J      $��Right=�5K      $��50, 10q�5L       5M      �� 5N      $
��Auto �6#   �� 5O      $
��Auto �6#   .+�5R      �� -   5         ��Name$ btnNewColors��5R      $��
New Colors��5S      $��Center=�5T      5U      �� 5W      -   5        $ btnSave��5W      $��1��5X      $��Save Picture��5Y      $��Center=�5Z      5[      5]      �� 5`   
   -   5         ��Name$ canvas��5`      $��1��5a      ���	#FF13FFAF}�. 5k      5l      5m      