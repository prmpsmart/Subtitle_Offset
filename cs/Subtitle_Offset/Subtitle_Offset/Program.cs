using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Subtitle_Offset
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void Maino()
        {
            add_offset("C:\\Users\\Administrator\\Coding_Projects\\Python\\Dev_Workspace\\Subtitle_Offset\\res\\sample.srt", 10, "C:\\Users\\Administrator\\Coding_Projects\\Python\\Dev_Workspace\\Subtitle_Offset\\res\\result.srt");
            Console.ReadKey();
        }

        public static void print(dynamic value)
        {
            Console.WriteLine(value);
        }

        public static void add_offset(string file, int offset, string out_)
        {
            {
                var subtitle = new Subtitle(file);
                subtitle.add_offset(offset);
                subtitle.write(out_);
            }
        }
    }
}
