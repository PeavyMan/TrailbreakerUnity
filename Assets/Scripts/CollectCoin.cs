using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour // the script handles coin collection when the player touches it 
{
    [SerializeField] AudioSource coinFX; // sound effect that plays when the coin is collected 

    void OnTriggerEnter(Collider other) //its called when the collider when its triggered
    {
        coinFX.Play();
        MasterInfo.coinCount += 1; // increases the coin count and is stored in master info
        this.gameObject.SetActive(false); // disables the coin so it disappears when its collected
    }

}
