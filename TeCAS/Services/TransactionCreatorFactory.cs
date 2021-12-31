using Microsoft.Extensions.Logging;
using System;
using TeCAS.Data.Context;
using TeCAS.Data.Models.Enums;

namespace TeCAS.Services
{
    public class TransactionCreatorFactory
    {
        /// <summary>
        /// Context to access to data base
        /// </summary>
        private readonly ApplicationContext _context;
        /// <summary>
        /// Default logger
        /// </summary>
        private readonly ILoggerFactory _loggerFactory;
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="loggerFactory">Injected logger factory</param>
        public TransactionCreatorFactory(
            ApplicationContext context,
            ILoggerFactory loggerFactory
            )
        {
            _context = context;
            _loggerFactory = loggerFactory;
        }

        /// <summary>
        /// Provide a implementation of <see cref="ITransactionCreator"/> based on transaction type
        /// </summary>
        /// <param name="type">The type of transaction</param>
        /// <returns>Implementation of <see cref="ITransactionCreator"/></returns>
        public ITransactionCreator Create(TransactionType type)
        {
            switch (type)
            {
                case TransactionType.Deposit:
                    return new DepositTransactionCreator(_context, _loggerFactory);
                case TransactionType.Withdrawal:
                    return new WithdrawalTransactionCreator(_context, _loggerFactory);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
