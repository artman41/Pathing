using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Pathing {
    internal class Program {
        public static void Main(string[] args) {
            ReadLevel().ForEach(Console.WriteLine);
        }

        public static string[] ReadLevel() {
            var x = ReadLevelMap();
            var y = ReadLevelFlags();

            if (x.Length != y.Length) {
                throw new Exception("Incorrect File Length");
            }
            
            for (int i = 0; i < x.Length; i++) {
                var s = x[i].ToCharArray();
                for (int j = 0; j < y[i].Length; j++) {
                    switch (y[i][j]) {
                        case 'O':
                            bool l = false, r = false, u = false, d = false;
                            try {
                                if (y[i][j - 1] == 'O') {
                                    l = true;
                                }
                            }catch {
                            } try {
                                if (y[i][j + 1] == 'O') {
                                    r = true;
                                }
                            }catch {
                            } try {
                                if (y[i-1][j] == 'O') {
                                    u = true;
                                }
                            }catch {
                            } try {
                                if (y[i+1][j] == 'O') {
                                    d = true;
                                }
                            } catch {
                            }
                            if ((l || r) && (u || d)) {
                                s[j] = '+';
                            } else if (l || r) {
                                s[j] = '-';
                            } else {
                                s[j] = '|';
                            }
                            break;
                    }
                }
                x[i] = new string(s);
            }
            return x;
        }

        public static string[] ReadLevelMap() {
            var map = new StreamReader("./Level/Level.map");
            List<string> Mapping = new List<string>();
            while (!map.EndOfStream) {
                Mapping.Add(map.ReadLine());
            }

            return Mapping.ToArray();
        }

        public static string[] ReadLevelFlags() {
            var flags = new StreamReader("./Level/Level.flags");
            List<string> MapFlags = new List<string>();
            while (!flags.EndOfStream) {
                MapFlags.Add(flags.ReadLine());
            }

            return MapFlags.ToArray();
        }
    }
}