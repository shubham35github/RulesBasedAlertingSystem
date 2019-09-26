using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AlertingUrlsLib;
using MonitorControlLib.Model;
using System.Net.Http;
using System.Runtime.Serialization.Json;

namespace MonitorControlLib.ViewModel
{
    class AddNewMonitorViewModel: INotifyPropertyChanged
    {
        #region PrivateField
        readonly  MonitoringDevice _MonitorRef= new MonitoringDevice();
        public event PropertyChangedEventHandler PropertyChanged;
        string successMessage = "";
        #endregion

        #region Initializers
        public AddNewMonitorViewModel()
        {
            this.AddNewMonitorCommand = new MvvmUtilityLib.DelegateCommand(
                (object obj) => { this.AddNewMonitor(); },
                (object obj) => { return true; }
                );
        }
        #endregion

        #region Properties
        public string Model { get => _MonitorRef.Model; set => _MonitorRef.Model = value; }
        public bool IsAssigned { get => _MonitorRef.IsAssigned; set => _MonitorRef.IsAssigned = false; }
        public string Id { get => _MonitorRef.Id; set => _MonitorRef.Id = value; }
        public string SuccessMessage
        {
            get
            {
                return this.successMessage;
            }
            set
            {
                if (value != this.successMessage)
                {
                    this.successMessage = value;
                    OnPropertyChanged("SuccessMessage");

                }
            }
        }
        void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region Commands
        public ICommand AddNewMonitorCommand { get; set; }
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
                this.SuccessMessage = "Monitor Added Successfully";
            }
            else
            {
                this.SuccessMessage = response.StatusDescription;
            }
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
        #endregion
    }
}

