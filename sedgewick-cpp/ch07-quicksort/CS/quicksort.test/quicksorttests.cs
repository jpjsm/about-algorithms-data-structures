namespace quicksort.test;

public class QSUnitTests
{
    [Theory]
    [InlineData(new int[]{0},0,0, new int[]{0})]
    [InlineData(new int[]{0,1},0,1, new int[]{0, 1})]
    [InlineData(new int[]{1,0},0,1, new int[]{0,1})]
    [InlineData(new int[]{0,0},0,1, new int[]{0,0})]
    [InlineData(new int[]{2,1,0},0,2, new int[]{0,1,2})]
    [InlineData(new int[]{9,8,7,6,5,4,3,2,1,0},0,9, new int[]{0,1,2,3,4,5,6,7,8,9})]
    [InlineData(new int[]{9,8,7,6,5,4,3,2,1,0},0,2, new int[]{7,8,9,6,5,4,3,2,1,0})]
    [InlineData(new int[]{9,9,9,9,9,8,8,8,8,8},0,9, new int[]{8,8,8,8,8,9,9,9,9,9})]
    public void quicksorttest(int[] A, int l, int r, int[] expected)
    {
        QS.Quicksort(A, l, r);
        Assert.Equal(expected, A);
    }
}
