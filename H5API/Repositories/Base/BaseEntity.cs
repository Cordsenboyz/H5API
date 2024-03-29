﻿using System.ComponentModel.DataAnnotations;

namespace H5API.Repositories.Base
{
    /// <summary>
    /// Represent basic entity.
    /// </summary>
    /// <typeparam name="TId">Generic ID type to any primitive type.</typeparam>
    public abstract class BaseEntity<TId>
    {
        /// <summary>
        /// Unique identifier of the entity
        /// </summary>
        [Key]
        public virtual TId Id { get; set; }
    }
}
