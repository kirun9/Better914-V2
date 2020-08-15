using Scp914;

namespace Better914
{
	public class Recipe
    {
        public ItemInfo[] Input;
        public ItemInfo[] Output;
        public Scp914Knob Setting;
        public int Weight;

        public Recipe() : this(new ItemInfo[] { }, new ItemInfo[] { }, Scp914Knob.Rough, 0) { }
        public Recipe(ItemInfo input, ItemInfo output, Scp914Knob setting, int weight = 1) : this(new ItemInfo[] { input }, new ItemInfo[] { output }, setting, weight) {}
        public Recipe(ItemInfo[] input, ItemInfo[] output, Scp914Knob setting, int weight = 1)
		{
            Input = input;
            Output = output;
            Setting = setting;
            Weight = weight;
		}

        public bool Equals(Recipe recipe)
		{
            return Input == recipe.Input && Output == recipe.Output && Setting == recipe.Setting;
		}
    }
}
