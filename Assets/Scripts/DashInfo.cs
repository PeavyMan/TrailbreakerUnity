using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DashInfo : MonoBehaviour // this dashinfo update the text to show how many dashes remain after getting used
{
    public static int remainingDashes; // this will be used to accessed and modify other scripts
    [SerializeField] TMP_Text dashDisplay; // this allows to assign it to the unity inspector 

    void Update()
    {
        if (dashDisplay != null) // this chekcs for the dashdisplay to be assigned
        {
            dashDisplay.text = "Dashes: " + remainingDashes; // the text update the current number of remaining dashes
        }
    }
}