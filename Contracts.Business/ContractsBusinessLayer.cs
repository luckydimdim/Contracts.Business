using System.Collections.Generic;
using System.Threading.Tasks;
using Cmas.BusinessLayers.Contracts.CommandsContexts;
using Cmas.BusinessLayers.Contracts.Entities;
using Cmas.Infrastructure.Domain.Commands;
using Cmas.Infrastructure.Domain.Criteria;
using Cmas.Infrastructure.Domain.Queries;
using System;
using System.Security.Claims;

namespace Cmas.BusinessLayers.Contracts
{
    public class ContractsBusinessLayer
    {
        private readonly ICommandBuilder _commandBuilder;
        private readonly IQueryBuilder _queryBuilder;
        private readonly ClaimsPrincipal _claimsPrincipal;

        public ContractsBusinessLayer(IServiceProvider serviceProvider, ClaimsPrincipal claimsPrincipal)
        {
            _claimsPrincipal = claimsPrincipal;
            _commandBuilder = (ICommandBuilder)serviceProvider.GetService(typeof(ICommandBuilder));
            _queryBuilder = (IQueryBuilder)serviceProvider.GetService(typeof(IQueryBuilder));
        }


        public async Task<string> CreateContract()
        {
            Contract contract = new Contract();

            contract.Id = null;
            contract.UpdatedAt = DateTime.UtcNow;
            contract.CreatedAt = DateTime.UtcNow;

            var context = new CreateContractCommandContext
            {
                Form = contract
            };

            context = await _commandBuilder.Execute(context);

            return context.Id;
        }

        public async Task<string> UpdateContract(string id, Contract contract)
        {
            contract.UpdatedAt = DateTime.UtcNow;

            var context = new UpdateContractCommandContext
            {
                Form = contract
            };

            context = await _commandBuilder.Execute(context);

            return context.Form.Id;
        }

        public async Task<Contract> GetContract(string id)
        {
            return await _queryBuilder.For<Task<Contract>>().With(new FindById(id));
        }

        public async Task<string> DeleteContract(string id)
        {

            var context = new DeleteContractCommandContext
            {
                Id = id
            };

            context = await _commandBuilder.Execute(context);

            return context.Id;
        }

        public async Task<IEnumerable<Contract>> GetContracts()
        {
            return await _queryBuilder.For<Task<IEnumerable<Contract>>>().With(new AllEntities());
        }

    }
}
