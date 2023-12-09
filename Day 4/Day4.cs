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

        // I needed help in solving part 2. Resources I used:
        // https://github.com/danielhuang/aoc-2023/blob/master/src/bin/4.rs
        // https://www.youtube.com/watch?v=-bJa4VEeQ2M
        public static void Solve2() {
            string[] lines = File.ReadAllLines("day4.txt");
            int[] ints = new int[lines.Length];
            for (int i = 0; i < ints.Length; i++) {
                ints[i]++;
            }

            for (int i = 0; i < lines.Length; i++) {
                string line = lines[i];
                string nums = line.Substring(line.IndexOf(':') + 1);
                int[] winning = Array.ConvertAll(nums.Split('|')[0].Trim().Replace("  ", " ").Split(' '), int.Parse);
                int[] picked = Array.ConvertAll(nums.Split("|")[1].Trim().Replace("  ", " ").Split(' '), int.Parse);

                int wins = winning.Intersect(picked).ToArray().Length;
                for (int j = i+1; j <= i + wins; j++) {
                    ints[j] += ints[i];
                }
                //Environment.Exit(0);
            }
            Console.WriteLine(ints.Sum());
        }
    }
}
