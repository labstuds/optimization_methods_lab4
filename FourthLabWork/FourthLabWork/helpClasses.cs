using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FourthLabWork
{
    public class Vector2
    {
        private double x, y;
        // Для рандомного вектора
        public static Vector2 getRandomVectorKsi()
        {
            Random rnd = new Random();
            double x = 2 * rnd.NextDouble() - 1;
            double y = 2 * rnd.NextDouble() - 1;
            return new Vector2(x, y);
        }

        public Vector2()
        {
            this.x = 0;
            this.y = 0;
        }

        public double getEuclidNorm()
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }
        ///////////////////////////////////////

        public Vector2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double X
        {
            get { return x; }
            set
            {
                x = value;
            }
        }

        public double Y
        {
            get { return y; }
            set
            {
                y = value;
            }
        }

        public double get(int index)
        {
            if (index == 0)
            {
                return x;
            }
            else if (index == 1)
            {
                return y;
            }
            else
            {
                throw new ArgumentOutOfRangeException("В Vector2 возможны только индексы 0 и 1");
            }
        }

        public void set(int index, double value)
        {
            if (index == 0)
            {
                x = value;
            }
            else if (index == 1)
            {
                y = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("В Vector2 возможны только индексы 0 и 1");
            }
        }

        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X - v2.X, v1.Y - v2.Y);
        }

        public static bool operator <(Vector2 v1, Vector2 v2)
        {
            return v1.Length < v2.Length;
        }

        public static bool operator >(Vector2 v1, Vector2 v2)
        {
            return v2.Length > v2.Length;
        }

        public static bool operator ==(Vector2 v1, Vector2 v2)
        {
            return !(v1 < v2) && !(v1 > v2);
        }

        public static bool operator !=(Vector2 v1, Vector2 v2)
        {
            return !(v1 == v2);
        }

        public static Vector2 operator *(double constant, Vector2 v1)
        {
            return new Vector2(v1.X * constant, v1.Y * constant);
        }

        public static Vector2 operator /(Vector2 v1, double constant)
        {
            return new Vector2(v1.X / constant, v1.Y / constant);
        }

        public static Vector2 operator +(Vector2 v1, double constant)
        {
            return new Vector2(v1.x + constant, v1.y + constant);
        }

        public static Vector2 operator -(Vector2 v1, double constant)
        {
            return new Vector2(v1.x - constant, v1.y - constant);
        }

        public double Length
        {
            get { return Math.Sqrt(x * x + y * y); }
        }

        public static Vector2 Right
        {
            get { return new Vector2(1, 0); }
        }
        public static Vector2 Up
        {
            get { return new Vector2(0, 1); }
        }

        public Vector2 Clone()
        {
            return new Vector2(this.x, this.y);
        }
        /// <summary>
        /// не скалярное умножение, а просто x на x и y на y
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector2 operator *(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X * v2.X, v1.Y * v2.Y);
        }

        /// <summary>
        /// Возвращает вектор единичной длины направленный в сторону оси под номером аргумента
        /// </summary>
        /// <param name="axisNumber">Номер оси, куда направлен вектор</param>
        /// <returns>Нормализованный вектор</returns>
        public static Vector2 getNormalizedVectorByAxisNumber(int axisNumber)
        {
            if (axisNumber == 1)
            {
                return Vector2.Right;
            }
            if (axisNumber == 2)
            {
                return Vector2.Up;
            }
            else
                throw new ArgumentException("Требуется получить ось, которую двумерный вектор напрямую представить не может, т.е. номер оси не верен.");
        }

        public override string ToString()
        {
            string outPut = string.Format("({0:f3};{1:f3})", x, y);
            return outPut;
        }

        public double this[int index]
        {
            get { return get(index); }
            set { set(index, value); }
        }

        public static Matrix multiplieTransp(Vector2 v1,Vector2 v2)
        {
            Matrix result = new Matrix(2);
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    result[i,j] += v1[i] * v2[j];
                }
            }
            return result;
        }
    }

    public class Matrix
    {
        double[] values;
        int size;
        /// <summary>
        /// Инициализирует матрицу с нулями
        /// </summary>
        public Matrix(int size)
        {
            values = new double[size*size];
            for(int i=0;i<size*size;i++)
            {
                values[i] = 0;
            }
            this.size = size;
        }

        public Matrix(double[] values)
        {
            if (Math.Sqrt(values.Length) % 1 != 0)
                throw new ArgumentException("Матрица не квадратная");
            size = (int)Math.Sqrt(values.Length);
            this.values = values;
        }

        
        public static Matrix getIdentityMatrix(int size)
        {
            Matrix matr = new Matrix(size);
            for (int j = 0; j < matr.Size; j++)
            {
                matr[j, j] = 1;
            }
            return matr;
        }

        public static Matrix operator-(Matrix a, Matrix b)
        {
            if(a.Size!=b.Size)
            {
                //пшол вон псих
                throw new ArgumentException("Нельзя вычитать матрицы разных размеров");
            }
            Matrix result = new Matrix(a.Size);
            for (int i = 0; i < a.Size; i++)
            {
                for (int j = 0; j < a.Size; j++)
                {
                    result[i, j] = a[i, j] - b[i, j];
                }
            }
            return result;
        }

        public static Matrix operator /(Matrix a, double b)
        {
            Matrix result = new Matrix(a.Size);
            for(int i=0;i<a.Size;i++)
            {
                for(int j=0;j<a.Size;j++)
                {
                    result[i, j] = a[i, j] / b;
                }
            }
            return result;
        }

        public static Matrix operator *(Matrix a, double b)
        {
            return a / (1 / b);
        }

        public static Matrix operator /(Matrix a,Matrix b)
        {
            if (a.Size != b.Size)
            {
                //пшол вон псих, кого понабирали, поглядите
                throw new ArgumentException("Нельзя делить матрицы разных размеров");
            }
            Matrix result = new Matrix(a.Size);
            result = a * (b.GetTranspMatrix() / b.getDeterminator());
            return result;
        }

        public static Matrix operator-(Matrix a)
        {
            return a*(-1);
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.Size != b.Size)
            {
                //пшол вон псих
                throw new ArgumentException("Нельзя вычитать матрицы разных размеров");
            }
            Matrix result = new Matrix(a.Size);
            for (int i = 0; i < a.Size; i++)
            {
                for (int j = 0; j < a.Size; j++)
                {
                    result[i, j] = a[i, j] + b[i, j];
                }
            }
            return result;
        }

        public Matrix GetTranspMatrix()
        {
            Matrix result = new Matrix(this.Size);
            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                {
                    result[i, j] = this[j, i];
                }
            }
            return result;
        }

        public double getDeterminator()
        {
            double det = 0;
            double EPS = 1E-8;
            Matrix a = this;
            Matrix b = new Matrix(a.Size);
            int n = a.Size;
            for (int i = 0; i < n; ++i)
            {
                int k = i;
                for (int j = i + 1; j < n; ++j)
                    if (Math.Abs(a[j,i]) > Math.Abs(a[k,i]))
                        k = j;
                if (Math.Abs(a[k,i]) < EPS)
                {
                    det = 0;
                    break;
                }
                Matrix.swapStrings(ref a, ref a, i, k);
                if (i != k)
                    det = -det;
                det *= a[i,i];
                for (int j = i + 1; j < n; ++j)
                    a[i,j] /= a[i,i];
                for (int j = 0; j < n; ++j)
                    if ((j != i) && (Math.Abs(a[j,i]) > EPS))
                        for (k = i + 1; k < n; ++k)
                            a[j,k] -= a[i,k] * a[j,i];
            }
            return det;
        }

        /// <summary>
        /// Swap Strings in Matrix. Also, you can swap strings in one matrix
        /// </summary>
        /// <param name="a">First Matrix</param>
        /// <param name="b">Second Matrix</param>
        /// <param name="aStringIndex">index in first matrix</param>
        /// <param name="bStringIndex">index in second matrix</param>
        public static void swapStrings(ref Matrix a,ref Matrix b, int aStringIndex, int bStringIndex)
        {
            if(a.Size!=b.Size)
            {
                throw new ArgumentException("Невозможно поменять местами строки матрицы с несовпадающими размерами");
            }
            double temp = 0;
            for(int i=0;i<a.Size;i++)
            {
                temp = a[aStringIndex, i];
                a[aStringIndex, i] = b[bStringIndex, i];
                b[bStringIndex, i] = temp;
            }
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.Size != b.Size)
            {
                throw new ArgumentException("Не поддерживается умножение матриц с разными размерами");
            }
            Matrix result = new Matrix(a.Size);
            for (int i = 0; i < a.Size; i++)
            {
                for (int j = 0; j < a.Size; j++)
                {
                    for (int k = 0; k < a.Size; k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return result;
        }
        

        public static Vector2 operator*(Matrix matr,Vector2 vec)
        {
            Vector2 result=new Vector2(0,0);
            for (int i = 0; i < matr.Size; i++)
            {
                for (int j = 0; j < matr.Size; j++)
                {
                    result[i] += vec[j]*matr[i,j];
                }
            }
            return result;
        }

        public static Vector2 multiplieTransp(Matrix matr,Vector2 likeTranspVector)
        {
            Vector2 result = new Vector2(0, 0);
            for (int i = 0; i < matr.Size; i++)
            {
                for (int j = 0; j < matr.Size; j++)
                {
                    result[i] += likeTranspVector[j] * matr[j, i];
                }
            }
            return result;
        }
        public int Size
        {
            get { return size; }
        }

        public double this[int i,int j]
        {
            get {return values[i*2+j];}
            set { values[i * 2 + j] = value; }
        }

        public override string ToString()
        {
            String result = "";
            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                {
                    result += this[i, j]+"  ";
                }
                result += "\r\n";
            }
            return result;
        }
    }
}
