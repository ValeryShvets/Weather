using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json.Linq;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        const string API = "0fc3955a86cd1b3ea2c50c37818ae3fd";


        public MainPage()
        {
            InitializeComponent();
        }

        private async void getWeather_Clicked(object sender, EventArgs e)
        {
            string city = userInput.Text.Trim();
            if(city.Length < 2) 
            {
                await DisplayAlert("Error", "The name of city used to be bigger", "Okay");
                return;
            }
       
           
            
            HttpClient client = new HttpClient();
            string url =$"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={API}&units=metric";
            string response = await client.GetStringAsync(url);

            var json = JObject.Parse(response);
           
             string temp = json["main"]["temp"].ToString();
             string fl = json["main"]["feels_like"].ToString();
             string humidity = json["main"]["humidity"].ToString();
            resultLabel.Text = "Weather right now : " + temp +  "     Feels like : " + fl + "    Humidity : " + humidity;
             
        }
    }
}
