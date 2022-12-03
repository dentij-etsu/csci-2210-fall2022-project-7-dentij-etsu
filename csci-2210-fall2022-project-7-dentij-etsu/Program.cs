///////////////////////////////////////////////////////////////////////////////
//
// Author: Jackson Denti, dentij@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Project 7
// Description: Main driver for project, creates calculator object and menu loop
//
///////////////////////////////////////////////////////////////////////////////
namespace csci_2210_fall2022_project_7_dentij_etsu

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            while (true)
            {
                calc.DisplayData();
                string userInput = Console.ReadLine();
                calc.ProcessMenuOption(userInput);
                Console.Clear();
            }
        }
    }
}