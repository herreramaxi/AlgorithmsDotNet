using _5TreesAndGraphs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Trees;

namespace General
{
    class Program
    {
        static void Main(string[] args)
        {


            var p = ""[0];
              var dic = new Dictionary<char,int>();

            var graph1 = new GraphAdjacencyList();
            graph1.AddEdge(1, 2);
            graph1.AddEdge(2,3);
            graph1.AddEdge(2,0);
            graph1.AddEdge(0,1);
            graph1.AddEdge(0, 2);
            graph1.AddEdge(3,3);
            graph1.Print();

            Console.WriteLine();
            var graph2 = new GraphAdjacencyMatrix(4);
            graph2.AddEdge(1, 2);
            graph2.AddEdge(2, 3);
            graph2.AddEdge(2, 0);
            graph2.AddEdge(0, 1);
            graph2.AddEdge(0, 2);
            graph2.AddEdge(3, 3);
            graph2.Print();
            return;
            var minHeap = new MinHeap();
            minHeap.Add(3);
            minHeap.Add(10);
            minHeap.Add(15);
            minHeap.Add(25);
            minHeap.Add(30);
            minHeap.Add(5);
            minHeap.Add(22);
            minHeap.Add(20);
            minHeap.PrintAsArray();
            minHeap.Print();
            minHeap.PrintByLevels();
            Console.WriteLine("height: " +  minHeap.GetHeight());

            var maxHeap = new MaxHeap();
            maxHeap.Add(3);
            maxHeap.Add(10);
            maxHeap.Add(15);
            maxHeap.Add(25);
            maxHeap.Add(30);
            maxHeap.Add(5);
            maxHeap.Add(22);
            maxHeap.Add(20);
            maxHeap.PrintAsArray();
            maxHeap.Print();
            maxHeap.PrintByLevels();
            Console.WriteLine("height: " + maxHeap.GetHeight());

            return;

            var list = new List<int>() { 1, 2, 3, 4, 5, 6 };

            list.ForEach(x => Console.Write($"{x},"));
            list.Insert(1, 99);
            Console.WriteLine();
            list.ForEach(x => Console.Write($"{x},"));
            list.Insert(list.Count,100);
            Console.WriteLine();
            list.ForEach(x => Console.Write($"{x},"));

            //TestTrees();

            return;

            Console.WriteLine(IsSmooth("Marta appreciated deep perpendicular right trapezoids"));
            Console.WriteLine(IsSmooth2("Marta appreciated deep perpendicular right trapezoids"));
            Console.WriteLine(IsSmooth2("Someone is outside the doorway"));
            Console.WriteLine(IsSmooth2(""));
            return;

            Console.WriteLine(CupSwapping(new string[] { "AC", "CA", "CA", "AC" }));
            Console.WriteLine(Cons(new int[] { 5, 3 }));
            Console.WriteLine(Integral(0, 2, 5));

            Console.WriteLine(collatz(10));
            Console.WriteLine(GreaterThanOne("1/2"));// ➞ false
            Console.WriteLine(GreaterThanOne("7/4"));// ➞ true
            Console.WriteLine(GreaterThanOne("10/10"));// ➞ false

            Console.WriteLine(CountVowels("Celebration"));// ➞ 5
            Console.WriteLine(CountVowels("Palm"));// ➞ 1
            Console.WriteLine(CountVowels("Prediction"));//➞ 4

            "".IndexOf("", StringComparison.InvariantCultureIgnoreCase);
            "".Contains("", StringComparison.InvariantCultureIgnoreCase);
            Console.WriteLine(MonthName(3));
            Console.WriteLine(MonthName(12));

            Console.WriteLine("Bubble sort: O(N^2)");
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var sorted = SortNumsAscendingBubble(new int[] { 80, 29, 4, -95, -24, 85 });// ➞ [-95, -24, 4, 29, 80, 85]
            stopwatch.Stop();
            Console.WriteLine($"Elapsed: {stopwatch.ElapsedMilliseconds}ms");
            foreach (var item in sorted)
            {
                Console.Write($"{item},");
            }
            Console.WriteLine();
            //sorted = SortNumsDescBubble(new int[] { 80, 29, 4, -95, -24, 85 });// ➞ [-95, -24, 4, 29, 80, 85]
            //foreach (var item in sorted)
            //{
            //    Console.Write($"{item},");
            //}

            Console.WriteLine("Insert sort: O(N^2)");
            stopwatch.Start();
            sorted = InsertSort(new int[] { 80, 29, 4, -95, -24, 85 });// ➞ [-95, -24, 4, 29, 80, 85]
            stopwatch.Stop();
            Console.WriteLine($"Elapsed: {stopwatch.ElapsedMilliseconds}ms");
            foreach (var item in sorted)
            {
                Console.Write($"{item},");
            }

            Console.WriteLine();
            Console.WriteLine("Merge sort: O(N*log N)");
            stopwatch.Start();
            sorted = MergeSort(new int[] { 80, 29, 4, -95, -24, 85 });// ➞ [-95, -24, 4, 29, 80, 85]
            stopwatch.Stop();
            Console.WriteLine($"Elapsed: {stopwatch.ElapsedMilliseconds}ms");
            foreach (var item in sorted)
            {
                Console.Write($"{item},");
            }

            Console.WriteLine();
            Console.WriteLine("Quick sort: O(N*log N)");
            stopwatch.Start();
            sorted = QuickSort(new int[] { 80, 29, 4, -95, -24, 85 });// ➞ [-95, -24, 4, 29, 80, 85]
            stopwatch.Stop();
            Console.WriteLine($"Elapsed: {stopwatch.ElapsedMilliseconds}ms");
            foreach (var item in sorted)
            {
                Console.Write($"{item},");

            }
            Console.WriteLine();
            var array = ArrayOfMultiples(12, 10);
            foreach (var item in array)
            {
                Console.Write($"{item},");
            }

            Console.Write(ReverseCase("Happy Birthday"));
        }

