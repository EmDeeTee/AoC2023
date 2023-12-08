using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC2023 {
    public static class Day4 {
        public static void Solve() {
            string[] lines = File.ReadAllLines("day4.txt");
            int sum = 0;

            foreach (string line in lines) {
                int value = 0;
                bool streak = false;
                string nums = line.Substring(line.IndexOf(':') + 1);
                int[] winning = Array.ConvertAll(nums.Split('|')[0].Trim().Replace("  ", " ").Split(' '), int.Parse);
                int[] picked = Array.ConvertAll(nums.Split("|")[1].Trim().Replace("  ", " ").Split(' '), int.Parse);

                foreach (int pic in picked) {
                    if (winning.Contains(pic)) {
                        if (!streak) {
                            streak = true;
                            value++;
                        }
                        else
                            value *= 2;
                        //Console.WriteLine(pic);
                    }
                }
                sum += value;
                //Environment.Exit(0);
            }
            Console.WriteLine(sum);
        }

    }
}
