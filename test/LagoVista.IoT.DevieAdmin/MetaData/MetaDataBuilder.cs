using LagoVista.Core.Models.UIMetaData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using System.Reflection;
using Newtonsoft.Json;

namespace LagoVista.IoT.DevieAdmin.Tests.MetaData
{
    public class MetaDataBuilder
    {
        [Fact]
        public void BuildMetaData()
        {
            MetaDataHelper.Instance.RegisterAssembly(typeof(LagoVista.IoT.DeviceAdmin.Startup).Assembly);
            Console.WriteLine(JsonConvert.SerializeObject(MetaDataHelper.Instance.Domains));
            foreach(var domain in MetaDataHelper.Instance.Domains)
            {
                var entitySummary = MetaDataHelper.Instance.EntitySummaries.Where(ent => ent.DomainKey == domain.Key);
                foreach(var summary in entitySummary)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(summary));
                    var entity = MetaDataHelper.Instance.Entities.Where(ent => ent.Name ==summary.ClassName);
                    Console.WriteLine(JsonConvert.SerializeObject(entity));
                }
            }
            Console.WriteLine(JsonConvert.SerializeObject(MetaDataHelper.Instance.Entities.Where(ent=>ent.DomainName == MetaDataHelper.Instance.Domains.First().Key)));
        }

    }
}
