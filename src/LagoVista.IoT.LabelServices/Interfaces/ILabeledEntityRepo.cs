// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 0bf2089d9d2cc0bdbfda46e7cfb3ca11ad85e399cadad89599fda38c79a27cee
// IndexVersion: 2
// --- END CODE INDEX META ---
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
