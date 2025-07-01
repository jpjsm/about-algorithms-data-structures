namespace arrays;

public static class Arrays
{
    public static int[] Eratosthenes(int n)
    {
        // Let's sieve represent all odd numbers greater equal of three
        // This is because even numbers cannot be primes
        // So: 
        //   sieve[0] -> 3, 
        //   sieve[1] -> 5, 
        //   sieve[2] -> 7, 
        //   sieve[3] -> 9,
        //   sieve[4] -> 11,
        //   sieve[5] -> 13
        //   sieve[6] -> 15
        int[] sieve = new int[n / 2];
        for (int i = 0; i < n / 2; i++)
        {
            sieve[i] = 1;
        }

        for (int i = 0; i < n / 2; i++)
        {
            int k = 2 * i + 3;
            if (sieve[i] == 1)
            {
                for (int j = i + k; j < n / 2; j += k)
                {
                    sieve[j] = 0;
                }
            }
        }

        int primesCount = 1;
        for (int i = 0; i < n / 2; i++)
        {
            if (sieve[i] == 1) primesCount++;
        }

        int[] result = new int[primesCount];
        result[0] = 2;
        int nextPrime = 1;
        for (int i = 0; i < n / 2; i++)
        {
            int k = 2 * i + 3;
            if (sieve[i] == 1) result[nextPrime++] = k;
        }

        return result;
    }
}
