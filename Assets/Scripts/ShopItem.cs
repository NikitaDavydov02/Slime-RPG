using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem:MonoBehaviour
{
    public int Cost;
    public Feature Feature;
    [SerializeField]
    private Text CostText;
    //public ShopItem(int cost, Feature feature)
    //{
    //    Cost = cost;
    //    Feature = feature;
    //}
    private void Start()
    {
        
    }
    private void Update()
    {
        CostText.text = Cost.ToString();
    }
    public void Buy()
    {
        MainManager.Shop.BuyItem(this);
    }
}


