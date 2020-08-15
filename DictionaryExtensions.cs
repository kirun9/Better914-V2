using System.Collections.Generic;
using System.Linq;

namespace Better914
{
	public static class DictionaryExtensions
	{
        public static IEnumerable<Recipe> GetValidRecipes(this Dictionary<ItemType, Dictionary<Scp914.Scp914Knob, List<Recipe>>> recipes, ItemType item, List<ItemType> otherItems, Scp914.Scp914Knob setting)
		{
			return recipes[item] is null ? null : recipes[item][setting].Where(r => r.Input.Select(e => e.Item).IsInList(otherItems));
		}

		private static bool IsInList<T>(this IEnumerable<T> array1, IEnumerable<T> array2)
        {
            var found = new List<T>();
            var temp = new List<T>(array2);
            foreach (var item in array1)
            {
                if (temp.Contains(item))
                {
                    found.Add(item);
                    temp.Remove(item);
                }
            }
            return found.Count == array1.Count();
        }
    }
}