        private static void TestTrees()
        {
            Trees.BinaryTree bt = new Trees.BinaryTree();
            BTNode node50 = new BTNode(50);
            BTNode node25 = new BTNode(25);
            BTNode node75 = new BTNode(75);
            BTNode node12 = new BTNode(12);
            BTNode node30 = new BTNode(30);
            BTNode node60 = new BTNode(60);
            BTNode node80 = new BTNode(80);
            BTNode node90 = new BTNode(90);

            bt.insertNode(null, node50);
            bt.insertNode(node50, node25);
            bt.insertNode(node50, node75);
            bt.insertNode(node50, node12);
            bt.insertNode(node50, node30);
            bt.insertNode(node50, node60);
            bt.insertNode(node50, node80);
            bt.insertNode(node50, node90);

            Console.WriteLine("preOrderTraversal: root, left and rigth");
            Console.WriteLine("-----------------");
            //root, left and rigth
            bt.preOrderTraversal(node50);
            Console.WriteLine("inOrderTraversal: left,root and rigth");
            Console.WriteLine("-----------------");
            //left,root and rigth
            bt.inOrderTraversal(node50);
            Console.WriteLine("postOrderTraversal: left right root");
            Console.WriteLine("-----------------");
            // left right root
            bt.postOrderTraversal(node50);

            BTNode temp = bt.search(20, bt.Root);
            Console.WriteLine("Search 20: " + (temp == null ? "not found" : temp.Element.ToString()));

            temp = bt.search(80, bt.Root);
            Console.WriteLine("Search 80: " + (temp == null ? "not found" : temp.Element.ToString()));
            //        Console.WriteLine("Search: " + temp == null ? "not found" : temp.getElement());

            Console.WriteLine("Node counts: " + bt.countNodes(node50));
            Console.WriteLine("Tree height: " + bt.height(node50));
            Console.WriteLine("Tree height of node " + node25.Element + ": " + bt.height(node25));
        }

        public static bool IsSmooth(string sentence)
        {
            if (string.IsNullOrEmpty(sentence)) return false;

            var words = sentence.ToLower().Split(" ");
            var isSmooth = false;

            for (int i = 0; i < words.Length - 1; i++)
            {
                var firstWord = words[i];
                var secondWord = words[i + 1];
                var lastLetterFirstWord = firstWord[firstWord.Length - 1];
                var firstLetterSecondWord = secondWord[0];

                if (!lastLetterFirstWord.Equals(firstLetterSecondWord)) break;

                if (i == words.Length - 2)
                    isSmooth = true;
            }

            return isSmooth;
        }

        public static bool IsSmooth2(string sentence)
        {
            if (string.IsNullOrEmpty(sentence)) return false;

            var aggregated = sentence
                .ToLower()
                .Split(" ")
                .Aggregate((aggregated, next) => aggregated.Last().Equals(next.First()) ? next : "#");

            return !aggregated.Equals("#");
        }

