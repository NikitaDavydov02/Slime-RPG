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
    [SerializeField]
    private Button BuyButton;
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
        if (!MainManager.GameIsFinished && MainManager.Shop.ICanBuy(this))
            BuyButton.enabled = true;
        else
            BuyButton.enabled = false;
    }
    public void Buy()
    {
        MainManager.Shop.BuyItem(this);
    }
}


