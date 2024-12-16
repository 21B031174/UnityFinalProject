using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    public TextMeshProUGUI txtCoin;

    private int totalCoins = 0;

    private void Awake(){
        if (instance == null){
            instance = this; 
        }
        else {
            Destroy(gameObject);
        }
    }
    
    public void AddCoin(int amount){

        totalCoins += amount;
        // Debug.Log("Coin: " + totalCoins);
        txtCoin.text = totalCoins.ToString();
    }
}
