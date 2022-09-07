using NamingSetter.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NamingSetter.MVVM.ViewModel
{
    
    public class MainViewModel : BaseViewModel
    {
        public ICommand Copy { get; set; }
        public ICommand Confirm { get; set; }
        public MainViewModel()
        {
            Copy = new RelayCommand<object>(p => true, p =>
            {
                var text = Information.Result;
                if (text != null)
                {
                    Clipboard.SetText(text);
                }
            });
            Confirm = new RelayCommand<TextBox>(p => p is TextBox ? true : false, p =>
            {
                p.Text = Information.GetResult();
            });
        }
    }
}
