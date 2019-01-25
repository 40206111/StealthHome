using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textReveal : MonoBehaviour
{
    // Text
    private TextMeshPro txt;

    private void Start()
    {
        //get Text
        txt = gameObject.GetComponent<TextMeshPro>();
        //Start Reveal
        StartCoroutine(Go());
    }

    //Reveal
    IEnumerator Go()
    {

        int totVis = txt.textInfo.characterCount;
        int counter = 0;

        int visCount = 0;

        //While there are more characters
        while (visCount < totVis)
        {
            //make next character visible
            visCount = counter % (totVis + 1);
            txt.maxVisibleCharacters = visCount;

            counter++;
            yield return new WaitForSeconds(0.05f);
        }



    }

}
