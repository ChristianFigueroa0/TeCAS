using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TeCAS.Data.Models;

namespace TeCAS.Data.Context
{
    /// <summary>
    /// Database context
    /// </summary>
    public class ApplicationContext : DbContext
    {
        /// <summary>
        /// Default constructor for this class
        /// </summary>
        /// <param name="options">Options to configure DatabaseContext</param>
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        /// <summary>
        /// Collection of customers
        /// </summary>
        public DbSet<Customer> Customers { get; set; }
        /// <summary>
        /// Collection of transactions
        /// </summary>
        public DbSet<Transaction> Transactions { get; set; }
        /// <summary>
        /// Collection of saving accounts
        /// </summary>
        public DbSet<SavingAccount> SavingAccounts { get; set; }
    }
}
