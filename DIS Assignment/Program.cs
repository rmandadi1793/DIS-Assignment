using System;
using System.Collections.Generic;
using System.Text;

namespace ISM6225_Spring_2024_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1 - Test Case 1
            int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int numberOfUniqueNumbers1 = RemoveDuplicates(nums1);
            Console.WriteLine("Question 1 - Test Case 1:");
            Console.WriteLine(numberOfUniqueNumbers1);

            // Question 1 - Test Case 2
            int[] nums2 = { 1, 1, 2 };
            int numberOfUniqueNumbers2 = RemoveDuplicates(nums2);
            Console.WriteLine("Question 1 - Test Case 2:");
            Console.WriteLine(numberOfUniqueNumbers2);

            // Question 2 - Test Case 1
            int[] nums3 = { 0, 1, 0, 3, 12 };
            IList<int> resultAfterMovingZero1 = MoveZeroes(nums3);
            string combinationsString1 = ConvertIListToArray(resultAfterMovingZero1);
            Console.WriteLine("Question 2 - Test Case 1:");
            Console.WriteLine(combinationsString1);

            // Question 2 - Test Case 2
            int[] nums4 = { 0 };
            IList<int> resultAfterMovingZero2 = MoveZeroes(nums4);
            string combinationsString2 = ConvertIListToArray(resultAfterMovingZero2);
            Console.WriteLine("Question 2 - Test Case 2:");
            Console.WriteLine(combinationsString2);

            // Question 3 - Test Case 1
            int[] nums5 = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> triplets1 = ThreeSum(nums5);
            string tripletResult1 = ConvertIListToNestedList(triplets1);
            Console.WriteLine("Question 3 - Test Case 1:");
            Console.WriteLine(tripletResult1);

            // Question 3 - Test Case 2
            int[] nums6 = { 0, 1, 1 };
            IList<IList<int>> triplets2 = ThreeSum(nums6);
            string tripletResult2 = ConvertIListToNestedList(triplets2);
            Console.WriteLine("Question 3 - Test Case 2:");
            Console.WriteLine(tripletResult2);

            // Question 3 - Test Case 3
            int[] nums7 = { 0, 0, 0 };
            IList<IList<int>> triplets3 = ThreeSum(nums7);
            string tripletResult3 = ConvertIListToNestedList(triplets3);
            Console.WriteLine("Question 3 - Test Case 3:");
            Console.WriteLine(tripletResult3);

            // Question 4 - Test Case 1
            int[] nums8 = { 1, 1, 0, 1, 1, 1 };
            int maxOnes1 = FindMaxConsecutiveOnes(nums8);
            Console.WriteLine("Question 4 - Test Case 1:");
            Console.WriteLine(maxOnes1);

            // Question 4 - Test Case 2
            int[] nums9 = { 1, 0, 1, 1, 0, 1 };
            int maxOnes2 = FindMaxConsecutiveOnes(nums9);
            Console.WriteLine("Question 4 - Test Case 2:");
            Console.WriteLine(maxOnes2);

            // Question 5 - Test Case 1
            int binaryInput1 = 101010;
            int decimalResult1 = BinaryToDecimal(binaryInput1);
            Console.WriteLine("Question 5 - Test Case 1:");
            Console.WriteLine(decimalResult1);

            // Question 6 - Test Case 1
            int[] nums10 = { 3, 6, 9, 1 };
            int maxGap1 = MaximumGap(nums10);
            Console.WriteLine("Question 6 - Test Case 1:");
            Console.WriteLine(maxGap1);

            // Question 6 - Test Case 2
            int[] nums11 = { 10 };
            int maxGap2 = MaximumGap(nums11);
            Console.WriteLine("Question 6 - Test Case 2:");
            Console.WriteLine(maxGap2);

            // Question 7 - Test Case 1
            int[] nums12 = { 2, 1, 2 };
            int largestPerimeter1 = LargestPerimeter(nums12);
            Console.WriteLine("Question 7 - Test Case 1:");
            Console.WriteLine(largestPerimeter1);

            // Question 7 - Test Case 2
            int[] nums13 = { 1, 2, 1, 10 };
            int largestPerimeter2 = LargestPerimeter(nums13);
            Console.WriteLine("Question 7 - Test Case 2:");
            Console.WriteLine(largestPerimeter2);

            // Question 8 - Test Case 1
            string result1 = RemoveOccurrences("daabcbaabcbc", "abc");
            Console.WriteLine("Question 8 - Test Case 1:");
            Console.WriteLine(result1);

            // Question 8 - Test Case 2
            string result2 = RemoveOccurrences("axxxxyyyyb", "xy");
            Console.WriteLine("Question 8 - Test Case 2:");
            Console.WriteLine(result2);
        }

        // Question 1

        // Time complexity: O(n)
        // Space complexity: O(1)
        public static int RemoveDuplicates(int[] nums)
        {
            try
            {
                if (nums.Length == 0)
                    return 0;

                int uniqueCount = 1; // At least one element is unique
                for (int i = 1; i < nums.Length; i++)
                {
                    if (nums[i] != nums[i - 1])
                    {
                        nums[uniqueCount] = nums[i]; // Moving the unique element to the next position
                        uniqueCount++;
                    }
                }

                return uniqueCount;    //Returning the uniquecount
            }
            catch (Exception)
            {
                throw;
            }
        }



        // Question 2

        // Time complexity: O(n)
        // Space complexity: O(1)
        public static IList<int> MoveZeroes(int[] nums)
        {
            try
            {
                int nonZeroIndex = 0;
                // Moving the non-zero elements to the beginning of the array
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] != 0)
                    {
                        nums[nonZeroIndex++] = nums[i];
                    }
                }
                // Filling the remaining elements with zeros
                for (int i = nonZeroIndex; i < nums.Length; i++)
                {
                    nums[i] = 0;
                }

                return nums;
            }
            catch (Exception)
            {
                throw;
            }
        }



        // Question 3

        // Time complexity: O(n^2)
        // Space complexity: O(n)
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            try
            {
                // Sorting the array
                Array.Sort(nums);
                IList<IList<int>> result = new List<IList<int>>();

                for (int i = 0; i < nums.Length - 2; i++)
                {
                    // Skip duplicate elements to avoid duplicate triplets
                    if (i == 0 || (i > 0 && nums[i] != nums[i - 1]))
                    {
                        int left = i + 1;
                        int right = nums.Length - 1;
                        int target = 0 - nums[i];

                        //finding pairs which summ up to the target
                        while (left < right)
                        {
                            if (nums[left] + nums[right] == target)
                            {
                                result.Add(new List<int> { nums[i], nums[left], nums[right] });
                                // Skip duplicates
                                while (left < right && nums[left] == nums[left + 1]) left++;
                                while (left < right && nums[right] == nums[right - 1]) right--;
                                left++;
                                right--;
                            }
                            else if (nums[left] + nums[right] < target)
                            {
                                left++;
                            }
                            else
                            {
                                right--;
                            }
                        }
                    }
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4

        // Time complexity: O(n)
        // Space complexity: O(1)
        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            try
            {
                int maxCount = 0;
                int currentCount = 0;

                // Iterate through the array
                foreach (int num in nums)
                {
                    if (num == 1)  // If the current number is 1, increment the count of consecutive ones
                    {
                        currentCount++;
                        maxCount = Math.Max(maxCount, currentCount); // Update the maximum count of consecutive ones encountered
                    }
                    else
                    {
                        currentCount = 0;
                    }
                }

                return maxCount; // Return the maximum count of consecutive ones found in the array
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5

        // Time complexity: O(log n)
        // Space complexity: O(1)
        public static int BinaryToDecimal(int binary)
        {
            try
            {
                int decimalNumber = 0;
                int baseValue = 1;

                while (binary > 0) // Iterate until the binary number becomes zero
                {
                    int lastDigit = binary % 10;
                    binary /= 10;

                    decimalNumber += lastDigit * baseValue;  // Convert the binary digit to its decimal equivalent and add it to the result
                    baseValue *= 2;
                }

                return decimalNumber; // Return the decimal equivalent of the binary number
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6:

        //Time complexity of O(n log n)
        //Space complexity of O(1)


        public static int MaximumGap(int[] nums)
        {
            try
            {
                if (nums.Length < 2)
                    return 0;

                // Sort the array
                Array.Sort(nums);

                // Initialize maximum gap
                int maxGap = 0;

                // Traverse the sorted array to find the maximum difference between successive elements
                for (int i = 1; i < nums.Length; i++)
                {
                    int currentGap = nums[i] - nums[i - 1];
                    maxGap = Math.Max(maxGap, currentGap);
                }

                return maxGap;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7

        // Time complexity: O(n log n)
        // Space complexity: O(1)
        public static int LargestPerimeter(int[] nums)
        {
            try
            {
                Array.Sort(nums); // Sort the array in non-decreasing order

                for (int i = nums.Length - 3; i >= 0; i--)
                {
                    if (nums[i] + nums[i + 1] > nums[i + 2]) // Checking if the current triplet forms a valid triangle
                    {
                        return nums[i] + nums[i + 1] + nums[i + 2];
                    }
                }

                return 0; // If no valid triangle is found, return 0
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8

        // Time complexity: O(n * m), where n is the length of the input string and m is the length of the part to remove
        // Space complexity: O(n)
        public static string RemoveOccurrences(string s, string part)
        {
            try
            {
                while (s.Contains(part))  // Loop until all occurrences of the substring are removed
                {
                    int index = s.IndexOf(part);
                    s = s.Remove(index, part.Length);  // Remove the substring from the original string
                }

                return s; // Return the modified string with all occurrences of the substring removed
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Inbuilt functions
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }

        static string ConvertIListToArray(IList<int> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "" + input[i] + ""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}
