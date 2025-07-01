namespace binarytree.test;

public class BinaryTreeTests
{
    [Theory]
    [InlineData(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
    [InlineData(new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
    [InlineData(new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new int[] { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9 })]
    public void BuildTreeTest(int[] inserts, int[] expected)
    {
        BinaryTree<int> bt = new BinaryTree<int>(inserts[0]);
        for (int i = 1; i < inserts.Length; i++)
        {
            bt.Insert(inserts[i]);
        }
        Assert.Equal(expected.ToList(), bt.ToListAscending());
    }

    [Theory]
    [InlineData(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 })]
    [InlineData(new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }, new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 })]
    [InlineData(
        new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
        new int[] { 9,9,8,8,7,7,6,6,5,5,4,4,3,3,2,2,1,1,0,0 }
    )]
    public void ToListDescendingTest(int[] inserts, int[] expected)
    {
        BinaryTree<int> bt = new BinaryTree<int>(inserts[0]);
        for (int i = 1; i < inserts.Length; i++)
        {
            bt.Insert(inserts[i]);
        }
        Assert.Equal(expected.ToList(), bt.ToListDescending());
    }

    [Theory]
    [InlineData(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 9)]
    [InlineData(new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }, 9)]
    [InlineData(new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 9)]
    public void CheckTreeHeightTest(int[] inserts, int expected)
    {
        BinaryTree<int> bt = new BinaryTree<int>(inserts[0]);
        for (int i = 1; i < inserts.Length; i++)
        {
            bt.Insert(inserts[i]);
        }
        Assert.Equal(expected, bt.Height);
    }

    [Theory]
    [InlineData(new int[] { 0 }, 0, 0)]
    [InlineData(new int[] { 0, 1 }, 1, 1)]
    [InlineData(new int[] { 0, 1, 2 }, 2, 1)]
    [InlineData(new int[] { 0, 1, 2, 3 }, 3, 2)]
    [InlineData(new int[] { 0, 1, 2, 3, 4 }, 4, 2)]
    [InlineData(new int[] { 0, 1, 2, 3, 4, 5 }, 5, 2)]
    [InlineData(new int[] { 0, 1, 2, 3, 4, 5, 6 }, 6, 2)]
    [InlineData(new int[] { 0, 1, 2, 3, 4, 5, 6, 7 }, 7, 3)]
    [InlineData(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 9, 3)]
    [InlineData(new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }, 9, 3)]
    [InlineData(new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 9, 3)]
    public void CheckTreeBalancedHeightTest(int[] inserts, int expectedunbalanced, int expectedbalanced)
    {
        BinaryTree<int> bt = new BinaryTree<int>(inserts[0]);
        for (int i = 1; i < inserts.Length; i++)
        {
            bt.Insert(inserts[i]);
        }
        Assert.Equal(expectedunbalanced, bt.Height);
        bt.Balance();
        Assert.Equal(expectedbalanced, bt.Height);
    }

    public static IEnumerable<object[]> ToListLevelTraverseTestData =>
        [
            [new int[] { 0 }, -1, new List<(int level, int item)> { (0,0) }],
            [new int[] { 0 }, 0, new List<(int level, int item)> { (0,0) }],
            [new int[] { 0 }, 1, new List<(int level, int item)> {  }],
            [
                new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                -1,
                new List<(int level, int item)> { (0,9), (0,9), (1,8), (1,8), (2,7), (2,7), (3,6), (3,6), (4,5), (4,5), (5,4), (5,4), (6,3), (6,3),  (7,2), (7,2), (8,1), (8,1), (9,0), (9,0),}
            ],
            [
                new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                7,
                new List<(int level, int item)> { (7,2), (7,2)}
            ],
        ];

    [Theory]
    [MemberData(nameof(ToListLevelTraverseTestData))]
    public void ToListLevelTraverseTest(int[] inserts, int level, List<(int level, int item)> expected)
    {
        BinaryTree<int> bt = new BinaryTree<int>(inserts[0]);
        for (int i = 1; i < inserts.Length; i++)
        {
            bt.Insert(inserts[i]);
        }

        var actual = bt.ToListLevelTraverse(level);
        Assert.Equal(expected, actual);
    }
}
