using System;
using System.IO;
using System.Net.Http;
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
            string data = string.Empty;
            Task<string> fileToRead = ReadFileAsync();

            richTextBox2.Text = await new HttpClient().GetStringAsync("https://www.google.com");

            data = await fileToRead;

            richTextBox1.Text = data;
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
