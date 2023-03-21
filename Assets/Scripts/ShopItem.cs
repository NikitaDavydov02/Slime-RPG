using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem
{
    public int Cost { get; set; }
    public Feature Feature { get; set; }
    public ShopItem(int cost, Feature feature)
    {
        Cost = cost;
        Feature = feature;
    }
}
public enum Feature {
    Health,
    AtackSpeed,
    Damage,
    Protection,
    HPRecovery,
    CriticalHitChanse,
    CriticalHitDamage,

}

