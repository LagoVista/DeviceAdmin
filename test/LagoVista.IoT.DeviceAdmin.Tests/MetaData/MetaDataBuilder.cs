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
        //[Fact]
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
        public void SerializeUnits()
        {
            UnitSet unitSet = new UnitSet();

            Console.WriteLine(JsonConvert.SerializeObject(unitSet));
        }
    


    }
}
