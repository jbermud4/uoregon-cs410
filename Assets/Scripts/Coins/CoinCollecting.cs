using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Referenced from https://www.youtube.com/watch?v=tfnwwEHCjic&t=0s



public class CoinCollecting : MonoBehaviour
{
    public int coins =  0;
    public TextMeshProUGUI coinText;
    

    public void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Coin")
        {   
            Debug.Log("Coin Collected");
            coins++;
            coinText.text = "Coins: " + coins;
            Destroy(Col.gameObject);
        }
    }
   
}
