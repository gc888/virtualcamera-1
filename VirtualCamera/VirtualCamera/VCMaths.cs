using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace VirtualCamera
{
    class VCMaths
    {
        public static Matrix<double> Generate_Rot_Matrix(double angle, string axis)
        {
            if (axis.Equals("x"))
            {
                return DenseMatrix.OfArray(new double[,] {
                                                {1,0,0,0},
                                                {0, Math.Cos(Math.PI * angle / 180), -Math.Sin(Math.PI * angle / 180),0},
                                                {0, Math.Sin(Math.PI * angle / 180), Math.Cos(Math.PI * angle / 180),0},
                                                {0,0,0,1}
                });
            }
            else if (axis.Equals("y"))
            {
                return DenseMatrix.OfArray(new double[,] {
                                                {Math.Cos(Math.PI * angle / 180),0, Math.Sin(Math.PI * angle / 180),0},
                                                {0,1,0,0},
                                                {-Math.Sin(Math.PI * angle / 180),0, Math.Cos(Math.PI * angle / 180),0},
                                                {0,0,0,1}
                });
            }
            else
            {
                return DenseMatrix.OfArray(new double[,] {
                                                {Math.Cos(Math.PI * angle / 180), -Math.Sin(Math.PI * angle / 180),0,0},
                                                {Math.Sin(Math.PI * angle / 180), Math.Cos(Math.PI * angle / 180),0,0},
                                                {0,0,1,0},
                                                {0,0,0,1}
                });
            }
        }

        public static void Rotate(List<List<List<double[,]>>> objects, Matrix<double> rot_matrix)
        {
            foreach (var obj in objects)
            {
                foreach (var line in obj)
                {
                    Matrix<double> mat1 = Matrix.Build.DenseOfArray(line[0]).Append(Matrix.Build.Dense(1, 1, 1)).Transpose();
                    Matrix<double> mat2 = Matrix.Build.DenseOfArray(line[1]).Append(Matrix.Build.Dense(1, 1, 1)).Transpose();
                    line[0] = (rot_matrix * mat1).RemoveRow(3).Transpose().ToArray();
                    line[1] = (rot_matrix * mat2).RemoveRow(3).Transpose().ToArray();
                }
            }
        }

        public static List<List<List<double[,]>>> Change3Dto2D(List<List<List<double[,]>>> objects, Viewport port)
        {
            List<List<List<double[,]>>> transformed = new List<List<List<double[,]>>>();
            foreach(var obj in objects)
            {
                List<List<double[,]>> trans_line = new List<List<double[,]>>();
                foreach (var line in obj)
                {
                    Matrix<double> m1 = Matrix<double>.Build.DenseOfArray(line[0]);
                    Matrix<double> m2 = Matrix<double>.Build.DenseOfArray(line[1]);
                    var x = m1.Multiply(port.perspective_coe / line[0][0, 2]);
                    var y = m2.Multiply(port.perspective_coe / line[1][0, 2]);

                    trans_line.Add(new List<double[,]>() { x.ToArray() , y.ToArray()});
                }
                transformed.Add(trans_line);
            }

            return transformed;
        }

        public static void Move(List<List<List<double[,]>>> objects, double[,] vector)
        {
            Matrix<double> vec = Matrix.Build.DenseOfArray(vector);
            foreach(var obj in objects)
            {
                foreach(var line in obj)
                {
                    Matrix<double> vec1 = Matrix.Build.DenseOfArray(line[0]);
                    Matrix<double> vec2 = Matrix.Build.DenseOfArray(line[1]);
                    line[0] = vec1.Add(vec).ToArray();
                    line[1] = vec2.Add(vec).ToArray();
                }
            }
        }

        

        public static void W_Used(List<List<List<double[,]>>> objects)
        {
            double[,] transformation_vector = new double[,] { { 0, -10, 0 } };
            Move(objects, transformation_vector);
        }

        public static void A_Used(List<List<List<double[,]>>> objects)
        {
            double[,] transformation_vector = new double[,] { { 10, 0, 0 } };
            Move(objects, transformation_vector);
        }

        public static void S_Used(List<List<List<double[,]>>> objects)
        {
            double[,] transformation_vector = new double[,] { { 0, 10, 0 } };
            Move(objects, transformation_vector);
        }

        public static void D_Used(List<List<List<double[,]>>> objects)
        {
            double[,] transformation_vector = new double[,] { { -10, 0, 0 } };
            Move(objects, transformation_vector);
        }

        public static void E_Used(List<List<List<double[,]>>> objects)
        {
            double[,] transformation_vector = new double[,] { { 0, 0, -10 } };
            Move(objects, transformation_vector);
        }

        public static void Q_Used(List<List<List<double[,]>>> objects)
        {
            double[,] transformation_vector = new double[,] { { 0, 0, 10 } };
            Move(objects, transformation_vector);
        }

        public static void Y_Used(List<List<List<double[,]>>> objects)
        {
            Matrix<double> rot_matrix = Generate_Rot_Matrix(5, "x");
            Rotate(objects, rot_matrix);
        }

        public static void U_Used(List<List<List<double[,]>>> objects)
        {
            Matrix<double> rot_matrix = Generate_Rot_Matrix(-5, "x");
            Rotate(objects, rot_matrix);
        }

        public static void H_Used(List<List<List<double[,]>>> objects)
        {
            Matrix<double> rot_matrix = Generate_Rot_Matrix(5, "y");
            Rotate(objects, rot_matrix);
        }

        public static void J_Used(List<List<List<double[,]>>> objects)
        {
            Matrix<double> rot_matrix = Generate_Rot_Matrix(-5, "y");
            Rotate(objects, rot_matrix);
        }

        public static void N_Used(List<List<List<double[,]>>> objects)
        {
            Matrix<double> rot_matrix = Generate_Rot_Matrix(5, "z");
            Rotate(objects, rot_matrix);
        }

        public static void M_Used(List<List<List<double[,]>>> objects)
        {
            Matrix<double> rot_matrix = Generate_Rot_Matrix(-5, "z");
            Rotate(objects, rot_matrix);
        }
    }
}
