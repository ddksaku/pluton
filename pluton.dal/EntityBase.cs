using System;
using System.ComponentModel.DataAnnotations;
using Mars.Common;
using Mars.Common.Repositories;

namespace pluton.dal
{
    [Serializable]
    public abstract class EntityBase<TId> : IEntity, IEquatable<EntityBase<TId>>
        where TId : struct
    {
        private object _id;

        /// <summary>
        /// Key
        /// </summary>
        [Key]
        public virtual TId Id
        {
            get
            {
                if (_id == null && typeof(TId) == typeof(Guid))
                    _id = IdentityGenerator.NewSequentialGuid();

                return _id == null ? default(TId) : (TId)_id;
            }
            set { _id = value; }
        }

        /// <summary>
        /// Deleted flag
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Определение равенства по ключу
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool EqualsByKey(object key)
        {
            if (key == null) return false;
            return Id.GetType() == key.GetType() && Id.Equals(key);
        }

        public bool Equals(EntityBase<TId> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.GetType() == GetType() && other.Id.Equals(Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == typeof(EntityBase<TId>) && Equals((EntityBase<TId>)obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return Id.ToString();
        }

        public static bool operator ==(EntityBase<TId> left, EntityBase<TId> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(EntityBase<TId> left, EntityBase<TId> right)
        {
            return !Equals(left, right);
        }
    }
}
