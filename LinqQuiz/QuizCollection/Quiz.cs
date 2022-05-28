using LinqQuiz.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqQuiz.QuizCollection
{
    public class Quiz
    {
        /// <summary>
        /// Returns all even numbers between 1 and the specified upper limit.
        /// </summary>
        /// <param name="exclusiveUpperLimit">Upper limit (exclusive)</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Thrown if <paramref name="exclusiveUpperLimit"/> is lower than 1.
        /// </exception>
        public static int[] GetEvenNumbers(int exclusiveUpperLimit)
        {
            if (exclusiveUpperLimit < 1)
                throw new ArgumentOutOfRangeException($"{exclusiveUpperLimit} is less than 1.");
            
            var numbers = new List<int>();
            for(int i = 1; i < exclusiveUpperLimit; i++)
            {
                numbers.Add(i);
            }

            return numbers.Where(x => x % 2 == 0).ToArray();
        }

        /// <summary>
        /// Returns the squares of the numbers between 1 and the specified upper limit 
        /// that can be divided by 7 without a remainder (see also remarks).
        /// </summary>
        /// <param name="exclusiveUpperLimit">Upper limit (exclusive)</param>
        /// <exception cref="OverflowException">
        ///     Thrown if the calculating the square results in an overflow for type <see cref="System.Int32"/>.
        /// </exception>
        /// <remarks>
        /// The result is an empty array if <paramref name="exclusiveUpperLimit"/> is lower than 1.
        /// The result is in descending order.
        /// </remarks>
        public static int[] GetSquares(int exclusiveUpperLimit)
        {
            if(exclusiveUpperLimit < 1)
                return Array.Empty<int>();

            // Checks if the square results in an overflow for type Int32 and throws "OverflowException".
            checked
            {
                var numbers = new List<int>();
                for (var i = 1; i < exclusiveUpperLimit; i++)
                {
                    numbers.Add(i);
                }

                return numbers.Where(x => x % 7 == 0)
                    .Select(x => x * x)                   
                    .OrderByDescending(x => x)
                    .ToArray();
            }
        }

        /// <summary>
        /// Returns a statistic about families.
        /// </summary>
        /// <param name="families">Families to analyze</param>
        /// <returns>
        /// Returns one statistic entry per family in <paramref name="families"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Thrown if <paramref name="families"/> is <c>null</c>.
        /// </exception>
        /// <remarks>
        /// <see cref="FamilySummary.AverageAge"/> is set to 0 if <see cref="IFamily.Persons"/>
        /// in <paramref name="families"/> is empty.
        /// </remarks>
        public static FamilySummary[] GetFamilyStatistic(IReadOnlyCollection<IFamily> families)
        {
            if(families == null)
                throw new ArgumentNullException(nameof(families));

            var result = new List<FamilySummary>();
            var count = 1;

            foreach (var item in families)
            {
                if (item.Persons.Count() == 0)
                {
                    result.Add(new FamilySummary 
                    { 
                        FamilyID = count, 
                        NumberOfFamilyMembers = 0, 
                        AverageAge = 0 
                    });
                }
                else
                {
                    result.Add(new FamilySummary 
                    { 
                        FamilyID = count, 
                        NumberOfFamilyMembers = item.Persons.Count(p => p != null), 
                        AverageAge = item.Persons.Average(item => item.Age) 
                    });
                    count++;
                }
            }
            return result.ToArray();
        }

        /// <summary>
        /// Returns a statistic about the number of occurrences of letters in a text.
        /// </summary>
        /// <param name="text">Text to analyze</param>
        /// <returns>
        /// Collection containing the number of occurrences of each letter (see also remarks).
        /// </returns>
        /// <remarks>
        /// Casing is ignored (e.g. 'a' is treated as 'A'). Only letters between A and Z are counted;
        /// special characters, numbers, whitespaces, etc. are ignored. The result only contains
        /// letters that are contained in <paramref name="text"/> (i.e. there must not be a collection element
        /// with number of occurrences equal to zero.
        /// </remarks>
        public static (char letter, int numberOfOccurrences)[] GetLetterStatistic(string text)
        {
            return text.Where(c => char.IsLetter(c))
                .GroupBy(x => x)
                .Select(x => (letter: x.Key, numberOfOccurrences: x.Count()))
                .ToArray();
        }
    }
}
