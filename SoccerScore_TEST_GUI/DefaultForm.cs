using SoccerScoreData.Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoccerScore_TEST_GUI
{
    public partial class DefaultForm : Form
    {
        internal DataManager dataManager = new DataManager();
        public DefaultForm()
        {
            InitializeComponent();
            if (dataManager.HasDefaultSettings())
            {
                Form dialog = new InitializeForm(dataManager);
                dialog.ShowDialog();
            }
        }

        private void DefaultForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
