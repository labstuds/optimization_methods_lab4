using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathNet.Numerics.LinearAlgebra;

namespace FourthLabWork
{
    class DFPSolver
    {
        Vector<double> basicX;
        double eps;
        Vector<double> result = Vector<double>.Build.Dense(2, 0);
        double alpha = 0f;
        Func<Vector2, double> func;
        double scale = 0.00001f;
        Vector2 vec2XKmod;
        Vector<double> sk = Vector<double>.Build.Dense(2, 0), xk = Vector<double>.Build.Dense(2, 0), xk_1 = Vector<double>.Build.Dense(2, 0), yk = Vector<double>.Build.Dense(2, 0), pk = Vector<double>.Build.Dense(2, 0);
        public DFPSolver()
        {

        }

        public void setStartingVariables(Vector2 x, double eps)
        {
            basicX = Vector<double>.Build.Dense(2, 0);
            basicX[0] = x.X;
            basicX[1] = x.Y;
            this.eps = eps;
        }

        public void clear()
        {
            alpha = 0f;
            result = Vector<double>.Build.Dense(2, 0);
            sk = Vector<double>.Build.Dense(2, 0);
            yk = Vector<double>.Build.Dense(2, 0);
            xk = Vector<double>.Build.Dense(2, 0);
            xk_1 =Vector<double>.Build.Dense(2, 0);
            pk = Vector<double>.Build.Dense(2, 0);
        }

        public Vector2 calculate(Func<Vector2, double> taskFunction)
        {
            clear();
            func = taskFunction;
            //LoggerEvs.writeLog("DFP method started");
            Vector<double> grad = Vector<double>.Build.Dense(2,0);
            xk = basicX;
            Matrix<double> Hk_1 = Matrix<double>.Build.DenseIdentity(2);
            Matrix<double> Hk = Matrix<double>.Build.DenseIdentity(2);
            Hk[0, 0] = 1;
            Hk[1, 1] = 1;
            Hk[0, 1] = 0;
            Hk[1, 0] = 0;
            double ak;
            double normalize=0;
            //LoggerEvs.writeLog(string.Format("Input data. Start point {0}, epsilon {1:N5}", basicX, eps));
        step1:
            //LoggerEvs.writeLog(string.Format("Step 1: K = 0"));
            int k = 0;
        step2:
            //LoggerEvs.writeLog(string.Format("Step 2: ITERATION number {0}", k));
            Vector2 gradTemp = Gradient.get(scale, new Vector2(xk[0], xk[1]), taskFunction);
            grad[0] = gradTemp.X;
            grad[1] = gradTemp.Y;
        step3:
            normalize = grad.L2Norm();
            if (normalize <= eps)
            {
                //LoggerEvs.writeLog(string.Format("Step 3: End of searching. Final values: Function = {0}, Point = {1}. Go to step 12.", taskFunction(new Vector2(xk[0], xk[1])), xk));
                goto step12;
            }
        step4:
            if (k == 0)
            {
                //LoggerEvs.writeLog("Step 4: K==0, go to step 8.");
                goto step8;
            }
        step5:
            sk = xk - xk_1;
            //LoggerEvs.writeLog(string.Format("Step 5: Sk = {0}", sk));
        step6:
            Vector2 ykTemp = Gradient.get(scale, new Vector2(xk[0], xk[1]), taskFunction) - Gradient.get(scale, new Vector2(xk_1[0], xk_1[1]), taskFunction);
            yk[0] = ykTemp.X;
            yk[1] = ykTemp.Y;
            //LoggerEvs.writeLog(string.Format("Step 6: Yk = {0}", yk));
        step7:
            Hk_1 = Hk;
            Matrix<double> firstUp =  Hk_1*yk.ToColumnMatrix()*yk.ToRowMatrix()*Hk_1;
            Matrix<double> firstDown = yk.ToRowMatrix()*Hk_1*yk.ToColumnMatrix();
            Matrix<double> secondUp = sk.ToColumnMatrix()*sk.ToRowMatrix();
            Matrix<double> secondDown =  yk.ToRowMatrix()*sk.ToColumnMatrix();
            
            Hk = Hk_1 - firstUp / firstDown[0, 0] + secondUp / secondDown[0, 0];
            //LoggerEvs.writeLog(string.Format("Step 7: Quasi-Newton matrix: \r\n{0}", Hk));
        step8:
            Vector2 tempPk = Gradient.get(scale, new Vector2(xk[0], xk[1]), taskFunction);
            Vector<double> test = Vector<double>.Build.Dense(2, 0);
            test[0] = tempPk.X;
            test[1] = tempPk.Y;
            pk = -1*Hk * test;
            
            //LoggerEvs.writeLog(string.Format("Step 8: Search vector: {0}", pk));
        step9:
            Vector<double> tmpxk = xk + alpha * pk;
            vec2XKmod = new Vector2(tmpxk[0], tmpxk[1]);
            Vector2 gradientValue = Gradient.get(scale, vec2XKmod, taskFunction);
            double inputOrder = OptimalGradientMethod.findPositiveOrder(Math.Max(Math.Abs(basicX[0]), Math.Abs(basicX[1])));
            double dichotomyEpsilon = OptimalGradientMethod.countDichotomyEps(inputOrder);
            LinearInterval alphaValues = LocalizationMethod.calculate(alpha,eps,minimizeFunc);
            alpha = DichotomyMethodCounter.findMinimum(taskFunction, new Interval(alphaValues.LeftBorder,alphaValues.RightBorder), dichotomyEpsilon, vec2XKmod, gradientValue);//pouelMethod.calculate(alphaValues,eps/10,minimizeFunc);
            //LoggerEvs.writeLog(string.Format("Step 9: New alpha {0}", alpha));
        step10:
            xk_1 = xk;
            xk = xk + alpha * pk;//??
            //LoggerEvs.writeLog(string.Format("Step 10: New local search point {0}", xk));
        step11:
            k++;
            //LoggerEvs.writeLog("Step 11: Iteration end.");
            if (k >= 50)
                goto step12;
            goto step2;
        step12:
            //LoggerEvs.writeLog("Step 12: Search is done!");
            Vector2 result = new Vector2(xk[0], xk[1]);
            return result;
        }

        public double minimizeFunc(double arg)
        {
            var res = func(new Vector2((xk + arg * pk)[0],(xk + arg * pk)[1]));
            return res;
        }

        public Vector2 returnApproximateSolution(Vector2 x, double eps, Func<Vector2, double> taskFunction)
        {
            setStartingVariables(x, eps);
            return calculate(taskFunction);
        }
    }
}
