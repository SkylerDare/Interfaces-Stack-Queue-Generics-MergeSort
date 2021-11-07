using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_4
{
    class MergeSort
    {
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

        private void Sort(IComparable[] a, IComparable[] aux, int lo, int hi)
        {
            if (hi <= lo) return;
            int mid = lo + (hi - lo) / 2;
            Sort(a, aux, lo, mid);
            Sort(a, aux, mid + 1, hi);
            Merge(a, aux, lo, mid, hi);
        }


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
