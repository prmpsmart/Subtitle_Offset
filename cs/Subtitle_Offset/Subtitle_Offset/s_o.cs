using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Subtitle_Offset
{
    class Index
    {
        string DELIM = "-->";
        static public string NEW_LINE = "\n";
        string TIME_FORMAT = "HH:mm:ss,fff";
        string index, _text;
        DateTime start, end;


        public Index(List<string> index_lines)
        {
            index = index_lines[0];
            setStartEnd(index_lines[1]);
            for (int line = 2; line < index_lines.Count; line++) _text += index_lines[line] + NEW_LINE;
        }

        public void add_offset(int offset)
        {
            start = start.AddSeconds(offset);
            end = end.AddSeconds(offset);
        }

        public override string ToString()
        {
            var text = index + NEW_LINE + start.ToString(TIME_FORMAT) + " " + DELIM + " " + end.
                ToString(TIME_FORMAT) + NEW_LINE + _text + NEW_LINE;
            return text;
        }

        public void setStartEnd(string text)
        {
            text = text.Replace(" ", "");
            var delim_1 = DELIM[0];
            var delim_3 = DELIM[2];

            List<string> start_end = new List<string>();
            string txt = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (i < text.Length - 3)
                {
                    if (text[i] == delim_1 && text[i + 1] == delim_1 && text[i + 2] == delim_3)
                    {
                        start_end.Add(txt);
                        txt = "";
                    }
                    else txt += text[i];
                }
                else txt += text[i];
            }
            start_end.Add(txt);

            var start = start_end[0];
            var end = start_end[start_end.Count - 1];

            start = start.Replace("-", "").Replace(">", "");
            end = end.Replace("-", "").Replace(">", "");

            this.start = DateTime.ParseExact(start, TIME_FORMAT, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
            this.end = DateTime.ParseExact(end, TIME_FORMAT, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);

        }
    }

    class Subtitle
    {
        List<Index> indices = new List<Index>();

        public Subtitle(string file = "")
        {
            if (file.Length > 0) read(file);
        }

        public void read(string file)
        {
            indices.Clear();
            var text = File.ReadAllText(file);

            List<string> lines = new List<string>();
            string txt = "";
            foreach (char letter in text)
            {
                if (letter == '\n')
                {
                    lines.Add(txt);
                    txt = "";
                }
                txt += letter;
            }

            if (txt != "") lines.Add(txt);

            List<string> index_lines = new List<string>();
            foreach (string line_ in lines)
            {
                string line = line_.Trim();
                if (line != "") index_lines.Add(line);
                else
                {
                    if (index_lines.Count > 0) indices.Add(new Index(index_lines));
                    index_lines.Clear();
                }
            }
        }

        public void add_offset(int offset)
        {
            foreach (Index index in indices) index.add_offset(offset);
        }

        public void write(string file)
        {
            string text = "";
            foreach (Index index in indices) text += index.ToString();
            File.WriteAllText(file, text);

        }
    }
}
