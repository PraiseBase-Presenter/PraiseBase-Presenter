using System.Collections.Generic;
using System.Linq;

namespace PraiseBase.Presenter.Model
{
    public class ComparableList<T> : List<T>
    {
        public override int GetHashCode()
        {
            unchecked
            {
                return this.Aggregate(19, (current, e) => current*31 + e.GetHashCode());
            }
        }

        protected bool Equals(ComparableList<T> other)
        {
            if (Count != other.Count) return false;
            for (var i = 0; i < Count; i++)
            {
                if (!Equals(this[i], other[i])) return false;
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ComparableList<T>) obj);
        }
    }
}