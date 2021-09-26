using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompulsoryAssigment
{
    public partial class Form1 : Form
    {
        CancellationTokenSource ctsGenerating;
        CancellationTokenSource ctsDrawing;
        CancellationToken tokenG;
        CancellationToken tokenD;

        public Form1()
        {
            ctsGenerating = new CancellationTokenSource();
            ctsDrawing = new CancellationTokenSource();
            tokenG = ctsGenerating.Token;
            tokenD = ctsDrawing.Token;
            InitializeComponent();
        }

        private int sort()
        {
            if (rbtnAsc.Checked)
            {
                return 1;
            }
            if (rbtnDes.Checked)
            {
                return -1;
            }
            return 0;
        }

        private void logConsole(string text)
        {
            tBoxConsole.AppendText(text + Environment.NewLine);
        }

        private void addItemsListResult(List<long> primeList, int sort)
        {
            if (sort == 1)
            {
                for (int i = 0; i < primeList.Count; i++)
                {
                    if (tokenD.IsCancellationRequested)
                    {
                        restoreTokenD();
                        break;
                    }
                    else
                    {
                        this.Invoke(new Action(() => listResult.Items.Add(primeList[i])));
                    }
                }
            }
            else if (sort == -1)
            {
                for (int i = (primeList.Count - 1); i >= 0; i--)
                {
                    if (tokenD.IsCancellationRequested)
                    {
                        restoreTokenD();
                        break;
                    }
                    else
                    {
                        this.Invoke(new Action(() => listResult.Items.Add(primeList[i])));
                    }
                }
            }
            else
            {
                this.Invoke(new Action (() => listResult.Items.Add("An error has occurred, please restart the app")));
            }
        }

        private void clearResult()
        {
            listResult.Items.Clear();
        }

        private bool validateInput()
        {
            if (tBoxInitNum.Text.Equals("") || tBoxInitNum.Text.Equals("Initial number"))
            {
                logConsole("The initial number can't be empty");
                return false;
            }
            else if (tBoxFinalNum.Text.Equals("") || tBoxFinalNum.Text.Equals("Final number"))
            {
                logConsole("The final number can't be empty");
                return false;
            }
            else 
            {
                long longStr;
                if (!long.TryParse(tBoxInitNum.Text, out longStr))
                {
                    logConsole("The initial number must be a number");
                    return false;
                }
                else if (!long.TryParse(tBoxFinalNum.Text, out longStr))
                {
                    logConsole("The final number must be a number");
                    return false;
                }
                else
                {
                    long initial = long.Parse(tBoxInitNum.Text);
                    long final = long.Parse(tBoxFinalNum.Text);
                    if (initial < 2)
                    {
                        logConsole("The initial number must be bigger than 1");
                        return false;
                    }
                    else if (final < initial)
                    {
                        logConsole("The final number must be bigger than the inital number");
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }                
            }
        }

        private void restoreTokenG()
        {
            ctsGenerating = new CancellationTokenSource();
            tokenG = ctsGenerating.Token;
        }

        private void restoreTokenD()
        {
            ctsDrawing = new CancellationTokenSource();
            tokenD = ctsDrawing.Token;
        }

        private void disableCancelBtn()
        {
            btnCancel.Enabled = false;
        }

        private void disableCancelBtn(String text)
        {
            btnCancel.Enabled = false;
            btnCancel.Text = text;
        }

        private void enableCancelBtn(string text)
        {
            btnCancel.Enabled = true;
            btnCancel.Text = text;
        }

        private void enableMario()
        {
            marioDraw.Visible = true;
        }

        private void disableMario()
        {
            marioDraw.Visible = false;
        }

        private async void btnGenerate_Click(object sender, EventArgs e)
        {
            if (validateInput())
            {
                btnClearResult.Enabled = false;
                enableCancelBtn("Stop Generating");
                enableMario();

                Stopwatch sw = new Stopwatch();

                long initNumber = long.Parse(tBoxInitNum.Text);
                long finalNumber = long.Parse(tBoxFinalNum.Text);
                int sort = this.sort();

                logConsole("Generating prime between " + initNumber + " & " + finalNumber);

                sw.Start();
                List<long> primeList = await Task.Run(() =>
                {
                    return PrimeGenerator.GetPrimesParallel(initNumber, finalNumber, tokenG);
                });
                sw.Stop();

                disableCancelBtn();
                restoreTokenG();

                double elapsed = sw.Elapsed.TotalMilliseconds / 1000;
                logConsole(primeList.Count + " numbers generated in " + elapsed + " seconds.");
                lblTimeUsed.Text = elapsed + " seconds.";
                logConsole("Drawing the result...");

                clearResult();

                enableCancelBtn("Stop Drawing");

                await Task.Run(() => addItemsListResult(primeList, sort), tokenD);

                logConsole("Done.");
                btnClearResult.Enabled = true;
                disableCancelBtn("Stop");
                disableMario();
            }            
        }
        
        private void btnClearResult_Click(object sender, EventArgs e)
        {
            clearResult();
            lblTimeUsed.Text = "";
        }

        private void tBoxInitNum_Enter(object sender, EventArgs e)
        {
            if (tBoxInitNum.Text == "Initial number")
            {
                tBoxInitNum.Text = "";
                tBoxInitNum.ForeColor = SystemColors.WindowText;
            }
        }

        private void tBoxInitNum_Leave(object sender, EventArgs e)
        {
            if (tBoxInitNum.Text.Length == 0)
            {
                tBoxInitNum.Text = "Initial number";
                tBoxInitNum.ForeColor = SystemColors.GrayText;
            }
        }

        private void tBoxFinalNum_Enter(object sender, EventArgs e)
        {
            if (tBoxFinalNum.Text == "Final number")
            {
                tBoxFinalNum.Text = "";
                tBoxFinalNum.ForeColor = SystemColors.WindowText;
            }
        }

        private void tBoxFinalNum_Leave(object sender, EventArgs e)
        {
            if (tBoxFinalNum.Text.Length == 0)
            {
                tBoxFinalNum.Text = "Final number";
                tBoxFinalNum.ForeColor = SystemColors.GrayText;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.Text.Equals("Stop Generating"))
            {
                ctsGenerating.Cancel();
            }
            if (btnCancel.Text.Equals("Stop Drawing"))
            {
                ctsDrawing.Cancel();
            }
        }

        private void tBoxInitNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tBoxFinalNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}
