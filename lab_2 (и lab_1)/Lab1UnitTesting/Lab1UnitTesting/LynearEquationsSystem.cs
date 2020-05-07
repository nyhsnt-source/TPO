using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1UnitTesting
{
    public class LynearEquationsSystem
    {
        #region Fields
        private double[,] coefs_;
        private double[] res_;
        private double[] tmp_;
        private String formEx = "Expected a 2D array 3x3 or 2x2";
        private String argEx = "Determinant equels to 0";
        #endregion

        #region Constructors
        public LynearEquationsSystem() { }
        public LynearEquationsSystem(double[,] coefs) 
        {
            SetCoefs(coefs);
        }
        #endregion

        #region Methods

        public double[] Solve() 
        {
            if (coefs_.GetLength(0) != coefs_.GetLength(1) && coefs_.GetLength(0) != 2 || coefs_.GetLength(0) != 3)
                throw new System.FormatException(formEx);
            if (Det() == 0)
                throw new System.ArgumentException(argEx);
            res_ = new double[coefs_.GetLength(0)];
            double[,] initial_coefs = coefs_;
            double[] initial_tmps = tmp_;
            GaussSolve();
            return res_;
        }
        public double Det()
        {
            double res=0.0;

            if (coefs_.GetLength(0) == 2)
                res = coefs_[0,0] * coefs_[1,1] - coefs_[0,1] * coefs_[1,0];
            else if (coefs_.GetLength(0) == 3)
                res = coefs_[0, 0] * coefs_[1, 1] * coefs_[2, 2] + coefs_[0, 1] * coefs_[1, 2] * coefs_[2, 0]
                    + coefs_[0, 2] * coefs_[1, 0] * coefs_[2, 1] - coefs_[0, 1] * coefs_[1, 0] * coefs_[2, 2] 
                    - coefs_[0, 2] * coefs_[1, 1] * coefs_[2, 0] - coefs_[0, 0] * coefs_[1, 2] * coefs_[2, 1];
            return res;
        }
        public void SetCoefs(double[,] coefs)
        {
            coefs_ = new double[coefs.GetLength(0), coefs.GetLength(0)];
            tmp_ = new double[coefs.GetLength(0)];
            for (int i = 0; i<coefs.GetLength(0); i++)
            {
                for (int j = 0; j < coefs.GetLength(1); j++)
                {
                    if (j == 3)
                        tmp_[i] = coefs[i, j];
                    else
                        coefs_[i, j] = coefs[i, j];
                }
            }
        }

        private int[] InitIndex()
        {
            int[] index = new int[coefs_.GetLength(0)];
            for (int i = 0; i < index.Length; ++i)
                index[i] = i;
            return index;
        }

        // поиск главного элемента в матрице
        private double FindR(int row, int[] index)

        {
            int max_index = row;
            double max = coefs_[row, index[max_index]];
            double max_abs = Math.Abs(max);
            //if(row < size - 1)
            for (int cur_index = row + 1; cur_index < coefs_.GetLength(0); ++cur_index)
            {
                double cur = coefs_[row, index[cur_index]];
                double cur_abs = Math.Abs(cur);
                if (cur_abs > max_abs)
                {
                    max_index = cur_index;
                    max = cur;
                    max_abs = cur_abs;
                }
            }

            // меняем местами индексы столбцов
            int temp = index[row];
            index[row] = index[max_index];
            index[max_index] = temp;

            return max;

        }

        // Нахождение решения СЛУ методом Гаусса

        private void GaussSolve()
        {
            int[] index = InitIndex();
            GaussForwardStroke(index);
            GaussBackwardStroke(index);
        }

        // Прямой ход метода Гаусса
        private void GaussForwardStroke(int[] index)
        {
            // перемещаемся по каждой строке сверху вниз
            for (int i = 0; i < coefs_.GetLength(0); ++i)
            {
                // 1) выбор главного элемента
                double r = FindR(i, index);
                // 2) преобразование текущей строки матрицы A
                for (int j = 0; j < coefs_.GetLength(0); ++j)
                    coefs_[i, j] /= r;

                // 3) преобразование i-го элемента вектора b
                tmp_[i] /= r;

                // 4) Вычитание текущей строки из всех нижерасположенных строк

                for (int k = i + 1; k < coefs_.GetLength(0); ++k)
                {
                    double p = coefs_[k, index[i]];
                    for (int j = i; j < coefs_.GetLength(0); ++j)
                        coefs_[k, index[j]] -= coefs_[i, index[j]] * p;
                    tmp_[k] -= tmp_[i] * p;
                    coefs_[k, index[i]] = 0.0;
                }
            }
        }



        // Обратный ход метода Гаусса

        private void GaussBackwardStroke(int[] index)
        {
            // перемещаемся по каждой строке снизу вверх

            for (int i = coefs_.GetLength(0) - 1; i >= 0; --i)
            {
                // 1) задаётся начальное значение элемента x
                double x_i = tmp_[i];
                // 2) корректировка этого значения
                for (int j = i + 1; j < coefs_.GetLength(0); ++j)
                    x_i -= res_[index[j]] * coefs_[i, index[j]];
                res_[index[i]] = x_i;
            }
        }

        #endregion
    }
}
