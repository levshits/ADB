﻿using Levshits.Data.Entity;

namespace ADB.Data.Entity
{
    /// <summary>
    /// Class CityEntity.
    /// </summary>
    public class CityEntity: BaseEntity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public virtual string Name { get; set; }
    }
}