namespace Better914
{
	public class ItemInfo
	{
        public ItemType Item;
        public bool IgnoreAddons;
        public float Damage;
        public int Sight;
        public int Barrel;
        public int Other;

        public ItemInfo() : this(ItemType.None) { }
        public ItemInfo(ItemType item, bool ignoreAddons = false, float damage = 0, int sight = 0, int barrel = 0, int other = 0)
		{
            Item = item;
            IgnoreAddons = ignoreAddons;
            if (!IgnoreAddons)
			{
                Damage = damage;
                Sight = sight;
                Barrel = barrel;
                Other = other;
			}
		}

        public bool ShouldSerializeDamage() => !IgnoreAddons && Damage != 0;
        public bool ShouldSerializeSight() => !IgnoreAddons && Sight != 0;
        public bool ShouldSerializeBarrel() => !IgnoreAddons && Barrel != 0;
        public bool ShouldSerializeOther() => !IgnoreAddons && Other != 0;

        public bool Equals(ItemInfo info)
		{
			return IgnoreAddons || info.IgnoreAddons
				? Item.Equals(info.Item)
				: Item.Equals(info.Item) && Sight.Equals(info.Sight) && Barrel.Equals(info.Barrel) && Other.Equals(info.Other);
		}

        public static explicit operator ItemInfo(ItemType item)
		{
            switch (item)
			{
                case ItemType.Adrenaline:                   return Adrenaline;
                case ItemType.Ammo556:                      return Ammo556;
                case ItemType.Ammo762:                      return None;
                case ItemType.Ammo9mm:                      return Ammo9mm;
                case ItemType.Coin:                         return Coin;
                case ItemType.Disarmer:                     return Disarmer;
                case ItemType.Flashlight:                   return Flashlight;
                case ItemType.GrenadeFlash:                 return GrenadeFlash;
                case ItemType.GrenadeFrag:                  return GrenadeFrag;
                case ItemType.GunCOM15:                     return GunCOM15;
                case ItemType.GunE11SR:                     return GunE11SR;
                case ItemType.GunLogicer:                   return GunLogicer;
                case ItemType.GunMP7:                       return GunMP7;
                case ItemType.GunProject90:                 return GunProject90;
                case ItemType.GunUSP:                       return GunUSP;
                case ItemType.KeycardChaosInsurgency:       return KeycardChaosInsurgency;
                case ItemType.KeycardContainmentEngineer:   return KeycardContainmentEngineer;
                case ItemType.KeycardFacilityManager:       return KeycardFacilityManager;
                case ItemType.KeycardGuard:                 return KeycardGuard;
                case ItemType.KeycardJanitor:               return KeycardJanitor;
                case ItemType.KeycardNTFCommander:          return KeycardNTFCommander;
                case ItemType.KeycardNTFLieutenant:         return KeycardNTFLieutenant;
                case ItemType.KeycardO5:                    return KeycardO5;
                case ItemType.KeycardScientist:             return KeycardScientist;
                case ItemType.KeycardScientistMajor:        return KeycardScientistMajor;
                case ItemType.KeycardSeniorGuard:           return KeycardSeniorGuard;
                case ItemType.KeycardZoneManager:           return KeycardZoneManager;
                case ItemType.Medkit:                       return Medkit;
                case ItemType.MicroHID:                     return MicroHID;
                case ItemType.None:                         return None;
                case ItemType.Painkillers:                  return Painkillers;
                case ItemType.Radio:                        return Radio;
                case ItemType.SCP018:                       return SCP018;
                case ItemType.SCP207:                       return SCP207;
                case ItemType.SCP268:                       return SCP268;
                case ItemType.SCP500:                       return SCP500;
                case ItemType.WeaponManagerTablet:          return WeaponManagerTablet;
                default:                                    return None;
			}
		}

