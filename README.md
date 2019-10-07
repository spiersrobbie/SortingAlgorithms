# SortingAlgorithms
Collection of eight array sorting algorithms in C# with data analysis of their comparable speeds according to Big O Notation. 
All algorithms are personally developed from scratch.

Includes:
  Bubble Sort (optimized to break after the minimum number of iterations)
  
  Selection Sort
  
  Insertion Sort
  
  Bucket Sort (Recursively applies the bucket sort into each bucket to decrease external reliance on other methods)
  
  Quick Sort (Similar to a recursive two bucket sort)
  
  Radix LSD Sort (Uses string manipulation to sort individual digit places)
  
  Merge Sort
  
  Cocktail Shaker Sort (Maximally optimized bubble sort)
  
  
All data from the tests is found in the .xlsx files or .docx to show the graphs

O(n^2) sorts are iterated through arrays from n=200 to n=10000 with delta(n)=200

O(n) sorts are additionally iterated through arrays n=10000 to n=730000
