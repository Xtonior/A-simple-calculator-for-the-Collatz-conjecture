using System;
using System.Collections.Generic;
/*
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
*/
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class CollatzConjecture : Form
    {
        int value;
        int currentSteps;
        List<string> stepsSum;

        string target = "https://github.com/Xtonior";

        public CollatzConjecture()
        {
            InitializeComponent();
            valueNumeric.Controls[0].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            value = (int)numericUpDown1.Value;
            
            currentSteps = 0;
            comboBox1.Items.Clear();

            stepsSum = new List<string>();

            while (value > 1)
            {
                if (value % 2 == 0)
                {
                    stepsSum.Add(value.ToString() + " / 2 = " + value / 2);

                    value = value / 2;
                    currentSteps++;
                }
                else
                {
                    stepsSum.Add("3 * " + value + " + 1 = " + (3 * value + 1).ToString() );

                    value = 3 * value + 1;
                    currentSteps++;
                }
            }
            valueNumeric.Value = currentSteps;

            for (int i = 0; i < stepsSum.Count; i++)
            {
                comboBox1.Items.Insert(i, stepsSum[i]);
            }
        }

        private void gitHubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(target);
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
