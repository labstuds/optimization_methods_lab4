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
