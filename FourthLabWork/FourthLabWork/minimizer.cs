using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FourthLabWork
{
    public class Minimizer
    {
        public Minimizer(MinimizationTask task)
        {
            this.Task = task;
        }
        public MinimizationTask Task
        {
            get;
            set;
        }
        public void minimize()
        {
            int k = 0;
            Vector2 x=Task.x0;
            Vector2 x_r=new Vector2();
            double B;
            double F;
            do
            {
                //step2
                F=Task.ModifiedFunction(x);
                //step3
                x_r=OptimalGradientMethod.findMinimum(x, Task.eps, Task.ModifiedFunction,Task);
                double mfv = Task.ModifiedFunction(x_r);
                double defaul = Task.ModifiedFunction(new Vector2(1, 1));
                //step4
                B = Task.LimitationsForceSumm(x_r)*Task.r0;
                //step5
                Task.r0*=Task.z;
                x=x_r;
                k++;
            }while(Math.Abs(B)>Task.eps);
            //step6
            Task.MinimumPoint = x_r;
            Task.MinimumValue = Task.Formula(x_r);
        }
    }
    public class LinearInterval
    {
        double leftBorder;
        double rightBorder;

        public LinearInterval(double firstBorder, double secondBorder)
        {
            if (firstBorder >= secondBorder)
            {
                leftBorder = secondBorder;
                rightBorder = firstBorder;
            }
            else
            {
                leftBorder = firstBorder;
                rightBorder = secondBorder;
            }
        }

        public double LeftBorder
        {
            get { return leftBorder; }
            set { leftBorder = value; }
        }

        public double RightBorder
        {
            get { return rightBorder; }
            set { rightBorder = value; }
        }

        public override string ToString()
        {
            return "" + leftBorder + ";" + rightBorder;
        }

        public double Length
        {
            get { return rightBorder - leftBorder; }
        }

        public bool valueIsBelongsIncludingLeftAndRightBorders(double value)
        {
            return leftBorder <= value && value <= rightBorder;
        }

        public bool valueIsBelongsIncludingRightBorders(double value)
        {
            return leftBorder < value && value <= rightBorder;
        }

        public double Middle
        {
            get { return (leftBorder + rightBorder) / 2; }
        }
    }
    class LocalizationMethod
    {
        static public LinearInterval calculate(double x0, double h, Func<double, double> func)
        {
            //LoggerEvs.writeLog("Начата работа метода Дэвиса-Свенна-Кэмпи.");
            //LoggerEvs.writeLog("Начальная точка x0 = "+x0+", h= "+h);
            double a = 0f, b = 0f;
            int k = 1;
            Dictionary<int, double> x = new Dictionary<int, double>();
            x.Add(0, x0);
            x.Add(1, 0);
            //LoggerEvs.writeLog("1. Вычисление f(x0) = " + func(x0) + ", f(x0+h) = " + func(x0 + h));
            if (func(x0) > func(x0 + h))
            {
                //LoggerEvs.writeLog("2. Сработало условие f(x0)>f(x0+h), f(x0) = " + func(x0) + ", f(x0+h) = " + func(x0 + h));
                a = x[0];
                x[1] = x[0] + h;
                k = 2;
            }
            else if (func(x[0] - h) >= func(x[0]))
            {
                //LoggerEvs.writeLog("3. Сработало условие f(x0-h)>=f(x0), f(x0-h) = " + func(x0-h) + ", f(x0) = " + func(x0));
                a = x0 - h;
                b = x0 + h;
                //LoggerEvs.writeLog("3. Метод завершается с результатом "+a+";"+b);
                return new LinearInterval(a, b);
            }
            else
            {
                //LoggerEvs.writeLog("3. Сработало условие f(x0)<=f(x0+h), f(x0) = " + func(x0) + ", f(x0+h) = " + func(x0 + h));
                b = x[0];
                x[1] = x[0] - h;
                h = -h;
                k = 2;
            }
            bool aIsFound = false;
            bool bIsFound = false;
            //LoggerEvs.writeLog("4. Начало итерационного поиска");
            int iter = 1;
            while (!bIsFound || !aIsFound)
            {
                //LoggerEvs.writeLog("Итерация номер " + iter);
                iter++;
                x.Add(k, x[0] + Math.Pow(2, k - 1) * h);
                if (func(x[k - 1]) <= func(x[k]))
                {
                    //LoggerEvs.writeLog("5. Сработало условие f(x[k-1])<=f(x[k]). k = "+k+", f(x[k-1]) = "+func(x[k-1])+", f(x[k]) = "+func(x[k]));
                    if (h > 0)
                    {
                        b = x[k];
                        //LoggerEvs.writeLog("Была найдена более подходящая правая граница отрезка локализации минимума: "+b);
                        bIsFound = true;
                    }
                    else
                    {
                        a = x[k];
                        //LoggerEvs.writeLog("Была найдена более подходящая левая граница отрезка локализации минимума: " + a);
                        aIsFound = true;
                    }
                }
                else if (h > 0)
                {
                    //LoggerEvs.writeLog("5. Сработало условие f(x[k-1])>f(x[k]). k = " + k + ", f(x[k-1]) = " + func(x[k - 1]) + ", f(x[k]) = " + func(x[k]));
                    a = x[k - 1];
                    //LoggerEvs.writeLog("Была найдена более подходящая левая граница отрезка локализации минимума: " + a);
                    aIsFound = true;
                }
                else
                {
                    //LoggerEvs.writeLog("5. Сработало условие f(x[k-1])>f(x[k]). k = " + k + ", f(x[k-1]) = " + func(x[k - 1]) + ", f(x[k]) = " + func(x[k]));
                    b = x[k - 1];
                    //LoggerEvs.writeLog("Была найдена более подходящая правая граница отрезка локализации минимума: " + b);
                    bIsFound = true;
                }
                k++;
            }
            //LoggerEvs.writeLog("Найдены подходящие границы отрезка локализации минимума. Это "+a+";"+b);
            LinearInterval interval = new LinearInterval(a, b);
            return interval;
        }
    }
}
