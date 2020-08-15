using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using YamlDotNet.Serialization;

namespace Better914
{
    public class Better914Config : IConfig
    {
        public Boolean IsEnabled { get; set; }
        
        [Description("Enables/Disables option to rotate knob while SCP-914 is working")]
        public bool CanChangeKnobWhileWorking { get; set; } = true;
        [Description("Indicates if b914_disarmed_interact sould be used instread of game value")]
        public bool OverrideHandcuffConfig { get; set; } = true;
        [Description("Enables/Disables ability of disarmed people to interact with SCP-914")]
        public bool CanDisarmedInteract { get; set; } = true;
        [Description("Enables/Disables ussage of new recipes")]
        public bool UseNewRecipeSystem { get; set; } = true;

        [Description("Chances to degrade item to level -4")]
        [YamlMember(Alias = "Level-4Chance")]
        public float Level_4Chance { get; set; } = 5f;
        [Description("Chances to degrade item to level -3")]
        [YamlMember(Alias = "Level-3Chance")]
        public float Level_3Chance { get; set; } = 10f;
        [Description("Chances to degrade item to level -2")]
        [YamlMember(Alias = "Level-2Chance")]
        public float Level_2Chance { get; set; } = 20f;
        [Description("Chances to upgrade item to level 2")]
        [YamlMember(Alias = "Level2Chance")]
        public float Level2Chance { get; set; } = 20f;
        [Description("Chances to upgrade item to level 3")]
        [YamlMember(Alias = "Level3Chance")]
        public float Level3Chance { get; set; } = 10f;
        [Description("Chances to upgrade item to level 4")]
        [YamlMember(Alias = "Level4Chance")]
        public float Level4Chance { get; set; } = 5f;
        [Description("Chances for upgrade to not occure on coarse, 1:1 and fine settings")]
        public float SameItemChance { get; set; } = 20f;
        [Description("Chances for upgrade one random item in player inventory while inside SCP-914")]
        public float InvUpgradeChance { get; set; } = 20f;

        [Description("Enables/Disables modification of health by SCP-914")]
        public bool ChangePlayerHealth { get; set; } = true;
        [Description("Chances for taking health from player")]
        public float RoughDamageChance { get; set; } = 60f;
        [Description("Chances for taking health from player")]
        public float CoarseDamageChance { get; set; } = 50f;
        [Description("Chances for giving health from player")]
        public float FineHealChance { get; set; } = 40f;
        [Description("Chances for giving health from player")]
        public float VeryFineHealChance { get; set; } = 30f;
        [Description("% Ammount of health to take from player")]
        public float RoughDamageAmmout { get; set; } = 100f;
        [Description("% Ammount of health to take from player")]
        public float CoarseDamageAmmout { get; set; } = 50f;
        [Description("% Ammount of health to give to player")]
        public float FineHealAmmout { get; set; } = 25f;
        [Description("% Ammount of health to give to player")]
        public float VeryFineHealAmmout { get; set; } = 50f;

        [Description("Enables/Disables taking damage to SCP's inside SCP-914 while on settings rough or coarse")]
        public bool RoughCoarseDamageScp { get; set; } = true;
        [Description("Multiplies chances of taking damage by SCP's (see b914_rough_damage_chance and b914_coarse_damage_chance)")]
        public float ScpDamageChanceMultiplier { get; set; } = 0.5f;

        [Description("Enables/Disables swapping of players roles while on setting 1:1 (To occur two different classes inside SCP-914 are needed)")]
        public bool SwapPlayersRoles { get; set; } = true;
        [Description("Chances for swapping roles to occur")]
        public float SwapRoleChance { get; set; } = 20f;

    }
}
