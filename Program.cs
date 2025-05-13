using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SeriesAnalyzer
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<double> numbers = new List<double>();


            bool isVallidArgs()
            {

                
                if (args.Length < 3)
                {
                    return false;
                }
                foreach (string arg in args)
                {
                    if (double.TryParse(arg, out double num) && num >= 0) numbers.Add(num);
                    else
                    {
                        numbers.Clear();
                        return false;
                    }

                }
                return true;
            }

            bool isVallidInput(string userNum)
            {

                 
                if (double.TryParse(userNum, out double num) && num >= 0) numbers.Add(num);
                else
                    {
                        numbers.Clear();
                        return false;
                    }

                return true;

            }

            void GetSeriesFromUser()
            {
                while (true)
                {
                    Console.Write("Enter at least 3 positive numbers or 'e' to finish: ");
                    string userNum = Console.ReadLine();
                    if (userNum != "e") isVallidInput(userNum);

                    else break;
                }

            }

            void printSeries(List<double> series)
            {
                foreach (double num in series)
                {
                    Console.Write(num + ",");
                }
            }

            int seriesLength(List<double>series)
            {
                int counter = 0;
                foreach (double num in series)
                {
                    counter++;
                }
                return counter;
            }

            double sumOfTheSeries(List<double>series)
            {
                double seriesSum = 0;
                foreach (double num in series)
                {
                    seriesSum += num;
                }
                return seriesSum;
            }

            void ShowReversed()

            {
                for (int i = numbers.Count -1; i >= 0; i--) 
                {
                    Console.Write(numbers[i] + ",");
                }
            }

            void maxNumber()
            {
                double max = 0;
                foreach (double num in numbers)
                {
                    if (num > max)
                    {
                        max = num;
                    }
                }
                Console.WriteLine($"The biggest number is {max}");  
            }

            void minNumber()
            {
                double min = numbers[0];
                foreach (double num in numbers)
                {
                    if (num < min)
                    {
                        min = num;
                    }
                }
                Console.WriteLine($"The smallest number is {min}");
            }

            double Average(List<double>series)
            {
                return sumOfTheSeries(series) / seriesLength(series);
            }

            void sort(List<double>series)
            {
                double temp;
                List<double> tempList = new List<double>(series);
                for (int i = 0; i < tempList.Count-1; i++)
                {
                    bool flag = false;
                    for (int j = 0; j < tempList.Count-i -1; j++)
                    {
                        if ( tempList[j] > tempList[j + 1])
                        {
                            temp = tempList[j];
                            tempList[j] = tempList[j + 1];
                            tempList[j + 1] = temp;
                            flag = true;
                        }
                    }
                    if(!flag) break;
                }
              printSeries(tempList);  
            }

            void userChois()
            {
                int chois;
                do
                {
                    menu();
                    Console.Write("Please enter your choice: ");
                    string input = Console.ReadLine();
                    Console.WriteLine();
                    if (int.TryParse(input, out chois))
                    {
                        switch (chois)
                        {
                            case 1:
                                Console.WriteLine("1- You chose to enter your own numbers,");
                                numbers.Clear();
                                GetSeriesFromUser();
                                while (numbers.Count < 3)
                                {
                                    Console.WriteLine("\n You must enter at least 3 numbers!");
                                    numbers.Clear();
                                    GetSeriesFromUser();
                                }
                                break;
                            case 2:
                                Console.WriteLine("2- You chose to see the numbers you entered,");
                                printSeries(numbers); break;
                            case 3:
                                Console.WriteLine("3- You chose to see the numbers in reverse order");
                                ShowReversed(); break;
                            case 4:
                                Console.WriteLine("4- You chose to arrange the numbers in ascending order.");
                                sort(numbers); break;
                            case 5:
                                Console.WriteLine("5- You chose to see the largest number");
                                maxNumber(); break;
                            case 6:
                                Console.WriteLine("6- You chose to see the smallest number");
                                minNumber(); break;
                            case 7:
                                Console.WriteLine("7- You chose to see the average of all numbers");
                                Console.WriteLine($"The average of the series is: {Average(numbers)}"); break;
                            case 8:
                                Console.WriteLine("8- You chose to see the amount of numbers entered.");
                                Console.WriteLine($"The number of values in the series is: {seriesLength(numbers)}"); break;
                            case 9:
                                Console.WriteLine("9- You chose to see the sum of all the numbers");
                                Console.WriteLine($"The sum of all the values in the series is: {sumOfTheSeries(numbers)}"); break;
                            case 10:
                                Console.WriteLine("The program has ended."); break;
                            default:
                                Console.WriteLine("Please enter a number beetwen 1-10: "); break;

                        }
                    }
                    else Console.WriteLine("Please enter a number beetwen 1-10: ");
                } while (chois != 10);
              
                    
            }

            void menu()
            {
                
                
                {
                    Console.Write("\n\n Browse the menu and enter a number between 1 and 10.\n" + "\n" +
                        "1. Input a Series. (Replace the current series)\r\n" +
                        "2. Display the series in the order it was entered.\r\n" +
                        "3. Display the series in the reversed order it was entered.\r\n" +
                        "4. Display the series in sorted order (from low to high).\r\n" +
                        "5. Display the Max value of the series.\r\n" +
                        "6. Display the Min value of the series.\r\n" +
                        "7. Display the Average of the series.\r\n" +
                        "8. Display the Number of elements in the series.\r\n" +
                        "9. Display the Sum of the series.\r\n" +
                        "10. Exit.\n");
  
                }
                




            }



            void manager()
            {

                if (!(isVallidArgs()))
                {
                    GetSeriesFromUser();
                    

                    userChois();

                }
                else
                {
                    Console.WriteLine("Arguments were successfully received.");
                    userChois();
                }
            }
            manager();





                




            Console.ReadLine();
        }
    }
}
