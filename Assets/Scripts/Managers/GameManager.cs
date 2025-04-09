using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] int currentBitcoins;
    
    
    private void Awake()
    {
        instance = this;
    }



    public void GetBitcoins(int amountToGet)
    {
        currentBitcoins += amountToGet;
    }

    public void SpendBitcoins(int amountToSpend)
    {
        currentBitcoins -= amountToSpend;

        if(currentBitcoins <= 0)
        {
            currentBitcoins = 0;
        }
    }
}
