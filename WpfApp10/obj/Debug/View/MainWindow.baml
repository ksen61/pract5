   M S B A M L   `   `   `  ����C  ?WpfApp10, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WpfApp10.ViewModelWpfApp10.ViewModel  5   	       WpfApp10.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6	viewmodel clr-namespace:WpfApp10.ViewModel     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5   	   
�������  � WindowStartupLocation$  CenterScreen=�5   	    � Title$> 8Калькулятор таблиц истинности��5   	   $	��600��6/   $	��800��6<   .��5      �� $
��Auto=�6   .��5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      �� $��25��5      $��25��5      $��?��5      $��16(�5      $
��20,5q�5      
�������$
��Left=�5        � ToolTip$ Подсказка��5!      $��0q�5"      ��5#      �� *OpenHelpWindowCommand+�� 5&      $��1��5'      $	��170��5(      $��
20,5,20,20q�5)       �� Padding$ 65q�5*       �� TextAlignment$ Center=�5+      
�������$��14(�5-      ��5.      ��  �� ElementName$ InputTextBox�� �� Path$
 Text� �� StringFormat$k eСоставить таблицу истинности логического выражения:
{0}���� 51      -   5        	 ��Name$	 InputTextBox��52      $��2��53      $��35��54      $��20,10q�55      
 �� TextAlignment$
 Center=�56      $��Center=�57      $��14(�58      ��59      �� *Expression.Text+ �� Mode$ TwoWay=�� 5<      $��3��5=      $��35��5>      $��20,10q�5?       � Orientation$ 
Horizontal=�5@      $��Center=�5A      .+�5D      �� $��35��5E      $��35��5F      $��¬��5G      $��20(�5H      $	��5,0q�5I      $ Не (отрицание)��5J      
�������$��¬��5M      ��5L      �� *AddSymbolCommand+5M      �� 5O      $��35��5P      $��35��5Q      $	��∧��5R      $��18(�5S      $	��5,0q�5T      $2 ,И (логическое умножение)��5U      
�������$	��∧��5X      ��5W      �� *AddSymbolCommand+5X      �� 5Z      $��35��5[      $��35��5\      $	��∨��5]      $��20(�5^      $	��5,0q�5_      $4 .Или (логическое сложение)��5`      
�������$	��∨��5c      ��5b      �� *AddSymbolCommand+5c      �� 5e      $��35��5f      $��35��5g      $	��⊕��5h      $��20(�5i      $	��5,0q�5j      $# Исключающее или��5k      
�������$	��⊕��5n      ��5m      �� *AddSymbolCommand+5n      �� 5p      $��35��5q      $��35��5r      $	��↑��5s      $��20(�5t      $	��5,0q�5u      $ Штрих Шеффера��5v      
�������$	��↑��5y      ��5x      �� *AddSymbolCommand+5y      �� 5{      $��35��5|      $��35��5}      $	��↓��5~      $��20(�5      $	��5,0q�5�      $ Стрелка Пирса��5�      
�������$	��↓��5�      ��5�      �� *AddSymbolCommand+5�      �� 5�      $��35��5�      $��35��5�      $	��↔��5�      $��20(�5�      $	��5,0q�5�      $$ Эквивалентность��5�      
�������$	��↔��5�      ��5�      �� *AddSymbolCommand+5�      �� 5�      $��35��5�      $��35��5�      $	��→��5�      $��20(�5�      $	��5,0q�5�      $ Импликация��5�      
�������$	��→��5�      ��5�      �� *AddSymbolCommand+5�      5�      �� 5�      $��4��5�      $��35��5�      $��20,10q�5�      $��Результат��5�      $��14(�5�      
�������$l fДвойное нажатие, чтобы вынести таблицу в отдельное окно��5�      ��5�      �� *GetAnswerCommand+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5�      +  %Microsoft.Xaml.Behaviors.EventTrigger  5�         	EventName$ MouseDoubleClick��6%   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5�      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 60   �� *TakeAwayTruthTableCommand+5�      5�      &   System.Windows.Controls.DataGrid  5�      $��5��5�      $��Stretch=�5�      $��Stretch=�5�      $��20,10q�5�      $��14(�5�      $��Center=�5�         CanUserAddRows .     
IsReadOnly . ��5�      �� *Expression.Table+$ OneWay=�y�5�      �� *IsDataGridVisible+5�      5�      5�      