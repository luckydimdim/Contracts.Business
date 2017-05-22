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

        /// <summary>
        /// Создать договор
        /// </summary>
        /// <returns>ID договора</returns>
        public async Task<string> CreateContract()
        {
            Contract contract = new Contract();

            contract.Id = null;
            contract.UpdatedAt = DateTime.UtcNow;
            contract.CreatedAt = DateTime.UtcNow;

            // Добавляем по умолчанию стоимость  в рублях
            contract.Amounts.Add(new Amount { CurrencySysName = "RUR" });

            var context = new CreateContractCommandContext
            {
                Form = contract
            };

            context = await _commandBuilder.Execute(context);

            return context.Id;
        }

        /// <summary>
        /// Обновить договор
        /// </summary>
        public async Task<string> UpdateContract(string id, Contract contract)
        {

            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("id");

            contract.UpdatedAt = DateTime.UtcNow;
            contract.Id = id;

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

        /// <summary>
        /// Удалить договор
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> DeleteContract(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("id");

            var context = new DeleteContractCommandContext
            {
                Id = id
            };

            context = await _commandBuilder.Execute(context);

            return context.Id;
        }

        /// <summary>
        /// Получить все договоры
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Contract>> GetContracts()
        {
            return await _queryBuilder.For<Task<IEnumerable<Contract>>>().With(new AllEntities());
        }

    }
}
