using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Shop : MonoBehaviour
{
    public int Balance { get; private set; } = 0;
    [SerializeField]
    public List<ShopItem> Items;
    // Start is called before the first frame update
    void Start()
    {
        //foreach (Feature f in Enum.GetValues(typeof(Feature)))
        //{
        //    ShopItem item = new ShopItem(5,f);
        //    Items.Add(item);
        //}
        //MainManager.UIManager.UpddateShopList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Add(int value)
    {
        Balance += value;
    }
    public void BuyItem(string feature)
    {
        Debug.Log("Buy");
        ShopItem item = null;
        foreach (ShopItem i in Items)
            if (i.Feature.ToString()== feature)
                item = i;
        if (item == null)
            return;
        if (Balance < item.Cost || !Items.Contains(item))
            return;
        Balance -= item.Cost;

        item.Cost++;
    }
    public void BuyItem(ShopItem item)
    {
        Debug.Log("Buy!");
        if (Balance < item.Cost || !Items.Contains(item))
            return;
        Balance -= item.Cost;
        MainManager.EnemyAndPlayerManager.Player.GetComponent<PlayerMovment>().Enhanse(item.Feature);
        item.Cost++;
    }
    public bool ICanBuy(ShopItem item)
    {
        if (Balance >= item.Cost)
            return true;
        return false;
    }
}
public enum Feature
{
    Health,
    AtackSpeed,
    Damage,
    Protection,
    HPRecovery,
    CriticalHitChanse,
    CriticalHitDamage,

}
