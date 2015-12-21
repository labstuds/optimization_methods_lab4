using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FourthLabWork
{
    /// <summary>
    /// Ограничение для функции
    /// </summary>
    class Limitation
    {
        public Func<Vector2, double> Formula { get; private set; }
        public bool IsEqual { get; private set; }
        public bool IsBiggerThanZero { get; private set; }
        public Limitation() { }
        public Limitation(Func<Vector2, double> formula, bool isEqual, bool isBiggerThanZero)
        {
            Formula = formula;
            IsEqual = isEqual;
            IsBiggerThanZero = IsBiggerThanZero;
        }
    }

    /// <summary>
    /// Задача минимизации
    /// </summary>
    class MinimizationTask
    {
        public List<Limitation> Limitations { get; private set; }
        public Func<Vector2, double> Formula { get; private set; }
        public MinimizationTask() { }
        public MinimizationTask(List<Limitation> limits, Func<Vector2, double> formula)
        {
            Limitations = limits;
            Formula = formula;
        }
    }
}
