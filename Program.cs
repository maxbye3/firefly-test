using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace firefly_test
{
    public class Program
    {

        public static void Main(string[] args)
        {


            //string sequenceTest = "1";
            //string sequenceTest = "1,2";
            //string sequenceTest = "1:3,5";
            string sequenceTest = "1,2:5,9";
            var result = String.Join(",", sequence(sequenceTest));
            //Console.WriteLine(result);
            

            // Example: ranges([1,2,3,5]) = "1:3,5"
            // Example: ranges([1,4,3,2,5 ]) = "1:5"
            // Example: ranges(1) = "1"
            List<int> rangeTest = new List<int>
            (
                new int[] { 1,2 }
            );

            Console.WriteLine(ranges(rangeTest));
            Console.ReadLine();
            //  output: 1-5, 12-14, 19

        }

        //1) Implement the following method:
        // Convert a list of not-necessarily sequential
        // numbers into a comma-separated list of
        // ranges, of the format "from:to".
        public static string ranges(IEnumerable<int> numbers)
        {
            
            // sorts list of (not-necessarily sequential numbers) into a sequential list
            int[] sorted = numbers.OrderBy(e => e).ToArray();

            StringBuilder output = new StringBuilder();
            
            //Loop over the collection
            for (int i = 0; i < sorted.Length; i++)
            {
                var number = sorted[i];
                var count = 0;

                if (number <= 0)
                throw new ArgumentNullException("numbers");
              

                for (int j = number; ; j++)
                {
                    if (Array.IndexOf(sorted, j) == -1)
                        break;
                    else
                        count++;
                }

                if (count == 0)
                    throw new InvalidOperationException();
                else if (count < 3)
                    output.Append(", ").Append(number);
                else if (count >= 3)
                {
                    output.Append(", ").AppendFormat("{0}:{1}", number, sorted[i + count - 1]);

                    i += count - 1;
                }
            }

            return output.ToString().Trim(',', ' '); ;
        }



        //2) Write a method to turn the ranges from above back into an enumerable
        public static IEnumerable<int> sequence(string input)
        {
            string[] parts = input.Split(',');
            foreach (var part in parts)
            {
                if (!part.Contains(':')) // simple number, just return it
                {
                    yield return Int32.Parse(part);
                    continue;
                }
                // otherwise we have range
                string[] rangeParts = part.Split(':');
                int start = Int32.Parse(rangeParts[0]);
                int end = Int32.Parse(rangeParts[1]);

                while (start <= end)
                {
                    yield return start;
                    start++;
                }
            }
        }
    }
}