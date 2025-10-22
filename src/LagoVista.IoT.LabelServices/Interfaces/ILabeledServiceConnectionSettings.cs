// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 4817d3c2f33f8ae425e9fb29737eb397b0fa0cd2b4fad7eae44aa2398fca4327
// IndexVersion: 0
// --- END CODE INDEX META ---
using LagoVista.Core.Interfaces;

namespace LagoVista.IoT.LabelServices
{
    public interface ILabeledServiceConnectionSettings
    {
        bool ShouldConsolidateCollections { get; }

        IConnectionSettings LabelServicesConnection { get;  }
    }
}
