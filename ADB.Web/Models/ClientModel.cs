using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ADB.Common.Item;
using ADB.Web.Attributes;
using ADB.Web.Models.Enumerations;
using Levshits.Web.Common.Models;

namespace ADB.Web.Models
{
    public class ClientModel: ModelBase
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [Required]
        [DataType(DataType.Text)]
        [MinLength(2)]
        [LocalisedName()]
        public virtual string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the name of the middle.
        /// </summary>
        /// <value>The name of the middle.</value>
        [Required]
        [DataType(DataType.Text)]
        [MinLength(2)]
        [LocalisedName()]
        public virtual string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        [Required]
        [DataType(DataType.Text)]
        [MinLength(2)]
        [LocalisedName()]
        public virtual string LastName { get; set; }

        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        /// <value>The birth date.</value>
        [Required]
        [LocalisedName()]
        [UIHint("Date")]
        public virtual DateTime BirthDate { get; set; } = DateTime.Today;
        /// <summary>
        /// Gets or sets the passport series.
        /// </summary>
        /// <value>The passport series.</value>
        [Required]
        [StringLength(2, MinimumLength = 2)]
        [LocalisedName()]
        public virtual string PassportSeries { get; set; }
        /// <summary>
        /// Gets or sets the passport number.
        /// </summary>
        /// <value>The passport number.</value>
        [Required]
        [RegularExpression("\\d{7}")]
        [LocalisedName()]
        public virtual string PassportNumber { get; set; }
        /// <summary>
        /// Gets or sets the issued by.
        /// </summary>
        /// <value>The issued by.</value>
        [Required]
        [DataType(DataType.Text)]
        [LocalisedName()]
        public virtual string IssuedBy { get; set; }

        /// <summary>
        /// Gets or sets the issued date.
        /// </summary>
        /// <value>The issued date.</value>
        [Required]
        [LocalisedName()]
        [UIHint("Date")]
        public virtual DateTime IssuedDate { get; set; } = DateTime.Today;
        /// <summary>
        /// Gets or sets the passport identifier.
        /// </summary>
        /// <value>The passport identifier.</value>
        [Required]
        [LocalisedName()]
        [RegularExpression("\\d{7}\\w{1}\\d{3}\\w{2}\\d{1}")]
        public virtual string PassportId { get; set; }
        /// <summary>
        /// Gets or sets the birth place.
        /// </summary>
        /// <value>The birth place.</value>
        [DataType(DataType.Text)]
        [LocalisedName()]
        public virtual string BirthPlace { get; set; }
        /// <summary>
        /// Gets or sets the residence city identifier.
        /// </summary>
        /// <value>The residence city identifier.</value>
        [Required]
        [LocalisedName()]
        public virtual int? ResidenceCityId { get; set; }

        /// <summary>
        /// Gets or sets the residence sities.
        /// </summary>
        /// <value>The residence sities.</value>
        public IList<LookupItem> ResidenceSities { get; set; }
        /// <summary>
        /// Gets or sets the residence address.
        /// </summary>
        /// <value>The residence address.</value>
        [Required]
        [DataType(DataType.Text)]
        [LocalisedName()]
        public virtual string ResidenceAddress { get; set; }
        /// <summary>
        /// Gets or sets the home phone.
        /// </summary>
        /// <value>The home phone.</value>
        [DataType(DataType.PhoneNumber)]
        [LocalisedName()]
        public virtual string HomePhone { get; set; }
        /// <summary>
        /// Gets or sets the mobile phone.
        /// </summary>
        /// <value>The mobile phone.</value>
        [DataType(DataType.PhoneNumber)]
        [LocalisedName()]
        public virtual string MobilePhone { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        [DataType(DataType.EmailAddress)]
        [LocalisedName()]
        public virtual string Email { get; set; }
        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        /// <value>The company.</value>
        [DataType(DataType.Text)]
        [LocalisedName()]
        public virtual string Company { get; set; }
        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        [DataType(DataType.Text)]
        [LocalisedName()]
        public virtual string Position { get; set; }
        /// <summary>
        /// Gets or sets the registration address.
        /// </summary>
        /// <value>The registration address.</value>
        [DataType(DataType.MultilineText)]
        [LocalisedName()]
        public virtual string RegistrationAddress { get; set; }
        /// <summary>
        /// Gets or sets the marital status.
        /// </summary>
        /// <value>The marital status.</value>
        [LocalisedName()]
        public virtual MaritalStatus MaritalStatus { get; set; }
        /// <summary>
        /// Gets or sets the nationality.
        /// </summary>
        /// <value>The nationality.</value>
        [LocalisedName()]
        public virtual Nationality Nationality { get; set; }
        /// <summary>
        /// Gets or sets the disability status.
        /// </summary>
        /// <value>The disability status.</value>
        [LocalisedName()]
        public virtual DisabilityStatus DisabilityStatus { get; set; }
        /// <summary>
        /// Gets or sets the monthly income.
        /// </summary>
        /// <value>The monthly income.</value>
        [DataType(DataType.Currency)]
        [LocalisedName()]
        public virtual decimal MonthlyIncome { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is retired.
        /// </summary>
        /// <value><c>true</c> if this instance is retired; otherwise, <c>false</c>.</value>
        [Required]
        [LocalisedName()]
        public virtual bool IsRetired { get; set; }
    }
}