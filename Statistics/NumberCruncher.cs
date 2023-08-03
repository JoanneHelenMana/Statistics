using System;
using System.Collections.Generic;
using System.Linq;


namespace Statistics
{
    public class NumberCruncher
    {
        public double?[] data = new double?[1000];

        public int count = 0;


        /// <summary>
        /// Adds a number into the next slot in the array and updates the count.
        /// </summary>
        /// <param name="number"></param>
        public void AddNumber(double number)
        {
            data[count] = number;
            count++;
        }


        /// <summary>
        /// Displays all stored numbers to the console.
        /// </summary>
        public void DisplayData()
        {
            foreach (double? number in data) 
            {
                if (!(number is null))
                    Console.WriteLine(number);
            }
        }


        /// <summary>
        /// Removes the last number in the array and updates the count.
        /// </summary>
        public void RemoveLastNumber()
        {
            double? lastNumber = data[data.Length - 1];

            if (!(lastNumber is null))
            {
                data[data.Length - 1] = null;
                count--;
            }
        }

        
        /// <summary>
        /// Removes the number at the index provided and shuffles all the numbers that come after it down to fill the gap.
        /// The count is also updated.
        /// </summary>
        /// <param name="number"></param>
        public void RemoveNumberAt(int number)
        {
            if (!(data[number] is null))
            {
                for (int i = number + 1; i < data.Length; i++)
                {
                    data[i - 1] = data[i];
                }

                data[data.Length - 1] = null;
                count--;
            }            
        }
        

        /// <summary>
        /// Returns the total (sum) of the numbers in the array.
        /// </summary>
        public double Total()
        {
            double total = 0;

            foreach (double? number in data) 
            { 
                if (!(number is null))
                {
                    total = (double)(total + number);
                }
            }

            return total;
        }


        /// <summary>
        /// Returns the average of the numbers in the array.
        /// </summary>
        public double Average()
        {
            double average;
            double total = Total();
            int count = 0;

            foreach (double? number in data)
            {
                if (!(number is null))
                {
                    count++;
                }
            }

            average = total / count;

            return average;
        }


        /// <summary>
        /// Returns the mean of the numbers in the array.
        /// </summary>
        public double Mean()
        {
            return Average();
        }


        /// <summary>
        /// Returns the lowest number in the array.
        /// </summary>
        public double Minimum()
        {
            double lowest = (double)data.Min();
            return lowest;
        }

        
        /// <summary>
        /// Returns the highest number in the array.
        /// </summary>
        public double Maximum()
        {
            double highest = (double)data.Max();
            return highest;
        }


        /// <summary>
        /// Returns the range of the numbers in the array (highest minus lowest).
        /// </summary>
        public double Range()
        {
            double range = Maximum() - Minimum();
            return range;
        }
        

        /// <summary>
        /// Returns the number that ocurrs the most often in the array.
        /// The possibility of more than one number occurring with the same frequency is contemplated.
        /// </summary>
        public List<double> Mode()
        {
            List<double> mode = new List<double>{ };
            Dictionary<double, int> dataFrequency = new Dictionary<double, int>();
            List<double?> distinctData = data.Distinct().ToList();
            int highestCount = 0;

            for (int i = 0; i < distinctData.Count()-1; i++)    // iterates through distinct data, last value -null- is excluded from iteration
            {
                int count = 0;

                for (int j = 0; j < data.Length; j++)   // compares distinct data against all data
                {
                    if (distinctData[i] == data[j]) // counts occurrences of each distinct number in data
                    {
                        count++;                        
                    }                    
                }

                dataFrequency.Add((double)distinctData[i], count);
            }

            foreach (KeyValuePair<double, int> numberCountPair in dataFrequency)
            {
                if (numberCountPair.Value > highestCount)  // looks for the highest count (frequency)
                {
                    highestCount = numberCountPair.Value;
                }
            }

            foreach (KeyValuePair<double, int> numberCountPair in dataFrequency)
            {
                if (numberCountPair.Value == highestCount)  // looks for all numbers with highest frequency, adds numbers to 'mode' list
                {
                    mode.Add(numberCountPair.Key);
                }
            }

            return mode;
        }
    }
}
