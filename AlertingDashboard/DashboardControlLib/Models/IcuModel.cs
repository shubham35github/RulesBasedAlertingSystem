using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AlertingUrlsLib;
using MvvmUtilityLib;

namespace DashboardControlLib.Models
{
    public class IcuModel:INotifyPropertyChanged
    {
        public IcuModel()
        {
            DischargeFromIcuCommand = new DelegateCommand((object obj) => { this.DischargeFromIcu(obj.ToString()); }, (object obj) => { return true; });
        }
        
        private double temperature;
        private int spo2;
        private int pulseRate;
        private string temperatureColor="Green";
        private string spo2Color="Green";
        private string pulseRateColor="Green";
        public string Name { get; set; }
        public string Age { get; set; }
        public string Bed { get; set; }
        public string Monitor { get; set; }
        public string AssociationId { get; set; }
        public ICommand DischargeFromIcuCommand { get; set; }
        public double Temperature {
            get=>temperature;
            set
            {
                this.temperature = value;
                OnPropertyChange("Temperature");
            }
        }
        public int Spo2
        {
            get => spo2;
            set
            {
                this.spo2 = value;
                OnPropertyChange("Spo2");
            }
        }
        public int PulseRate
        {
            get => pulseRate;
            set
            {
                this.pulseRate = value;
                OnPropertyChange("PulseRate");
            }
        }
        public string TemperatureColor
        {
            get => temperatureColor;
            set
            {
                this.temperatureColor = value;
                OnPropertyChange("TemperatureColor");
            }
        } 
        public string Spo2Color
        {
            get => spo2Color;
            set
            {
                this.spo2Color = value;
                OnPropertyChange("Spo2Color");
            }
        }
        public string PulseRateColor
        {
            get => pulseRateColor;
            set
            {
                this.pulseRateColor = value;
                OnPropertyChange("PulseRateColor");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChange([CallerMemberName]string propertyName = null)
        {
            var eventhandler = this.PropertyChanged;
            if (eventhandler != null)
                eventhandler(this, new PropertyChangedEventArgs(propertyName));
        }
        public void DischargeFromIcu(string v)
        {
            UrlFactory url = new UrlFactory();
            url.Id = v;
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.DeleteAsync(new Uri(url.IcuAssociationUrl)).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    DashboardControlLib.ViewModels.DashboardViewModel dc = new ViewModels.DashboardViewModel();
                    var that=dc.GetCurrentReference();
                    that.GetAllBeds(new UrlFactory().BedsUrl);
                    that.GetAllMonitors(new UrlFactory().MonitorsUrl);
                    that.GetAllPatients(new UrlFactory().PatientsUrl);
                    that.GetAllIcuPatients(new UrlFactory().IcuAssociationUrl);

                    System.Windows.MessageBox.Show("Patient Removed Successfully");
                }
                else
                {
                    System.Windows.MessageBox.Show("Patient not removed");
                }
            }
            

        }
    }
}
