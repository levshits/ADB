using ADB.Data.Data;
using Levshits.Logic.Common;

namespace ADB.Data.Common
{
    /// <summary>
    ///     Class AdbRepository.
    /// </summary>
    public class AdbRepository : Repository
    {
        /// <summary>
        ///     Gets or sets the client data.
        /// </summary>
        /// <value>The client data.</value>
        public ClientData ClientData { get; set; }

        /// <summary>
        ///     Gets or sets the city data.
        /// </summary>
        /// <value>The city data.</value>
        public CityData CityData { get; set; }

        /// <summary>
        ///     Gets or sets the account data.
        /// </summary>
        /// <value>The account data.</value>
        public AccountData AccountData { get; set; }

        /// <summary>
        ///     Gets or sets the transaction history data.
        /// </summary>
        /// <value>The transaction history data.</value>
        public TransactionHistoryData TransactionHistoryData { get; set; }

        /// <summary>
        ///     Gets or sets the credit contract data.
        /// </summary>
        /// <value>The credit contract data.</value>
        public CreditContractData CreditContractData { get; set; }

        /// <summary>
        ///     Gets or sets the deposit contract data.
        /// </summary>
        /// <value>The deposit contract data.</value>
        public DepositContractData DepositContractData { get; set; }

        /// <summary>
        ///     Gets or sets the card data.
        /// </summary>
        /// <value>The card data.</value>
        public CardData CardData { get; set; }
    }
}