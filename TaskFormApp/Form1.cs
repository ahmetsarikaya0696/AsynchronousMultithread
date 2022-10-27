using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskFormApp
{
    public partial class Form1 : Form
    {
        public int Counter { get; set; } = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnReadFile_Click(object sender, EventArgs e)
        {
            //richTextBox1.Text = ReadFile();
            richTextBox1.Text = await ReadFileAsync();
        }

        private void btnCounter_Click(object sender, EventArgs e)
        {
            tbCounter.Text = Counter++.ToString();
        }

        private string ReadFile()
        {
            var data = string.Empty;
            using (var streamReader = new StreamReader("file.txt"))
            {
                Thread.Sleep(5000);
                data = streamReader.ReadToEnd();
            }
            return data;
        }

        private async Task<string> ReadFileAsync()
        {
            var data = string.Empty;
            using (var streamReader = new StreamReader("file.txt"))
            {
                await Task.Delay(5000);
                data = await streamReader.ReadToEndAsync();
            }
            return data;
        }
    }
}
