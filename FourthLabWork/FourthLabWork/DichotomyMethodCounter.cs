using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FourthLabWork
{
    // <summary>
    /// Вычислить частные производные первого порядка функции двух переменных
    /// </summary>
    abstract class CountFirstOrderPartialDerivatives
    {
        public abstract Vector2 countDerivative(double h, Vector2 args, Func<Vector2, double> func);
    }

    class CountRightScheme : CountFirstOrderPartialDerivatives
    {
        private static CountRightScheme instance;
        public static CountRightScheme Instance
        {
            get
            {
                if (instance == null)
                    instance = new CountRightScheme();
                return instance;
            }
        }

        private CountRightScheme()
        {

        }

        public override Vector2 countDerivative(double h, Vector2 args, Func<Vector2, double> func)
        {
            double x1 = (func(new Vector2(args.X + h, args.Y)) - func(args)) / h;
            double x2 = (func(new Vector2(args.X, args.Y + h)) - func(args)) / h;
            return new Vector2(x1, x2);
        }
    }

    class CountCentralScheme : CountFirstOrderPartialDerivatives
    {
        private static CountCentralScheme instance;
        public static CountCentralScheme Instance
        {
            get
            {
                if (instance == null)
                    instance = new CountCentralScheme();
                return instance;
            }
        }

        private CountCentralScheme()
        {

        }

        public override Vector2 countDerivative(double h, Vector2 args, Func<Vector2, double> func)
        {
            double x1 = (func(new Vector2(args.X + h / 2, args.Y)) - func(new Vector2(args.X - h / 2, args.Y))) / h;
            double x2 = (func(new Vector2(args.X, args.Y + h / 2)) - func(new Vector2(args.X, args.Y - h / 2))) / h;
            return new Vector2(x1, x2);
        }
    }

    class Gradient
    {
        public static Vector2 get(double alpha, Vector2 args, Func<Vector2, double> taskFunction)
        {
            //  if (alpha >= 0.001)
            return CountCentralScheme.Instance.countDerivative(alpha, args, taskFunction);
            //else
            //  return CountRightScheme.Instance.countDerivative(alpha, args, taskFunction);
        }
    }
    public static class DichotomyMethodCounter
    { 

        public static double findMinimum(Func<Vector2, double> taskFunction, Interval searchInterval, double eps, Vector2 args, Vector2 gradient)
        {
            //LoggerEvs.writeLog("Dichotomy method has been started!");
            double alpha_end = 0;                       // Найденное значение x
            double alpha_1, alpha_2;                        // Границы промежуточных отрезков                        
            bool countStop = false;                 // Остановка расчетов
            double delta = eps / 10;                // Константа "различимости"
            double f_alpha_1, f_alpha_2;
            //LoggerEvs.writeLog("Counting: delta = eps / 10 = " + delta);
            for (int i = 0; !countStop; i++)
            {
                // Шаг первый                
                alpha_1 = 0.5 * (searchInterval.LeftEdge + searchInterval.RightEdge) - delta;
                alpha_2 = 0.5 * (searchInterval.LeftEdge + searchInterval.RightEdge) + delta;
                //LoggerEvs.writeLog(string.Format("Step 1: counting alpha_1 = {0:f4}, alpha_2 = {1:f4}", alpha_1, alpha_2));
                // Шаг второй (вычисление) и третий (сравнение)                
                f_alpha_1 = taskFunction(args - alpha_1*gradient);
                f_alpha_2 = taskFunction(args - alpha_2*gradient);
                if (f_alpha_1 <= f_alpha_2)
                {
                    searchInterval.RightEdge = alpha_2;
                    //LoggerEvs.writeLog(string.Format("Step 3: f({0:f4}) = {1:f4} <= f({2:f4}) = {3:f4}; b = alpha_2 = {4:f4}.", alpha_1, f_alpha_1, alpha_2, f_alpha_2, alpha_2));
                }
                else
                {
                    searchInterval.LeftEdge = alpha_1;
                    //LoggerEvs.writeLog(string.Format("Step 3: f({0:f4}) = {1:f4} > f({2:f4}) = {3:f4}; a = alpha_1 = {4:f4}.", alpha_1, f_alpha_1, alpha_2, f_alpha_2, alpha_1));
                }
                // Шаг четвертый
                double diff = (searchInterval.RightEdge - searchInterval.LeftEdge)/2;
                if ( diff < eps)
                {
                    countStop = true;
                    //LoggerEvs.writeLog(string.Format("Step 4: (b-a)/2 = {0:f4} < eps = {1:f4}; STOP SEARCHING!", diff, eps));
                }
                //LoggerEvs.writeLog("Iter " + i + ": Answer is in the range: [" + searchInterval.LeftEdge.ToString("f4") + "; " + searchInterval.RightEdge.ToString("f4") + "]");
            }
            // Шаг пятый
            alpha_end = (searchInterval.LeftEdge + searchInterval.RightEdge) / 2;
            // Вывод результата
            //LoggerEvs.writeLog("Step 5: alpha_end = (a+b)/2; Minimum x* is: " + alpha_end.ToString("f4"));
            return alpha_end;
        }
    
    }
}
