using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

    // Complete the workbook function below.
    static int workbook(int n, int k, int[] arr)
    {
        int specialProblems = 0;
        int page = 1;
        for (int chapter = 1; chapter <= n; chapter++)
        {
            int problemsInChapter = arr[chapter - 1];
            int pagesInChapter =
                (problemsInChapter / k) + (problemsInChapter % k == 0 ? 0 : 1);

            int firstProblemOnPage = 1;
            for (int p = 1; p <= pagesInChapter; p++)
            {
                // Determine the last problem on the page
                int lastProblemOnPage =  
                    (firstProblemOnPage + k - 1 <= problemsInChapter 
                        ? firstProblemOnPage + k - 1
                        : firstProblemOnPage + (problemsInChapter % k) - 1);

                // Is the page # between the first and last problems on the page
                if (firstProblemOnPage <= page && page <= lastProblemOnPage)
                {
                    specialProblems++;
                }

                // next page
                page += 1;
                firstProblemOnPage += k;
            }

        }

        return specialProblems;
    }

    static void Main(string[] args)
    {
        int n = 5;

        int k = 3;

        int[] arr = new int[] { 4, 2, 6, 1, 10 };
        int result = workbook(n, k, arr);

        Console.WriteLine(result);
    }
}
