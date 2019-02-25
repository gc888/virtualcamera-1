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
using MathNet.Numerics.LinearAlgebra;

namespace VirtualCamera
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Viewport viewport = new Viewport(100);
        List<List<List<double[,]>>> objects;

        int transform_x = 750;
        int transform_y = 500;

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            init();
            drawObjects(VCMaths.Change3Dto2D(objects, viewport));
        }

        private void drawObjects(List<List<List<double[,]>>> transformed)
        {
            MyCanvas.Children.Clear();
            foreach(var obj in transformed)
            {
                foreach(var line in obj)
                {
                    Line newLine = new Line();
                    newLine.X1 = line[0][0, 0] + transform_x;
                    newLine.X2 = line[1][0, 0] + transform_x;
                    newLine.Y1 = transform_y - line[0][0, 1];
                    newLine.Y2 = transform_y - line[1][0, 1];
                    newLine.Stroke = Brushes.White;
                    MyCanvas.Children.Add(newLine);
                }
            }
            
        }

        private void init()
        {
            List<List<List<double[,]>>> stageobj = new List<List<List<double[,]>>>();
            List<List<double[,]>> cubeLines = new List<List<double[,]>>();
            List<List<double[,]>> cubeLines2 = new List<List<double[,]>>();
            List<List<double[,]>> pyramidLines = new List<List<double[,]>>();

            cubeLines.Add(new List<double[,]>() { new double[,] { { -50, -20, 100 } }, new double[,] { { -10, -20, 100 } } });
            cubeLines.Add(new List<double[,]>() { new double[,] { { -50, 20, 100 } }, new double[,] { { -10, 20, 100 } } });
            cubeLines.Add(new List<double[,]>() { new double[,] { { -50, -20, 100 } }, new double[,] { { -50, 20, 100 } } });
            cubeLines.Add(new List<double[,]>() { new double[,] { { -10, -20, 100 } }, new double[,] { { -10, 20, 100 } } });
            cubeLines.Add(new List<double[,]>() { new double[,] { { -50, -20, 140 } }, new double[,] { { -10, -20, 140 } } });
            cubeLines.Add(new List<double[,]>() { new double[,] { { -50, 20, 140 } }, new double[,] { { -10, 20, 140 } } });
            cubeLines.Add(new List<double[,]>() { new double[,] { { -50, -20, 140 } }, new double[,] { { -50, 20, 140 } } });
            cubeLines.Add(new List<double[,]>() { new double[,] { { -10, -20, 140 } }, new double[,] { { -10, 20, 140 } } });
            cubeLines.Add(new List<double[,]>() { new double[,] { { -50, -20, 100 } }, new double[,] { { -50, -20, 140 } } });
            cubeLines.Add(new List<double[,]>() { new double[,] { { -50, 20, 100 } }, new double[,] { { -50, 20, 140 } } });
            cubeLines.Add(new List<double[,]>() { new double[,] { { -10, -20, 100 } }, new double[,] { { -10, -20, 140 } } });
            cubeLines.Add(new List<double[,]>() { new double[,] { { -10, 20, 100 } }, new double[,] { { -10, 20, 140 } } });

            cubeLines2.Add(new List<double[,]>() { new double[,] { { 50, -20, 100 } }, new double[,] { { 10, -20, 100 } } });
            cubeLines2.Add(new List<double[,]>() { new double[,] { { 50, 20, 100 } }, new double[,] { { 10, 20, 100 } } });
            cubeLines2.Add(new List<double[,]>() { new double[,] { { 50, -20, 100 } }, new double[,] { { 50, 20, 100 } } });
            cubeLines2.Add(new List<double[,]>() { new double[,] { { 10, -20, 100 } }, new double[,] { { 10, 20, 100 } } });
            cubeLines2.Add(new List<double[,]>() { new double[,] { { 50, -20, 140 } }, new double[,] { { 10, -20, 140 } } });
            cubeLines2.Add(new List<double[,]>() { new double[,] { { 50, 20, 140 } }, new double[,] { { 10, 20, 140 } } });
            cubeLines2.Add(new List<double[,]>() { new double[,] { { 50, -20, 140 } }, new double[,] { { 50, 20, 140 } } });
            cubeLines2.Add(new List<double[,]>() { new double[,] { { 10, -20, 140 } }, new double[,] { { 10, 20, 140 } } });
            cubeLines2.Add(new List<double[,]>() { new double[,] { { 50, -20, 100 } }, new double[,] { { 50, -20, 140 } } });
            cubeLines2.Add(new List<double[,]>() { new double[,] { { 50, 20, 100 } }, new double[,] { { 50, 20, 140 } } });
            cubeLines2.Add(new List<double[,]>() { new double[,] { { 10, -20, 100 } }, new double[,] { { 10, -20, 140 } } });
            cubeLines2.Add(new List<double[,]>() { new double[,] { { 10, 20, 100 } }, new double[,] { { 10, 20, 140 } } });

            pyramidLines.Add(new List<double[,]>() { new double[,] { { -50, 30, 100 } }, new double[,] { { 50, 30, 100 } } });
            pyramidLines.Add(new List<double[,]>() { new double[,] { { -50, 30, 140 } }, new double[,] { { 50, 30, 140 } } });
            pyramidLines.Add(new List<double[,]>() { new double[,] { { -50, 30, 100 } }, new double[,] { { -50, 30, 140 } } });
            pyramidLines.Add(new List<double[,]>() { new double[,] { { 50, 30, 100 } }, new double[,] { { 50, 30, 140 } } });
            pyramidLines.Add(new List<double[,]>() { new double[,] { { -50, 30, 100 } }, new double[,] { { 0, 70, 120 } } });
            pyramidLines.Add(new List<double[,]>() { new double[,] { { -50, 30, 140 } }, new double[,] { { 0, 70, 120 } } });
            pyramidLines.Add(new List<double[,]>() { new double[,] { { 50, 30, 100 } }, new double[,] { { 0, 70, 120 } } });
            pyramidLines.Add(new List<double[,]>() { new double[,] { { 50, 30, 140 } }, new double[,] { { 0, 70, 120 } } });


            stageobj.Add(cubeLines);
            stageobj.Add(cubeLines2);
            stageobj.Add(pyramidLines);
            objects = stageobj;
        }

        private void Button_Click(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W)
            {
                VCMaths.W_Used(objects);
                drawObjects(VCMaths.Change3Dto2D(objects, viewport));
            }
            else if (e.Key == Key.A)
            {
                VCMaths.A_Used(objects);
                drawObjects(VCMaths.Change3Dto2D(objects, viewport));
            }
            else if (e.Key == Key.S)
            {
                VCMaths.S_Used(objects);
                drawObjects(VCMaths.Change3Dto2D(objects, viewport));
            }
            else if (e.Key == Key.D)
            {
                VCMaths.D_Used(objects);
                drawObjects(VCMaths.Change3Dto2D(objects, viewport));
            }
            else if (e.Key == Key.Q)
            {
                VCMaths.Q_Used(objects);
                drawObjects(VCMaths.Change3Dto2D(objects, viewport));
            }
            else if (e.Key == Key.E)
            {
                VCMaths.E_Used(objects);
                drawObjects(VCMaths.Change3Dto2D(objects, viewport));
            }
            else if (e.Key == Key.Y)
            {
                VCMaths.Y_Used(objects);
                drawObjects(VCMaths.Change3Dto2D(objects, viewport));
            }
            else if (e.Key == Key.U)
            {
                VCMaths.U_Used(objects);
                drawObjects(VCMaths.Change3Dto2D(objects, viewport));
            }
            else if (e.Key == Key.H)
            {
                VCMaths.H_Used(objects);
                drawObjects(VCMaths.Change3Dto2D(objects, viewport));
            }
            else if (e.Key == Key.J)
            {
                VCMaths.J_Used(objects);
                drawObjects(VCMaths.Change3Dto2D(objects, viewport));
            }
            else if (e.Key == Key.N)
            {
                VCMaths.N_Used(objects);
                drawObjects(VCMaths.Change3Dto2D(objects, viewport));
            }
            else if (e.Key == Key.M)
            {
                VCMaths.M_Used(objects);
                drawObjects(VCMaths.Change3Dto2D(objects, viewport));
            }
            else if (e.Key == Key.I)
            {
                viewport.perspective_coe += 10;
                drawObjects(VCMaths.Change3Dto2D(objects, viewport));
            }
            else if (e.Key == Key.O)
            {
                viewport.perspective_coe -= 10;
                drawObjects(VCMaths.Change3Dto2D(objects, viewport));
            }
        }
    }
}
