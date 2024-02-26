using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.IO;

namespace les._30._12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Thread tred = new Thread(() => { Dispatcher.Invoke(() => { lab.Content = "hi"; }); });
            funct();
            //tred.Start();
            //tred.Join();
        }
        public async void funct()
        {
            await Task.Run(() => { Dispatcher.InvokeAsync(() => { lab.Content = "hi"; }); });
        }
    }
}
