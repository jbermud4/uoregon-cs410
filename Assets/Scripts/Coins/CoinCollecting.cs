using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< Updated upstream
using TMPro;

// Referenced from https://www.youtube.com/watch?v=tfnwwEHCjic&t=0s



public class CoinCollecting : MonoBehaviour
{
    public int coins =  0;
    public TextMeshProUGUI coinText;
    
=======

public class CoinCollecting : MonoBehaviour
{
    public int coins;
    void Start()
    {
        
    }
>>>>>>> Stashed changes

    public void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Coin")
<<<<<<< Updated upstream
        {   
            Debug.Log("Coin Collected");
            coins++;
            coinText.text = "Coins: " + coins;
            Destroy(Col.gameObject);
        }
    }
   
=======
        {
            Debug.Log("Coin Collected");
            coins++;
            Destroy(Col.gameObject);
            //Col.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
>>>>>>> Stashed changes
}
