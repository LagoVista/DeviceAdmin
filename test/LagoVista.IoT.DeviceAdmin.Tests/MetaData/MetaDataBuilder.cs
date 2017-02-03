using LagoVista.Core.Models.UIMetaData;
using System;
using System.Linq;
using Xunit;
using Newtonsoft.Json;
using LagoVista.IoT.DeviceAdmin.Models;
using System.Collections.Generic;
using LagoVista.Core;

namespace LagoVista.IoT.DevieAdmin.Tests.MetaData
{
    public class MetaDataBuilder
    {
        [Fact]
        public void BuildMetaData()
        {
            MetaDataHelper.Instance.RegisterAssembly(typeof(LagoVista.IoT.DeviceAdmin.Startup).Assembly);
            //Console.WriteLine(JsonConvert.SerializeObject(MetaDataHelper.Instance.Domains));
            foreach(var domain in MetaDataHelper.Instance.Domains)
            {
                var entitySummary = MetaDataHelper.Instance.EntitySummaries.Where(ent => ent.DomainKey == domain.Key);
                foreach(var summary in entitySummary)
                {
              //      Console.WriteLine(JsonConvert.SerializeObject(summary));
                    var entity = MetaDataHelper.Instance.Entities.Where(ent => ent.Name ==summary.ClassName);
                    //Console.WriteLine(JsonConvert.SerializeObject(entity));
                }
            }
   //         Console.WriteLine(JsonConvert.SerializeObject(MetaDataHelper.Instance.Entities.Where(ent=>ent.DomainName == MetaDataHelper.Instance.Domains.First().Key)));
        }

        [Fact]
        public void testSeri()
        {
            var response = DetailResponse<DeviceConfiguration>.Create();
            response.Model.Id = Guid.NewGuid().ToId();
            response.Model.Actions = new List<IoT.DeviceAdmin.Models.Action>();
            response.Model.Attributes = new List<IoT.DeviceAdmin.Models.Attribute>();
            response.Model.StateMachines = new List<StateMachine>();
            response.Model.CustomFields = new List<CustomField>();
            response.Model.Sensors = new List<Sensor>();
            response.Model.OwnerOrganization = new Core.Models.EntityHeader() { Id = "123", Text = "OWNER" };
            response.Model.CreatedBy = new Core.Models.EntityHeader() { Id = "123", Text = "CREATED" };
            response.Model.LastUpdatedBy = new Core.Models.EntityHeader() { Id = "123", Text = "UPDATED" };
            response.Model.DeviceCommands = new List<DeviceCommand>();
            response.Model.Environment = LagoVista.IoT.DeviceAdmin.Models.Environment.GetDefault().ToEntityHeader();
            response.Model.ConfigurationVersion = 0.1;
            response.Model.Name = "KEVIN";

            Console.WriteLine(JsonConvert.SerializeObject(response.Model));

            var config = JsonConvert.DeserializeObject<DeviceConfiguration>(JsonConvert.SerializeObject(response.Model));

            Console.WriteLine(config.Name);
            
        }

    }
}
