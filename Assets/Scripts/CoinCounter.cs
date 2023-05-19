using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter instance;
    public TMP_Text cointext;
    public int currentcoin = 0;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        cointext.text = "Coins" + currentcoin.ToString();
    }

    public void IncreaseCoin(int v)
    {
        currentcoin += v;
        cointext.text = "Coins" + currentcoin.ToString();
    }
    public void IncreaseCoins(int v)
    {
        currentcoin = v+2;
        cointext.text = "Coins" + currentcoin.ToString();
    }
}
