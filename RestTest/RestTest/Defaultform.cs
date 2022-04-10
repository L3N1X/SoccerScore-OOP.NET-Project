using Newtonsoft.Json;
using RestSharp;
using RestTest.Constants;
using RestTest.Model;
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

namespace RestTest
{
    public partial class Defaultform : Form
    {
        private bool inProgress;
        public Defaultform()
        {
            InitializeComponent();
        }

        private async void FillDdlWithData()
        {
            inProgress = true;
            //var usersRawData = await GetRawData();
            //var usersData = GetDeserializedObject(usersRawData);
            var usersData = await GetData();

            foreach (var user in usersData.Users)
            {
                cbUsers.Items.Add(user);
            }

            // Select the first item
            cbUsers.SelectedIndex = 0;

            inProgress = false;
        }

        private Task<IRestResponse<UserData>> GetRawData()
        {
            var apiClient = new RestClient(ApiConstants.ENDPOINT);
            return apiClient.ExecuteAsync<UserData>(new RestRequest());
        }

        private UserData GetDeserializedObject(IRestResponse<UserData> usersRawData)
        {
            return JsonConvert.DeserializeObject<UserData>(usersRawData.Content);
        }

        private Task<UserData> GetData()
        {
            return Task.Run(() =>
            {
                var apiClient = new RestClient(ApiConstants.ENDPOINT);
                var apiResult = apiClient.Execute<UserData>(new RestRequest());

                // Simulates long operation
                Thread.Sleep(TimeSpan.FromSeconds(10));

                return JsonConvert.DeserializeObject<UserData>(apiResult.Content);
            });
        }

        private void btnShowProgress_Click(object sender, EventArgs e)
        {
            var message = inProgress ? "In progress..." : "Done";
            MessageBox.Show(message, "Progress");
        }

        private void Defaultform_Load(object sender, EventArgs e)
        {
            try
            {
                this.FillDdlWithData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
