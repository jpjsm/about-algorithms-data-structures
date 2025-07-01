namespace arrays.test;

public class ArraysTest
{
    [Theory]
    [InlineData(10,new int[]{2,3,5,7,11})]
    [InlineData(20,new int[]{2,3,5,7,11, 13, 17, 19})]
    [InlineData(100,new int[]{2,3,5,7,11,13,17,19,23,29,31,37,41,43,47,53,59,61,67,71,73,79,83,89,97,101})]
    public void Eratosthenes(int n, int[] expected)
    {
        int[] actual = Arrays.Eratosthenes(n);
        string values = string.Join(',', actual.Select(p => p.ToString()));
        Assert.Equal(expected, actual);
    }
}
