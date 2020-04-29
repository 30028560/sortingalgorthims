using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Sorting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] numberArray = DataArrays.numArray1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bubblesortButton_Click(object sender, RoutedEventArgs e)
        {
            Sort.SortBubble(numberArray);
            outputText.Text = "Sorting number:\n";
            for (int i = 0; i < numberArray.Length; i++)
            {
                outputText.Text += numberArray[i];
                if ( i != (numberArray.Length - 1))
                {
                    outputText.Text += ", ";
                }

            }
        }

        private void heapsortButton_Click(object sender, RoutedEventArgs e)
        {
            Sort.SortHeap(numberArray);
            outputText.Text = "Sorting number:\n";
            for (int i = 0; i < numberArray.Length; i++)
            {
                outputText.Text += numberArray[i];
                if (i != (numberArray.Length - 1))
                {
                    outputText.Text += ", ";
                }

            }
        }

        private void quicksortButton_Click(object sender, RoutedEventArgs e)
        {
            Sort.SortQuick(numberArray, 0, numberArray.Length - 1);
            outputText.Text = "Sorting number:\n";
            for (int i = 0; i < numberArray.Length; i++)
            {
                outputText.Text += numberArray[i];
                if (i != (numberArray.Length - 1))
                {
                    outputText.Text += ", ";
                }

            }

        }

        private void mergesortButton_Click(object sender, RoutedEventArgs e)
        {
            Sort.SortMerge(numberArray, 0, numberArray.Length - 1);
            outputText.Text = "Sorting number:\n";
            for (int i = 0; i < numberArray.Length; i++)
            {
                outputText.Text += numberArray[i];
                if (i != (numberArray.Length - 1))
                {
                    outputText.Text += ", ";
                }

            }
        }

        private void perfomance_Click(object sender, RoutedEventArgs e)
        {
            outputText.Text = "";
            Stopwatch stopwatch1 = Stopwatch.StartNew(); //creates and start the instance of Stopwatch
            Sort.SortBubble(DataArrays.numArray2);                                            //your sample code
            System.Threading.Thread.Sleep(500);
            stopwatch1.Stop();
            outputText.Text += "Bubble sort take " + stopwatch1.ElapsedMilliseconds + " milliseconds \n";

            Stopwatch stopwatch2 = Stopwatch.StartNew();
            Sort.SortHeap(DataArrays.numArray2);
            stopwatch2.Stop();
            outputText.Text += "Heap sort take " + stopwatch2.ElapsedMilliseconds + " milliseconds \n";

            Stopwatch stopwatch3 = Stopwatch.StartNew();
            Sort.SortQuick(DataArrays.numArray2, 0, DataArrays.numArray2.Length - 1);
            stopwatch3.Stop();
            outputText.Text += "Quick sort take " + stopwatch3.ElapsedMilliseconds + " milliseconds \n";

            Stopwatch stopwatch4 = Stopwatch.StartNew();
            Sort.SortMerge(DataArrays.numArray2, 0, DataArrays.numArray2.Length - 1);
            stopwatch4.Stop();
            outputText.Text += "Merge sort take " + stopwatch4.ElapsedMilliseconds + " milliseconds \n";


        }
    }
}
