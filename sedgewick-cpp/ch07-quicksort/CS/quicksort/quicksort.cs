namespace quicksort;

public static class QS
{
    public static void Quicksort<T>(T[] A, int l, int r) where T : IComparable
    {
        if (r <= l) return;

        int pivot = Partition(A, l, r);
        Quicksort(A, l, pivot - 1);
        Quicksort(A, pivot + 1, r);

    }

    public static int Partition<T>(T[] A, int l, int r) where T : IComparable
    {
        if (l >= r) return l;
        T reference = A[(r + l) >> 1] ; // divide by 2
        
        int leftindex = l;
        int rightindex = r;
        while (true)
        {
            while (A[leftindex].CompareTo(reference) < 0) leftindex++; // increment l until an element is greater than pivot element

            while (rightindex > leftindex && A[rightindex].CompareTo(reference) > 0) rightindex--; // decrement r until an element is smaller than pivot element

            if (leftindex >= rightindex) break;

            (A[leftindex], A[rightindex]) = (A[rightindex], A[leftindex]);
            leftindex++;
            rightindex--;
        }

        return leftindex;
    }
}
