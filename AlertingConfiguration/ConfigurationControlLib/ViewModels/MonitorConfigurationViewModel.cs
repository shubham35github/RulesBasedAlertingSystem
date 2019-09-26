using AlertingUrlsLib;
using ConfigurationControlLib.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ConfigurationControlLib.ViewModels
{
    class MonitorConfigurationViewModel:INotifyPropertyChanged
    {
        #region PrivateField
        readonly MonitoringDevice _MonitorRef = new MonitoringDevice();
        private ObservableCollection<MonitoringDevice> monitors;
        private MonitoringDevice monitorSelected;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Initializers
        public MonitorConfigurationViewModel()
        {
            GetAllMonitors(new UrlFactory().MonitorsUrl);
            this.AddNewMonitorCommand = new MvvmUtilityLib.DelegateCommand(
                (object obj) => { this.AddNewMonitor(); },
                (object obj) => { return true; }
                );
            this.RemoveMonitorCommand = new MvvmUtilityLib.DelegateCommand(
                (object obj) => { this.RemoveMonitor(); },
                (object obj) => { return true; }
                );

        }
        #endregion
        
        #region Properties
        public string Model { get => _MonitorRef.Model; set => _MonitorRef.Model = value; }
        public bool IsAssigned { get => _MonitorRef.IsAssigned; set => _MonitorRef.IsAssigned = value; }
        public string Id { get => _MonitorRef.Id; set => _MonitorRef.Id = value; }
        public int CountMonitors { get; set; } = 0;
        public bool IsMonitorSelected { get; set; } = false;
        public ObservableCollection<MonitoringDevice> Monitors
        {
            get
            {
                return this.monitors;
            }
            set
            {
                monitors = value;
                OnPropertyChange("Monitors");

            }
        }
        public MonitoringDevice MonitorSelected
        {
            get => monitorSelected;
            set
            {
                monitorSelected = value;
                this.IsMonitorSelected =true;
                OnPropertyChange("IsMonitorSelected");
                OnPropertyChange("MonitorSelected");
            }
        }
        #endregion

        #region Commands
        public ICommand AddNewMonitorCommand { get; set; }
        public ICommand RemoveMonitorCommand { get; set; }
        #endregion

        #region ViewLogic
        public void AddNewMonitor()
        {
            string monitorId = GetMonitorId("M");
            this._MonitorRef.Id = monitorId;
            DataContractJsonSerializer _serailizer = new DataContractJsonSerializer(typeof(MonitoringDevice));
            System.Net.HttpWebRequest _req = System.Net.HttpWebRequest.CreateHttp(new UrlFactory().MonitorsUrl);
            _req.Method = "POST";
            _req.ContentType = "application/json";
            _serailizer.WriteObject(_req.GetRequestStream(), this._MonitorRef);
            var response = _req.GetResponse() as System.Net.HttpWebResponse;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                System.Windows.MessageBox.Show("Monitor Added Successfully");
            }
            else
            {
                System.Windows.MessageBox.Show(response.StatusDescription);
            }
            GetAllMonitors(new UrlFactory().MonitorsUrl);
            this.IsMonitorSelected = false;
            OnPropertyChange("IsMonitorSelected");

        }
        public void RemoveMonitor()
        {
            string monitorId = this.monitorSelected.Id;
            UrlFactory url = new UrlFactory();
            url.Id = monitorId;
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.DeleteAsync(new Uri(url.MonitorsUrl)).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    System.Windows.MessageBox.Show("Monitor Removed Successfully");
                }
                else
                {
                    System.Windows.MessageBox.Show("Monitor not exists");
                }
            }
            GetAllMonitors(new UrlFactory().MonitorsUrl);
            this.IsMonitorSelected = false;
            OnPropertyChange("IsMonitorSelected");
        }
        private string GetMonitorId(string type)
        {
            UrlFactory url = new UrlFactory();
            url.Id = type;
            using (var httpClient = new HttpClient())
            {

                var response = httpClient.GetStringAsync(new Uri(url.RandomIdGeneratorUrl)).Result;
                return response;
            }
        }
        public void GetAllMonitors(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetStringAsync(new Uri(url)).Result;
                ObservableCollection<MonitoringDevice> allmonitors = JsonConvert.DeserializeObject<ObservableCollection<MonitoringDevice>>(Convert.ToString(response));
                this.Monitors = allmonitors;
                this.CountMonitors = this.Monitors.Count;
                OnPropertyChange("CountMonitors");
            }
        }
        public void OnPropertyChange([CallerMemberName]string propertyName = null)
        {
            var eventhandler = this.PropertyChanged;
            if (eventhandler != null)
                eventhandler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
