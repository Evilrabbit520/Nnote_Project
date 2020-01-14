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
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Threading;

namespace Nnote_Project
{
    /// <summary>
    /// PreloadedPages.xaml 的交互逻辑
    /// </summary>
    public partial class PreloadedPages : Window
    {
        private int count;
        public PreloadedPages()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 窗体加载事件(Form load event)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //for (count = 1; count <= 10; count++)
            //{
            //    Thread.Sleep(1000);
            //    if (count == 10)
            //    {
            //        MainWindow PreloadedPages = new MainWindow();
            //        PreloadedPages.Show();
            //        this.Close();
            //    }
            //}
        }
        
    }
}
