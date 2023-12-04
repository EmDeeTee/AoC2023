using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC2023 {
    // Who needs regex, when you can write spaghetti C#
    public static class Day2 {
        private const int MAX_RED = 12;
        private const int MAX_GREEN = 13;
        private const int MAX_BLUE = 14;

        public static void Solve() {
            string[] lines = File.ReadAllLines("day2.txt");
            int sum = 0;
            foreach (string line in lines) {
                bool passing = true;
                string[] parts = line.Split();
                int ID = int.Parse(Regex.Match(parts[1], @"\d+").Value);
                string[] sets = line.Split(';');
                sets[0] = sets[0].Remove(0, sets[0].IndexOf(':')+1);
                foreach (string s in sets) {
                    string[] cubes = s.Split(',');
                    foreach (string c in cubes.Select(c => c.Trim())) {
                        string[] slice = c.Split(' ');
                        int num = int.Parse(slice[0]);
                        string color = slice[1];

                        if (color == "red" && num > MAX_RED) {
                            passing = false;
                        } else if (color == "green" && num > MAX_GREEN) {
                            passing = false;
                        } else if (color == "blue" && num > MAX_BLUE) {
                            passing = false;
                        }

                    }
                }
                if (passing) {
                    sum += ID;
                    Console.WriteLine($"{ID} passing");
                }
                //Environment.Exit(0);
            }
            Console.WriteLine($"Sum = {sum}");

        }
    }
}
