using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Chapter_5_Practice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateInterestButton_Click(object sender, RoutedEventArgs e)
        {
            /// For this section, the goal was to create a program that
            /// would show how much money a person would have in their 
            /// account after adding interest

            try
            {

            /// I began by defining my variables. I knew that anything dealing with 
            /// money had to be written as a decimal, but wasn't sure about everything
            /// else. I ended up looking at the text book and found that they could be
            /// written as integers. 

                decimal interestRate = 0.005m;
                int startingBalance = int.Parse(startingBalanceTextBox.Text);
                int numberOfMonths = int.Parse(numberOfMonthsTextBox.Text);
                int count = 1;
                decimal endingBalance = ((interestRate * startingBalance) * numberOfMonths) + startingBalance;

            
            /// In my original run through I had the math completed in the while statements.
            /// I thought that multiplying the decimal by the integers would make the end 
            /// result an integer. But I learned that I was incorrect. So I instead decided 
            /// make the result of the math a variable and then use the .ToString("c2") 
            /// method to get it to print the way I wanted.
                while (count <= 6)
                {
                    endingBalanceCalculationLabel.Content = endingBalance.ToString("c2");
                    count = count + 1;
                }

                while (count <= 12)
                {
                    interestRate = interestRate + 0.005m;
                    endingBalanceCalculationLabel.Content = endingBalance.ToString("c2");
                    count = count + 1;
                }

                while (count >= 24)
                {
                    interestRate = interestRate + 0.010m;
                    endingBalanceCalculationLabel.Content = endingBalance.ToString("c2");
                    count =count + 1;
                }

           
            }

            /// I also did it in the try/catch format so that the program
            /// wouldn't break if the inputs weren't formatted as I intended.
            /// At first I did it incorrectly because I didn't include the
            /// variables inside the try/catch statements, but it was quite easy to fix.

            catch
            {
                errorLabel.Content = "Error! Try again.";
                endingBalanceCalculationLabel.Content = " ";
                startingBalanceTextBox.Text = " ";
                numberOfMonthsTextBox.Text = " ";
                
            }
        }

        ///The purpose of this section was just to practice putting items into listboxes.
        private void clearListBoxButton_Click(object sender, RoutedEventArgs e)
        {
            squaresListBox.Items.Clear();
        }

        private void calculateSquaresButton_Click(object sender, RoutedEventArgs e)
        {
            const int MAX_VALUE = 15;
            int number, square;

            for (number = 1; number <= MAX_VALUE; number++)
            {
                square = number * number;
                squaresListBox.Items.Add("The square of " + number.ToString() + " is " + square.ToString());
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            endingBalanceCalculationLabel.Content = " ";
            startingBalanceTextBox.Text = " ";
            numberOfMonthsTextBox.Text = " ";
            errorLabel.Content = " ";
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void calculateKiloToMiles_Click(object sender, RoutedEventArgs e)
        {
            ///In this particular area, the goal was to calculate kilometres per hour 
            ///into miles per hour. I definitely needed to rely more on the book to figure 
            ///out how to organize the constants. My original idea was much more complicated
            ///andd didn't work as intended. 

            const double FORMULA = 0.6214;
            const int MAX_KPH = 130;
            const int STARTING_KPH = 60;
            const int COUNTER = 10;

           for (int kph = STARTING_KPH; kph <= MAX_KPH; kph += COUNTER)
            {
                double mph = kph * FORMULA;
                kilometersToMilesLabel.Items.Add(kph + " KPH is equal to " + mph + " MPH.");
            }
        }

        private void noteWritingButton_Click(object sender, RoutedEventArgs e)
        {
            /// Figuring out how to write the lines took me a while because I didn't realize that 
            /// the path I was trying to take doesn't actually exist in the way that I thought it did.
            /// But I was able to eventually get it to work! I just wanted to practice going through 
            /// the process of creating text files.

            try
            {
                StreamWriter noteToSelf;

                noteToSelf = File.CreateText(@"C:\Users\yakim\Documents\Note to Self.txt");
                noteToSelf.WriteLine("The WriteLine function tells the application to go to the next line.");
                noteToSelf.WriteLine("There is also the 'Write' option, which doesn't move to a new line");
                noteToSelf.WriteLine("Nor does it tell the program to create a space between words");
                noteToSelf.WriteLine("Also, I think I know how to make the application write whatever is written in the TextBox");
                noteToSelf.WriteLine("Let's see!");
                noteToSelf.WriteLine(" ");
                noteToSelf.WriteLine(noteWritingTextBox.Text);

                noteToSelf.Close();
                noteWritingTextBox.Text = " ";

            }

            catch
            {
                MessageBox.Show("Error with compiling note! Please try rewriting the code.");
                noteWritingTextBox.Text = " ";
            }
            

        }

        private void noteAppedningButton_Click(object sender, RoutedEventArgs e)
        {
            /// Though it didn't stop at creating the file. I also wanted to see how I could append 
            /// the file as well. This part was actually super easy as soon as I figured out that
            /// the path I was originally going for didn't exist.

            try
            {
                StreamWriter noteToSelf;

                noteToSelf = File.AppendText(@"C:\Users\yakim\Documents\Note to Self.txt");
                noteToSelf.WriteLine("So, I was definitely able to figure it out.");
                noteToSelf.WriteLine("My only complaint is that the line is super long");
                noteToSelf.WriteLine(noteWritingTextBox.Text);

                noteToSelf.Close();
                noteWritingTextBox.Text = " ";
            }

            catch
            {

                MessageBox.Show("Error with compiling note! Please try rewriting the code.");
                noteWritingTextBox.Text = " ";
            }
            
        }

        private void noteReadButton_Click(object sender, RoutedEventArgs e)
        {
            /// I'm unsure of why, but this button doesn't work. In fact,
            /// I'm pretty sure that it crashes whenever I try to use it.

            /// I figured it out. I forgot to add curly brackets to the
            /// while argument! It works as expected now!

            try
            {
                string messageText;

                StreamReader noteToSelf;

                noteToSelf = File.OpenText(@"C:\Users\yakim\Documents\Note to Self.txt");

                while (!noteToSelf.EndOfStream)
                {
                    messageText = noteToSelf.ReadLine();
                    MessageBox.Show(messageText);
                }
               
            }

            catch
            {
                MessageBox.Show("Error with compiling note! Please try rewriting the code.");
            }
        }
    }
}
