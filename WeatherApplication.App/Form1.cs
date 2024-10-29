using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeatherApplication.Data.Context;

namespace WeatherApplication.App
{
    public partial class Form1 : Form
    {
        Context db;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            db = new Context();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var city = db.WeatherRepository.GetCity(txtSearch.Text);
            foreach (var item in city)
            {
                var weather = db.WeatherRepository.GetWeather(item.lat, item.lon);
                lblTitle.Text = weather.Name;
                lblTemp.Text = weather.Main.Temp.ToString();
                lblTempMin.Text = weather.Main.Temp_Min.ToString();
                lblTempMax.Text = weather.Main.Temp_Max.ToString();
                lblPessure.Text = weather.Main.Pressure.ToString();
                lblHumidity.Text = weather.Main.Humidity.ToString();
                lblSeaLevel.Text = weather.Main.Sea_Level.ToString();
                lblGrndLevel.Text = weather.Main.Grnd_Level.ToString();
                lblSpeed.Text = weather.Wind.Speed.ToString();
                lblDeg.Text = weather.Wind.Deg.ToString();
                lblGust.Text = weather.Wind.Gust.ToString();
                lblClouds.Text = weather.Clouds.All.ToString();
                lblLat.Text = item.lat.ToString();
                lblLod.Text = item.lon.ToString();
                
            }
        }
    }
}
