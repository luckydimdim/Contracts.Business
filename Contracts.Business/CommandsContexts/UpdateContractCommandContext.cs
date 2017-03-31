using Cmas.BusinessLayers.Contracts.Entities;
using Cmas.Infrastructure.Domain.Commands;

namespace Cmas.BusinessLayers.Contracts.CommandsContexts
{
    public class UpdateContractCommandContext : ICommandContext
    {
        public Contract Form;
    }
}
