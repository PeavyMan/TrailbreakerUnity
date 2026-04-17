using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegementGenerator : MonoBehaviour // this script generates level segnemnt in front of the player to give off the endless feeling
{
    public GameObject[] segment;
    [SerializeField] int zPos = 50;
    [SerializeField] bool creatingSegment = false;
    [SerializeField] int segmentNum;


    void Update()
    {
        if(creatingSegment == false) // if its not generating a segnment then start creating one
        {
            creatingSegment = true;
            StartCoroutine(SegmentGen());
        }
        
    }

    IEnumerator SegmentGen() // this handles the spawning of new segments over time 
    {
        segmentNum = Random.Range(0, 3); //pick a random segment from the array 
        Instantiate(segment[segmentNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 50; // moves spawn for the next segment to be cloned and played forward to make the endless runner 
        yield return new WaitForSeconds(3);// wait 3 seconds before allowing another segment to spawn
        creatingSegment = false;
    }
}