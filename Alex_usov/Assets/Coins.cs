using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : Bonus
{
    //void Start()
    //{
    //    coins = 1;
    //}
    public override void QuantityCoins()
    {
        coins = 1;
        playerShop.GetCoins(coins);
    }
}
