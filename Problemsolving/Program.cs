using System;
using System.Collections.Generic;
using System.Text;

namespace Problemsolving
{
  class Program
  {
    static void Main(string[] args)
    {

      Program p = new Program();

      // Question 1:Given a string S, write a function to remove all the duplicate
      // (either letters or words, depending if the string is a single word or a sentence) in this given string
      Console.WriteLine(p.replaceDuplicate("patel patel parth patel parth v patel"));

      //Question 2:Write a function to reverse a string which represents a sentence with multiple words.
      //For the first solution, use only for loops and if statements, no built-in functions.
      //Try to get the best performing(less complicated) solution.
      Console.WriteLine(p.reverseString("patel patel parth patel parth v patel"));

      //Question 3:Inside an array, find a partial array that has a specific sum, write a function that takes an array and an integer(the sum),
      //and returns two indexes representing the start and the end of the partial array that has this sum.
      //  Examples :Input: arr[] = {1, 4, 20, 3, 10, 5}, sum = 33
      //  Ouptut: Sum found between indexes 2 and 4
      int[] array = { 1, 4 };
      var result = p.FindSumIndexes(array, 0);

      //Find the famous person in two dimensional array.
      bool[,] peoples = new bool[4, 4] { { true, false, true, false }, { true, true, true, false }, { false, false, true, false }, { false, true, true, true } };
      Console.WriteLine(FindFamousPeople2(peoples));
      Console.WriteLine(result.Item1 + result.Item2 + "," + result.Item3);

      int[,] crossArray = new int[4, 9] {
        {0,0,0,0,1,1,1,0,0},
        {0,0,0,1,0,1,1,1,0},
        {0,1,0,1,1,1,1,1,1},
        {1,1,1,0,0,1,1,1,1}
       };
      Console.WriteLine("Max Length is:==== " + CheckMaxCrossLength(crossArray));
      Console.ReadLine();

    }

    public static int CheckMaxCrossLength(int[,] crossArray)
    {
      int bound1 = crossArray.GetUpperBound(0);
      int bound2 = crossArray.GetUpperBound(1);
      int maxLength = 0;
      for (int i = 0; i <= bound1; i++)
      {
        for (int j = 0; j <= bound2; j++)
        {
          if (crossArray[i, j] == 0 && i < bound1)
          {
            var left = 0;
            var right = CheckRight(crossArray, i, j);
            var tempRight = right;
            var tempLeft = 0;

            while (tempRight > 1 && (j + tempRight - 1) <= bound2)
            {
              if (crossArray[i, j + (tempRight - 1)] == 0)
              {
                tempLeft = CheckLeft(crossArray, i, j + (tempRight - 1));
                if (tempLeft == tempRight && tempLeft > left)
                {
                  left = tempLeft;
                }
                tempRight--;
              }
              else
              {
                tempRight--;
              }
            }

            if (maxLength < left && maxLength < right && left > 0)
            {
              maxLength = SetMaxLength(left, right);
            }
          }
        }
      }
      return maxLength;
    }

    public static int CheckRight(int[,] crossArray, int i, int j)
    {
      int length = 0;
      while (i <= crossArray.GetUpperBound(0) && j <= crossArray.GetUpperBound(1))
      {
        if (crossArray[i, j] == 0)
        {
          length++;
          i++;
          j++;
        }
        else
        {
          break;
        }

      }
      return length;
    }

    public static int CheckLeft(int[,] crossArray, int i, int j)
    {
      int length = 0;
      while (i <= crossArray.GetUpperBound(0) && j >= 0)
      {
        if (crossArray[i, j] == 0)
        {
          length++;
          i++;
          j--;
        }
        else
        {
          break;
        }

      }
      return length;
    }

    public static int SetMaxLength(int left, int right)
    {
      int UpdatedMaxLength = 0;
      if (left == right)
      {
        UpdatedMaxLength = left;
      }
      else if (left < right)
      {
        UpdatedMaxLength = left;
      }
      else
      {
        UpdatedMaxLength = right;
      }
      return UpdatedMaxLength;
    }

    public static int FindFamousPeople(bool[,] peoples)
    {
      for (int i = 0; i < 4; i++)
      {
        bool allPeopleKnow = true;
        bool personKnowsSomeone = false;
        for (int j = 0; j < 4; j++)
        {
          if (peoples[j, i] == false)
          {
            allPeopleKnow = false;
            break;
          }
          if (i != j && peoples[i, j] == true)
          {
            personKnowsSomeone = true;
          }
        }
        if (allPeopleKnow && !personKnowsSomeone)
        {
          return i + 1;
        }
      }
      return -1;
    }
    public static int FindFamousPeople2(bool[,] peoples)
    {
      List<int> personIndex = new List<int>();
      int length = 0;

      while (length < 4)
      {
        if (peoples[0, length] == true)
        {
          personIndex.Add(length);
        }
        length++;
      }


      foreach (int i in personIndex)
      {
        int searchIndex = 0;
        bool allPeopleKnow = true;
        bool personKnowsSomeone = false;
        while (searchIndex < 4)
        {
          if (peoples[searchIndex, i] == false)
          {
            allPeopleKnow = false;
            break;
          }
          if (peoples[i, searchIndex] == true && i != searchIndex)
          {
            personKnowsSomeone = true;
            break;
          }
          searchIndex++;
        }
        if (allPeopleKnow && !personKnowsSomeone)
        {
          return i + 1;
        }
      }
      return -1;
    }
    private (string, int, int) FindSumIndexes(int[] array, int sum)
    {

      bool GetSum = false;
      for (int i = 0; i < array.Length; i++)
      {
        int LocalSum = 0;
        int StartIndex = i;
        int EndIndex = i;
        for (int j = i; j < array.Length; j++)
        {
          if (!GetSum)
          {
            LocalSum += array[j];
            if (LocalSum == sum)
            {
              EndIndex = j;
              GetSum = true;
              return ("Sub array found between: ", StartIndex, EndIndex);
            }
            if (LocalSum > sum)
            {
              break;
            }
          }
        }
      }
      return ("No sub array found", -1, -1);
    }

    private string reverseString(string str)
    {
      StringBuilder Output = new StringBuilder();
      for (int i = str.Length - 1; i >= 0; i--)
      {
        Output.Append(str[i]);
      }
      return Output.ToString();
    }

    public string replaceDuplicate(string str)
    {
      if (!IsSentence(str))
      {
        for (int i = 0; i < str.Length; i++)
        {
          char currentChar = str[i];
          for (int j = i + 1; j < str.Length; j++)
          {
            if (currentChar == str[j])
            {
              str = RemoveChar(str, j);
              j = i;
            }
          }
        }
      }
      else
      {
        string[] stringArray = str.Split(' ');
        HashSet<string> hashSet = new HashSet<string>();
        for (int i = 0; i < stringArray.Length; i++)
        {
          hashSet.Add(stringArray[i]);
        }
        str = string.Join(" ", hashSet);
        //We can use hash set for removing char too.
      }

      return str;
    }

    private string RemoveChar(string str, int i)
    {
      StringBuilder stringBuilder = new StringBuilder(str);
      for (int j = i; j < str.Length - 1; j++)
      {
        var s = str[j + 1];
        stringBuilder[j] = str[j + 1];
      }

      stringBuilder.Remove(stringBuilder.Length - 1, 1);

      return stringBuilder.ToString();
    }

    public bool IsSentence(string str)
    {
      foreach (char s in str)
      {
        if (s == Convert.ToChar(" "))
          return true;
      }

      return false;
    }
  }
}
