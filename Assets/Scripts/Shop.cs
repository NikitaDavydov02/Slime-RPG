using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Shop : MonoBehaviour
{
    public int Balance { get; private set; } = 0;
    public List<ShopItem> Items { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        Items = new List<ShopItem>();
        foreach (Feature f in Enum.GetValues(typeof(Feature)))
        {
            ShopItem item = new ShopItem(5,f);
            Items.Add(item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Add(int value)
    {
        Balance += value;
    }
    public bool BuyItem(ShopItem item)
    {
        if (Balance < item.Cost || !Items.Contains(item))
            return false;
        Balance -= item.Cost;
        item.Cost++;
        return true;

    }
    
}
