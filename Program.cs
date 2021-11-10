using System;
using System.Collections.Generic;
using System.IO;

namespace PS_Month_Creator
{
    class Program
    {        
        static void Main(string[] args)
        {
            Console.WriteLine("This program is designed to output a *.txt doc that contains the PS that are supposed to" +
                " be sent on the month you choose");
            Console.WriteLine("The App requieres the directory of a txt file with this columns delimited by tabs:");
            Console.WriteLine("Id, Project, Employee, Performance Survey Start Date");
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Type the path to the source txt doc: ");
            string path = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Please be sure that the destination directory ends with a '/'");
            Console.WriteLine("Type the destination path for the output: ");
            string destination = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Type the year of the period you want to create: ");
            int selectedYear = int.Parse(Console.ReadLine());
            Console.WriteLine("Type the month of the period you want to create: ");
            int selectedMonth = int.Parse(Console.ReadLine());
            string[] lines = System.IO.File.ReadAllLines(path);
            string test = System.IO.File.ReadAllText(path); //PRUEBAAA
            List<string> output = new List<string>();
            DateTime forecastDate = new DateTime(selectedYear, selectedMonth, 1);

            foreach (string line in lines)
            {
                if (line == "Id	Project	Employee	Performance Survey Start Date")
                {
                    output.Add("Id|Project|Employee|Performance Survey Start Date|Survey Num");
                    continue;
                }
                char[] delimiterChars = { ' ', '/' };
                string[] columns = line.Split("	");
                string[] currentDate = columns[3].Split(delimiterChars);
                DateTime currentDateForm = new DateTime(int.Parse(currentDate[2]), 
                                                            int.Parse(currentDate[0]), 
                                                            int.Parse(currentDate[1]));
                DateTime lastMonth = forecastDate.AddMonths(-1);
                if (currentDateForm.Year > forecastDate.Year)
                    continue;
                else if(currentDateForm.Year == forecastDate.Year && currentDateForm.Month > forecastDate.Month)
                    continue;
                if((currentDateForm.Year == forecastDate.Year && currentDateForm.Month == forecastDate.Month) 
                    || (currentDateForm.Year == forecastDate.Year && currentDateForm.Month == lastMonth.Month))
                {
                    if(currentDateForm.AddDays(7).Month == forecastDate.Month)
                    output.Add(columns[0] + "|" 
                            + columns[1] + "|" 
                            + columns[2] + "|" 
                            + currentDateForm + "|"
                            + currentDateForm.AddDays(7) + "|" 
                            + 1);
                    if(currentDateForm.AddDays(14).Month == forecastDate.Month)
                        output.Add(columns[0] + "|"
                            + columns[1] + "|"
                            + columns[2] + "|"
                            + currentDateForm + "|"
                            + currentDateForm.AddDays(14) + "|"
                            + 2);
                }
                if (currentDateForm.AddMonths(1).Month == forecastDate.Month && currentDateForm.AddMonths(2).Year == forecastDate.Year)
                {
                    output.Add(columns[0] + "|"
                            + columns[1] + "|"
                            + columns[2] + "|"
                            + currentDateForm + "|"
                            + currentDateForm.AddMonths(1) + "|"
                            + 3);
                    continue;
                }
                if (currentDateForm.AddMonths(2).Month == forecastDate.Month && currentDateForm.AddMonths(2).Year == forecastDate.Year)
                {
                    output.Add(columns[0] + "|"
                            + columns[1] + "|"
                            + columns[2] + "|"
                            + currentDateForm + "|"
                            + currentDateForm.AddMonths(2) + "|"
                            + 4);
                    continue;
                }
                if (currentDateForm.AddMonths(3).Month == forecastDate.Month && currentDateForm.AddMonths(3).Year == forecastDate.Year)
                {
                    output.Add(columns[0] + "|"
                            + columns[1] + "|"
                            + columns[2] + "|"
                            + currentDateForm + "|"
                            + currentDateForm.AddMonths(3) + "|"
                            + 5);
                    continue;
                }
                if (currentDateForm.AddMonths(4).Month == forecastDate.Month && currentDateForm.AddMonths(4).Year == forecastDate.Year)
                {
                    output.Add(columns[0] + "|"
                            + columns[1] + "|"
                            + columns[2] + "|"
                            + currentDateForm + "|"
                            + currentDateForm.AddMonths(4) + "|"
                            + 6);
                    continue;
                }
                if (currentDateForm.AddMonths(6).Month == forecastDate.Month && currentDateForm.AddMonths(6).Year == forecastDate.Year)
                {
                    output.Add(columns[0] + "|"
                            + columns[1] + "|"
                            + columns[2] + "|"
                            + currentDateForm + "|"
                            + currentDateForm.AddMonths(6) + "|"
                            + 7);
                    continue;
                }
                if(((forecastDate.Year - currentDateForm.Year)*12 + forecastDate.Month - currentDateForm.Month) % 3 == 0 && forecastDate > currentDateForm.AddMonths(6))
                {
                    int monthsInBetween = ((forecastDate.Year - currentDateForm.Year) * 12 + forecastDate.Month - currentDateForm.Month);
                    output.Add(columns[0] + "|"
                        + columns[1] + "|"
                        + columns[2] + "|"
                        + currentDateForm + "|"
                        + currentDateForm.AddMonths(monthsInBetween) + "|"
                        + (7 + (monthsInBetween / 3)));
                    continue;
                }
            }
            System.Text.StringBuilder ultimateOutput = new System.Text.StringBuilder();
            foreach (var item in output)
            {
                ultimateOutput.AppendLine(item.ToString());
            }
            System.IO.File.WriteAllText(
                System.IO.Path.Combine(destination + "output.txt"),
                ultimateOutput.ToString());
        }
    }
}
