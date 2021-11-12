using LagoVista.Core.Interfaces;

namespace LagoVista.IoT.LabelServices
{
    public interface ILabeledServiceConnectionSettings
    {
        bool ShouldConsolidateCollections { get; }

        IConnectionSettings LabelServicesConnection { get;  }
    }
}
