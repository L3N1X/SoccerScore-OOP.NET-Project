using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackgroundWorkerCalculator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ShowTime();
        }

        private void ShowTime()
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            long n = long.Parse(txtNumber.Text);

            txtNumber.Enabled = false;
            btnCancel.Enabled = true;
            btnCalculate.Enabled = false;
            lblStatus.Text = "Calculating...";

            backgroundWorker.RunWorkerAsync(n);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            backgroundWorker.CancelAsync();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            ShowTime();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            long n = (long)e.Argument;

            long sum = 0;
            int percentage = 0;
            int previousPercentage = 0;

            for (long i = 1; i <= n; i++)
            {
                if (backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                percentage = (int)((double)i / n * 100);
                if (percentage != previousPercentage)
                {
                    backgroundWorker.ReportProgress(percentage);
                }
                previousPercentage = percentage;

                sum += i;
            }

            e.Result = sum;
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            progressBarLbl.Text = $"{progressBar.Value}%";
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            txtNumber.Enabled = true;
            btnCancel.Enabled = false;
            btnCalculate.Enabled = true;

            if (e.Cancelled)
            {
                lblStatus.Text = "Calculating canceled!";
                return;
            }

            // Separating thousands in the ToString method
            lblStatus.Text = ((long)e.Result).ToString("#,###");
        }
    }
}
