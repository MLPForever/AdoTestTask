namespace AdoTestTask
{
    internal class Program
    {
        private static Random rand = new Random();
        static void Main(string[] args)
        {
            //int[] nums = new int[] { 8828, 9581, 49, 9818, 9974, 9869, 9991, 10000, 10000, 10000, 9999, 9993, 9904, 8819, 1231, 6309 };
            int[] nums = GenerateRandomNumms();
            int x = GetRandomNum();
            //int x = 134365;
            int minOperations = CountMinOperations(nums, x);
            Console.WriteLine(minOperations);
            Console.ReadLine();
        }

        private static int CountMinOperations(int[] nums, int x)
        {
            int sum = nums.Sum() - x;
            if (sum == 0) return nums.Length;
            if (sum < 0) return -1;
            int start = 0;
            int cur = 0;
            int maxLen = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (cur < sum)
                    cur += nums[i];
                while (cur >= sum)
                {
                    if (cur == sum)
                        maxLen = Math.Max(maxLen, i - start + 1);
                    cur -= nums[start];
                    start++;
                }            
            }
            return maxLen == -1 ? -1 : nums.Length - maxLen;
        }

        private static int GetRandomNum() => rand.Next(1, 1000);

        private static int[] GenerateRandomNumms()
        {
            int[] nums = new int[rand.Next(10, 1000)];
            for (int i = 0; i < nums.Length; i++)
            {
                nums.Append(rand.Next(1, 100));
            }
            return nums;
        }
    }
}