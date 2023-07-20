using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EquipmentEnum : MonoBehaviour
{
    public enum EquipType 
    { 
        Weapon, 
        Defense, 
        Gloves, 
        Ring 
    };

    public enum WeaponName
    {
        AssassinDagger,
        BalancedSword,
        BronzeDagger,
        Katana,
        VikingAxe,
        Harpoon,
        MountainSword,
        AriostinSword,
        BerserkAxe,
        DestroyerAxe,
        ButcherKnife,
        DarkSword
    };

    public enum DefenseName
    {
        BanditArmor,
        BattleArmor,
        DarkMountainArmor,
        GeryKnightArmor,
        ManticoreArmor,
        NewbieArmor,
        RoyalTunicArmor
    };

    public enum GlovesName
    {
        BanditGloves,
        BattleGloves,
        DarkMountainGloves,
        GeryKnightGloves,
        ManticoreGloves,
        NewbieGloves
    };

    public enum RingName
    {
        BronzeRing,
        SliverRing,
        GoldenRing,
        MagicBronzeRing,
        MagicSilverRing,
        MagicGoldenRing
    };

    public EquipType equipType;

    [HideInInspector][SerializeField] public WeaponName weaponName;
    [HideInInspector][SerializeField] public DefenseName defenseName;
    [HideInInspector][SerializeField] public GlovesName glovesName;
    [HideInInspector][SerializeField] public RingName ringName;
}
