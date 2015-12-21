using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FourthLabWork
{
    /// <summary>
    /// Задача минимизации
    /// </summary>
    class MinimizationTask
    {
        public Func<Vector2, double> Formula { get; private set; }
        public bool IsEqual { get; private set; }
        public bool IsBiggerThanZero { get; private set; }        
    }

    /// <summary>
    /// Ограничение для функции
    /// </summary>
    class Limitation
    {
        public List<Limitation> Limitations { get; private set; }
        public Func<Vector2, double> Formula { get; private set; }                
    }
}
