using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.PersonalPractice
{
    public class StringCalculator
    {
        #region Step_1
        //public int Add(string numbers)
        //{
        //    if (numbers == string.Empty) return 0; 
        //    return numbers.Length == 1 ? 
        //        int.Parse(numbers[0].ToString()) :
        //        int.Parse(numbers[0].ToString()) + int.Parse(numbers[2].ToString());
        //}
        #endregion

        #region Step_2

        //public int Add(string numbers)
        //{
        //    return numbers == string.Empty ? 0 : numbers.Split(',').Sum(x => int.Parse(x));
        //}

        #endregion

        #region Step_3

        //public int Add(string numbers)
        //{
        //    numbers = numbers.Replace('\n', ',');
        //    return numbers == string.Empty ? 0 : numbers.Split(',').Sum(x => int.Parse(x));
        //}

        #endregion

        #region Step_4

        //public int Add(string numbers)
        //{
        //    if (numbers == string.Empty) return 0;
        //    if (numbers.Length == 1) return int.Parse(numbers[0].ToString());

        //    char delimiter = numbers.Substring(0, 2) == "//" ? numbers[2] : ',';
        //    numbers = numbers.Substring(0, 2) == "//" ? numbers.Substring(4, numbers.Length - 4) : numbers;
        //    numbers = numbers.Replace('\n', delimiter);
        //    return numbers.Split(delimiter).Sum(x => int.Parse(x));
        //}

        #endregion

        #region Step_5

        //public int Add(string numbers)
        //{
        //    if (numbers == string.Empty) return 0;
        //    if (numbers.Length == 1) return int.Parse(numbers[0].ToString());

        //    char delimiter = numbers.Substring(0, 2) == "//" ? numbers[2] : ',';
        //    numbers = numbers.Substring(0, 2) == "//" ? numbers.Substring(4, numbers.Length - 4) : numbers;
        //    numbers = numbers.Replace('\n', delimiter);

        //    var negativeNumbers = numbers.Split(delimiter).Where((number) => int.Parse(number) < 0);
        //    if (negativeNumbers.Count() > 0)
        //    {
        //        throw new ArgumentException("Negatives not allowed: " + string.Join(delimiter.ToString(), negativeNumbers));
        //    }

        //    return numbers.Split(delimiter).Sum(x => int.Parse(x));
        //}

        #endregion

        #region Step_6

        //public int Add(string numbers)
        //{
        //    if (numbers == string.Empty) return 0;
        //    if (numbers.Length == 1) return int.Parse(numbers[0].ToString());

        //    char delimiter = numbers.Substring(0, 2) == "//" ? numbers[2] : ',';
        //    numbers = numbers.Substring(0, 2) == "//" ? numbers.Substring(4, numbers.Length - 4) : numbers;
        //    numbers = numbers.Replace('\n', delimiter);

        //    var negativeNumbers = numbers.Split(delimiter).Where((number) => int.Parse(number) < 0);
        //    if (negativeNumbers.Count() > 0)
        //    {
        //        throw new ArgumentException("Negatives not allowed: " + string.Join(delimiter.ToString(), negativeNumbers));
        //    }

        //    return numbers.Split(delimiter).Where(x => int.Parse(x) <= 1000).Sum(x => int.Parse(x));
        //}

        #endregion

        #region Step_7

        //public int Add(string numbers)
        //{
        //    if (string.IsNullOrEmpty(numbers))
        //    {
        //        return 0;
        //    }

        //    string delimiter = GetDelimiter(numbers);
        //    string numbersWithoutDelimiterSettings = GetNumbersWithoutDelimiterSettings(numbers, delimiter);

        //    IEnumerable<int> negativeNumbers = GetNegativeNumbers(numbersWithoutDelimiterSettings, delimiter);
        //    if (negativeNumbers.Any())
        //    {
        //        throw new ArgumentException("Negatives not allowed: " + string.Join(delimiter, negativeNumbers));
        //    }

        //    return GetValidNumbers(numbersWithoutDelimiterSettings, delimiter).Sum();
        //}

        //private string GetDelimiter(string numbers)
        //{
        //    string delimiter = ",";
        //    if (numbers.StartsWith("//["))
        //    {
        //        delimiter = numbers.Substring(3, numbers.IndexOf('\n') - 4);
        //    }
        //    else if (numbers.StartsWith("//"))
        //    {
        //        delimiter = numbers[2].ToString();
        //    }

        //    return delimiter;
        //}

        //private string GetNumbersWithoutDelimiterSettings(string numbers, string delimiter)
        //{
        //    string numbersWithoutDelimiterSettings = numbers;
        //    if (numbers.StartsWith("//["))
        //    {
        //        int newLineIndex = numbers.IndexOf('\n') + 1;
        //        numbersWithoutDelimiterSettings = numbers.Substring(newLineIndex, numbers.Length - newLineIndex);
        //    }
        //    else if (numbers.StartsWith("//"))
        //    {
        //        numbersWithoutDelimiterSettings = numbers.Substring(4);
        //    }

        //    return numbersWithoutDelimiterSettings.Replace("\n", delimiter);
        //}

        //private IEnumerable<int> GetNegativeNumbers(string numbers, string delimiter)
        //{
        //    return numbers.Split(new[] { delimiter }, StringSplitOptions.None)
        //        .Select(int.Parse)
        //        .Where(x => x < 0);
        //}

        //private IEnumerable<int> GetValidNumbers(string numbers, string delimiter)
        //{
        //    return numbers.Split(new[] { delimiter }, StringSplitOptions.None)
        //        .Select(int.Parse)
        //        .Where(x => x <= 1000);
        //}

        #endregion

        #region Step_8/9

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            IEnumerable<string> delimiters = GetDelimiters(numbers);
            string numbersWithoutDelimiterSettings = GetNumbersWithoutDelimiterSettings(numbers, delimiters);

            IEnumerable<int> negativeNumbers = GetNegativeNumbers(numbersWithoutDelimiterSettings, delimiters);
            if (negativeNumbers.Any())
            {
                throw new ArgumentException("Negatives not allowed: " + string.Join(delimiters.FirstOrDefault(), negativeNumbers));
            }

            return GetValidNumbers(numbersWithoutDelimiterSettings, delimiters).Sum();
        }

        private IEnumerable<string> GetDelimiters(string numbers)
        {
            var delimiters = new List<string>();
            if (numbers.StartsWith("//["))
            {
                var delimitersString = numbers.Substring(2, numbers.IndexOf('\n') - 3);
                delimiters = delimitersString.Split(']').Select(del => del.Substring(1)).ToList();
            }
            else if (numbers.StartsWith("//"))
            {
                delimiters.Add(numbers[2].ToString());
            } else
            {
                delimiters.Add(",");
            }

            return delimiters;
        }

        private string GetNumbersWithoutDelimiterSettings(string numbers, IEnumerable<string> delimiter)
        {
            string numbersWithoutDelimiterSettings = numbers;
            if (numbers.StartsWith("//["))
            {
                int newLineIndex = numbers.IndexOf('\n') + 1;
                numbersWithoutDelimiterSettings = numbers.Substring(newLineIndex, numbers.Length - newLineIndex);
            }
            else if (numbers.StartsWith("//"))
            {
                numbersWithoutDelimiterSettings = numbers.Substring(4);
            }

            return numbersWithoutDelimiterSettings.Replace("\n", delimiter.FirstOrDefault());
        }

        private IEnumerable<int> GetNegativeNumbers(string numbers, IEnumerable<string> delimiter)
        {
            return numbers.Split(delimiter.ToArray(), StringSplitOptions.None)
                .Select(int.Parse)
                .Where(x => x < 0);
        }

        private IEnumerable<int> GetValidNumbers(string numbers, IEnumerable<string> delimiter)
        {
            return numbers.Split(delimiter.ToArray(), StringSplitOptions.None)
                .Select(int.Parse)
                .Where(x => x <= 1000);
        }

        #endregion
    }
}
