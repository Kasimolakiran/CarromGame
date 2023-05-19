using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coin;


    void OnTriggerEnter2D(Collider2D collider)
    {
       
        if (collider.gameObject.tag == "Coins"|| collider.gameObject.tag=="WhiteCoin")
        {
            Destroy(collider.gameObject);
           
            CoinCounter.instance.IncreaseCoin(coin);
        }
        //if (collider.gameObject.tag == "Striker")
        //{

        //   // collider.transform.position = new Vector2(0.36f, -3.25f);
        //}
        if (collider.gameObject.tag == "Queen")
        {
            Destroy(collider.gameObject);

            CoinCounter.instance.IncreaseCoins(coin);
        }

    }
   
}
