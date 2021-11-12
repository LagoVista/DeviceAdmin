using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using System.Threading.Tasks;

namespace LagoVista.IoT.LabelServices
{
    public interface ILabelRepo
    {
        Task<LabelSet> AddLabelAsync(Label label, EntityHeader org, EntityHeader user);
        Task<LabelSet> UpdateLabelAsync(Label label, EntityHeader org, EntityHeader user);
        Task<LabelSet> GetLabelSetAsync(EntityHeader org, EntityHeader user);
    }
}
