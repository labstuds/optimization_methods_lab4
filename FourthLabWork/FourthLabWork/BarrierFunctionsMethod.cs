using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FourthLabWork
{
    public static class BarrierFunctionsMethod
    {
        /// <summary>
        /// Найти минимум функции
        /// </summary>
        /// <param name="startPoint">Начальная точка</param>
        /// <param name="eps">Точность</param>
        /// <param name="r">Параметр штрафа</param>
        /// <param name="z">Коэффициент изменения параметра штрафа</param>
        /// <param name="taskFunction">Функция задания (расчетная)</param>
        /// <param name="barrierFunc">Используемая барьерная функция</param>
        /// <returns>Координаты точки, где функция минимальна</returns>
        public static Vector2 findMinimum(Vector2 startPoint, double eps, double r, double z, Func<Vector2, double> taskFunction, Func<Vector2, double> barrierFunc)
        {
            Vector2 answer = new Vector2(0,0);

            return answer;
        }
    }
}
