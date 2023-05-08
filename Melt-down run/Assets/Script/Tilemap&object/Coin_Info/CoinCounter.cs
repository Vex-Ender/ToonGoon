using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter Instance;

    public TMP_Text coinText;
    public int currentCoins = 0;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        coinText.text = "Coins: " + currentCoins.ToString();
    }

    public void IncreaseCoins(int v)
    {
        currentCoins += v;
        coinText.text = "Coins: " + currentCoins.ToString();
    }

}
