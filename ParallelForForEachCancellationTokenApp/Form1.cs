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

namespace ParallelForForEachCancellationTokenApp
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource _cancellationTokenSource;
        private int _counter = 0;

        public Form1()
        {
            InitializeComponent();
            _cancellationTokenSource = new CancellationTokenSource();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            listBox1.Invoke((MethodInvoker)delegate { listBox1.Items.Clear(); });
            _cancellationTokenSource = new CancellationTokenSource();

            List<string> urls = new List<string>()
            {
                "https://www.trendyol.com",
                "https://www.twitch.tv/",
                "https://twitter.com/",
                "https://www.trendyol.com",
                "https://www.twitch.tv/",
                "https://twitter.com/",
                "https://www.trendyol.com",
                "https://www.twitch.tv/",
                "https://twitter.com/",
                "https://www.trendyol.com",
                "https://www.twitch.tv/",
                "https://twitter.com/",
                "https://www.trendyol.com",
                "https://www.twitch.tv/",
                "https://twitter.com/",
                "https://www.trendyol.com",
                "https://www.twitch.tv/",
                "https://twitter.com/"
            };

            HttpClient httpClient = new HttpClient();

            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.CancellationToken = _cancellationTokenSource.Token;

            Task.Run(() =>
            {
                try
                {
                    Parallel.ForEach(urls, parallelOptions, (url) =>
                    {
                        string content = httpClient.GetStringAsync(url).Result;
                        string data = $"Url : {url} Length : {content.Length}";

                        parallelOptions.CancellationToken.ThrowIfCancellationRequested(); // _cancellationtokensource ' a erişemediğimiz zaman bu şekilde kullanılır.
                        //_cancellationTokenSource.Token.ThrowIfCancellationRequested();
                        listBox1.Invoke((MethodInvoker)delegate { listBox1.Items.Add(data); });
                    });
                }
                catch (OperationCanceledException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception)
                {
                    MessageBox.Show("Genel bir hata meydana geldi.");
                }
            });

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource.Cancel();
        }

        private void btnCounter_Click(object sender, EventArgs e)
        {
            btnCounter.Text = _counter++.ToString();
        }
    }
}
