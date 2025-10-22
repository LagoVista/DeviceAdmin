// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: f2e7dac49c3b9301a45f0f784be73283cae9a5e310c5426134d6269aa7ac0304
// IndexVersion: 0
// --- END CODE INDEX META ---
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
