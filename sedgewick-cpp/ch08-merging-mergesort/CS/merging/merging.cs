using System.Runtime.ExceptionServices;

namespace merging;

public static class Merging
{
    /// <summary>
    /// Merges two arrays pre-sorted in ascending order, leaving the items in them in ascending order. 
    /// The arrays are joint over the same 'A' array.
    /// The arguments 'l' and 'm' indicate the beginning and end (both inclusive) of the first array, 
    /// the second array starts at 'm'+1 and ends at 'r' (both inclusive).
    /// </summary>
    /// <typeparam name="T">Any class or structure that implements IComparable</typeparam>
    /// <param name="A">The array with the two sub-arrays.</param>
    /// <param name="l">The index of the first item of the left sub-array</param>
    /// <param name="m">The index of the last item of the left sub-array</param>
    /// <param name="r">The index of the last item of the right sub-array</param>
    public static void Merge<T>(T[] A, int l, int m, int r) where T : IComparable
    {
        string initialState = $"[{string.Join(',', A.Select(a => A.ToString()))}]";
        // C --> auxiliary space
        T[] C = new T[r - l + 1];

        // Let's make a bitonic array
        // Copy left array first to C, in ascending order (the order it is).
        for (int i = l; i <= m; i++)
        {
            C[i - l] = A[i];
        }

        // Copy right array to C, in descending order.
        for (int i = r, j = (m - l) + 1; i > m; i--)
        {
            C[j++] = A[i];
        }

        // Merge both arrays back in A, between l and r
        int leftend = 0, rightend = C.Length - 1;
        for (int i = 0; i < C.Length; i++)
        {
            A[i + l] = C[leftend].CompareTo(C[rightend]) < 0 ? C[leftend++] : C[rightend--];
        }

        Console.WriteLine($"l: {l}, m: {m}, r: {r}, final state [{string.Join(',', A.Select(a => A.ToString()))}] <--  {initialState} initial ");
    }
    public static T[] MergeArrays<T>(T[] A, T[] B) where T : IComparable
    {
        T[] C = new T[A.Length + B.Length];
        for (int a = 0, b = 0, c = 0; c < C.Length; c++)
        {
            if (a == A.Length)
            {
                C[c] = B[b++];
                continue;
            }

            if (b == B.Length)
            {
                C[c] = A[a++];
                continue;
            }

            C[c] = (A[a].CompareTo(B[b]) < 0) ? A[a++] : B[b++];
        }
        return C;
    }


    public static T[] SortBitonic<T>(T[] A) where T : IComparable
    {
        T[] C = new T[A.Length];
        for (int l = 0, r = A.Length - 1, c = 0; c < C.Length; c++)
        {

            C[c] = (A[l].CompareTo(A[r]) < 0) ? A[l++] : A[r--];
        }
        return C;
    }

    public static T[] MergeManyArrays<T>(T[][] Arrays) where T : IComparable
    {
        switch (Arrays.Rank)
        {
            case 0:
                return Array.Empty<T>();

            case 1:
                return Arrays[0];

            case 2:
                return MergeArrays(Arrays[0], Arrays[1]);

            default:
                T[] result = MergeArrays(Arrays[0], Arrays[1]);
                for (int i = 2; i < Arrays.Rank; i++)
                {
                    result = MergeArrays(Arrays[i], result);
                }

                return result;
        }
    }

    public static void MergesortTD<T>(T[] A, int l, int r) where T : IComparable
    {
        if (r <= l) return;

        int m = (l + r) >> 1; // dividing by 2
        MergesortTD(A, m + 1, r);
        MergesortTD(A, l, m);
        Merge(A, l, m, r);
    }

    public static void MergeSortTopDown<T>(T[] A) where T : IComparable
    {
        MergesortTD(A, 0, A.Length - 1);
    }

    public static void MergesortBU<T>(T[] A, int l, int r) where T : IComparable
    {
        for (int binsize = 1; binsize <= r - l; binsize <<= 1) // double i on each loop
        {
            for (int binstart = l; binstart <= r - binsize; binstart += binsize << 1)
            {
                Merge(A, binstart, binstart + binsize - 1, Min(binstart + (binsize << 1) - 1, r));
            }
        }
    }

    public static void MergeSortBottomUp<T>(T[] A) where T : IComparable
    {
        MergesortBU(A, 0, A.Length - 1);
    }
    public static T Min<T>(T a, T b) where T : IComparable
        => a.CompareTo(b) < 0 ? a : b;
}
