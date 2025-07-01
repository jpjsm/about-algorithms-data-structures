namespace binarytree;

public class BinaryTree<T> where T : IComparable
{
    private List<T> values = new List<T>();
    private BinaryTree<T>? left = null;
    private BinaryTree<T>? right = null;

    public T Value => values[0];
    public int Height => height(this);

    public BinaryTree(T value)
    {
        values.Add(value);
    }

    public void Insert(T value)
    {
        int comparison = value.CompareTo(Value);

        switch (comparison)
        {
            case 0:
                values.Add(value);
                break;

            case -1:
                if (left == null)
                {
                    left = new BinaryTree<T>(value);
                }
                else
                {
                    left.Insert(value);
                }
                break;

            case 1:
                if (right == null)
                {
                    right = new BinaryTree<T>(value);
                }
                else
                {
                    right.Insert(value);
                }
                break;

            default:
                throw new ApplicationException("Unexpected 'value.CompareTo(Value)' result");

        }
    }

    public List<T> ToListAscending()
    {
        List<T> results = new List<T>();
        if (left != null) results.AddRange(left.ToListAscending());
        results.AddRange(values);
        if (right != null) results.AddRange(right.ToListAscending());
        return results;
    }

    public List<T> ToListDescending()
    {
        List<T> results = new List<T>();
        if (right != null) results.AddRange(right.ToListDescending());
        results.AddRange(values);
        if (left != null) results.AddRange(left.ToListDescending());
        return results;
    }

    public List<(int level,T item)> ToListLevelTraverse(int whichlevel=-1)
    {
        List<(int level,T item)> results = [];
        Dictionary<int, List<T>> levelnodes = [];
        leveltraverse(this, 0, levelnodes);

        if (whichlevel == -1) // list all levels in ascending order 
        {
            foreach (int level in levelnodes.Keys.Order())
            {
                foreach (T item in levelnodes[level])
                {
                    results.Add((level, item));
                }
            }
        }
        else
        {
            if (levelnodes.ContainsKey(whichlevel))
            {
                foreach (T item in levelnodes[whichlevel])
                {
                    results.Add((whichlevel, item));
                }
            }
        }

        return results;
    }

    public void Balance()
    {
        T[] sortedlist = [.. this.ToListAscending()];
        HashSet<T> uniques = new HashSet<T>();
        List<T> insertlist = new List<T>();
        List<T> duplicates = new List<T>();

        foreach (T item in sortedlist)
        {
            if (!uniques.Contains(item))
            {
                insertlist.Add(item);
            }
            else
            {
                duplicates.Add(item);
            }
        }

        List<int> insertindexes = lrsplits(0, insertlist.Count - 1);

        this.left = null;
        this.right = null;
        this.values = new List<T>();
        values.Add(insertlist[insertindexes[0]]);
        insertindexes.RemoveAt(0);
        foreach (int index in insertindexes)
        {
            this.Insert(insertlist[index]);
        }

        foreach (T dup in duplicates)
        {
            this.Insert(dup);
        }
    }
    private static void leveltraverse(BinaryTree<T> n, int level, Dictionary<int, List<T>> levelnodes)
    {
        if (!levelnodes.ContainsKey(level))
        {
            levelnodes[level] = [];
        }

        levelnodes[level].AddRange(n.values);
        if (n.left != null) leveltraverse(n.left, level + 1, levelnodes);
        if (n.right != null) leveltraverse(n.right, level + 1, levelnodes);
    }

/// <summary>
/// This helper function generates the list of indices to create a balanced tree
/// from an ordered list.
/// </summary>
/// <param name="l">The left end of the partition</param>
/// <param name="r">The right end of the partition</param>
/// <returns>The list of indices to use to create a balanced tree.</returns>
    private static List<int> lrsplits(int l, int r)
    {
        List<int> results = new List<int>();
        if (l >= r)
        {
            results.Add(l);
            return results;
        }

        if (l + 1 == r)
        {
            results.Add(r);
            results.Add(l);
            return results;
        }

        if (l + 2 == r)
        {
            results.Add(l + 1);
            results.Add(r);
            results.Add(l);
            return results;
        }

        int mid = (l + r) >> 1;
        results.Add(mid);
        results.AddRange(lrsplits(mid + 1, r));
        results.AddRange(lrsplits(l, mid - 1));

        return results;
    }

/// <summary>
/// Calculate the height of the tree to the deepest leaf node.
/// </summary>
/// <param name="n">The top node to calculate height</param>
/// <returns></returns>
    private static int height(BinaryTree<T> n)
    {
        int leftheight = 0;
        int rightheight = 0;

        if (n.left != null)
        {
            leftheight = height(n.left) + 1;
        }

        if (n.right != null)
        {
            rightheight = height(n.right) + 1;
        }

        return leftheight > rightheight ? leftheight : rightheight;
    }
}
