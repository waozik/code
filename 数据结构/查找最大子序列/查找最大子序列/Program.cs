using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] arrInt = new int[] { 1, 2, 3, 4, 5, 11, 33, 44, 55, -1, 2, -5 };
            int summax = MaxSubSequenceSumFour(arrInt, 10);
            Console.WriteLine(summax);
            Console.ReadLine();
        }
        private static int MaxSubSequenceSumOne(int[] arr, int n) //O(n^3)
        {
            int sumMax = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    int sum = 0;
                    for (int k = j; k <= i; k++)
                    {
                        sum += arr[k];
                        if (sumMax < sum) sumMax = sum;
                    }
                }
            }
            return sumMax;
        }

        private static int MaxSubSequenceSumTwo(int[] arr, int n)//O(n^2)
        {
            int sumMax = 0;
            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                for (int j = i; j >= 0; j--)
                {
                    sum += arr[j];
                    if (sum > sumMax) sumMax = sum;
                }
            }
            return sumMax;
        }

        private static int MaxSubSequenceSumThree(int[] arr, int n) //O(n)
        {
            int sumMax = 0;
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += arr[i];
                if (sumMax < sum) sumMax = sum;
                if (sum < 0) sum = 0;

            }
            return sumMax;
        }
        private static int MaxSubSequenceSumFour(int[] arr, int n)
        {
           return BinaryMaxSum(arr, 0, n - 1);
        }

        private static int BinaryMaxSum(int[] arr, int left, int right)
        {
            int leftSumMax, rightSumMax;
            int leftboardSumMax, rightboardSumMax;
            int leftbordSum, rightboardSum;
            int center, i = 0;
            if (left == right)
            {
                if (arr[left] > 0) return arr[left];
                else return 0;
            }
            center = (left + right) / 2;
            leftSumMax = BinaryMaxSum(arr, left, center);
            rightSumMax = BinaryMaxSum(arr, center + 1, right);
            leftboardSumMax = 0;
            leftbordSum = 0;
            for (i = center; i >= left; i--)
            {
                leftbordSum += arr[i];
                if (leftbordSum > leftboardSumMax) leftboardSumMax = leftbordSum;
            }
            rightboardSumMax = 0;
            rightboardSum = 0;
            for (i = center; i >= left; i--)
            {
                leftbordSum += arr[i];
                if (rightboardSum > rightboardSumMax) rightboardSumMax = rightboardSum;
            }
          return  Math.Max(Math.Max(rightSumMax, leftSumMax), leftboardSumMax + rightboardSumMax);
        }
     

    }
}
