using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    [SerializeField] GameObject fadeOut; /// this fade out the screne for transition 
    //[SerializeField] GameObject bounceText;
    [SerializeField] GameObject bigButton; // this is the main menu start button
    [SerializeField] GameObject animCam; // camera used for intro animation 
    [SerializeField] GameObject mainCam; //Main gameplay/ menu camera
    [SerializeField] GameObject menuControls; // these are for UI controls shown after intro
    [SerializeField] AudioSource buttonSelect; // sound effect for button press

    void Start()
    {
        //called once the scene starts
    }

    void Update()
    {
        // this is unused
    }

    public void MenuBeginButton()
    {
        StartCoroutine(AnimCam()); // When the begin button is pressed on the main manu 
    }  
    
     /// start the camera animation 


    public void StartGame() ///start game when button is pressed
    {
        StartCoroutine(StartButton());
    }

    IEnumerator StartButton()
    {
        buttonSelect.Play();  //plays button click soun
        fadeOut.SetActive(true); // eable fade out visual
        yield return new WaitForSeconds(1); //wait for fade animation to finish
        SceneManager.LoadScene(1); // Load scene with build index 1
    }

    IEnumerator AnimCam() // Handles the animated camera transition int the menu
    {
        animCam.GetComponent<Animator>().Play("AnimeCam"); // Play animation on the animated camera
        //bounceText.SetActive(false);
        bigButton.SetActive(false);        
        yield return new WaitForSeconds(1.5f);    // wait for animation to finish 
        mainCam.SetActive(true); /// switch from animated camera to main camera

        animCam.SetActive(false);
        //show menu controls after animation complete
        menuControls.SetActive(true);
    }
}