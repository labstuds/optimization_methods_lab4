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
        int currentTaskIndex = 0;
        public Form1()
        {
            InitializeComponent();
            InitTasks();
            LoggerEvsLib.LoggerEvs.messageCame += printMessage;
        }             

        public void printMessage(string a)
        {
            rtbLog.AppendText(a);
        }

        public double testFunc(Vector2 arg)
        {
            return Math.Pow(arg.X, 2) + Math.Pow(arg.Y, 2);
        }

        public double testLimit(Vector2 arg)
        {
            return (0-arg.X-arg.Y + 2);
        }

        public double secondTestLimit(Vector2 arg)
        {
            return arg.X - 1;
        }

        // Учебная задача 2.1
        public double firstFunc(Vector2 arg)
        {
            double result = Math.Pow((arg.X + 1), 3)/3 + arg.Y;
            return result;
                
        }

        public double firstFuncLim_1(Vector2 arg)
        {
            return arg.X - 1;
        }

        public double firstFuncLim_2(Vector2 arg)
        {
            return arg.Y;
        }
        /// <summary>
        /// Инициализировать задачи 
        /// </summary>
        private void InitTasks()
        {
            // Тестовая задача 1.1
            MinimizationTask currentTask = new MinimizationTask(new List<Limitation> { new Limitation(testLimit,true,true,false),new Limitation(secondTestLimit,true,true,false)}, testFunc);
            tasks.Add(currentTask);
            // Учебная задача 2.1
            currentTask = new MinimizationTask(new List<Limitation> { new Limitation(firstFuncLim_1, true, true, false), new Limitation(firstFuncLim_2, true, true, false) }, firstFunc);
            tasks.Add(currentTask);
            // Учебная задача 2.2
            // Учебная задача 2.3
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            // Считать входные данные            
            tasks[currentTaskIndex].eps = (double)nudEps.Value;
            tasks[currentTaskIndex].z = (double)nudZ.Value;
            tasks[currentTaskIndex].x0 = new Vector2((double)nudX1.Value, (double)nudX2.Value);
            tasks[currentTaskIndex].r0 = (double)nudR0.Value;
            Minimizer min = new Minimizer(tasks[currentTaskIndex]);
            min.minimize();
            answerBox.Text = String.Format("Minimum f({0}) = {1}", tasks[currentTaskIndex].MinimumPoint, tasks[currentTaskIndex].MinimumValue);
        }

        private void rbTestFunc_CheckedChanged(object sender, EventArgs e)
        {
            //тестовая
            setTestTask();
        }

        private void setTestTask()
        {
            currentTaskIndex = 0;
        }

        private void rbFunc2_1_CheckedChanged(object sender, EventArgs e)
        {
            //2.1
            currentTaskIndex = 1;
        }

        private void rbFunc2_2_CheckedChanged(object sender, EventArgs e)
        {
            //2.2
            currentTaskIndex = 2;
        }

        private void rbFunc2_3_CheckedChanged(object sender, EventArgs e)
        {
            //2.3
            currentTaskIndex = 3;
        }       
    }
}
