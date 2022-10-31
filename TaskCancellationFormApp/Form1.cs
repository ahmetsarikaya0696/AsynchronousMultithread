using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskCancellationFormApp
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource cancellationTokenSource;
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                cancellationTokenSource = new CancellationTokenSource();
                richTextBox1.Text = "Loading...";
                Task<HttpResponseMessage> myTask;

                myTask = new HttpClient().GetAsync("https://localhost:44332/api/Home", cancellationTokenSource.Token);

                await myTask;

                var content = await myTask.Result.Content.ReadAsStringAsync();
                richTextBox1.Text = content;
            }
            catch (TaskCanceledException ex)
            {
                MessageBox.Show(ex.Message);
                richTextBox1.Text = string.Empty;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (cancellationTokenSource != null) cancellationTokenSource.Cancel();
        }
    }
}
