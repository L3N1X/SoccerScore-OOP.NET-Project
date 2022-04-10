using Newtonsoft.Json;
using RESTfulAPI.Constants;
using RESTfulAPI.Models;
using RestSharp;
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

namespace RESTfulAPI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    FillDdlWithData();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            try
            {
                FillDdlWithData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillDdlWithData()
        {
            var usersData = GetData();

            foreach (var user in usersData.Users)
            {
                ddlUsers.Items.Add(user);
            }

            // Select the first item
            ddlUsers.SelectedIndex = 0;
        }

        private UsersData GetData()
        {
            var apiClient = new RestClient(ApiConstants.ENDPOINT);
            var apiResult = apiClient.Execute<UsersData>(new RestRequest());

            // Simulates long operation
            Thread.Sleep(TimeSpan.FromSeconds(10));
            
            return JsonConvert.DeserializeObject<UsersData>(apiResult.Content);
        }
    }
}
