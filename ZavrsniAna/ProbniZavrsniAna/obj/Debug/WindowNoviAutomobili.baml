   M S B A M L   `   `   `  ����K  GProbniZavrsniAna, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ProbniZavrsniAnaProbniZavrsniAna  5   	   +    %ProbniZavrsniAna.WindowNoviAutomobili   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:ProbniZavrsniAna     5   	     � Title$  WindowNoviAutomobili��5   	   $	��500��6&   $	��600��63   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ datagridAutomobili��5
      $
��Left=�6/   $	��137��6J   $��
34,118,0,0q�6W   $	��Top=�6k   $	��462��6�    �� AlternationCount$ 2��6�      AlternatingRowBackground
 ��  �   CanUserAddRows .     CanUserSortColumns .     AutoGenerateColumns .     SelectionMode$ Single=�5   /      SelectionUnit$ FullRow=�6F   	   
IsReadOnly	 . 
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 40 61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   ��  �� Path$ AutomobilId� �� Mode$ OneWay=�  5      $ Brend��6%   $ 80 64    6?   �� $ Brend�$ OneWay=�  5      $ Model��6%   $ 80 64    6?   �� $ Model�$ OneWay=�  5      $ Godina proizvodnje��6%   $	 130 6A    6M   �� $ Godina_proizvodnje�$ OneWay=�  5      $ Cena po danu��6%   $	 130 6;    6G   �� $ Cena_po_danu�$ OneWay=�5      �� 5   
   -   5         ��Name$ buttonDodaj��5      $��Dodaj��6&   $
��Left=�66   $��
34,287,0,0q�6Q   $	��Top=�6e   $��75��6}   6�   �� 5   
   -   5        $ buttonPromeni��5      $��Promeni��6(   $
��Left=�6:   $��166,287,0,0q�6U   $	��Top=�6j   $��75��6�   6�   �� 5   
   -   5        $ buttonIzbrisi��5      $��Izbrisi��6(   $
��Left=�6:   $��301,287,0,0q�6U   $	��Top=�6j   $��75��6�   6�   �� 5   
   -   5         ��Name$ textboxPretraga��5      $
��Left=�6+   $��23��6F   $��	34,75,0,0q�6R    �� TextWrapping$
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��120��6�   6�   �� 5   
   $��Unesite brend ��6   $
��Left=�6)   $��	34,35,0,0q�6D   $	��Top=�6W   $��26��6o   $	��120��6{   5      5      