using merging;
namespace unittests;

public class MergingTests
{
    [Theory]
    [InlineData(new int[] { 1, 2 }, 0, 0, 0, new int[] { 1, 2 })]
    [InlineData(new int[] { 1, 2 }, 1, 1, 1, new int[] { 1, 2 })]
    [InlineData(new int[] { 1, 2 }, 0, 0, 1, new int[] { 1, 2 })]
    [InlineData(new int[] { 2, 1 }, 0, 0, 0, new int[] { 2, 1 })]
    [InlineData(new int[] { 2, 1 }, 1, 1, 1, new int[] { 2, 1 })]
    [InlineData(new int[] { 2, 1 }, 0, 0, 1, new int[] { 1, 2 })]
    [InlineData(new int[] { 2, 1 }, 0, 1, 1, new int[] { 1, 2 })]
    [InlineData(new int[] { 4, 3, 2, 1 }, 2, 2, 3, new int[] { 4, 3, 1, 2 })]
    [InlineData(new int[] { 1, 3, 5, 7, 9, 2, 4, 6 }, 0, 4, 7, new int[] { 1, 2, 3, 4, 5, 6, 7, 9 })]
    [InlineData(new int[] { 1, 2, 3, 5, 7, 11, 13, 17, 19, 23 }, 0, 9, 9, new int[] { 1, 2, 3, 5, 7, 11, 13, 17, 19, 23 })]
    [InlineData(new int[] { 1, 2, 3, 5, 7, 11, 13, 17, 19, 23, 1, 2, 3, 5, 7, 11, 13, 17, 19, 23 }, 0, 9, 19, new int[] { 1, 1, 2, 2, 3, 3, 5, 5, 7, 7, 11, 11, 13, 13, 17, 17, 19, 19, 23, 23 })]
    [InlineData(new int[] { 1, 1, 1, 1, 1, 1, 1 }, 0, 0, 6, new int[] { 1, 1, 1, 1, 1, 1, 1 })]
    [InlineData(new int[] { 1, 1, 1, 1, 1, 1, 1 }, 0, 1, 6, new int[] { 1, 1, 1, 1, 1, 1, 1 })]
    [InlineData(new int[] { 1, 1, 1, 1, 1, 1, 1 }, 0, 2, 6, new int[] { 1, 1, 1, 1, 1, 1, 1 })]
    [InlineData(new int[] { 1, 1, 1, 1, 1, 1, 1 }, 0, 3, 6, new int[] { 1, 1, 1, 1, 1, 1, 1 })]
    [InlineData(new int[] { 1, 1, 1, 1, 1, 1, 1 }, 0, 4, 6, new int[] { 1, 1, 1, 1, 1, 1, 1 })]
    [InlineData(new int[] { 1, 1, 1, 1, 1, 1, 1 }, 0, 5, 6, new int[] { 1, 1, 1, 1, 1, 1, 1 })]
    [InlineData(new int[] { 1, 1, 1, 1, 1, 1, 1 }, 0, 6, 6, new int[] { 1, 1, 1, 1, 1, 1, 1 })]
    public void MergeInts(int[] A, int l, int m, int r, int[] expected)
    {
        Merging.Merge(A, l, m, r);

        Assert.Equal(expected, A);
    }

