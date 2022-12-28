using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : Bonus
{
    //void Start()
    //{
    //    coins = -5;
    //}
    public override void QuantityCoins()
    {
        coins = -5;
        playerShop.GetCoins(coins);
    }
}
