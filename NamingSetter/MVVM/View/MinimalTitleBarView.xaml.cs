using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NamingSetter.MVVM.View
{
    /// <summary>
    /// Interaction logic for MinimalTitleBarView.xaml
    /// </summary>
    public partial class MinimalTitleBarView : UserControl
    {
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(MinimalTitleBarView), new PropertyMetadata(""));
        public MinimalTitleBarView()
        {
            InitializeComponent();
        }
    }
}
