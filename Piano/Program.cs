using System;
using System.Threading;
using System.IO;

namespace Piano
{
    class Program
    {
        readonly static int[] c_frequency = { 65, 131, 262, 523, 988, 2093, 4186 };
        readonly static int[] cis_frequency = { 69, 139, 277, 554, 1108, 2217, 4435 };
        readonly static int[] d_frequency = { 73, 147, 294, 587, 1175, 2349, 4699 };
        readonly static int[] dis_frequency = { 78, 156, 311, 622, 1245, 2489, 4978 };
        readonly static int[] e_frequency = { 82, 165, 330, 659, 1319, 2637, 5274 };
        readonly static int[] f_frequency = { 87, 175, 349, 698, 1397, 2793, 5588 };
        readonly static int[] fis_frequency = { 93, 185, 370, 740, 1480, 2960, 5920 };
        readonly static int[] g_frequency = { 98, 196, 392, 784, 1568, 3136, 6272 };
        readonly static int[] gis_frequency = { 104, 208, 415, 831, 1661, 3322, 6645 };
        readonly static int[] a_frequency = { 110, 220, 440, 880, 1760, 3520, 7040 };
        readonly static int[] ais_frequency = { 117, 233, 466, 932, 1865, 3729, 7459 };
        readonly static int[] h_frequency = { 123, 247, 494, 988, 1976, 3951, 7902 };
        static void CursorMove(int x, int y)
        {
            Console.CursorLeft = y;
            Console.CursorTop = x;
        }
        static void VisualPiano()
        {
            Console.CursorVisible = false;
            Console.WindowWidth = 150;
            Console.WriteLine(@"███████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████
│ ││ │ │ │ ││ ││ │ │ │ ││ │ │ │ ││ ││ │ │ │ ││ │ │ │ ││ ││ │ │ │ ││ │ │ │ ││ ││ │ │ │ ││ │ │ │ ││ ││ │ │ │ ││ │ │ │ ││ ││ │ │ │ ││ │ │ │ ││ ││ │ │ 
│ ││ │ │ │ ││ ││ │ │ │ ││ │ │ │ ││ ││ │ │ │ ││ │ │ │ ││ ││ │ │ │ ││ │ │ │ ││ ││ │ │ │ ││ │ │ │ ││ ││ │ │ │ ││ │ │ │ ││ ││ │ │ │ ││ │ │ │ ││ ││ │ │
└─┘└─┘ │ └─┘└─┘└─┘ │ └─┘└─┘ │ └─┘└─┘└─┘ │ └─┘└─┘ │ └─┘└─┘└─┘ │ └─┘└─┘ │ └─┘└─┘└─┘ │ └─┘└─┘ │ └─┘└─┘└─┘ │ └─┘└─┘ │ └─┘└─┘└─┘ │ └─┘└─┘ │ └─┘└─┘└─┘ │
 │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │
 │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │  │
─┴──┴──┴──┴──┴──┴──┴──┴──┴──┴──┴──┴──┴──┴──┴──┴──┴──┴──┴──┴──┴──┴──┴──┴──┴──┴──┴──┴──┴──┴──┴──┴──┴──┴──┴──┴──┴──┴──┴──┴──┴──┴──┴──┴──┴──┴──┴──┴──┴─");
        }
        static void Main(string[] args)
        {
            Console.Write("Vyberte skladbu:");
            string file = Console.ReadLine().ToLower();
            StreamReader song = new StreamReader($"{file}.txt");
            Console.Write("Zvolte rychlost:");
            double speed = Convert.ToDouble(Console.ReadLine());
            Console.Clear();
            VisualPiano();
            while (!song.EndOfStream)
            {                
                string[] line = song.ReadLine().Split(" ");
                for (int i = 0; i < line.Length; i++)
                {
                    string[] tone = line[i].Split(":");
                    string substring = tone[0];                   
                    int frequency = 0;
                    int index = 0;
                    int x = 0;
                    int y = 0;
                    double duration = Convert.ToInt32(tone[1]) * 0.9 / speed;
                    try
                    {
                        index = Convert.ToInt32(new string(substring[^1], 1)) - 2;
                    }
                    catch {} 
                    substring = substring.Remove(substring.Length - 1).ToLower();
                    int check_void = 1;
                    if (substring == "c" || substring == "d" || substring == "e" || substring == "f" || substring == "g" || substring == "a" || substring == "h")
                    {
                        x = 4;
                    }
                    else if (substring == "c#" || substring == "d#" || substring == "f#" || substring == "g#" ||  substring == "a#")
                    {
                        x = 1;
                    }
                    switch (substring)
                    {
                        case "c":                            
                            frequency = c_frequency[index];                            
                            if (index > 0)
                            {
                                y = -1;
                            }
                            else if (index == 0)
                            {
                                y = 0;
                            }
                            break;
                        case "c#":                            
                            frequency = cis_frequency[index];
                            y = 1;
                            break;
                        case "d":                            
                            frequency = d_frequency[index];
                            y = 2;
                            break;
                        case "d#":
                            frequency = dis_frequency[index];
                            y = 4;
                            break;
                        case "e":
                            frequency = e_frequency[index];
                            y = 5;
                            break;
                        case "f":
                            frequency = f_frequency[index];
                            y = 8;
                            break;
                        case "f#":
                            frequency = fis_frequency[index];
                            y = 10;
                            break;
                        case "g":
                            frequency = g_frequency[index];
                            y = 11;
                            break;
                        case "g#":
                            frequency = gis_frequency[index];
                            y = 13;
                            break;
                        case "a":
                            frequency = a_frequency[index];
                            y = 14;
                            break;
                        case "a#":
                            frequency = ais_frequency[index];
                            y = 16;
                            break;
                        case "h":
                            frequency = h_frequency[index];
                            y = 17;
                            break;
                        case "p":
                            check_void = 0;
                            break;
                    }
                    if (check_void == 1)
                    {
                        if (substring == "c" & index == 0)
                        {
                            CursorMove(x, 0);
                            Console.WriteLine("█");
                            CursorMove(x + 1, 0);
                            Console.WriteLine("█");
                        }
                        else if (x == 1)
                        {
                            CursorMove(x, y + 21*index);
                            Console.WriteLine("█");
                            CursorMove(x + 1, y + 21 * index);
                            Console.WriteLine("█");
                        }
                        else if (x == 4)
                        {
                            CursorMove(x, y + 21 * index);
                            Console.WriteLine("██");
                            CursorMove(x + 1, y + 21 * index);
                            Console.WriteLine("██");
                        }
                        CursorMove(7, 0);
                        Console.WriteLine($"Tone:{frequency} Hz, Time:{Math.Round(duration, 2)} ms");
                        Console.Beep(frequency, Convert.ToInt32(duration));                        
                        if (substring == "c" & index == 0)
                        {
                            CursorMove(x, 0);
                            Console.WriteLine(" ");
                            CursorMove(x + 1, 0);
                            Console.WriteLine(" ");
                        }
                        else if (x == 1)
                        {
                            CursorMove(x, y + 21 * index);
                            Console.WriteLine(" ");
                            CursorMove(x + 1, y + 21 * index);
                            Console.WriteLine(" ");
                        }
                        else if (x == 4)
                        {
                            CursorMove(x, y + 21 * index);
                            Console.WriteLine("  ");
                            CursorMove(x + 1, y + 21 * index);
                            Console.WriteLine("  ");
                        }                        
                    }
                    else
                    {
                        Console.WriteLine($"Pause:{duration}");
                        Thread.Sleep(Convert.ToInt32(duration));
                    }
                    Thread.Sleep(50);
                }
            }
            Console.ReadKey(true);
        }
    }
}
