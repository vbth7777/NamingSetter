using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using NamingSetter.Core;

namespace NamingSetter.MVVM.ViewModel
{
    public class MinimalTitleBarViewModel : BaseViewModel
    {
        public Window window { get; set; }

        #region Commands
        public ICommand MinimizeCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand MouseDownCommand { get; set; }
        #endregion
        public MinimalTitleBarViewModel()
        {
            Load();
        }
        void Load()
        {
            LoadCommands();
        }
        void LoadCommands()
        {
            MinimizeCommand = new RelayCommand<ContentControl>(p => p is ContentControl ? true : false, p =>
            {
                if (window == null)
                    window = Window.GetWindow(p);
                window.WindowState = WindowState.Minimized;
            });
            CloseCommand = new RelayCommand<ContentControl>(p => p is ContentControl ? true : false, p =>
            {
                if (window == null)
                    window = Window.GetWindow(p);
                window.Close();
            });
            MouseDownCommand = new RelayCommand<ContentControl>(p => p is ContentControl ? true : false, p =>
            {
                if (window == null)
                    window = Window.GetWindow(p);
                window.DragMove();
            });
        }
    }
}