    [Theory]
    [InlineData(new string[] { "1", "2" }, 0, 0, 1, new string[] { "1", "2" })]
    [InlineData(new string[] { "2", "1" }, 0, 0, 1, new string[] { "1", "2" })]
    [InlineData(new string[] { "1", "11", "13", "3", "5", "7", "9", "2", "23", "29", "41", "43", "6" }, 0, 6, 12, new string[] { "1", "11", "13", "2", "23", "29", "3", "41", "43", "5", "6", "7", "9" })]
    [InlineData(new string[] { "a", "b", "c", "d", "", " ", "a", "b", "c", "d" }, 0, 3, 9, new string[] { "", " ", "a", "a", "b", "b", "c", "c", "d", "d" })]
    [InlineData(new string[] { "1", "11", "13", "17", "19", "2", "23", "3", "5", "7" }, 0, 0, 9, new string[] { "1", "11", "13", "17", "19", "2", "23", "3", "5", "7" })]
    [InlineData(new string[] { "1", "11", "13", "17", "19", "2", "23", "3", "5", "7" }, 0, 1, 9, new string[] { "1", "11", "13", "17", "19", "2", "23", "3", "5", "7" })]
    [InlineData(new string[] { "1", "11", "13", "17", "19", "2", "23", "3", "5", "7" }, 0, 2, 9, new string[] { "1", "11", "13", "17", "19", "2", "23", "3", "5", "7" })]
    [InlineData(new string[] { "1", "11", "13", "17", "19", "2", "23", "3", "5", "7" }, 0, 3, 9, new string[] { "1", "11", "13", "17", "19", "2", "23", "3", "5", "7" })]
    [InlineData(new string[] { "1", "11", "13", "17", "19", "2", "23", "3", "5", "7" }, 0, 4, 9, new string[] { "1", "11", "13", "17", "19", "2", "23", "3", "5", "7" })]
    [InlineData(new string[] { "1", "11", "13", "17", "19", "2", "23", "3", "5", "7" }, 0, 5, 9, new string[] { "1", "11", "13", "17", "19", "2", "23", "3", "5", "7" })]
    [InlineData(new string[] { "1", "11", "13", "17", "19", "2", "23", "3", "5", "7" }, 0, 6, 9, new string[] { "1", "11", "13", "17", "19", "2", "23", "3", "5", "7" })]
    [InlineData(new string[] { "1", "11", "13", "17", "19", "2", "23", "3", "5", "7" }, 0, 7, 9, new string[] { "1", "11", "13", "17", "19", "2", "23", "3", "5", "7" })]
    [InlineData(new string[] { "1", "11", "13", "17", "19", "2", "23", "3", "5", "7" }, 0, 8, 9, new string[] { "1", "11", "13", "17", "19", "2", "23", "3", "5", "7" })]
    [InlineData(new string[] { "1", "11", "13", "17", "19", "2", "23", "3", "5", "7" }, 0, 9, 9, new string[] { "1", "11", "13", "17", "19", "2", "23", "3", "5", "7" })]
    [InlineData(new string[] { "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" }, 0, 0, 9, new string[] { "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" })]
    public void MergeStrings(string[] A, int l, int m, int r, string[] expected)
    {
        Merging.Merge(A, l, m, r);

        Assert.Equal(expected, A);
    }

