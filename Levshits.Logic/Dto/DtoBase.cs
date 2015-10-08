using System;

namespace Levshits.Logic.Dto
{
    [Serializable]
    public class DtoBase
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>The version.</value>
        public int Version { get; set; }

        /// <summary>
        /// Gets or sets the create time.
        /// </summary>
        /// <value>The create time.</value>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// Gets or sets the modify time.
        /// </summary>
        /// <value>The modify time.</value>
        public DateTime ModifyTime { get; set; }
         
    }
}