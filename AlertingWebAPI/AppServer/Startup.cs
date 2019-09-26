using AppServer.Controllers;
using BedAssociationDataModelLib;
using BedDataModelLib;
using DataContextContractsLib;
using DataModelDataContextLib;
using DataModelFileReader;
using DataModelFileWriterLib;
using DataReaderContractsLib;
using DataWriterContractsLib;
using DefaultValidatorLib;
using GenericRepositoryLib;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MonitorDataModelLib;
using PatientDataModelLib;
using PatientVitalsDataModelLib;
using RepositoryContractsLib;
using ValidatorContractsLib;

namespace AppServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IRepository<BedData>, GenericRepository<BedData>>();
            services.AddSingleton<IDataContext<BedData>, DataModelDataContext<BedData>>();
            services.AddSingleton<IDataReader<BedData>>(new DataModelFileReader<BedData>("beds.txt"));
            services.AddSingleton<IDataWriter<BedData>>(new DataModelFileWriter<BedData>("beds.txt"));

            services.AddSingleton<IRepository<PatientDetails>, GenericRepository<PatientDetails>>();
            services.AddSingleton<IDataContext<PatientDetails>, DataModelDataContext<PatientDetails>>();
            services.AddSingleton<IDataReader<PatientDetails>>(new DataModelFileReader<PatientDetails>("patients.txt"));
            services.AddSingleton<IDataWriter<PatientDetails>>(new DataModelFileWriter<PatientDetails>("patients.txt"));

            services.AddSingleton<IRepository<MonitoringDevice>, GenericRepository<MonitoringDevice>>();
            services.AddSingleton<IDataContext<MonitoringDevice>, DataModelDataContext<MonitoringDevice>>();
            services.AddSingleton<IDataReader<MonitoringDevice>>(new DataModelFileReader<MonitoringDevice>("monitors.txt"));
            services.AddSingleton<IDataWriter<MonitoringDevice>>(new DataModelFileWriter<MonitoringDevice>("monitors.txt"));

            services.AddSingleton<IDataContext<PatientVitalsData>, DataModelDataContext<PatientVitalsData>>();
            services.AddSingleton<IDataReader<PatientVitalsData>>(new DataModelFileReader<PatientVitalsData>("patientVitals.txt"));
            services.AddSingleton<IDataWriter<PatientVitalsData>>(new DataModelFileWriter<PatientVitalsData>("patientVitals.txt"));

            services.AddSingleton<IRepository<BedAssociation>, GenericRepository<BedAssociation>>();
            services.AddSingleton<IDataContext<BedAssociation>, DataModelDataContext<BedAssociation>>();
            services.AddSingleton<IDataReader<BedAssociation>>(new DataModelFileReader<BedAssociation>("bedAssociation.txt"));
            services.AddSingleton<IDataWriter<BedAssociation>>(new DataModelFileWriter<BedAssociation>("bedAssociation.txt"));

            services.AddSingleton<IValidate<PatientVitalsData>, DefaultValidator>();

            services.AddTransient<BedsController, BedsController>();
            services.AddTransient<MonitorsController, MonitorsController>();
            services.AddTransient<PatientsController, PatientsController>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Alerting App API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c=>{c.SwaggerEndpoint("/swagger/v1/swagger.json", "Alerting App API v1");});
        }
    }
}
