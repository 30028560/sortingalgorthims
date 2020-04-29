using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Sort
    {
		public static void SortBubble(int[] numArray)
		{
			int temp;

			for (int outerLoop = 0; outerLoop < numArray.Length - 1; outerLoop++)
			{
				for (int innerLoop = 0; innerLoop < numArray.Length - 1; innerLoop++)
				{
					if (numArray[innerLoop] > numArray[innerLoop + 1])
					{
						temp = numArray[innerLoop + 1];
						numArray[innerLoop + 1] = numArray[innerLoop];
						numArray[innerLoop] = temp;
					}
				}
			}

		}
		public static void SortHeap(int[] numArray)
		{
			int n = numArray.Length;

			// Build heap (rearrange array) 
			for (int i = n / 2 - 1; i >= 0; i--) heapify(numArray, n, i);

			// One by one extract an element from heap 
			for (int i = n - 1; i >= 0; i--)
			{
				// Move current root to end 
				int temp = numArray[0];
				numArray[0] = numArray[i];
				numArray[i] = temp;

				// call max heapify on the reduced heap 
				heapify(numArray, i, 0);
			}

		}
		private static void heapify(int[] arr, int n, int i)
		{
			int largest = i;   // Initialize largest as root 
			int l = 2 * i + 1; // left = 2*i + 1 
			int r = 2 * i + 2; // right = 2*i + 2 

			// If left child is larger than root 
			if (l < n && arr[l] > arr[largest]) largest = l;

			// If right child is larger than largest so far 
			if (r < n && arr[r] > arr[largest]) largest = r;

			// If largest is not root 
			if (largest != i)
			{
				int swap = arr[i];
				arr[i] = arr[largest];
				arr[largest] = swap;

				// Recursively heapify the affected sub-tree 
				heapify(arr, n, largest);
			}

		}
		public static void SortQuick(int[] numArray, int startIndex, int endIndex)
		{
			int[] stack = new int[endIndex - startIndex + 1]; // Create an auxiliary stack 
			int top = -1;                                     // initialize top of stack 
															  // push initial values of l and h to stack 
			stack[++top] = startIndex;
			stack[++top] = endIndex;
			// Keep popping from stack while is not empty 
			while (top >= 0)
			{
				// Pop h and l 
				endIndex = stack[top--];
				startIndex = stack[top--];
				// Set pivot element at its correct position in sorted array 
				int p = Partition(numArray, startIndex, endIndex);
				// If there are elements on left side of pivot, then push left side to stack 
				if (p - 1 > startIndex)
				{
					stack[++top] = startIndex;
					stack[++top] = p - 1;
				}
				// If there are elements on right side of pivot, then push right side to stack 
				if (p + 1 < endIndex)
				{
					stack[++top] = p + 1;
					stack[++top] = endIndex;
				}
			}

		}
		private static int Partition(int[] inputarray, int low, int high)
		{
			int temp;
			int pivot = inputarray[high];
			// index of smaller element 
			int i = (low - 1);
			for (int j = low; j <= high - 1; j++)
			{
				// If current element is smaller than or equal to pivot 
				if (inputarray[j] <= pivot)
				{
					i++;
					// swap arr[i] and arr[j] 
					temp = inputarray[i];
					inputarray[i] = inputarray[j];
					inputarray[j] = temp;
				}
			}
			// swap arr[i+1] and arr[high] (or pivot) 
			temp = inputarray[i + 1];
			inputarray[i + 1] = inputarray[high];
			inputarray[high] = temp;
			return i + 1;

		}
		public static void SortMerge(int[] arr, int l, int r)
		{
			if (l < r)
			{
				// Same as (l+r)/2, but avoids overflow for large l and h 
				int m = l + (r - l) / 2;

				// Sort first and second halves 
				SortMerge(arr, l, m);
				SortMerge(arr, m + 1, r);
				merge(arr, l, m, r);
			}

		}
		private static void merge(int[] arr, int l, int m, int r)
		{
			int i, j, k;
			int n1 = m - l + 1;
			int n2 = r - m;
			// Create temp arrays 
			int[] L = new int[n1];
			int[] R = new int[n2];

			// Copy data to temp arrays L[] and R[] 
			for (i = 0; i < n1; i++) L[i] = arr[l + i];
			for (j = 0; j < n2; j++) R[j] = arr[m + 1 + j];
			// Merge the temp arrays back into arr[l..r]
			i = 0;      // Initial index of first subarray 
			j = 0;      // Initial index of second subarray 
			k = l;      // Initial index of merged subarray
			while (i < n1 && j < n2)
			{
				if (L[i] <= R[j])
				{
					arr[k] = L[i];
					i++;
				}
				else
				{
					arr[k] = R[j];
					j++;
				}
				k++;
			}
			// Copy the remaining elements of L[], if there are any
			while (i < n1)
			{
				arr[k] = L[i];
				i++;
				k++;
			}
			// Copy the remaining elements of R[], if there are any 
			while (j < n2)
			{
				arr[k] = R[j];
				j++;
				k++;
			}

		}
	}
}
