using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterInfo : MonoBehaviour // this script tracks and displays the player's total coin count
{
    public static int coinCount = 0;
    [SerializeField] GameObject coinDisplay; // Object that displays the coin count

    void Update()
    {
        coinDisplay.GetComponent<TMPro.TMP_Text>().text = "COINS: " + coinCount;
    }
}
 // this gets the text attached to coinDisplay and then updates the text to show the current coin count