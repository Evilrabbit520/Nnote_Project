using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Threading;

namespace Nnote_Project
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private PreloadedPages PreloadedPages;
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(ShowLoginWindow);
        }
        private void ShowLoginWindow(object sender, RoutedEventArgs e)
        {
            // 弹窗样式
            PreloadedPages = new PreloadedPages();
            PreloadedPages.Topmost = true; // 窗口置顶
            PreloadedPages.WindowStartupLocation = WindowStartupLocation.CenterScreen; // 在屏幕中心显示
            PreloadedPages.ResizeMode = ResizeMode.NoResize; // 锁定宽高
            PreloadedPages.WindowStyle = WindowStyle.None;   // 无窗体样式，即可不显示状态栏

            // 预加载背景Logo
            ImageBrush brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resource/MainNnote.png"));
            PreloadedPages.Background = brush;

            // 设置窗体{StartCloseTimer}秒后自动关闭
            StartCloseTimer();
            PreloadedPages.ShowDialog();
        }
        private void StartCloseTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5); // 3秒
            // 为了方便测试，先把这个秒数写到App.config配置文件中
            double t = double.Parse(ConfigurationManager.AppSettings["LOGO_WINDOW_AUTO_CLOSE_TIMER"]);
            timer.Tick += TimerTick; // 注册计时器到点后触发的回调
            timer.Start();
        }
        private void TimerTick(object sender, EventArgs e)
        {
            DispatcherTimer timer = (DispatcherTimer)sender;
            timer.Stop();
            timer.Tick -= TimerTick; // 取消注册
            PreloadedPages.Close();
        }

        private void CloseLogoWindow(object state)
        {
            // 关闭Logo窗体
            PreloadedPages.Close();
        }
    }
}
