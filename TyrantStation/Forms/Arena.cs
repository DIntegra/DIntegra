using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace DI.TyrantStation.Forms
{
    public partial class Arena : Form
    {
        public Arena()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var request = RequestsHelper.RequestFormer.CreateGetHuntingRequest("3840857", "41a4f7c1f497f257fed1e4dbe16ab887");

            var response = (HttpWebResponse)request.GetResponse();

            MessageBox.Show(response.StatusDescription);

            using (var stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    String temp = reader.ReadToEnd();

                    stream.Flush();

                    this.textBox1.Text = temp;
                }                
            }

            response.Close();

            var x = Newtonsoft.Json.Linq.JObject.Parse(this.textBox1.Text);

            var children = x.Children();

            foreach (KeyValuePair<String,Newtonsoft.Json.Linq.JToken>  token in x)
            {
                String name = token.Key;
                String v = token.Value+"";
            }         

            
        }
    }
}
