using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableRotate : MonoBehaviour // this script males a collectable object rotation constatly 
{

    [SerializeField] int rotateSpeed = 1; // speed at which the object rotates 
    void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World); // rotate the object around the y axis

    }
}
    // this creates a spinning effect for the coin collectable 