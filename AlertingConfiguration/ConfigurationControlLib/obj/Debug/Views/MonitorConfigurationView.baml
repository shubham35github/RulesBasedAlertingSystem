   M S B A M L   `   `   `  ����R  NConfigurationControlLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:ConfigurationControlLib.ViewsConfigurationControlLib.Views  5      W0clr-namespace:ConfigurationControlLib.ViewModels"ConfigurationControlLib.ViewModels  5      <    6ConfigurationControlLib.Views.MonitorConfigurationView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:ConfigurationControlLib.Views     5      ?vm0clr-namespace:ConfigurationControlLib.ViewModels     5        � DataContext  5
      F  @ConfigurationControlLib.ViewModels.MonitorConfigurationViewModel  5   
   6-   .��5      ]� .+�5   
   �� $	��Top=�6   $��3q�6&   
�������
����ح�._�5      �  � RowDefinitions 5      �� 5      $��40 �6$   62   +�5      �� 5      $��0��6    $��5q�6-   $��20(�68   $!��Configured Monitor for ICUs��6R   5      5      �� 5   
   $	��Top=�6   $	��150��6&   
�������._�5      �  � ColumnDefinitions 5      �� 5      $	��200 �6'   65   �� 5      $	��230 �6'   65   �� 5      $	��170 �6'   65   �� 5      $	��200 �6'   65    5       �� 5!      $��60 �6$   62   �� 5"      $��60 �6$   62   .+�5$      �� $
��Left=�6   $��0,27,0,0q�67   $
��Wrap=�6I   $
��Name��6]   $��18(�6i   
�������$
��Bold"�6�   $	��Top=�6�   $��34��6�   $	��200��6�   $��0��6�   $��0��6�   �� 5%      $
��Left=�6   $��5,27,0,0q�67   $
��Wrap=�6I   $��Number of Monitors��6]   $��18(�6w   
�������$
��Bold"�6�   $	��Top=�6�   $��34��6�   $	��225��6�   $��1��6�   $��0��6  �� 5&      $
��Left=�6   $��5,27,0,0q�67   $
��Wrap=�6I   $��Remove��6]   $��18(�6k   
�������$
��Bold"�6�   $	��Top=�6�   $��34��6�   $	��165��6�   $��2��6�   $��0��6�   �� 5'      $
��Left=�6   $��5,27,0,0q�67   $
��Wrap=�6I   $��Import Monitors��6]   $��18(�6t   
�������$
��Bold"�6�   $	��Top=�6�   $��34��6�   $	��195��6�   $��3��6�   $��0��6  �� 5(      $
��Left=�6   $��	27,23,0,0q�66   $��1��6I   $	��Top=�6V   $	��120��6n   $��0��6z    �� DisplayMemberPath$ Id��5)   B   ��6   ��  �� Path$ Monitors� �� SelectedItem 6Y   �� $ MonitorSelected��� 5+      $��1��6   $
��Left=�6*   $��23��6E   $��	10,22,0,0q�6Q   $��1��6d    �� TextWrapping$
 Wrap=�6q   $	��Top=�6�   $	��120��6�   ��5,      �� $ CountMonitors� �� Mode$ OneWay=��� 5-      -   5         ��Name$ RemoveButton��5.      $��	- Monitor��5-      $��2��6-   $
��Left=�6=   $��	10,25,0,0q�6X   $��1��6k   $	��Top=�6x   $��75��6�   ��5/      �� *RemoveMonitorCommand+{�50      �� $ IsMonitorSelected��� 52      $��3��6   $��1��6-   $��	10,25,0,0q�6;   $��75��6N   $
��Left=�6Y   	 � 	Resources	 53      
 �� 
TargetType �� Property �� Value��%_   '��       �� 54      "
 ��6    .�55      ��  � ��$ 2q�67   -   5        57      58      .+�59      �� -   5        $��btnShowPopup��59   1   $��	+ Monitor��6   61   5:      5;      5<      �� 5=   
   $��Bottom=�6   $	��253��6)   ._�5>      �� .+�5?      � -   5        $��myPopup��5?      $��Center=�5@       � 	StaysOpen . $	��800��68   .��5A      �� $��Bottom=�6   
�������$	��238��6H   ._�5B      �  5C      �� 5D   "   $	��150 �63   6A   �� 5E   "   $	��250 �63   6A   �� 5F   "   $	��250 �63   6A    5H      �� 5I   "   $	��100 �60   6?   +�5K      �� 5L   "   $��0��6,   $��0��69   $��16,47,10,19q�6I   $��18(�6^   $��Monitor Model:��6x   �� 5M   "   -   5         ��Name$ MModelTextBox��5N   !   $��0��5M   *   $��1��67   $��	0,42,0,19q�6G   
����ح�
�������$��3q�6�   ��5O   !   �� $ Model�$ OneWayToSource=�.��6R   5P   #   �� 5Q   "   -   5        $ 	AddButton��5R   !   $��78,42,26,19q�5Q   *   $��20(�6?   $��Add Monitor��6Y   $��0��6o   $��2��6|   $��2��6�   ��5S   !   �� *AddNewMonitorCommand+6J   5U      5V      5W      5X      5Y      5Z      5[      