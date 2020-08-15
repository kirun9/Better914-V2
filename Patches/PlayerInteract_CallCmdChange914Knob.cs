using Exiled.Events.EventArgs;
using HarmonyLib;
using Scp914;
using System;

namespace Better914.Patches
{
	[HarmonyPatch(typeof(PlayerInteract), nameof(PlayerInteract.CallCmdChange914Knob))]
	public class PlayerInteract_CallCmdChange914Knob
	{
		public static bool Prefix(PlayerInteract __instance)
		{
			Better914Config Config = Better914Plugin.instance.Config;
			if (!Config.IsEnabled) return false;
			if (!__instance._playerInteractRateLimit.CanExecute(true)) return true;
			if (__instance._hc.CufferId > 0 && (Config.OverrideHandcuffConfig ? !Config.CanDisarmedInteract : !PlayerInteract.CanDisarmedInteract)) return true;
			if (!Config.CanChangeKnobWhileWorking && Scp914Machine.singleton.working) return true;
			if (!__instance.ChckDis(Scp914Machine.singleton.knob.position)) return true;
			if (Math.Abs(Scp914Machine.singleton.curKnobCooldown) > 0.001f) return true;

			var ev = new ChangingKnobSettingEventArgs(Exiled.API.Features.Player.Get(__instance.gameObject), Scp914Machine.singleton.knobState + 1);
			Exiled.Events.Handlers.Scp914.OnChangingKnobSetting(ev);

			if (!ev.IsAllowed) return true;

			Scp914Machine.singleton.curKnobCooldown = Scp914Machine.singleton.knobCooldown;
			Scp914Machine.singleton.NetworkknobState = ev.KnobSetting;
			__instance.OnInteract();
			return true;
		}
	}
}
