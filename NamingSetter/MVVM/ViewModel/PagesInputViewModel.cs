using NamingSetter.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xceed.Wpf.Toolkit;

namespace NamingSetter.MVVM.ViewModel
{
    public class PagesInputViewModel : BaseViewModel
    {
        public ICommand ValueChangedCommand { get; set; }
        public PagesInputViewModel()
        {
            ValueChangedCommand = new RelayCommand<IntegerUpDown>(p => p is IntegerUpDown ? true : false, p => Information.AddPagesNumber(Convert.ToInt32(p.Value)));
        }
    }
}
