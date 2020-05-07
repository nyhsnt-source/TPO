using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1UnitTesting
{
    public class ArrayProcessor
    {
        #region Fields
        #endregion

        #region Constructors
        public ArrayProcessor() { }
        public ArrayProcessor(int[] a) { }
        #endregion

        #region Methods
        /// <summary>
        /// Sort the incoming array without changes in it
        /// 1) quick sort
        /// 2) delete the negative dublicates (if any)
        /// </summary>
        /// <param name="a"></param>
        /// <returns>
        /// Filtered int[] without negative dublicates
        /// </returns>
        public int[] SortAndFilter(int[] a)
        {
            int[] tmp_a=a;

            quickSort(tmp_a, 0, tmp_a.Length - 1);

            int[] test2= DeleteNegDublicates(tmp_a);

            return test2;
        }

        /// <summary>
        /// Delete all negative dublicates
        /// </summary>
        /// <param name="tmp_a"></param>
        /// <returns>
        /// Array without negative dublicates
        /// </returns>
        private int[] DeleteNegDublicates(int[] tmp_a) 
        {
            List<int> test = new List<int>();

            for (int i = 0; i < tmp_a.Length; i++)
            {
                if (i > 0 && tmp_a[i] < 0 && tmp_a[i] == tmp_a[i - 1]) { }
                else
                {
                    test.Add(tmp_a[i]);
                }
            }

            int[] fin = test.ToArray();

            return fin;
        }

        /// <summary>
        /// Sort array
        /// </summary>
        /// <param name="A"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        private static void quickSort(int[] A, int left, int right)
        {
            if (left > right || left < 0 || right < 0) return;

            int index = partition(A, left, right);

            if (index != -1)
            {
                quickSort(A, left, index - 1);
                quickSort(A, index + 1, right);
            }
        }

        /// <summary>
        /// Make the partitions of the array for this kind of sorting alghorithm
        /// </summary>
        /// <param name="A"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        private static int partition(int[] A, int left, int right)
        {
            if (left > right) return -1;

            int end = left;

            int pivot = A[right];    // choose last one to pivot, easy to code
            for (int i = left; i < right; i++)
            {
                if (A[i] < pivot)
                {
                    swap(A, i, end);
                    end++;
                }
            }

            swap(A, end, right);

            return end;
        }

        /// <summary>
        /// Swap the values in the array
        /// </summary>
        /// <param name="A"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        private static void swap(int[] A, int left, int right)
        {
            int tmp = A[left];
            A[left] = A[right];
            A[right] = tmp;
        }
        
        #endregion
    }
}
