using System.Collections.Generic;
using System;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int amountOfIterations;
            int maxLength;
            int maxNumber;
            int amountOfDataPoints;

            // Gets variable information from user to develop data set

            try
            {
                Console.Write("Enter an amount of random arrays to sort for each array length: ");
                amountOfIterations = int.Parse(Console.ReadLine());
            } catch (Exception e)
            {
                Console.WriteLine("Input could not be understood as an integer. Defaulting to 100 random arrays each");
                amountOfIterations = 100;
            }

            try
            {
                Console.Write("Enter maximum array length: ");
                maxLength = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Input could not be understood as an integer. Defaulting to maximum length of 1000");
                maxLength = 1000;
            }

            try
            {
                Console.Write("Enter the max value of each array: ");
                maxNumber = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Input could not be understood as an integer. Defaulting max value to 2,147,483,646");
                maxNumber = 2147483646;
            }

            try
            {
                Console.Write("Amount of data points to collect: ");
                amountOfDataPoints = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Input could not be understood as an integer. Defaulting amount of data points to 50");
                amountOfDataPoints = 50;
            }



            List<double> selectionTimes = new List<double>();           // Collects the time data from the runs
            List<double> insertionTimes = new List<double>();
            List<double> radixLSDTimes = new List<double>();
            List<double> quicksortTimes = new List<double>();
            List<double> mergeTimes = new List<double>();
            List<double> bubbleTimes = new List<double>();
            List<double> cocktailTimes = new List<double>();
            List<double> bucketTimes = new List<double>();


            var watch = System.Diagnostics.Stopwatch.StartNew();

            // Independently sorts the algorithms the specified amount of times

            for (int length = maxLength / amountOfDataPoints; length <= maxLength; length += maxLength / amountOfDataPoints)
            {
                Console.WriteLine(String.Format("Algorithm speeds for {0} iterations, array length of {1}, and maximum number of {2}", amountOfIterations, length, maxNumber));

                for (int i = 0; i < amountOfIterations; i++)
                {
                    SelectionSort(RandomGenerator(length, maxNumber));
                }
                selectionTimes.Add(watch.ElapsedMilliseconds / 1000.0);
                Console.WriteLine(watch.Elapsed + "  :  " + length + "  :  Selection Sort");
                watch.Restart();

                for (int i = 0; i < amountOfIterations; i++)
                {
                    InsertionSort(RandomGenerator(length, maxNumber));
                }
                insertionTimes.Add(watch.ElapsedMilliseconds / 1000.0);
                Console.WriteLine(watch.Elapsed + "  :  " + length + "  :  Insertion Sort");
                watch.Restart();

                for (int i = 0; i < amountOfIterations; i++)
                {
                    RadixLSD(RandomGenerator(length, maxNumber));
                }
                radixLSDTimes.Add(watch.ElapsedMilliseconds / 1000.0);
                Console.WriteLine(watch.Elapsed + "  :  " + length + "  :  Radix LSD Sort");
                watch.Restart();

                for (int i = 0; i < amountOfIterations; i++)
                {
                    QuickSort(RandomGenerator(length, maxNumber));
                }
                quicksortTimes.Add(watch.ElapsedMilliseconds / 1000.0);
                Console.WriteLine(watch.Elapsed + "  :  " + length + "  :  QuickSort");
                watch.Restart();

                for (int i = 0; i < amountOfIterations; i++)
                {
                    MergeSort(RandomGenerator(length, maxNumber));
                }
                mergeTimes.Add(watch.ElapsedMilliseconds / 1000.0);
                Console.WriteLine(watch.Elapsed + "  :  " + length + "  :  Merge Sort");
                watch.Restart();

                for (int i = 0; i < amountOfIterations; i++)
                {
                    BubbleSort(RandomGenerator(length, maxNumber));
                }
                bubbleTimes.Add(watch.ElapsedMilliseconds / 1000.0);
                Console.WriteLine(watch.Elapsed + "  :  " + length + "  :  Bubble Sort");
                watch.Restart();

                for (int i = 0; i < amountOfIterations; i++)
                {
                    CocktailShaker(RandomGenerator(length, maxNumber));
                }
                cocktailTimes.Add(watch.ElapsedMilliseconds / 1000.0);
                Console.WriteLine(watch.Elapsed + "  :  " + length + "  :  Cocktail Shaker Sort");
                watch.Restart();

                for (int i = 0; i < amountOfIterations; i++)
                {
                    RecursiveBucketSort(RandomGenerator(length, maxNumber));
                }
                bucketTimes.Add(watch.ElapsedMilliseconds / 1000.0);
                Console.WriteLine(watch.Elapsed + "  :  " + length + "  :  Recursive Bucket Sort");
                watch.Restart();

                Console.WriteLine();
            }

            // Writes out all of the times in one easily accessible data set of comma separated values

            Console.WriteLine("Selection Sort Times:");
            WriteList(selectionTimes);

            Console.WriteLine("Insertion Sort Times:");
            WriteList(insertionTimes);

            Console.WriteLine("Radix LSD Sort Times:");
            WriteList(radixLSDTimes);

            Console.WriteLine("QuickSort Times:");
            WriteList(quicksortTimes);

            Console.WriteLine("Merge Sort Times:");
            WriteList(mergeTimes);

            Console.WriteLine("Bubble Sort Times:");
            WriteList(bubbleTimes);

            Console.WriteLine("Cocktail Sort Times:");
            WriteList(cocktailTimes);

            Console.WriteLine("Bucket Sort Times:");
            WriteList(bucketTimes);



            Console.ReadKey();
        }
        
        /// <summary>
        /// Simple Bubble Sort compares the value to the right of the value and tests if it is smaller, then will switch if so
        /// Returns the array if it goes through once without any change
        /// </summary>
        /// <param name="unsortedInts">unsorted array of integers (int[])</param>
        /// <returns>the sorted version of the integers (int[])</returns>
        public static int[] BubbleSort(int[] unsortedInts)
        {
            int[] previousSort = new int[unsortedInts.Length];

            for (int iteration = 0; iteration < unsortedInts.Length - 1; iteration++)       // Iterates through the bubble sort for the length of the array times (worst case)
            {
                for (int i = 0; i < unsortedInts.Length; i++)                   // Copies all current entries to a new array to compare later
                {
                    previousSort[i] = unsortedInts[i];
                }

                for (int ndx = 0; ndx < unsortedInts.Length - 1; ndx++)     // Iterates through the unsorted array, looking for incorrectly paired values
                {
                    int leftSide = unsortedInts[ndx];
                    int rightSide = unsortedInts[ndx + 1];
                    if (leftSide > rightSide)
                    {
                        unsortedInts[ndx] = rightSide;
                        unsortedInts[ndx + 1] = leftSide;
                    }
                }

                bool arrIsSorted = true;
                for (int i = 0; i < unsortedInts.Length; i++)       // Checks to see if the array is the same as before the iteration through bubble sort
                {
                    if (unsortedInts[i] != previousSort[i])
                    {
                        arrIsSorted = false;
                    }
                }
                if (arrIsSorted == true)
                {
                    return unsortedInts;
                }
            }
            return unsortedInts;
        }

        /// <summary>
        /// Selection sort finds the next smallest value in the array and switches it with the current index evaluated
        /// </summary>
        /// <param name="arr">array of unsorted integers</param>
        /// <returns>corresponding array of sorted integers</returns>
        public static int[] SelectionSort(int[] arr)
        {
            for (int ndx = 0; ndx < arr.Length - 1; ndx++)
            {
                int indexOfSmallest = ndx;
                int smallestNumber = arr[ndx];                      // Sets an initial smallest number
                for (int ndy = ndx; ndy < arr.Length; ndy++)
                {
                    if (arr[ndy] < smallestNumber)                  // Finds the smallest number in the remainder of the array
                    {
                        smallestNumber = arr[ndy];
                        indexOfSmallest = ndy;
                    }
                }

                if (ndx != indexOfSmallest)                 // If the smallest number isn't the current number, then it switches the two
                {
                    arr[indexOfSmallest] = arr[ndx];
                    arr[ndx] = smallestNumber;
                }
            }
            return arr;
        }

        /// <summary>
        /// Insertion sort iterates through an array and places the selected value between two values: one above and one below
        /// </summary>
        /// <param name="unsortedArray"></param>
        /// <returns></returns>
        public static int[] InsertionSort(int[] arr)
        {

            for (int indexOfRight = 1; indexOfRight < arr.Length; indexOfRight++)
            {
                int valueOfLeft = arr[indexOfRight];        // Moving variable to search for the value of the lefthand index to put the current number into

                int indexOfLeft = indexOfRight;             // Moving variable to correspond with the value of the lefthand: shows the index

                int valueOfRight = arr[indexOfRight];       // Stationary variable to maintain the value at the selected index

                

                for (int panLeftSide = indexOfRight - 1; panLeftSide >= 0; panLeftSide--)
                {
                    if (arr[panLeftSide] < valueOfRight)               // Loop to look for the first number smaller than the selected value
                    {
                        indexOfLeft = panLeftSide + 1;
                        valueOfLeft = arr[indexOfLeft];
                        break;
                    }
                }

                if (indexOfLeft == indexOfRight && arr[indexOfRight] < arr[indexOfRight - 1])
                {
                    indexOfLeft = 0;                // Checks to see if the currently evaluated number is the smallest number in the array
                    valueOfLeft = arr[0];
                }

                if (indexOfLeft != indexOfRight)        // If the number is not already in the right spot, then it puts it in the right place, and shifts all others to the right
                {
                    for (int panRightSide = indexOfRight; panRightSide > indexOfLeft; panRightSide--)
                    {
                        arr[panRightSide] = arr[panRightSide - 1];
                    }
                    arr[indexOfLeft] = valueOfRight;
                }
            }

            return arr;
        }

        /// <summary>
        /// Radix LSD sorts through an array by first sorting the ones place, then the tens place, then the hundreds place, etc. etc.
        /// This algorithm uses string formatting instead of logarithms for both ease and for optimization, log base 10 function is slow
        /// </summary>
        /// <param name="arr">array to sort</param>
        /// <returns>sorted array</returns>
        public static int[] RadixLSD(int[] arr)
        {
            int maxNumber = 0;
            foreach (int num in arr)            // Finds the maximum number in an array
            {
                if (num > maxNumber)
                {
                    maxNumber = num;
                }
            }

            string[] paddedInts = new string[arr.Length];

            int lengthOfMaxNumber = (int)Math.Log10(maxNumber);

            for (int ndx = 0; ndx < arr.Length; ndx++)      // Pads each of the integers in the array with zeros (e.g. 452, 003, 014, 023)
            {
                string toString = arr[ndx].ToString();
                bool isPadded = false;
                while (!isPadded)
                {
                    if (toString.Length > lengthOfMaxNumber)
                    {
                        isPadded = true;
                    }
                    else
                    {
                        toString = "0" + toString;
                    }
                }
                paddedInts[ndx] = toString;
            }

            int[,] multi = new int[lengthOfMaxNumber + 2, arr.Length];      // Populates a two dimensional array with individual digits and the overall value at the base

            for (int ndy = 0; ndy < multi.GetLength(1); ndy++)              // Places the full values in the bottom row of the array   
            {
                multi[multi.GetLength(0) - 1, ndy] = arr[ndy];
            }
            for (int ndx = 0; ndx < Math.Log10(maxNumber); ndx++)
            {
                for (int ndy = 0; ndy < arr.Length; ndy++)
                {
                    int test1 = int.Parse(((paddedInts[ndy])[ndx]).ToString());     // Puts each digit into the array above the corresponding overall value
                    multi[ndx, ndy] = test1;
                }
            }

            
            for (int ndx = multi.GetLength(0) - 2; ndx >= 0; ndx--)
            {
                int[,] tempMulti = new int[multi.GetLength(0), multi.GetLength(1)];     // Two dimensional counting sort to sort the generated radix multiarray
                int[] count = new int[10];
                for (int ndy = 0; ndy < multi.GetLength(1); ndy++)
                {
                    count[multi[ndx, ndy]]++;                               // Counts how many of a given digit there are
                }
                for (int ndy = 1; ndy < count.Length; ndy++)
                {
                    count[ndy] += count[ndy - 1];                           // Summation of digits to place later indexes
                }

                for (int ndy = multi.GetLength(1) - 1; ndy >= 0; ndy--)         // Places the digits in their correct indexes
                {
                    for (int mbx = 0; mbx < multi.GetLength(0); mbx++)
                    {
                        tempMulti[mbx, count[multi[ndx, ndy]] - 1] = multi[mbx, ndy];       // Shifts the entire columns to the correct index
                    }
                    count[multi[ndx, ndy]]--;
                }
                multi = tempMulti;                      // Reapplies the counting sort to the next digit (e.g. goes from tens place to hundreds)
            }

            for (int ndy = 0; ndy < multi.GetLength(1); ndy++)
            {
                arr[ndy] = multi[multi.GetLength(0) - 1, ndy];      // Creates a new array with only the last line of numbers
            }

            return arr;
        }

        /// <summary>
        /// Splits a given array into the numbers below the average and above the average, then recursively sorts those arrays also
        /// </summary>
        /// <param name="inputArray">unsorted array</param>
        /// <returns>sorted array</returns>
        public static int[] QuickSort(int[] inputArray)
        {
            bool areRepeatingNums = true;
            int length = inputArray.Length;

            for (int ndx = 1; ndx < inputArray.Length; ndx++)       // Checks to see if an array is full of the same number repeating over and over
            {
                if (inputArray[0] != inputArray[ndx])
                {
                    areRepeatingNums = false;
                }
            }

            if (length == 1 || areRepeatingNums)        // Returns the array if it is small or has the same number repeating exclusively
            {
                return inputArray;
            }

            int[] smallerArray = new int[length];
            int[] largerArray = new int[length];

            int min = inputArray[0];
            int max = inputArray[0];

            foreach (int number in inputArray)          // Finds the max and min values of the array to average later
            {
                if (number > max)
                {
                    max = number;
                }
                else if (number < min)
                {
                    min = number;
                }
            }

            int evaluee = ((max - min) / 2) + min;          // Finds the average value of the array to pivot around

            int ndLow = 0;
            int ndHigh = 0;
            foreach (int input in inputArray)               // Splits the original array into two arrays around the average value pivot
            {
                if (input > evaluee)
                {
                    largerArray[ndHigh] = input;
                    ndHigh++;
                }
                else
                {
                    smallerArray[ndLow] = input;
                    ndLow++;
                }
            }
            

            int smallerNonZeros = 0;
            int largerNonZeros = 0;
            for (int i = 0; i < smallerArray.Length; i++)
            {
                smallerNonZeros += (smallerArray[i] != 0) ? 1 : 0;      // Counts the amount of nonzero numbers in each of the split arrays
                largerNonZeros += (largerArray[i] != 0) ? 1 : 0;
            }

            int[] smallerShrunk = new int[smallerNonZeros];
            int[] largerShrunk = new int[largerNonZeros];

            int index = 0;
            for (int j = 0; j < smallerArray.Length; j++)           // Unpads each of the arrays with zeros to create an array of values >0
            {
                if (smallerArray[j] != 0)
                {
                    smallerShrunk[index] = smallerArray[j];
                    index++;
                }
            }

            index = 0;
            for (int j = 0; j < largerArray.Length; j++)
            {
                if (largerArray[j] != 0)
                {
                    largerShrunk[index] = largerArray[j];
                    index++;
                }
            }


            int[] sortedLow = QuickSort(smallerShrunk);     // Recursively sorts each of the two split arrays
            int[] sortedHigh = QuickSort(largerShrunk);
            int[] sortedArray = new int[length];

            for (int ndx = 0; ndx < sortedLow.Length; ndx++)        // Creates a new array by merging the two arrays [smallerShrunk, largerShrunk]
            {
                sortedArray[ndx] = sortedLow[ndx];
            }
            for (int ndy = 0; ndy < sortedHigh.Length; ndy++)
            {
                sortedArray[ndy + sortedLow.Length] = sortedHigh[ndy];
            }

            return sortedArray;
        }
        
        /// <summary>
        /// Merge Sort splits an array directly in half, recurves into itself until it is length=1, then merges the two arrays together
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] MergeSort(int[] arr)
        {
            if (arr.Length == 1)                        // Immediately returns the array if it is length=1 (Prevents an infinite recursion loop)
            {
                return arr;
            }

            int[] leftArr = new int[arr.Length / 2];                            // Creates a left array with half of the numbers (rounded down)
            int[] rightArr = new int[(arr.Length / 2) + (arr.Length % 2)];      // Creates a right array with half of the numbers (rounded up)

            for (int ndx = 0; ndx < arr.Length; ndx++)                      // Places each of the numbers of the original array into their corresponding split array
            {
                if (ndx / leftArr.Length == 0)
                {
                    leftArr[ndx] = arr[ndx];
                }
                else
                {
                    rightArr[ndx - leftArr.Length] = arr[ndx];
                }
            }

            leftArr = MergeSort(leftArr);                               // Recursively sorts each of the smaller arrays
            rightArr = MergeSort(rightArr);

            int comparedRightIndex = 0;
            int comparedLeftIndex = 0;

            for (int ndx = 0; ndx < arr.Length; ndx++)                              // Merges the first and second arrays comparing the first index of each
            {
                if (leftArr[comparedLeftIndex] <= rightArr[comparedRightIndex])     // NOTE: doesn't have to compare all values, since the smaller arrays are sorted it can compare first values
                {
                    arr[ndx] = leftArr[comparedLeftIndex];
                    if (comparedLeftIndex < leftArr.Length - 1)
                    {
                        comparedLeftIndex++;
                    }
                    else
                    {
                        for (int ndw = 1; comparedRightIndex < rightArr.Length; ndw++)      // Triggers if all the values from the left array have been initialized into the new array
                        {
                            arr[ndx + ndw] = rightArr[comparedRightIndex];
                            comparedRightIndex++;
                        }
                        return arr;
                    }
                }
                else
                {
                    arr[ndx] = rightArr[comparedRightIndex];
                    if (comparedRightIndex < rightArr.Length - 1)
                    {
                        comparedRightIndex++;
                    }
                    else
                    {
                        for (int ndw = 1; comparedLeftIndex < leftArr.Length; ndw++)        // Triggers if all of the values from the right array have been added to the new array
                        {
                            arr[ndx + ndw] = leftArr[comparedLeftIndex];
                            comparedLeftIndex++;
                        }
                        return arr;
                    }
                }
            }
            return arr;
        }

        /// <summary>
        /// Maximally optimized Bubble Sort iterates both directions, and stops comparing through the first and last values each iteration
        /// </summary>
        /// <param name="arr">unsorted array</param>
        /// <returns>sorted array</returns>
        public static int[] CocktailShaker(int[] arr)
        {
            for (int i = 0; i < arr.Length / 2; i++)            // Maximum time through iteration (note: not arr.Length like bubble sort)
            {
                int[] lastSortedArr = arr;
                int index = 0;

                while (index < arr.Length - 1 - i)          // Iterates in the forward direction, leaving out the last 'i' values since they are already sorted
                {
                    if (arr[index] > arr[index + 1])        // The bubble sort portion: if the right value is less than the left, switches them
                    {
                        int rightSide = arr[index + 1];
                        arr[index + 1] = arr[index];
                        arr[index] = rightSide;
                    }
                    index++;
                }
                while (index > i)                           // iterates in the backward direction, leaving out the first 'i' values since they are also sorted
                {
                    if (arr[index] < arr[index - 1])
                    {
                        int rightSide = arr[index];         // Bubble sort portion: if left side value is greater than right side, switches them
                        arr[index] = arr[index - 1];
                        arr[index - 1] = rightSide;
                    }
                    index--;
                }
            }
            return arr;
        }

        /// <summary>
        /// Bucket sort creates sqrt(n) buckets evenly incremented, and individually sorts each bucket, then merges them all together
        /// Note: many bucket sorts call an external method to sort each bucket, this sort recursively sorts in itself to minimize code length
        /// </summary>
        /// <param name="arr">unsorted array</param>
        /// <returns>sorted array</returns>
        public static int[] RecursiveBucketSort(int[] arr)
        {

            bool allNumsAreSame = true;                         // Tests to see if each of the numbers in an array are the same, or if the array has nothing in it
            foreach (int number in arr)
            {
                if (arr[0] != number)
                {
                    allNumsAreSame = false;
                }
            }
            if (allNumsAreSame == true || arr.Length == 0)
            {
                return arr;
            }


            int amountOfBuckets = (int)Math.Pow(arr.Length, 0.5) + 1;           // Finds the amount of buckets to optimally sort

            int lengthOfBucket = arr.Length / amountOfBuckets * 5 + 1;          // Arbitrarily decides the length of each bucket
            
            int[,] buckets = new int[amountOfBuckets, lengthOfBucket];          // Creates a multiarray of the buckets

            int maxNumber = 0;
            int minNumber = arr[0];
            foreach (int number in arr)         // Finds the minimum and maximum values of the array
            {
                if (number > maxNumber)
                {
                    maxNumber = number;
                }
                if (number < minNumber)
                {
                    minNumber = number;
                }
            }

            maxNumber++;
            double bucketIncrement = (maxNumber - minNumber) / (double)amountOfBuckets;         // Splits an array into evenly spaced buckets

            for (int currentBucket = 0; currentBucket < amountOfBuckets; currentBucket++)       // Places each of the values from the initial array into their corresponding bucket
            {
                int ndx = 0;
                foreach (int number in arr)
                {
                    if (number < (bucketIncrement * (1 + currentBucket)) + minNumber && number >= (bucketIncrement * currentBucket) + minNumber)
                    {
                        buckets[currentBucket, ndx] = number;
                        ndx++;
                    }
                }
            }


            int[,] cleanBuckets = new int[buckets.GetLength(0), buckets.GetLength(1)];

            for (int i = 0; i < buckets.GetLength(0); i++)              // Sorts each of the rows of the multiarray through recursion through the bucket sort
            {
                int amountOfNonzeros = 0;
                for (int y = 0; y < buckets.GetLength(1); y++)
                {
                    if (buckets[i, y] != 0)                             // Counts the amount of nonzero values in a row to create a new array of that size
                    {
                        amountOfNonzeros++;
                    }
                }

                int[] dirtyArray = new int[amountOfNonzeros];

                int indexOfDirty = 0;
                for (int y = 0; y < buckets.GetLength(1); y++)          // De-pads the bucket from its zeros
                {
                    if (buckets[i, y] != 0)
                    {
                        dirtyArray[indexOfDirty] = buckets[i, y];
                        indexOfDirty++;
                    }
                }


                int[] cleanArray = RecursiveBucketSort(dirtyArray);     // Recursively applies the bucket sort to the row of the multiarray (each bucket)

                for (int j = 0; j < cleanArray.Length; j++)             // Places the sorted bucket into the initial multiarray
                {
                    cleanBuckets[i, j] = cleanArray[j];
                }
            }


            List<int> returnList = new List<int>();
            for (int bucketNumber = 0; bucketNumber < cleanBuckets.GetLength(0); bucketNumber++)        // Merges the buckets back together using a list for ease
            {
                for (int indexNumber = 0; indexNumber < cleanBuckets.GetLength(1); indexNumber++)
                {
                    if (cleanBuckets[bucketNumber, indexNumber] != 0)
                    {
                        returnList.Add(cleanBuckets[bucketNumber, indexNumber]);
                    }
                }
            }

            int[] returnArray = new int[returnList.Count];      // Copies the list to an array, then returns
            returnList.CopyTo(returnArray);

            return returnArray;
        }

        /// <summary>
        /// Randomizes all of the numbers in an array with a given array length and random number
        /// </summary>
        /// <param name="length">length of the desired array</param>
        /// <param name="maxNumber">maximum possible generated value in the array</param>
        /// <returns>randomized integer array</returns>
        public static int[] RandomGenerator(int length, int maxNumber)
        {
            int[] randomArray = new int[length];
            Random randomInt = new Random();

            for (int ndx = 0; ndx < length; ndx++)
            {
                randomArray[ndx] = randomInt.Next(1, maxNumber + 1);
            }
            return randomArray;
        }
        
        /// <summary>
        /// Writes all of the values in a list to the console
        /// </summary>
        /// <param name="times">List of values to write to the console</param>
        public static void WriteList(List<double> times)
        {
            string output = "";
            foreach (double time in times)
            {
                output += time + ", ";
            }
            Console.WriteLine(output + "\r\n");
        }
    }
}
