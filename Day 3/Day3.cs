using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2023 {
    public static class Day3 {
        // It might be ugly, but cmon bro. This wasn't easy
        // Numbers at the borders gave me a headache
        public static void Solve() {
            string[] lines = File.ReadAllLines("day3.txt");
            int sum = 0;
            
            for (int i = 0; i < lines.Length; i++) {
                string line = lines[i];
                string kok = string.Empty;
                bool isSpecial = false;
                for (int j = 0; j < line.Length; j++) {
                    char c = line[j];

                    if (Char.IsDigit(c)) {
                        kok += c;
                        if (!isSpecial)
                            isSpecial = GetSurroundings(ref lines, i, j);

                    } else {
                        if (kok != string.Empty && isSpecial) {
                            //Console.WriteLine(kok);
                            sum += Convert.ToInt32(kok);
                        }

                        kok = string.Empty;
                        isSpecial = false;
                    }
                }
                if (kok != string.Empty && isSpecial) {
                    //Console.WriteLine(kok);
                    sum += Convert.ToInt32(kok);
                }

                kok = string.Empty;
                isSpecial = false;
            }
            Console.WriteLine(sum);
        }

        private static bool GetSurroundings(ref string[] lines, int i, int j) {
            string boxChars = "";
            boxChars += GetSafeChar(ref lines, i - 1, j + 1);
            boxChars += GetSafeChar(ref lines, i - 1, j - 1);
            boxChars += GetSafeChar(ref lines, i, j + 1);
            boxChars += GetSafeChar(ref lines, i - 1, j);
            boxChars += GetSafeChar(ref lines, i, j - 1);
            boxChars += GetSafeChar(ref lines, i + 1, j);
            boxChars += GetSafeChar(ref lines, i + 1, j + 1);
            boxChars += GetSafeChar(ref lines, i + 1, j - 1);

            if (boxChars.Trim().Length != 0) 
                return true;
            return false;
        }

        private static char GetSafeChar(ref string[] lines, int i, int j) {
            try {
                char c = lines[i][j];
                if (c != '.' && !char.IsDigit(c))
                    return lines[i][j];
                else 
                    return ' ';
            }
            catch (IndexOutOfRangeException) {
                return ' ';
            }
        }
    }
}
