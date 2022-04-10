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
    public partial class MainFormAsync : Form
    {
        private bool inProgress;

        public MainFormAsync()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
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

        private async void FillDdlWithData()
        {
            inProgress = true;
            //var usersRawData = await GetRawData();
            //var usersData = GetDeserializedObject(usersRawData);
            var usersData = await GetData();

            foreach (var user in usersData.Users)
            {
                ddlUsers.Items.Add(user);
            }

            // Select the first item
            ddlUsers.SelectedIndex = 0;

            inProgress = false;
        }

        private Task<IRestResponse<UsersData>> GetRawData()
        {
            var apiClient = new RestClient(ApiConstants.ENDPOINT);
            return apiClient.ExecuteAsync<UsersData>(new RestRequest());
        }

        private UsersData GetDeserializedObject(IRestResponse<UsersData> usersRawData)
        {
            return JsonConvert.DeserializeObject<UsersData>(usersRawData.Content);
        }

        private Task<UsersData> GetData()
        {
            return Task.Run(() =>
            {
                var apiClient = new RestClient(ApiConstants.ENDPOINT);
                var apiResult = apiClient.Execute<UsersData>(new RestRequest());

                // Simulates long operation
                Thread.Sleep(TimeSpan.FromSeconds(10));

                return JsonConvert.DeserializeObject<UsersData>(apiResult.Content);
            });
        }

        private void btnShowProgress_Click(object sender, EventArgs e)
        {
            var message = inProgress ? "In progress..." : "Done";
            MessageBox.Show(message, "Progress");
        }
    }
}
