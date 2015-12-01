using System;

namespace ADB.Data.Entity
{
    /// <summary>
    ///     Class ClientEntity.
    /// </summary>
    public class ClientEntity : PrincipalEntity
    {
        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public virtual string FirstName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the middle.
        /// </summary>
        /// <value>The name of the middle.</value>
        public virtual string MiddleName { get; set; }

        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public virtual string LastName { get; set; }

        /// <summary>
        ///     Gets or sets the birth date.
        /// </summary>
        /// <value>The birth date.</value>
        public virtual DateTime BirthDate { get; set; }

        /// <summary>
        ///     Gets or sets the passport series.
        /// </summary>
        /// <value>The passport series.</value>
        public virtual string PassportSeries { get; set; }

        /// <summary>
        ///     Gets or sets the passport number.
        /// </summary>
        /// <value>The passport number.</value>
        public virtual string PassportNumber { get; set; }

        /// <summary>
        ///     Gets or sets the issued by.
        /// </summary>
        /// <value>The issued by.</value>
        public virtual string IssuedBy { get; set; }

        /// <summary>
        ///     Gets or sets the issued date.
        /// </summary>
        /// <value>The issued date.</value>
        public virtual DateTime IssuedDate { get; set; }

        /// <summary>
        ///     Gets or sets the passport identifier.
        /// </summary>
        /// <value>The passport identifier.</value>
        public virtual string PassportId { get; set; }

        /// <summary>
        ///     Gets or sets the birth place.
        /// </summary>
        /// <value>The birth place.</value>
        public virtual string BirthPlace { get; set; }

        /// <summary>
        ///     Gets or sets the residence city.
        /// </summary>
        /// <value>The residence city.</value>
        public virtual CityEntity ResidenceCity { get; set; }

        /// <summary>
        ///     Gets or sets the residence city identifier.
        /// </summary>
        /// <value>The residence city identifier.</value>
        public virtual int ResidenceCityId { get; set; }

        /// <summary>
        ///     Gets or sets the residence address.
        /// </summary>
        /// <value>The residence address.</value>
        public virtual string ResidenceAddress { get; set; }

        /// <summary>
        ///     Gets or sets the home phone.
        /// </summary>
        /// <value>The home phone.</value>
        public virtual string HomePhone { get; set; }

        /// <summary>
        ///     Gets or sets the mobile phone.
        /// </summary>
        /// <value>The mobile phone.</value>
        public virtual string MobilePhone { get; set; }

        /// <summary>
        ///     Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public virtual string Email { get; set; }

        /// <summary>
        ///     Gets or sets the company.
        /// </summary>
        /// <value>The company.</value>
        public virtual string Company { get; set; }

        /// <summary>
        ///     Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        public virtual string Position { get; set; }

        /// <summary>
        ///     Gets or sets the registration address.
        /// </summary>
        /// <value>The registration address.</value>
        public virtual string RegistrationAddress { get; set; }

        /// <summary>
        ///     Gets or sets the marital status.
        /// </summary>
        /// <value>The marital status.</value>
        public virtual int MaritalStatus { get; set; }

        /// <summary>
        ///     Gets or sets the nationality.
        /// </summary>
        /// <value>The nationality.</value>
        public virtual int Nationality { get; set; }

        /// <summary>
        ///     Gets or sets the disability status.
        /// </summary>
        /// <value>The disability status.</value>
        public virtual int DisabilityStatus { get; set; }

        /// <summary>
        ///     Gets or sets the monthly income.
        /// </summary>
        /// <value>The monthly income.</value>
        public virtual decimal MonthlyIncome { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is retired.
        /// </summary>
        /// <value><c>true</c> if this instance is retired; otherwise, <c>false</c>.</value>
        public virtual bool IsRetired { get; set; }
    }
}