        public static readonly ItemInfo None                        = new ItemInfo(ItemType.None                        , true);
        public static readonly ItemInfo KeycardJanitor              = new ItemInfo(ItemType.KeycardJanitor              , true);
        public static readonly ItemInfo KeycardScientist            = new ItemInfo(ItemType.KeycardScientist            , true);
        public static readonly ItemInfo KeycardScientistMajor       = new ItemInfo(ItemType.KeycardScientistMajor       , true);
        public static readonly ItemInfo KeycardZoneManager          = new ItemInfo(ItemType.KeycardZoneManager          , true);
        public static readonly ItemInfo KeycardGuard                = new ItemInfo(ItemType.KeycardGuard                , true);
        public static readonly ItemInfo KeycardSeniorGuard          = new ItemInfo(ItemType.KeycardSeniorGuard          , true);
        public static readonly ItemInfo KeycardContainmentEngineer  = new ItemInfo(ItemType.KeycardContainmentEngineer  , true);
        public static readonly ItemInfo KeycardNTFLieutenant        = new ItemInfo(ItemType.KeycardNTFLieutenant        , true);
        public static readonly ItemInfo KeycardNTFCommander         = new ItemInfo(ItemType.KeycardNTFCommander         , true);
        public static readonly ItemInfo KeycardFacilityManager      = new ItemInfo(ItemType.KeycardFacilityManager      , true);
        public static readonly ItemInfo KeycardChaosInsurgency      = new ItemInfo(ItemType.KeycardChaosInsurgency      , true);
        public static readonly ItemInfo KeycardO5                   = new ItemInfo(ItemType.KeycardO5                   , true);
        public static readonly ItemInfo Radio                       = new ItemInfo(ItemType.Radio                       , true);
        public static readonly ItemInfo GunCOM15                    = new ItemInfo(ItemType.GunCOM15                    , false,  12);
        public static readonly ItemInfo Medkit                      = new ItemInfo(ItemType.Medkit                      , true);
        public static readonly ItemInfo Flashlight                  = new ItemInfo(ItemType.Flashlight                  , true);
        public static readonly ItemInfo MicroHID                    = new ItemInfo(ItemType.MicroHID                    , false, 100);
        public static readonly ItemInfo SCP500                      = new ItemInfo(ItemType.SCP500                      , true);
        public static readonly ItemInfo SCP207                      = new ItemInfo(ItemType.SCP207                      , true);
        public static readonly ItemInfo WeaponManagerTablet         = new ItemInfo(ItemType.WeaponManagerTablet         , true);
        public static readonly ItemInfo GunE11SR                    = new ItemInfo(ItemType.GunE11SR                    , false,  40);
        public static readonly ItemInfo GunProject90                = new ItemInfo(ItemType.GunProject90                , false,  50);
        public static readonly ItemInfo Ammo556                     = new ItemInfo(ItemType.Ammo556                     , false,  50);
        public static readonly ItemInfo GunMP7                      = new ItemInfo(ItemType.GunMP7                      , false,  35);
        public static readonly ItemInfo GunLogicer                  = new ItemInfo(ItemType.GunLogicer                  , false,  75);
        public static readonly ItemInfo GrenadeFrag                 = new ItemInfo(ItemType.GrenadeFrag                 , true);
        public static readonly ItemInfo GrenadeFlash                = new ItemInfo(ItemType.GrenadeFlash                , true);
        public static readonly ItemInfo Disarmer                    = new ItemInfo(ItemType.Disarmer                    , true);
        public static readonly ItemInfo Ammo762                     = new ItemInfo(ItemType.Ammo762                     , false,  50);
        public static readonly ItemInfo Ammo9mm                     = new ItemInfo(ItemType.Ammo9mm                     , false,  50);
        public static readonly ItemInfo GunUSP                      = new ItemInfo(ItemType.GunUSP                      , true);
        public static readonly ItemInfo SCP018                      = new ItemInfo(ItemType.SCP018                      , true);
        public static readonly ItemInfo SCP268                      = new ItemInfo(ItemType.SCP268                      , true);
        public static readonly ItemInfo Adrenaline                  = new ItemInfo(ItemType.Adrenaline                  , true);
        public static readonly ItemInfo Painkillers                 = new ItemInfo(ItemType.Painkillers                 , true);
        public static readonly ItemInfo Coin                        = new ItemInfo(ItemType.Coin                        , true);
    }

    public static class ItemInfoExtensons
	{
        public static ItemInfo GetItemInfo(this ItemType item)
		{
            return (ItemInfo)item;
		}
	}
}
