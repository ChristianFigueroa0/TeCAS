using System;
using System.Collections.Generic;
using System.Text;

namespace TeCAS.Data.Models.Enums
{
    /// <summary>
    /// Define the allowed transaction
    /// </summary>
    public enum TransactionType
    {
        /// <summary>
        /// Deposit transaction
        /// </summary>
        Deposit = 0,
        /// <summary>
        /// Withdrawal transaction
        /// </summary>
        Withdrawal = 1
    }
}
