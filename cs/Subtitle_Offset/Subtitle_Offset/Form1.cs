using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;


namespace Subtitle_Offset
{
    public partial class Form1 : Form
    {

        List<string> files = new List<string>();
        List<string> subtitle_files = new List<string>();
        int offset = 0;
        string output = "";

        Subtitle subtitle = new Subtitle();

        public Form1()
        {
            InitializeComponent();
        }

        private void add_subtitles_Click(object sender, EventArgs e)
        {
            using (var op = new OpenFileDialog())
            {
                op.Title = "Choose Subtitle Files";
                op.Filter = "Srt (*.srt)|*.srt| Text (*.txt)|*.txt";
                op.Multiselect = true;

                if (op.ShowDialog() == DialogResult.OK)
                {
                    subtitles.Items.Clear();
                    var fileNames = op.FileNames;
                    foreach (string file in fileNames)
                    {
                        if (!files.Contains(file))
                        {
                            var item = new ListViewItem(Path.GetFileName(file));
                            item.Name = file;
                            subtitles.Items.Add(item);
                            files.Add(file);
                        }
                    }
                }
            }
        }

        private void remove_subtitles_Click(object sender, EventArgs e)
        {
            var items = subtitles.SelectedItems;
            if (items.Count > 0)
            {
                foreach (ListViewItem item in items)
                {
                    subtitles.Items.Remove(item);
                    files.Remove(item.Name);
                }
            }
            else
            {
                subtitles.Items.Clear();
                files.Clear();
            }
        }

        private void browse_Click(object sender, EventArgs e)
        {

            using (var op = new FolderBrowserDialog())
            {
                op.Description = "Choose Save Directory";
                if (op.ShowDialog() == DialogResult.OK) outputDir.Text = op.SelectedPath;
            }
        }

        private void add_offset_Click(object sender, EventArgs e)
        {
            var offset = (int)(seconds.Value + (minutes.Value * 60));
            if (offset > 0)
            {
                if (negative.Checked) offset *= -1;
                this.offset = offset;

                var output = outputDir.Text;
                if (output.Length > 0)
                {
                    this.output = output;
                    var selected_subtitles = subtitles.SelectedItems;

                    if (selected_subtitles.Count > 0)
                    {
                        // ask quesion whether to use selected or not
                        if (MessageBox.Show("Work on the selected subtitles?", "Selected Subtitles", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            foreach (ListViewItem item in selected_subtitles) subtitle_files.Add(item.Name);
                            add_offset.Enabled = false;
                            progressBar1.Maximum = subtitle_files.Count;

                            Task.Run(() => action());
                        }
                    }
                    else subtitle_files = files;
                }
                else MessageBox.Show("Set the output folder", "Output Folder", MessageBoxButtons.OK);
            }
            else MessageBox.Show("Set the seconds or minutes", "Select Offset (seconds, minutes)", MessageBoxButtons.OK);
        }

        void action()
        {
            for (int i = 0; i < subtitle_files.Count; i++)
            {
                string file = subtitle_files[i];
                string basename = Path.GetFileName(file);
                string name = Path.GetFileNameWithoutExtension(Path.Combine(output, basename));
                string ext = Path.GetExtension(file);

                subtitle.read(file);
                subtitle.add_offset(offset);
                //subtitle.write(name + "-offset_" + offset + "-seconds" + ext);
                //progressBar1.Value = i + 1;

                Invoke(new MethodInvoker(delegate
                {
                    progressBar1.Value = i + 1;
                    result.Text = name;
                }));
            }

            Invoke(new MethodInvoker(delegate
            {
                add_offset.Enabled = true;
            }));
        }
    }
}
