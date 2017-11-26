using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoGracias
{
    public partial class CustomMessageBox : Form
    {
        #region Variables
        static CustomMessageBox newScoreBox;

        #endregion

        public CustomMessageBox()
        {
            InitializeComponent();
        }

        #region Functions
        public static void ShowBox(string message)
        {
            newScoreBox = new CustomMessageBox();
            newScoreBox.label1.Text = message;
            newScoreBox.ShowDialog();
        }
        #endregion

        private void OKButton_Click(object sender, EventArgs e)
        {
            newScoreBox.Dispose();
        }

        private void OKButton_MouseEnter(object sender, EventArgs e)
        {
            this.OKButton.BackColor = Color.FromArgb(40, 200, 200);
        }

        private void OKButton_MouseLeave(object sender, EventArgs e)
        {
            this.OKButton.BackColor = Color.LightSeaGreen;
        }
    }
}
