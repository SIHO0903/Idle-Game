using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EquipmentEnum : MonoBehaviour
{
    public enum EquipType
    {
        None,
        Weapon, 
        Defense, 
        Gloves, 
        Ring 
    };

    public enum WeaponName
    {
        None,
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
        None,
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
        None,
        BanditGloves,
        BattleGloves,
        DarkMountainGloves,
        GeryKnightGloves,
        ManticoreGloves,
        NewbieGloves
    };

    public enum RingName
    {
        None,
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
