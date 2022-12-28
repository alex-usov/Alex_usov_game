using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    protected int coins;
    protected PlayerShop playerShop;
    public void SetCoins()
    {
        playerShop = FindObjectOfType<PlayerShop>();
        QuantityCoins();
    }
    public virtual void QuantityCoins()
    {

    }
}
