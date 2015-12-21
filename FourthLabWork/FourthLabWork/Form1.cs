using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LoggerEvsLib;


namespace FourthLabWork
{
    public partial class Form1 : Form
    {
        // Учебные и тестовые задачи
        List<MinimizationTask> tasks = new List<MinimizationTask>();
        
        public Form1()
        {
            InitializeComponent();
            InitTasks();
        }             

        public double testFunc(Vector2 arg)
        {
            return Math.Pow(arg.X, 2) + Math.Pow(arg.Y, 2);
        }

        public double testLimit(Vector2 arg)
        {
            return arg.X + arg.Y - 2;
        }

        /// <summary>
        /// Инициализировать задачи 
        /// </summary>
        private void InitTasks()
        {
            // Тестовая задача 1.1
            List<Limitation> testTaskLimits = new List<Limitation>();
            testTaskLimits.Add(new Limitation(testLimit, true, false));            
            tasks.Add(new MinimizationTask(testTaskLimits, testFunc));
            // Учебная задача 2.1
            // Учебная задача 2.2
            // Учебная задача 2.3
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            // Считать входные данные            
            Vector2 startPoint = new Vector2((double)nudX1.Value, (double)nudX2.Value);
            double r0 = (double)nudR0.Value;
            double z = (double)nudZ.Value;
            double eps = (double)nudEps.Value;
        }       
    }
}
