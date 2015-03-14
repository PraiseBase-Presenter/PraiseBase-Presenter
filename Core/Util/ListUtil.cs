using System.Collections.Generic;
using System.Linq;

namespace PraiseBase.Presenter.Util
{
    public static class ListUtil
    {
        /// <summary>
        ///     Gets the hashcode of the given list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static int GetHashCode<T>(List<T> list)
        {
            unchecked
            {
                return list.Aggregate(19, (current, t) => current*31 + t.GetHashCode());
            }
        }
    }
}