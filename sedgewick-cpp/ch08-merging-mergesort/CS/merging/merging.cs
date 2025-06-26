using System.Runtime.ExceptionServices;

namespace merging;

public static class Merging
{
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
        for (int l = 0, r = A.Length-1, c = 0; c < C.Length; c++)
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
}
