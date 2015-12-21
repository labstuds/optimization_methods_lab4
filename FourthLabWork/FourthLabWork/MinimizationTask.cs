using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FourthLabWork
{
    /// <summary>
    /// Ограничение для функции
    /// </summary>
    public class Limitation
    {
        public Func<Vector2, double> Formula { get; private set; }
        public bool IsEqual { get; private set; }
        public bool IsBiggerThanZero { get; private set; }
        public bool IsLessThanZero
        {
            get;
            set;
        }
        public Limitation() { }
        public Limitation(Func<Vector2, double> formula, bool isEqual, bool isBiggerThanZero,bool isLessThanZero)
        {
            Formula = formula;
            IsEqual = isEqual;
            IsBiggerThanZero = IsBiggerThanZero;
            IsLessThanZero = isLessThanZero;
        }
    }

    /// <summary>
    /// Задача минимизации
    /// </summary>
    public class MinimizationTask
    {
        public List<Limitation> Limitations { get; private set; }
        public Func<Vector2, double> Formula { get; private set; }
        public double r0;
        public double z;
        public double eps;
        public Vector2 x0;
        public double MinimumValue
        {
            get;
            set;
        }
        public Vector2 MinimumPoint
        {
            get;
            set;
        }
        public MinimizationTask() { }
        public MinimizationTask(List<Limitation> limits, Func<Vector2, double> formula)
        {
            Limitations = limits;
            Formula = formula;
        }
        public double ModifiedFunction(Vector2 x)
        {
            double result = Formula(x) + r0 * LimitationsForceSumm(x);

            return result;
        }
        public double LimitationsForceSumm(Vector2 x)
        {
            //Кэрролла
            double result = 0;
            foreach(var limit in Limitations)
            {

                result += (1 / Math.Abs(limit.Formula(new Vector2(x[0], x[1]))));

            }
            return result;
        }
    }
}
