using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2023 {
    internal class Day6 {
        public static void Solve() {
            string[] lines = File.ReadAllLines("day6.txt");
            long[] times = Array.ConvertAll(lines[0].Replace("Time", "").Split(" ").Where(x => !string.IsNullOrWhiteSpace(x)).ToArray(), long.Parse);
            long[] dists = Array.ConvertAll(lines[1].Replace("Distance", "").Split(" ").Where(x => !string.IsNullOrWhiteSpace(x)).ToArray(), long.Parse);

            int sum = 1;

            for (int i = 0; i < times.Length; i++) {
                long time = times[i];
                long dist = dists[i];
                int speed = 0;
                int ways = 0;
                //Console.WriteLine($"Time {time} with dist {dist}");

                for (int t = 0; t < time; t++) {
                    if ((time - t) * speed > dist) {
                        //Console.WriteLine("VI VON");
                        ways++;
                    }

                    speed++;
                }
                Console.WriteLine(ways);
                sum *= ways;
            }
            Console.WriteLine(sum);
        }
    }
}
