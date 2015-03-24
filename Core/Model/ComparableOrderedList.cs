using System;

namespace PraiseBase.Presenter.Model
{
    public class ComparableOrderedList<T> : ComparableList<T> where T : ICloneable
    {
        /// <summary>
        ///     Swaps an entry with the previous one
        /// </summary>
        /// <param name="partId">Index of the part</param>
        /// <returns></returns>
        public bool SwapWithUpper(int partId)
        {
            if (partId > 0 && partId < Count)
            {
                var tmpPrt = this[partId - 1];
                RemoveAt(partId - 1);
                Insert(partId, tmpPrt);
                return true;
            }
            return false;
        }

        /// <summary>
        ///     Swaps an entry with the next one
        /// </summary>
        /// <param name="partId">Index of the part</param>
        /// <returns></returns>
        public bool SwapWithLower(int partId)
        {
            if (partId >= 0 && partId < Count - 1)
            {
                var tmpPrt = this[partId + 1];
                RemoveAt(partId + 1);
                Insert(partId, tmpPrt);
                return true;
            }
            return false;
        }

        /// <summary>
        ///     Duplicates a given entry
        /// </summary>
        /// <param name="idx">The slide index</param>
        public void Duplicate(int idx)
        {
            Insert(idx, (T)this[idx].Clone());
        }
    }
}
