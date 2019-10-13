using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgTester
{
    public partial class Form1 : Form
    {
        String enteredWord;
        List<AutoWord> dictWords;
        List<String> testWords;
        public Form1()
        {
            InitializeComponent();
            enteredWord = "";
            dictWords = new List<AutoWord>();
            using (StreamReader sr = new StreamReader("fullDictionary.txt"))
            //using (StreamReader sr = new StreamReader("tempDict.csv"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] seperateKeys = line.Split(',');
                    dictWords.Add(new AutoWord(seperateKeys[0], seperateKeys[1]));
                }

            }
            Console.WriteLine("Dictionary Loaded");
            testWords = new List<String>();
            using (StreamReader sr = new StreamReader("testWords.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    testWords.Add(line);
                }

            }
            Console.WriteLine("test words Loaded");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("test Started");
            button1.Text = "Running";
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            foreach (String word in testWords)
            {
                enteredWord = word;
                List<AutoWord> results = new List<AutoWord>();

                for (int i = 0; i < dictWords.Count; i++)
                {
                    int distance = GetDamerauLevenshteinDistance(enteredWord, dictWords[i].Word);
                    if (distance < 1)
                    {
                        dictWords[i].CurrentDistance = distance / (1 / dictWords[i].Frequency);
                        results.Add(dictWords[i]);
                    }
                }
                int optionCount = 4;
                //IntArrayInsertionSort(results);

                if (results.Count > 1)
                {
                    QuickSort_Recursive(results, 0, results.Count - 1);
                }
                
                if (results.Count < 4)
                {
                    optionCount = results.Count;
                }
                string sent = "Original word: " + word;
                for (int i = 0; i < optionCount; i++)
                {
                    sent += "    pred" + (i + 1) + "  " + results[i].Word;
                }

                File.AppendAllText("quickResults.txt", sent + Environment.NewLine);
            }
            stopWatch.Stop();
            File.AppendAllText("quickResults.txt", "Time Taken: " + stopWatch.ElapsedMilliseconds.ToString() + Environment.NewLine);
            button1.Text = "Done";
            Console.WriteLine("Test finished");
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("test Started");
            button2.Text = "Running";
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            foreach (String word in testWords)
            {
                enteredWord = word;
                List<AutoWord> results = new List<AutoWord>();

                for (int i = 0; i < dictWords.Count; i++)
                {
                    int distance = GetDamerauLevenshteinDistance(enteredWord, dictWords[i].Word);
                    if (distance < 1)
                    {
                        dictWords[i].CurrentDistance = distance / (1 / dictWords[i].Frequency);
                        results.Add(dictWords[i]);
                    }
                }
                int optionCount = 4;
                //IntArrayInsertionSort(results);


                IntArrayInsertionSort(results);
                

                if (results.Count < 4)
                {
                    optionCount = results.Count;
                }
                string sent = "Original word: " + word;
                for (int i = 0; i < optionCount; i++)
                {
                    sent += "    pred" + (i + 1) + "  " + results[i].Word;
                }

                File.AppendAllText("insResults.txt", sent + Environment.NewLine);
            }
            stopWatch.Stop();
            File.AppendAllText("insResults.txt", "Time Taken: " + stopWatch.ElapsedMilliseconds.ToString() + Environment.NewLine);
            button2.Text = "Done";
            Console.WriteLine("test Finished");
        }



        //Distance Algorithms

        public static int GetDamerauLevenshteinDistance(string s, string t)
        {
            var bounds = new { Height = s.Length + 1, Width = t.Length + 1 };

            int[,] matrix = new int[bounds.Height, bounds.Width];

            for (int height = 0; height < bounds.Height; height++) { matrix[height, 0] = height; };
            for (int width = 0; width < bounds.Width; width++) { matrix[0, width] = width; };

            for (int height = 1; height < bounds.Height; height++)
            {
                for (int width = 1; width < bounds.Width; width++)
                {
                    int cost = (s[height - 1] == t[width - 1]) ? 0 : 1;
                    int insertion = matrix[height, width - 1] + 1;
                    int deletion = matrix[height - 1, width] + 1;
                    int substitution = matrix[height - 1, width - 1] + cost;

                    int distance = Math.Min(insertion, Math.Min(deletion, substitution));

                    if (height > 1 && width > 1 && s[height - 1] == t[width - 2] && s[height - 2] == t[width - 1])
                    {
                        distance = Math.Min(distance, matrix[height - 2, width - 2] + cost);
                    }

                    matrix[height, width] = distance;
                }
            }

            return matrix[bounds.Height - 1, bounds.Width - 1];
        }





























        /// <summary>
        /// InsertionSort
        /// </summary>
        /// <param name="data"></param>
        public static void IntArrayInsertionSort(List<AutoWord> data)
        {
            int i, j;
            int N = data.Count;

            for (j = 1; j < N; j++)
            {
                for (i = j; i > 0 && data[i].CurrentDistance < data[i - 1].CurrentDistance; i--)
                {
                    exchange(data, i, i - 1);
                }
            }
        }
        public static void exchange(List<AutoWord> data, int m, int n)
        {
            AutoWord temporary;

            temporary = data[m];
            data[m] = data[n];
            data[n] = temporary;
        }


        //Quick Sort
        static public int Partition(List<AutoWord> numbers, int left, int right)

        {

            AutoWord pivot = numbers[left];

            while (true)

            {

                while (numbers[left].CurrentDistance < pivot.CurrentDistance)

                    left++;



                while (numbers[right].CurrentDistance > pivot.CurrentDistance)

                    right--;



                if (left < right)

                {

                    AutoWord temp = numbers[right];

                    numbers[right] = numbers[left];

                    numbers[left] = temp;

                }

                else

                {

                    return right;

                }

            }

        }



        static public void QuickSort_Recursive(List<AutoWord> arr, int left, int right)

        {

            // For Recusrion

            if (left < right)

            {

                int pivot = Partition(arr, left, right);



                if (pivot > 1)

                    QuickSort_Recursive(arr, left, pivot - 1);



                if (pivot + 1 < right)

                    QuickSort_Recursive(arr, pivot + 1, right);

            }

        }


    }
}
