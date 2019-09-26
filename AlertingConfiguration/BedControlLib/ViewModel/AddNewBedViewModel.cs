using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Net;
using AlertingUrlsLib;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using BedControlLib.Model;
using MvvmUtilityLib;
using System.IO;
namespace BedControlLib.ViewModel
{
    class AddNewBedViewModel: INotifyPropertyChanged
    {
        #region PrivateField
        readonly BedData _BedRef = new BedData();
        public event PropertyChangedEventHandler PropertyChanged;
        string successMessage = "";
        #endregion

        #region Initializers
        public AddNewBedViewModel()
        {
            this.AddNewBedCommand = new MvvmUtilityLib.DelegateCommand(
                (object obj) => { this.AddNewBed(); },
                (object obj) => { return true; }
                );
        }
        #endregion

        #region Properties
        public string Model { get => _BedRef.Model; set => _BedRef.Model = value; }
        public bool IsAssigned { get => _BedRef.IsAssigned; set => _BedRef.IsAssigned = false; }
        public string Id { get => _BedRef.Id; set => _BedRef.Id = value; }
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
        public ICommand AddNewBedCommand { get; set; }
        #endregion

        #region ViewLogic
        public void AddNewBed()
        {

            string bedId = GetBedId("M");
            this._BedRef.Id = bedId;
            DataContractJsonSerializer _serailizer = new DataContractJsonSerializer(typeof(BedData));
            System.Net.HttpWebRequest _req = System.Net.HttpWebRequest.CreateHttp(new UrlFactory().BedsUrl);
            _req.Method = "POST";
            _req.ContentType = "application/json";
            _serailizer.WriteObject(_req.GetRequestStream(), this._BedRef);
            var response = _req.GetResponse() as System.Net.HttpWebResponse;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                this.SuccessMessage = "Bed Added Successfully";
            }
            else
            {
                this.SuccessMessage = response.StatusDescription;
            }
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
        #endregion
    }
}
