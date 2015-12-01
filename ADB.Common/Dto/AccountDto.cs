using ADB.Common.Immutable;
using Levshits.Logic.Dto;

namespace ADB.Common.Dto
{
    public class AccountDto: DtoBase
    {
        public string PrincipalName { get; set; }

        /// <summary>
        ///     Gets or sets the balance.
        /// </summary>
        /// <value>The balance.</value>
        public decimal Balance { get; set; }

        /// <summary>
        ///     Gets or sets the type of the currency.
        /// </summary>
        /// <value>The type of the currency.</value>
        public CurrencyTypeEnum CurrencyType { get; set; }

        /// <summary>
        ///     Gets or sets the account identifier.
        /// </summary>
        /// <value>The account identifier.</value>
        public string AccountId { get; set; }

        /// <summary>
        ///     Gets or sets the type of the user.
        /// </summary>
        /// <value>The type of the user.</value>
        public UserTypeEnum UserType { get; set; }

        /// <summary>
        ///     Gets or sets the type of the activity.
        /// </summary>
        /// <value>The type of the activity.</value>
        public ActivityTypeEnum ActivityType { get; set; }

    }
}