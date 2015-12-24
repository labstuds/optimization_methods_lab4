using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FourthLabWork
{

    public static class OptimalGradientMethod
    {
        /// <summary>
        /// Найти точку, в которой функция минимальна
        /// </summary>
        /// <param name="startX">Начальная точка</param>
        /// <param name="eps">Точность</param>
        /// <param name="taskFunction">Функция для минимизации</param>
        /// <returns></returns>
        public static Vector2 findMinimum(Vector2 startX, double eps, Func<Vector2, double> taskFunction, MinimizationTask task)
        {
            // Точность для метода дихотомии
            double inputOrder = findPositiveOrder(findMax(Math.Abs(startX.X), Math.Abs(startX.Y)));
            double dichotomyEpsilon = countDichotomyEps(inputOrder);
            double alpha = countStartAlphaStep(inputOrder);
            // Шаг для метода одномерной отпитизации ДСК            
            double DSKStep = 0.001;
            
            //LoggerEvs.writeLog("Optimal gradient method started!");
            Vector2 answer = new Vector2();
            Vector2 args = startX;
            Vector2 gradientValue;               
            bool answerFound = false;
            //LoggerEvs.writeLog(string.Format("\tData input:\n(x1; x2) = ({0}; {1}),\nAlpha = {2},\neps = {3};", startX.X, startX.Y, alpha, eps));
            
            // Шаг 1
            int k = 0;            
            while (!answerFound)
            {
                if(k>=1000)
                {
                    answerFound = true;
                }
                    //LoggerEvs.writeLog(string.Format("ITER {0}:", k));
                    //LoggerEvs.writeLog(string.Format("Step 1: k = {0};", k));

                    gradientValue = CountCentralScheme.Instance.countDerivative(0.1, args, taskFunction);



                    //LoggerEvs.writeLog(string.Format("Step 2: gradient is ({0}, {1});", gradientValue.X, gradientValue.Y));
                    // Шаг 3
                    if (gradientValue.getEuclidNorm() <= eps)
                    {
                        // Перейти на шаг 7
                        answerFound = true;
                        //LoggerEvs.writeLog(string.Format("Step 3: gradient Euclidean norm is <= eps: {0} <= {1}; Go to step 7!", gradientValue.getEuclidNorm(), eps));
                    }
                    else
                    {
                        // Шаг 4   
                        // Провести метод одномерной оптимизации
                        if (alpha >= 0)
                        {
                            Interval alphaValues = DSKMethodCounter.countInterval(taskFunction, alpha, args, gradientValue, DSKStep,task);
                            alpha = DichotomyMethodCounter.findMinimum(taskFunction, alphaValues, dichotomyEpsilon, args, gradientValue);
                        }
                        //LoggerEvs.writeLog(string.Format("Step 4: Alpha = {0};", alpha));
                        // Шаг 5                    
                        args = args - alpha * gradientValue;
                        //LoggerEvs.writeLog(string.Format("Step 5: arguments = arguments - alpha * gradientValue = ({0}; {1});", args.X, args.Y));
                        // Шаг 6
                        k += 1;
                        //LoggerEvs.writeLog(string.Format("Step 6: k = k + 1 = {0};", k - 1));
                    }
                }        
            
            // Шаг 7
            // Положить
            answer = args;
            //LoggerEvs.writeLog(string.Format("Step 7: answer is: ({0:N3}; {1:N3});", answer.X, answer.Y));               
            return answer;
        }
                
        private static double findMax(double v1, double v2)
        {
            if (v1 > v2)
                return v1;
            else
                return v2;
        }

        /// <summary>
        /// Найти порядок числа
        /// </summary>
        /// <param name="value">Число, порядок которого нужно найти</param>
        /// <returns>Порядок</returns>
        public static double findPositiveOrder(double value)
        {
            double order = 0;
            for(int i = 1; value >= 10; i++)
            {
                value /= 10;
                order = i;
            }
            return order;
        }

        /// <summary>
        /// Вычислить точность для метода дихотомии
        /// </summary>
        /// <param name="order">Порядок</param>
        /// <returns>Точность</returns>
        public static double countDichotomyEps(double order)
        {
            double eps = 0.01;
            if(order > 0)
                return 1 / Math.Pow(10, order * 2 + 2);
            else
                return eps;
        }

        /// <summary>
        /// Вычислить шаг для ДСК
        /// </summary>
        /// <param name="order">Порядок</param>
        /// <returns>Шаг для ДСК</returns>
        public static double countDSKStep(double order)
        {
            return 1 / Math.Pow(10, order + 5);
        }

        /// <summary>
        /// Вычислить начальный шаг alpha
        /// </summary>
        /// <param name="order">Порядок</param>
        /// <returns>Начальный шаг alpha</returns>
        public static double countStartAlphaStep(double order)
        {
            return 1 / Math.Pow(10, order + 3);
        }
    }
}
