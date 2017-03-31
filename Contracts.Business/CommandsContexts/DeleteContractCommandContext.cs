using System;
using Cmas.Infrastructure.Domain.Commands;

namespace Cmas.BusinessLayers.Contracts.CommandsContexts
{
    public class DeleteContractCommandContext : ICommandContext
    {
        public String Id;
    }
}
