   M S B A M L   `   `   `  ????G  CNamingSetter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:NamingSetter.CoreNamingSetter.Core  5      +clr-namespace:NamingSetterNamingSetter  5      ?$clr-namespace:NamingSetter.MVVM.ViewNamingSetter.MVVM.View  5      I)clr-namespace:NamingSetter.MVVM.ViewModelNamingSetter.MVVM.ViewModel  5          NamingSetter.MainWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      0coreclr-namespace:NamingSetter.Core     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      &localclr-namespace:NamingSetter  5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5
      /view$clr-namespace:NamingSetter.MVVM.View  5      9	viewModel)clr-namespace:NamingSetter.MVVM.ViewModel  5        ? Title$  
MainWindow??5      $	??800??5      $	??700??5       ? AllowsTransparency$
 True??5      
??????  ? 
ResizeMode$ NoResize=?5       ? WindowStyle$
 None=?5       ? DataContext 5      /   )NamingSetter.MVVM.ViewModel.MainViewModel  5   
   .??5      ?? 
??????? ?? CornerRadius$ 35??6    ._?5   
   ?  ? RowDefinitions 5      ?? 5      $??50 ?6    ?? 5      .+?5      0   *NamingSetter.MVVM.View.MinimalTitleBarView     Title$ Naming Setter??5      $??0??5       $??	0,15,20,0q?5!      ? 5"      $??1??5#      $??10q?5$       ? Orientation$ 
Horizontal=?5%      .+?5&      +   %NamingSetter.MVVM.View.GenresListView  $
??Left=?6&   $	??Top=?6A   /   )NamingSetter.MVVM.View.CharactersListView  5'      $
??10,0q?5(      $??Right=?5)      $	??Top=?5*      )   #NamingSetter.MVVM.View.NameListView  5+      $	??280??5,      $??Right=?5-      $	??Top=?5.      ?? 5/      $??Center=?6   $??Center=?6:   .+?50      +   %NamingSetter.MVVM.View.AuthorListView  $	??270??6*   $??0,10,0,0q?67   ?? 51      $??0,10,0,0q?52      $??Center=?53      $??Center=?54      	 ?? Orientation$	 
Horizontal=?55      .+?56      ?? $??20(?6$   $??Pages: ??62   +   %NamingSetter.MVVM.View.PagesInputView  57      $??0,0,10,0q?6.   $??Center=?6@   ?? 58      $??80??59      $??35??5:      
???????$
??Copy??5=      $??20(?5>      ??5<      ?? *Copy+5>      ?? 5?      $	??105??5@      $??35??5A      $??5,0,0,0q?5B      
???????$??Confirm??5F      $??20(?5G      ??5D      ?? *	Confirm+??5E      ?? 
 ?? ElementName$
 tbResult??5G      5H      5I      ?? 5J      -   5         ??Name$ tbResult??5K      $	??420??5L      $	??305??5M      $??10,0,0,0q?5N      $??Center=?5O      $??Center=?5P      $??20(?5Q       ?? 
IsReadOnly$
 True??5R         ModernTextBoxTheme#??[  5S       ?? TextWrapping$
 Wrap=?5T      5U      5V      5W      5X      