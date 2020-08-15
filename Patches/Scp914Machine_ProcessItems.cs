using Exiled.API.Extensions;
using Exiled.API.Features;
using HarmonyLib;
using Mirror;
using Scp914;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Better914.Patches
{
#pragma warning disable SA1313
	[HarmonyPatch(typeof(Scp914Machine), nameof(Scp914Machine.ProcessItems))]
	public class Scp914Machine_ProcessItems
	{
		public static bool Prefix(Scp914Machine __instance)
		{
			try
			{
				Better914Config Config = Better914Plugin.instance.Config;
				if (!Config.IsEnabled && !Config.UseNewRecipeSystem) return false;

				if (!NetworkServer.active) return true;
				__instance.players.Clear();
				__instance.items.Clear();
				foreach (var collider in Physics.OverlapBox(__instance.intake.position, __instance.inputSize / 2f))
				{
					if (collider.GetComponent<CharacterClassManager>() is CharacterClassManager ccm)
						__instance.players.Add(ccm);
					if (collider.GetComponent<Pickup>() is Pickup pickup)
						__instance.items.Add(pickup);
				}
				return Upgrade(__instance);
			}
			catch (System.Exception ex)
			{
				Log.Error(ex.ToString());
				return true;
			}
		}

		public static bool Upgrade(Scp914Machine instance)
		{
			if (!NetworkServer.active) return true;

			UpgradeItems(instance.items);
			return false;
		}

		public static void UpgradeItems(IEnumerable<Pickup> items)
		{
			var leftItems = new List<Pickup>(items);
			while (leftItems.Count > 0)
			{
				var actualItem = leftItems[leftItems.Count == 1 ? 0 : Random.Range(0, leftItems.Count - 1)];
				var recipe = PickRecipe(Better914Plugin.SortedRecipes.GetValidRecipes(actualItem.ItemId, leftItems.Select(e => e.ItemId).ToList(), Scp914Machine.singleton.knobState));
			}
		}

		public static Recipe PickRecipe(IEnumerable<Recipe> recipes)
		{
			if (recipes.Count() == 0) return null;
			int totalWeight = recipes.Sum(e => e.Weight);
			int itemWeightIndex = totalWeight == 1 ? 1 : Random.Range(0, totalWeight);
			float currentWeightIndex = 0;
			foreach (var item in recipes)
			{
				currentWeightIndex += item.Weight;
				if (currentWeightIndex >= itemWeightIndex) return item;
			}
			return null;
		}
	}
}
