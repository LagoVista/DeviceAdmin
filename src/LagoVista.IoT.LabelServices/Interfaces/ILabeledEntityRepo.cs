using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LagoVista.IoT.LabelServices
{
  
    public interface ILabeledEntityRepo
    {
        Task<ListResponse<LabeledEntity>> GetLabeledEntitiesAsync(string labelId, ListRequest listRequest, EntityHeader org, EntityHeader user);
    }
}
