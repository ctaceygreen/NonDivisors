using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution
{
    public static void Main(string[] args)
    {
        int[] intArray = new int[args.Length];
        for(int i = 0; i < args.Length; i++)
        {
            intArray[i] = int.Parse(args[i]);
        }
        solution(intArray);
    }
    public static int[] solution(int[] A)
    {
        // write your code in C# 6.0 with .NET 4.5 (Mono)

        int nIntCount = A.Length; // = N in problem statement
        int nMaxInt = nIntCount + nIntCount; // max possible input int; problem statement specifies this
        int[] anIntCounts = new int[nMaxInt + 1]; // array of counters for all possible input ints
                                                  // (plus a never-used counter for 0)
        int[] anDivisorCounts = new int[nMaxInt + 1]; // array of counters for counts of divisors
        int[] anNotDivCounts = new int[nIntCount]; // to be returned, length and order same as input array A
        foreach (int a in A) // transform input array A into counts of its ints
            anIntCounts[a]++;
        for (int i = 0; i <= nMaxInt; i++) // cycling thru counter array instead of input array A speeds things up!
            if (anIntCounts[i] > 0) // skip this iteration if input array A didn't have this int
                for (int im = i; im <= nMaxInt; im += i) // mark multiples (they're divisable by this int, of course)
                                                         // since we're in the Sieve of Eratosthenes lesson
                    anDivisorCounts[im] += anIntCounts[i]; // mark by storing input int counts
                                                           // (some counts will never be read)
        for (int i = 0; i < nIntCount; i++)
            anNotDivCounts[i] = nIntCount - anDivisorCounts[A[i]]; // compute counts of non-divisors
                                                                   // (in original order of input array A)
        return anNotDivCounts;
    }
}