///////////////////////////////////////////////////////////////////////////////
//
// Author: Jackson Denti, dentij@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project 7
// Description: Implements a calculator class that performs calculations, reads and writes data
//
///////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csci_2210_fall2022_project_7_dentij_etsu
{
    internal class Calculator

    {
        double state;
        Dictionary<string, dynamic> menuActions = new();
        Dictionary<string, double> variables = new();

        /// <summary>
        /// Constructor method
        /// </summary>
        public Calculator ()
        {
            state = 0;
            InitializeMenuActions();
        }

        /// <summary>
        /// Creates Dispatch table
        /// Done in private method for ease of maintenance, only used by class constructor
        /// </summary>
        private void InitializeMenuActions ()
        {
            menuActions["1"] = new Action<double>((var) => { state += var; });
            menuActions["2"] = new Action<double>((var) => { state -= var; });
            menuActions["3"] = new Action<double>((var) => { state *= var; });
            menuActions["4"] = new Action<double>((var) => { state /= var; });
            menuActions["5"] = new Action<double>((var) => { state %= var; });
            menuActions["6"] = new Action(() => { state = Math.Pow(state, 2); });
            menuActions["7"] = new Action(() => { state = Math.Sqrt(state); });
            menuActions["8"] = new Action<double>((var) => { state = Math.Pow(state, var); });
            menuActions["9"] = new Action<double>((var) => { state += var; });
            menuActions["10"] = new Action(() => { DisplayVariables(); });
            menuActions["11"] = new Action<double>((var) => { state += var; });
            menuActions["12"] = new Action(() => { ReadFromFile(); });
            menuActions["13"] = new Action(() => { WriteToFile(); });
        }

        /// <summary>
        /// Displays all the current variables
        /// </summary>
        public void DisplayVariables()
        {
            foreach (var variable in variables)
            {
                Console.WriteLine($"{variable.Key}:{variable.Value}");
            }
            Console.WriteLine("\nPlease press Enter to Continue...");
            Console.ReadLine();
        }

        /// <summary>
        /// Takes user input string and passes it to a dispatch table to run the appropriate calculation
        /// </summary>
        /// <param name="str"> User Input String corresponding to menu option </param>
        public void ProcessMenuOption(string str)
        {
            if (menuActions.ContainsKey(str))
            {
                if (str == "6" || str == "7" || str == "13" ||str == "15" || str == "16")
                {
                    menuActions[str]();
                }
                else
                {
                    Console.WriteLine("Please enter a value for the operation");
                    string value = Console.ReadLine();
                    if (double.TryParse(value, out double var))
                    {
                        menuActions[str](var);
                    }
                }
            }
        }

        /// <summary>
        /// Reads data from variable dictionary and writes it to a file path
        /// </summary>
        public void WriteToFile()
        {
            Console.WriteLine("Please type a file path");

            StreamWriter sw = new StreamWriter(Console.ReadLine());

            foreach (var item in variables) 
            {
                sw.WriteLine($"{item.Key}:{item.Value}");
            }
        }

        /// <summary>
        /// Reads data from given file path and passes variables to Dictionary
        /// </summary>
        public void ReadFromFile()
        {
            Console.WriteLine("Please type a file path");
            string str = Console.ReadLine();
            StreamReader sr = new StreamReader(@"C:\Users\jacks\Desktop\proj7.txt");

            while (sr.Peek() >= 0)
            {
                string[] strings = sr.ReadLine().Split(":");
                menuActions[strings[0]] = strings[1];
            }
        }

        /// <summary>
        /// Writes menu strings to console on method execution
        /// </summary>
        public void DisplayData()
        {
            Console.WriteLine($"Current State: {state}");
            Console.WriteLine("1. Add [Value]");
            Console.WriteLine("2. Subtract [Value]");
            Console.WriteLine("3. Multiply [Value]");
            Console.WriteLine("4. Divide [Value]");
            Console.WriteLine("5. Mod [Value]");
            Console.WriteLine("6. Square");
            Console.WriteLine("7. Square Root");
            Console.WriteLine("8. Exponentiate [Value]");
            Console.WriteLine("9. Factorial  [Value]");
            Console.WriteLine("10. Create Variable [Name]");
            Console.WriteLine("11. Create Variable [Value, Name]");
            Console.WriteLine("12. Read Variables [FilePath]");
            Console.WriteLine("13. Save Variables [FilePath]");
        }
    }
}
