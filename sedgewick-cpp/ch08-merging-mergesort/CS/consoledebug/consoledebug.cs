using merging;

namespace consoledebug
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            string[] A = new string[] {"1","11","13","3","5","7","9"};
            string[] B = new string[] {"2","23", "29","41", "43","6"};
            string[] expected = new string[] {"1","11","13","2","23","29","3","41","43","5","6","7","9"};
            string[] actual = Merging.MergeArrays(A, B);

            if (actual.Length != expected.Length)
            {
                Console.WriteLine($"actual [{string.Join(",", actual.Select(n => $"{n}"))}] != [{string.Join(",", expected.Select(n => $"{n}"))}] expected");
            }
            else
            {
                for (int i = 0; i < actual.Length; i++)
                {
                    Console.WriteLine($"actual [{string.Join(",", actual.Select(n => $"{n}"))}] != [{string.Join(",", expected.Select(n => $"{n}"))}] expected");
                }
            }

            Console.WriteLine("Done!");
        }
    }
}