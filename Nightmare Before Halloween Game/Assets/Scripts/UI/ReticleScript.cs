using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReticleScript : MonoBehaviour
{
    /// <summary>
    /// This variable is a reference variable. This references the SampleInteractScript
    /// allowing us access to all public variables and methods in this script.
    /// </summary>
    public InteractScript ReferenceInteractScript;

    //This variable stores data for our Image
    public Image MyReticleImage;

    private void Update()
    {
        //If the SampleInteractScript variable canInteract is true
        if (ReferenceInteractScript.canInteract)
        {
            //Change the image to be green
            MyReticleImage.color = Color.green;
        }
        else //Else meaning if it is not true
        {
            //keep our color white
           MyReticleImage.color = Color.white;
        }
    }

}
