using AlertingUrlsLib;
using ConfigurationControlLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace ConfigurationControlLib.ViewModels
{
    class BedConfigurationViewModel:INotifyPropertyChanged
    {
        #region PrivateField
        readonly BedData _BedRef = new BedData();
        private ObservableCollection<BedData> beds;
        private BedData bedSelected;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Initializers
        public BedConfigurationViewModel()
        {
            GetAllBeds(new UrlFactory().BedsUrl);
            this.AddNewBedCommand = new MvvmUtilityLib.DelegateCommand(
                (object obj) => { this.AddNewBed(); },
                (object obj) => { return true; }
                );
            this.RemoveBedCommand = new MvvmUtilityLib.DelegateCommand(
                (object obj) => { this.RemoveBed(); },
                (object obj) => { return true; }
                );
        }
        #endregion

        #region Properties
        public string Model { get => _BedRef.Model; set => _BedRef.Model = value; }
        public bool IsAssigned { get => _BedRef.IsAssigned; set => _BedRef.IsAssigned = value; }
        public string Id { get => _BedRef.Id; set => _BedRef.Id = value; }
        public int CountBeds { get; set; } = 0;
        public bool IsBedSelected { get; set; } = false;

        public ObservableCollection<BedData> Beds
        {
            get
            {
                return this.beds;
            }
            set
            {
                beds = value;
                OnPropertyChange("Beds");

            }
        }
        public BedData BedSelected
        {
            get => bedSelected;
            set
            {
                bedSelected = value;
                this.IsBedSelected = true;
                OnPropertyChange("IsBedSelected");
                OnPropertyChange("BedSelected");
            }
        }
        #endregion

        #region Commands
        public ICommand AddNewBedCommand { get; set; }
        public ICommand RemoveBedCommand { get; set; }
        #endregion

        #region ViewLogic
        public void AddNewBed()
        {
            string bedId = GetBedId("B");
            this._BedRef.Id = bedId;
            DataContractJsonSerializer _serailizer = new DataContractJsonSerializer(typeof(BedData));
            System.Net.HttpWebRequest _req = System.Net.HttpWebRequest.CreateHttp(new UrlFactory().BedsUrl);
            _req.Method = "POST";
            _req.ContentType = "application/json";
            _serailizer.WriteObject(_req.GetRequestStream(), this._BedRef);
            var response = _req.GetResponse() as System.Net.HttpWebResponse;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                System.Windows.MessageBox.Show(" Bed Added Successfully"); 
            }
            else
            {
                System.Windows.MessageBox.Show(response.StatusDescription);
            }
            GetAllBeds(new UrlFactory().BedsUrl);
            this.IsBedSelected = false;
            OnPropertyChange("IsBedSelected");
        }
        public void RemoveBed()
        {
            string bedId = this.bedSelected.Id;
            UrlFactory url = new UrlFactory();
            url.Id = bedId;
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.DeleteAsync(new Uri(url.BedsUrl)).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    System.Windows.MessageBox.Show("Bed Removed Successfully");
                }
                else
                {
                    System.Windows.MessageBox.Show("Bed not exists");
                }
            }
            GetAllBeds(new UrlFactory().BedsUrl);
            this.IsBedSelected = false;
            OnPropertyChange("IsBedSelected");
        }
        private string GetBedId(string type)
        {
            UrlFactory url = new UrlFactory();
            url.Id = type;
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetStringAsync(new Uri(url.RandomIdGeneratorUrl)).Result;
                return response;
            }
        }
        public void GetAllBeds(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetStringAsync(new Uri(url)).Result;
                ObservableCollection<BedData> allbeds = JsonConvert.DeserializeObject<ObservableCollection<BedData>>(Convert.ToString(response));
                this.Beds = allbeds;
                this.CountBeds = this.Beds.Count;
                OnPropertyChange("CountBeds");
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
