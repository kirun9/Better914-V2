using Exiled.API.Enums;
using Exiled.API.Features;
using Scp914;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Utf8Json;

namespace Better914
{
	public class Better914Plugin : Plugin<Better914Config>
    {
        public override String Author => "kirun9";
        public override String Name => "Better914 2.0";
        public override String Prefix => "b914";
        public override Version Version => new Version("2.0.0.0");
        public override Version RequiredExiledVersion => new Version("2.0.0.0");
        public override PluginPriority Priority => PluginPriority.Last;

        public static Better914Plugin instance;
        public static Dictionary<ItemType, Dictionary<Scp914Knob, List<Recipe>>> Recipes { get; private set; } = new Dictionary<ItemType, Dictionary<Scp914Knob, List<Recipe>>>();

        public Better914Plugin()
		{
            instance = this;
		}

        public override void OnEnabled()
        {
            base.OnEnabled();

            if (Config.IsEnabled)
            {
                ReadRecipes();
                //Exiled.Events.Events.DisabledPatches.Add(new Tuple<Type, string>(typeof(PlayerInteract), nameof(PlayerInteract.CallCmdChange914Knob)));
                //Exiled.Events.Events.DisabledPatches.Add(new Tuple<Type, string>(typeof(Scp914Machine), nameof(Scp914Machine.ProcessItems)));
                //Exiled.Events.Events.Instance.ReloadDisabledPatches();
            }
        }

        private void CreateDefaultRecipes()
        {
            Exiled.Events.Handlers.Server.WaitingForPlayers -= CreateDefaultRecipes;
            var path = Path.Combine(Paths.Configs, $"{Server.Port}-B914Recipes.json");
            List<Recipe> temp = new List<Recipe>();
            foreach (var recipe in Scp914Machine.singleton.recipes)
            {
                foreach (var item in recipe.rough) temp.MyAdd(recipe.itemID, item, Scp914Knob.Rough);
                foreach (var item in recipe.coarse) temp.MyAdd(recipe.itemID, item, Scp914Knob.Coarse);
                foreach (var item in recipe.oneToOne) temp.MyAdd(recipe.itemID, item, Scp914Knob.OneToOne);
                foreach (var item in recipe.fine) temp.MyAdd(recipe.itemID, item, Scp914Knob.Fine);
                foreach (var item in recipe.veryFine) temp.MyAdd(recipe.itemID, item, Scp914Knob.VeryFine);
            }

            foreach (var recipe in temp)
            {
                foreach (var input in recipe.Input)
                {
                    if (!Recipes.ContainsKey(input.Item))
                    {
                        Recipes[input.Item] = new Dictionary<Scp914Knob, List<Recipe>>();
                        Recipes[input.Item][Scp914Knob.Rough] = new List<Recipe>();
                        Recipes[input.Item][Scp914Knob.Coarse] = new List<Recipe>();
                        Recipes[input.Item][Scp914Knob.OneToOne] = new List<Recipe>();
                        Recipes[input.Item][Scp914Knob.Fine] = new List<Recipe>();
                        Recipes[input.Item][Scp914Knob.VeryFine] = new List<Recipe>();
                    }
                    if (!Recipes[input.Item][recipe.Setting].Contains(recipe)) Recipes[input.Item][recipe.Setting].Add(recipe);
                }
            }
            File.WriteAllText(path, JsonSerializer.PrettyPrint(JsonSerializer.Serialize(Recipes)));
        }

		private void ReadRecipes()
        {
            var path = Path.Combine(Paths.Configs, $"{Server.Port}-B914Recipes.json");
            if (!File.Exists(path))
			{
				Exiled.Events.Handlers.Server.WaitingForPlayers += CreateDefaultRecipes;
                return;
            }
            Recipes = JsonSerializer.Deserialize<Dictionary<ItemType, Dictionary<Scp914Knob, List<Recipe>>>>(File.ReadAllText(path));
            Log.Info("Loaded " + Recipes.SelectMany(e => e.Value).SelectMany(e => e.Value).Count() + " recipes");
        }
	}

    public static class Temp
	{
        public static int counter = 0;
        public static void MyAdd(this List<Recipe> list, ItemType input, ItemType output, Scp914Knob setting)
		{
            Recipe recipe;
            if ((recipe = list.FirstOrDefault(r => r.Setting == setting && r.Input.Contains(input.GetItemInfo()) && r.Output.Contains(output.GetItemInfo()))) != null)
			{
                recipe.Weight++;
			}
            else
			{
                list.Add(new Recipe(input.GetItemInfo(), output.GetItemInfo(), setting));
                counter++;
			}
		}
	}
}
