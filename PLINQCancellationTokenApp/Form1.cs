using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLINQCancellationTokenApp
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource _cancellationTokenSource;
        public Form1()
        {
            InitializeComponent();
            _cancellationTokenSource = new CancellationTokenSource();
        }

        private bool Mod12(int number)
        {
            Thread.SpinWait(50000); // Gerçek bir hesaplama işlemi yapılmış gibi 500 iterasyon geciktirir.
            return number % 12 == 0;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
                Task.Run(() =>
                {
                    try
                    {
                        Enumerable.Range(1, 100000).AsParallel().WithCancellation(_cancellationTokenSource.Token).Where(Mod12).ToList().ForEach(x =>
                            {
                                Thread.Sleep(100);
                                _cancellationTokenSource.Token.ThrowIfCancellationRequested();
                                listBox1.Invoke((MethodInvoker)delegate { listBox1.Items.Add(x); });
                            });
                    }
                    catch (OperationCanceledException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource.Cancel();
        }
    }
}