    [Theory]
    [InlineData(new int[] { }, new int[] { }, new int[] { })]
    [InlineData(new int[] { 1 }, new int[] { 2 }, new int[] { 1, 2 })]
    [InlineData(new int[] { 1, 3, 5, 7, 9 }, new int[] { 2, 4, 6 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 9 })]
    [InlineData(new int[] { 1, 2, 3, 5, 7, 11, 13, 17, 19, 23 }, new int[] { }, new int[] { 1, 2, 3, 5, 7, 11, 13, 17, 19, 23 })]
    [InlineData(new int[] { }, new int[] { 1, 2, 3, 5, 7, 11, 13, 17, 19, 23 }, new int[] { 1, 2, 3, 5, 7, 11, 13, 17, 19, 23 })]
    public void MergeArraysInts(int[] A, int[] B, int[] expected)
    {
        int[] actual = Merging.MergeArrays(A, B);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new string[] { }, new string[] { }, new string[] { })]
    [InlineData(new string[] { "1" }, new string[] { "2" }, new string[] { "1", "2" })]
    [InlineData(new string[] { "1", "11", "13", "3", "5", "7", "9" }, new string[] { "2", "23", "29", "41", "43", "6" }, new string[] { "1", "11", "13", "2", "23", "29", "3", "41", "43", "5", "6", "7", "9" })]
    [InlineData(new string[] { "1", "11", "13", "17", "19", "2", "23", "3", "5", "7" }, new string[] { }, new string[] { "1", "11", "13", "17", "19", "2", "23", "3", "5", "7" })]
    [InlineData(new string[] { }, new string[] { "1", "11", "13", "17", "19", "2", "23", "3", "5", "7" }, new string[] { "1", "11", "13", "17", "19", "2", "23", "3", "5", "7" })]
    public void MergeArraysStrings(string[] A, string[] B, string[] expected)
    {
        string[] actual = Merging.MergeArrays(A, B);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new int[] { }, new int[] { })]
    [InlineData(new int[] { 1, 2 }, new int[] { 1, 2 })]
    [InlineData(new int[] { 2, 1 }, new int[] { 1, 2 })]
    [InlineData(new int[] { 1, 2, 3, 4, 4, 3, 2, 1 }, new int[] { 1, 1, 2, 2, 3, 3, 4, 4 })]
    [InlineData(new int[] { 1, 3, 5, 7, 9, 6, 4, 2 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 9 })]
    [InlineData(new int[] { 1, 2, 3, 5, 7, 11, 23, 19, 17, 13 }, new int[] { 1, 2, 3, 5, 7, 11, 13, 17, 19, 23 })]
    public void MergeBitonicInts(int[] A, int[] expected)
    {
        int[] actual = Merging.SortBitonic(A);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new string[] { }, new string[] { })]
    [InlineData(new string[] { "1", "2" }, new string[] { "1", "2" })]
    [InlineData(new string[] { "2", "1" }, new string[] { "1", "2" })]
    [InlineData(new string[] { "1", "11", "13", "3", "5", "7", "9", "6", "43", "41", "29", "23", "2" }, new string[] { "1", "11", "13", "2", "23", "29", "3", "41", "43", "5", "6", "7", "9" })]
    [InlineData(new string[] { "a", "b", "c", "d", "d", "c", "b", "a", " ", "" }, new string[] { "", " ", "a", "a", "b", "b", "c", "c", "d", "d" })]
    [InlineData(new string[] { "1", "11", "13", "17", "19", "2", "23", "3", "5", "7" }, new string[] { "1", "11", "13", "17", "19", "2", "23", "3", "5", "7" })]
    [InlineData(new string[] { "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" }, new string[] { "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" })]
    public void MergeBitonicStrings(string[] A, string[] expected)
    {
        string[] actual = Merging.SortBitonic(A);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new int[] { 1 }, 0, 0, new int[] { 1 })]
    [InlineData(new int[] { 1, 2 }, 0, 1, new int[] { 1, 2 })]
    [InlineData(new int[] { 2, 1 }, 0, 1, new int[] { 1, 2 })]
    [InlineData(new int[] { 3, 2, 1 }, 0, 2, new int[] { 1, 2, 3 })]
    [InlineData(new int[] { 4, 3, 2, 1 }, 0, 3, new int[] { 1, 2, 3, 4 })]
    [InlineData(new int[] { 5, 4, 3, 2, 1 }, 0, 4, new int[] { 1, 2, 3, 4, 5 })]
    [InlineData(new int[] { 6, 5, 4, 3, 2, 1 }, 0, 5, new int[] { 1, 2, 3, 4, 5, 6 })]

    [InlineData(new int[] { 6, 5, 4, 3, 2, 1 }, 0, 0, new int[] { 6, 5, 4, 3, 2, 1 })]
    [InlineData(new int[] { 6, 5, 4, 3, 2, 1 }, 1, 1, new int[] { 6, 5, 4, 3, 2, 1 })]
    [InlineData(new int[] { 6, 5, 4, 3, 2, 1 }, 2, 2, new int[] { 6, 5, 4, 3, 2, 1 })]
    [InlineData(new int[] { 6, 5, 4, 3, 2, 1 }, 3, 3, new int[] { 6, 5, 4, 3, 2, 1 })]
    [InlineData(new int[] { 6, 5, 4, 3, 2, 1 }, 4, 4, new int[] { 6, 5, 4, 3, 2, 1 })]
    [InlineData(new int[] { 6, 5, 4, 3, 2, 1 }, 5, 5, new int[] { 6, 5, 4, 3, 2, 1 })]

    [InlineData(new int[] { 6, 5, 4, 3, 2, 1 }, 0, 1, new int[] { 5, 6, 4, 3, 2, 1 })]
    [InlineData(new int[] { 6, 5, 4, 3, 2, 1 }, 1, 2, new int[] { 6, 4, 5, 3, 2, 1 })]
    [InlineData(new int[] { 6, 5, 4, 3, 2, 1 }, 2, 3, new int[] { 6, 5, 3, 4, 2, 1 })]
    [InlineData(new int[] { 6, 5, 4, 3, 2, 1 }, 3, 4, new int[] { 6, 5, 4, 2, 3, 1 })]
    [InlineData(new int[] { 6, 5, 4, 3, 2, 1 }, 4, 5, new int[] { 6, 5, 4, 3, 1, 2 })]

    [InlineData(new int[] { 1, 3, 5, 7, 9, 2, 4, 6 }, 0, 7, new int[] { 1, 2, 3, 4, 5, 6, 7, 9 })]

    [InlineData(new int[] { 1, 2, 3, 5, 7, 11, 13, 17, 19, 23 }, 0, 9, new int[] { 1, 2, 3, 5, 7, 11, 13, 17, 19, 23 })]
    [InlineData(new int[] { 1, 2, 3, 5, 7, 11, 13, 17, 19, 23, 1, 2, 3, 5, 7, 11, 13, 17, 19, 23 }, 0, 19, new int[] { 1, 1, 2, 2, 3, 3, 5, 5, 7, 7, 11, 11, 13, 13, 17, 17, 19, 19, 23, 23 })]
    [InlineData(new int[] { 1, 1, 1, 1, 1, 1, 1 }, 0, 6, new int[] { 1, 1, 1, 1, 1, 1, 1 })]
    public void MergeSortTDInts(int[] A, int l, int r, int[] expected)
    {
        Merging.MergesortTD(A, l, r);

        Assert.Equal(expected, A);
    }

    [Theory]
    [InlineData(new int[] { 1, 2 }, 0, 1, new int[] { 1, 2 })]
    [InlineData(new int[] { 2, 1 }, 0, 1, new int[] { 1, 2 })]
    [InlineData(new int[] { 3, 2, 1 }, 0, 2, new int[] { 1, 2, 3 })]
    [InlineData(new int[] { 4, 3, 2, 1 }, 0, 3, new int[] { 1, 2, 3, 4 })]
    [InlineData(new int[] { 5, 4, 3, 2, 1 }, 0, 4, new int[] { 1, 2, 3, 4, 5 })]
    [InlineData(new int[] { 6, 5, 4, 3, 2, 1 }, 0, 5, new int[] { 1, 2, 3, 4, 5, 6 })]

    [InlineData(new int[] { 1, 3, 5, 7, 9, 2, 4, 6 }, 0, 7, new int[] { 1, 2, 3, 4, 5, 6, 7, 9 })]

    [InlineData(new int[] { 1, 2, 3, 5, 7, 11, 13, 17, 19, 23 }, 0, 9, new int[] { 1, 2, 3, 5, 7, 11, 13, 17, 19, 23 })]
    [InlineData(new int[] { 1, 2, 3, 5, 7, 11, 13, 17, 19, 23, 1, 2, 3, 5, 7, 11, 13, 17, 19, 23 }, 0, 19, new int[] { 1, 1, 2, 2, 3, 3, 5, 5, 7, 7, 11, 11, 13, 13, 17, 17, 19, 19, 23, 23 })]
    [InlineData(new int[] { 1, 1, 1, 1, 1, 1, 1 }, 0, 6, new int[] { 1, 1, 1, 1, 1, 1, 1 })]
    public void MergeSortBUInts(int[] A, int l, int r, int[] expected)
    {
        Merging.MergesortBU(A, l, r);

        Assert.Equal(expected, A);
    }
}