        public static string CupSwapping(string[] swaps)
        {
            if (swaps == null) new Exception("swaps is null");

            var ballPosition = "B";

            foreach (var swap in swaps)
            {
                if (string.IsNullOrEmpty(swap) || swap.Length != 2)
                    throw new Exception($"swap is null or empty or with length greater than 2: {swap?.Length}");

                if (!swap.Contains(ballPosition, StringComparison.InvariantCultureIgnoreCase))
                    continue;

                var cup0 = swap[0].ToString();
                var cup1 = swap[1].ToString();

                ballPosition = ballPosition == cup0 ? cup1 : cup0;
            }

            return ballPosition.ToString();
        }

        public static int[] ArrayOfMultiples(int num, int length)
        {
            int[] array = new int[length];

            for (int i = 0; i < length; i++)
            {
                array[i] = num * (i + 1);
            }

            return array;
        }

        public static string ReverseCase(string str)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                var character = str[i];

                var convertedCharacter = Char.IsUpper(character) ? Char.ToLower(character) : Char.ToUpper(character);

                sb.Append(convertedCharacter);
            }

            return sb.ToString();
        }

        public static int Factorial(int num)
        {
            for (int i = num - 1; i > 0; i--)
            {
                num *= i;
            }

            return num;
        }

        //Bubble
        public static int[] SortNumsAscendingBubble(int[] arr)
        {
            //O(N^2)

            if (arr == null || arr.Length == 0) return new int[0];

            var newArray = new int[arr.Length];
            Array.Copy(arr, newArray, arr.Length);

            int numbOfElements = newArray.Length;

            for (int i = 0; i < numbOfElements; i++)
            {
                for (int j = 0; j < numbOfElements - 1 - i; j++)
                {
                    var elemAtj = newArray[j];
                    var elemAtjPlus = newArray[j + 1];

                    if (elemAtj > elemAtjPlus)
                    {
                        SwapElements(newArray, j, j + 1);
                    }
                }
            }

            return newArray;
        }

        public static int[] SortNumsDescBubble(int[] arr)
        {
            if (arr == null || arr.Length == 0) return new int[0];

            var newArray = new int[arr.Length];
            Array.Copy(arr, newArray, arr.Length);

            int numbOfElements = newArray.Length;

            for (int i = 0; i < numbOfElements; i++)
            {
                for (int j = 0; j < numbOfElements - 1 - i; j++)
                {
                    var elemAtj = newArray[j];
                    var elemAtjPlus = newArray[j + 1];

                    if (elemAtj < elemAtjPlus)
                    {
                        SwapElements(newArray, j, j + 1);
                    }
                }
            }

            return newArray;
        }

        public static int[] InsertSort(int[] arr)
        {
            //O(N^2)

            if (arr == null || arr.Length == 0) return new int[0];

            var newArray = new int[arr.Length];
            Array.Copy(arr, newArray, arr.Length);

            for (int i = 1; i < newArray.Length; i++)
            {
                var keyElement = newArray[i];
                int pos = i;

                while (pos > 0 && newArray[pos - 1] > keyElement)
                {
                    newArray[pos] = newArray[pos - 1];
                    pos--;
                }

                newArray[pos] = keyElement;
            }
            return newArray;
        }

        //Merge Sort – O(N*log N)
        public static int[] MergeSort(int[] arr)
        {
            if (arr == null || arr.Length == 0) return new int[0];

            var newArray = new int[arr.Length];
            Array.Copy(arr, newArray, arr.Length);

            mergeSort(newArray, 0, newArray.Length - 1);

            return newArray;
        }

        public static void mergeSort(int[] array, int start, int end)
        {
            int mid = 0;

            if (start < end)
            {
                mid = (start + end) / 2;

                mergeSort(array, start, mid);
                mergeSort(array, mid + 1, end);
                merge(array, start, mid, end);
            }
        }

        private static void merge(int[] array, int left, int middle, int right)
        {
            int i = left;
            int j = middle + 1;
            int tempIndex = 0;

            var tempArray = new int[array.Length];

            while (i <= middle && j <= right)
            {
                if (array[i] < array[j])
                {
                    tempArray[tempIndex] = array[i];
                    i++;
                }
                else
                {
                    tempArray[tempIndex] = array[j];
                    j++;
                }

                tempIndex++;
            }

            while (i <= middle)
            {
                tempArray[tempIndex] = array[i];
                i++;
                tempIndex++;
            }

            while (j <= right)
            {
                tempArray[tempIndex] = array[j];
                j++;
                tempIndex++;
            }

            for (i = left, tempIndex = 0; i <= right; i++, tempIndex++)
            {
                array[i] = tempArray[tempIndex];
            }
        }


        //        O(N* log N)  (expected in most of the situations)
        public static int[] QuickSort(int[] arr)
        {
            if (arr == null || arr.Length == 0) return new int[0];

            var newArray = new int[arr.Length];
            Array.Copy(arr, newArray, arr.Length);

            quickSort3(newArray, 0, newArray.Length - 1);

            return newArray;
        }
        public static void quickSort3(int[] array, int l, int r)
        {
            if (l < r)
            {
                int j = partitioning3(array, l, r);
                // sort partitions 
                quickSort3(array, l, j - 1);
                quickSort3(array, j + 1, r);
            }
        }

        private static int partitioning3(int[] array, int l, int r)
        {
            // select pivot element (left-most)
            var pivot = array[l];
            // partition and shuffle around pivot
            int i = l;
            int j = r;
            while (i < j)
            {
                // move right to avoid pivot element
                i += 1;
                // scan right: find elements greater than pivot
                while (i <= r && array[i] < pivot)
                {
                    i++;
                }
                // scan left: find elements smaller than pivot
                while (j >= l && array[j] > pivot)
                {
                    j--;
                }
                if (i <= r && i < j)
                {
                    // swap around pivot
                    SwapElements(array, i, j);
                }
            }

            // put pivot in correct place
            SwapElements(array, l, j);

            return j;
        }


        private static void SwapElements(int[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public enum Months
        {
            January = 1,
            February = 2,
            March = 3,
            April = 4,
            May = 5,
            June = 6,
            July = 7,
            August = 8,
            September = 9,
            October = 10,
            November = 11,
            December = 12,
        }

        public static string MonthName(int num)
        {
            return Enum.GetName(typeof(Months), num);
        }

        public static int CountVowels(string str)
        {
            var count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                var character = str[i].ToString();
                count += "aeiou".IndexOf(character, StringComparison.InvariantCultureIgnoreCase) >= 0 ? 1 : 0;
            }

            return count;
        }

        public static bool GreaterThanOne(string str)
        {
            var tokens = str.Split("/");
            if (tokens.Length != 2) throw new Exception($"Invalid argument: {str}");

            var numerator = Convert.ToInt32(tokens[0]);
            var denominator = Convert.ToInt32(tokens[1]);

            return numerator / (double)denominator > 1;
        }

        public static bool ValidatePIN(string pin)
        {
            if (pin.Length != 4 && pin.Length != 6) return false;

            foreach (var item in pin)
            {
                if (!Char.IsNumber(item)) return false;
            }

            return true;
        }

        private static Func<int, int> _fEven = x => x / 2;
        private static Func<int, int> _fOdd = x => x * 3 + 1;
        public static int collatz(int num)
        {
            int count = 0;

            return collatz(num, count);
        }

        public static int collatz(int num, int count)
        {
            if (num == 1)
                return count;

            count++;
            return collatz(num % 2 == 0 ? _fEven(num) : _fOdd(num), count);
        }

        public static int Integral(int b, int m, int n)
        {
            return Convert.ToInt32(Math.Pow(n, b + 1)) - Convert.ToInt32(Math.Pow(m, b + 1));
        }

        public static string ReverseAndNot(int n)
        {
            //ReverseAndNot(123) ➞ "321123"
            var numberAsString = n.ToString();
            var sb = new StringBuilder();

            for (int i = numberAsString.Length - 1; i >= 0; i--)
            {
                sb.Append(numberAsString[i]);
            }

            sb.Append(numberAsString);

            return sb.ToString();
        }

        //Interview(new int [] { 5, 5, 10, 10, 15, 15, 20, 20], 120 } ➞ "qualified"
        // [very easy, very easy, easy, easy, medium, medium, hard, hard].
        private const int VERY_EASY = 5;
        private const int EASY = 10;
        private const int MEDIUM = 15;
        private const int HARD = 20;
        public static string Interview(int[] arr, int tot)
        {
            if (arr.Length < 8 || tot > 120 ||
           arr[0] > VERY_EASY || arr[1] > VERY_EASY ||
           arr[2] > EASY || arr[3] > EASY ||
           arr[4] > MEDIUM || arr[5] > MEDIUM ||
           arr[6] > HARD || arr[7] > HARD)
                return "disqualified";

            return "qualified";
        }

        public static bool Cons(int[] arr)
        {
            Array.Sort(arr);

            for (int i = arr.Length - 1; i > 0; i--)
            {
                var delta = arr[i] - arr[i - 1];

                if (delta > 1 || delta == 0) return false;
            }

            return true;
        }
    }
}
