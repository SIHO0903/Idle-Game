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
        aa,
        bb
    };

    public enum GlovesName
    {
        cc,
        dd
    };

    public enum RingName
    {
        ee,
        ff
    };

    public EquipType equipType;

    [HideInInspector][SerializeField] public WeaponName weaponName;
    [HideInInspector][SerializeField] public DefenseName defenseName;
    [HideInInspector][SerializeField] public GlovesName glovesName;
    [HideInInspector][SerializeField] public RingName ringName;
}
