using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlertingUrlsLib
{
    public class UrlFactory
    {
        readonly static string port_no = "62455";
        private readonly string BaseUrl = string.Format("http://localhost:{0}/", UrlFactory.port_no);
        public string Id { get; set; } = null;
        public string BedsUrl
        {
            get
            {
                if (Id == null)
                    return BaseUrl + "api/Beds";
                else
                {
                    var url = BaseUrl + "api/Beds/" + Id;
                    Id = null;
                    return url;
                }

            }
        }
        public string MonitorsUrl
        {
            get
            {
                if (Id == null)
                    return BaseUrl + "api/Monitors";
                else
                {
                    var url = BaseUrl + "api/Monitors/" + Id;
                    Id = null;
                    return url;
                }

            }
        }
        public string PatientsUrl
        {
            get
            {
                if (Id == null)
                    return BaseUrl + "api/Patients";
                else
                {
                    var url = BaseUrl + "api/Patients/" + Id;
                    Id = null;
                    return url;
                }

            }
        }
        public string RandomVitalsGeneratorUrl { get { return BaseUrl + "api/Utility"; } }
        public string RandomIdGeneratorUrl
        {
            get
            {
                var url = BaseUrl + "api/Utility/" + Id;
                Id = null;
                return url;
            }
        }
        public string IcuAssociationUrl
        {
            get
            {
                if (Id == null)
                    return BaseUrl + "api/Icu/beds";
                else
                {
                    var url = BaseUrl + "api/Icu/beds/" + Id;
                    Id = null;
                    return url;
                }

            }
        }
        public string WritePatientVitalsUrl
        {
            get
            {
                var url = BaseUrl + "api/Icu/beds/" + Id + "/values";
                Id = null;
                return url;
            }
        }
        public string PatientVitalsValidationUrl
        {
            get
            {
                var url = BaseUrl + "api/Icu/beds/" + Id + "/validate";
                Id = null;
                return url;
            }
        }
        public string IcuAlerts { get { return BaseUrl + "api/Icu/beds/alerts"; } }

    }
}
