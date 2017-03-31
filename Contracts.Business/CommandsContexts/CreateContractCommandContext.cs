using System;
using Cmas.BusinessLayers.Contracts.Entities;
using Cmas.Infrastructure.Domain.Commands;

namespace Cmas.BusinessLayers.Contracts.CommandsContexts
{
    public class CreateContractCommandContext : ICommandContext
    {
        public String Id;
        public Contract Form;
    }
}
