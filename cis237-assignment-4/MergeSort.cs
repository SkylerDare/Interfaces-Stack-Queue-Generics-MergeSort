//Skyler Dare
//CIS237
//11/9/21
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_4
{
    class MergeSort
    {
        /// <summary>
        /// Method to create the aux array as a copy of the droid array. Counts the number of objects inside the array to avoid a null reference error.
        /// </summary>
        /// <param name="a">the passed in array of droids</param>
        public void StartSort(IComparable[] a)
        {
            IComparable[] aux = new IComparable[a.Length];
            int count = 0;
            foreach (IDroid droid in a)
            {
                if (droid != null)
                {
                    count++;
                }
            }
            Sort(a, aux, 0, count - 1);
        }
        /// <summary>
        /// splits and sorts the array to prep for the merge.
        /// </summary>
        /// <param name="a">the droid array</param>
        /// <param name="aux">copy of the doid array</param>
        /// <param name="lo">lowest index in the array that holds a value</param>
        /// <param name="hi">highest index in the array that holds a value</param>
        private void Sort(IComparable[] a, IComparable[] aux, int lo, int hi)
        {
            if (hi <= lo) return;
            int mid = lo + (hi - lo) / 2;
            Sort(a, aux, lo, mid);
            Sort(a, aux, mid + 1, hi);
            Merge(a, aux, lo, mid, hi);
        }

        /// <summary>
        /// merges the sorted array by comparing the values inside the array by total cost.
        /// </summary>
        /// <param name="a">droid array</param>
        /// <param name="aux">copy of droid array</param>
        /// <param name="lo">lowest index that stores a value</param>
        /// <param name="mid">the middle index of the array</param>
        /// <param name="hi">the highest index that stores a value</param>
        public void Merge(IComparable[] a, IComparable[] aux, int lo, int mid, int hi) 
        {
            for (int k = lo; k <= hi; k++)
            {
                aux[k] = a[k];
            }

            int i = lo;
            int j = mid + 1;

            for (int k = lo; k<= hi; k++)
            {
                if (i > mid)
                {
                    a[k] = aux[j++];
                }
                else if (j > hi)
                {
                    a[k] = aux[i++];
                }
                else if (aux[j].CompareTo(aux[i]) < 0)
                {
                    a[k] = aux[j++];
                }
                else
                {
                    a[k] = aux[i++];
                }
            }
        }
    }
}
