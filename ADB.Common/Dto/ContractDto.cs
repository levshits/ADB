using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADB.Common.Immutable;
using Levshits.Logic.Dto;

namespace ADB.Common.Dto
{
    public class ContractDto: DtoBase
    {
        /// <summary>
        /// Gets or sets the assign date.
        /// </summary>
        /// <value>The assign date.</value>
        public DateTime AssignDate { get; set; }
        /// <summary>
        /// Gets or sets the principal identifier.
        /// </summary>
        /// <value>The principal identifier.</value>
        public int PrincipalId { get; set; }

        public string PrincipalName { get; set; }
        /// <summary>
        /// Gets or sets the type of the contract.
        /// </summary>
        /// <value>The type of the contract.</value>
        public ContractTypeEnum ContractType { get; set; }
    }
}
