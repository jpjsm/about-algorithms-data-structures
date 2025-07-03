using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace binarytree;

public class BinaryTreeInts: BinaryTree<int>
{
    private List<int> values = [];
    private BinaryTree<int>? left = null;
    private BinaryTree<int>? right = null;


    public BinaryTreeInts(int value)
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
        LevelTraverse(this, 0, levelnodes);

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
        BalanceTree(this);
    }

    /// <summary>
    /// Remove and return value if exists, otherwise return null.
    /// </summary>
    /// <param name="value">The value to remove.</param>
    /// <returns>Value if exists, otherwise return null</returns>
    public void RemoveValue(T value)
    {
        List<BinaryTree<T>> ancestry = [];
        if (!Exists(value, this, ancestry)) return;

        int itemIndex = ancestry.Count - 1;
        int parentIndex = itemIndex - 1;

        // trivial case: value has duplicates
        if (ancestry[itemIndex].values.Count > 1)
        {
            int lastDuplicate = ancestry[itemIndex].values.Count - 1;
            ancestry[itemIndex].values.RemoveAt(lastDuplicate);
            return;
        }

        BinaryTree<T> parentNode = parentIndex >= 0 ? ancestry[parentIndex] : this;

        BalanceTreeWithRemove(ref parentNode, value);
        return;
    }

    public static void BalanceTree(BinaryTree<T> tree)
    {
        BalanceTreeWithRemove(ref tree);
    }

    public static void BalanceTreeWithRemove(ref BinaryTree<T> tree, T? removeMe = null, int removeCount = 1)
    {
        List<T> sortedList = [.. tree.ToListAscending()];
        if (removeMe != null)
        {
            if (removeCount == -1) // Remove all
            {
                sortedList.RemoveAll(r => r.CompareTo(removeMe) == 0);
            }
            else
            {
                for (int i = 0; i < removeCount; i++)
                {
                    sortedList.Remove((T)removeMe);
                }
            }
        }

        if (sortedList.Count == 0)
        {
            tree = null;
            return;
        }

        HashSet<T> uniques = new HashSet<T>();
        List<T> insertList = new List<T>();
        List<T> duplicates = new List<T>();

        foreach (T item in sortedList)
        {
            if (!uniques.Contains(item))
            {
                insertList.Add(item);
            }
            else
            {
                duplicates.Add(item);
            }
        }

        List<int> insertIndexes = LRSplits(0, insertList.Count - 1);

        tree.left = null;
        tree.right = null;
        tree.values = [insertList[insertIndexes[0]]];
        insertIndexes.RemoveAt(0);
        foreach (int index in insertIndexes)
        {
            tree.Insert(insertList[index]);
        }

        foreach (T dup in duplicates)
        {
            tree.Insert(dup);
        }
    }

    public static T? Floor(T target, BinaryTree<T> treeNode)
    {
        bool assigned = false;
        T? floor = default(T);
        if (treeNode == null) return assigned ? floor : default(T);

        BinaryTree<T> current = treeNode;
        while (current != null)
        {
            int comparison = target.CompareTo(current.Value);
            switch (comparison)
            {
            case 0: // Found exact match;
                return current.Value; 

            case -1: // target is smaller
                current = current.left;
                break;

            case 1: // target is larger
                    floor = current.Value;
                    current = current.right;
                break;

            default:
                throw new ApplicationException($"CompareTo method returns value outside the expected ones [-1, 0, 1], received value: {comparison}");
            }            
        }

        return default(T);
    }

    public static T? Ceiling(T target, BinaryTree<T> treeNode)
    {
        T? floor = default;
        if (treeNode == null) return floor;

        BinaryTree<T> current = treeNode;
        while (current != null)
        {
            int comparison = target.CompareTo(current.Value);
            switch (comparison)
            {
            case 0: // Found exact match;
                return current.Value; 

            case -1: // target is smaller
                floor = current.Value;
                current = current.left;
                break;

            case 1: // target is larger
                current = current.right;
                break;

            default:
                throw new ApplicationException($"CompareTo method returns value outside the expected ones [-1, 0, 1], received value: {comparison}");
            }            
        }

        return floor;
    }
    public static bool Exists(T target, BinaryTree<T> tree, List<BinaryTree<T>> ancestry)
    {
        ancestry.Add(tree);

        int comparison = target.CompareTo(tree.values[0]);

        switch (comparison)
        {
            case 0: //value and target are equal
                return true;

            case -1: //target less than value
                if (tree.left == null) return false;
                return Exists(target, tree.left, ancestry);

            case 1: // target greater than value
                if (tree.right == null) return false;
                return Exists(target, tree.right, ancestry);
            default:
                throw new ApplicationException("CompareTo method returns value different than -1, 0, 1.");
        }
    }
    private static void LevelTraverse(BinaryTree<T> n, int level, Dictionary<int, List<T>> levelnodes)
    {
        if (!levelnodes.ContainsKey(level))
        {
            levelnodes[level] = [];
        }

        levelnodes[level].AddRange(n.values);
        if (n.left != null) LevelTraverse(n.left, level + 1, levelnodes);
        if (n.right != null) LevelTraverse(n.right, level + 1, levelnodes);
    }

/// <summary>
/// This helper function generates the list of indices to create a balanced tree
/// from an ordered list.
/// </summary>
/// <param name="l">The left end of the partition</param>
/// <param name="r">The right end of the partition</param>
/// <returns>The list of indices to use to create a balanced tree.</returns>
    private static List<int> LRSplits(int l, int r)
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
        results.AddRange(LRSplits(mid + 1, r));
        results.AddRange(LRSplits(l, mid - 1));

        return results;
    }

/// <summary>
/// Calculate the height of the tree to the deepest leaf node.
/// </summary>
/// <param name="n">The top node to calculate height</param>
/// <returns></returns>
    private static int TreeHeight(BinaryTree<T> n)
    {
        int leftHeight = 0;
        int rightHeight = 0;

        if (n.left != null)
        {
            leftHeight = TreeHeight(n.left) + 1;
        }

        if (n.right != null)
        {
            rightHeight = TreeHeight(n.right) + 1;
        }

        return leftHeight > rightHeight ? leftHeight : rightHeight;
    }
}
