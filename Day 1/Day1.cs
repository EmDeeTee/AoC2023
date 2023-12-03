using System;

namespace AoC2023 {
    public static class Day1 {
        public static void Solve() {
            string[] lines = File.ReadAllLines("day1.txt");
            int sum = 0;

            foreach (string line in lines) {
                char lefty = '0';
                char righty = '0';
                Console.WriteLine(line);
                char[] allNumbers = line.Where(c => Char.IsDigit(c)).Select(c => c).ToArray();
                lefty = allNumbers.First();
                righty = allNumbers.Last();

                string s = lefty.ToString() + righty.ToString();
                Console.WriteLine(s);
                sum += Convert.ToInt32(s);
            }
            Console.WriteLine($"Calculated sum = {sum}");
        }
    }
}
