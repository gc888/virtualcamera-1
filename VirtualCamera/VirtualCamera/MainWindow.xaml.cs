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

namespace VirtualCamera
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            Line myLine = new Line();
            myLine.X1 = 100;
            myLine.X2 = 500;
            myLine.Y1 = 100;
            myLine.Y2 = 500;
            myLine.Stroke = Brushes.White;
            MyCanvas.Children.Add(myLine);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Line myLine = new Line();
            myLine.X1 = 200;
            myLine.X2 = 300;
            myLine.Y1 = 200;
            myLine.Y2 = 600;
            myLine.Stroke = Brushes.White;
            MyCanvas.Children.Add(myLine);
        }
    }
}
