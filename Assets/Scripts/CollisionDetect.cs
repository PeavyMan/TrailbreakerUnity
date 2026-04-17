using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetect : MonoBehaviour
{

    [SerializeField] GameObject thePlayer; // player 
    [SerializeField] GameObject playerAnim; // player animation
    [SerializeField] AudioSource collisionFX; // sound effect for collision
    [SerializeField] GameObject mainCam; // main camera for animated 
    [SerializeField] GameObject fadeOut; // fade out for scene transition

    void OnTriggerEnter(Collider other) // this is called when another collider triggers
    {
        StartCoroutine(CollisionEnd()); // start the collision sequence
    }

    IEnumerator CollisionEnd() // this will handle the full collision so timmy animation of falling backwards works
    {
        collisionFX.Play();
        thePlayer.GetComponent<PlayerMovement>().enabled = false; // disable player movement so that the player cont control character when he gets into a collision
        playerAnim.GetComponent<Animator>().Play("Stumble Backwards"); // play the stumble animation
        mainCam.GetComponent<Animator>().Play("CollisionCam"); // play camera animation for dramatic effect 
        yield return new WaitForSeconds(2); // wait for animation to play
        fadeOut.SetActive(true); // trigger fade out effect
        yield return new WaitForSeconds(2); // wait for fade out to comeplete
        SceneManager.LoadScene(0); // reload the scene 
    }
}
