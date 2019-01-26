using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textReveal : MonoBehaviour
{
    // Text
    private TextMeshPro txt;

    [SerializeField]
    private float wait = 0.05f;
    [SerializeField]
    private float waitBeforeBegin = 0.0f;

    private void Start()
    {
        //get Text
        txt = gameObject.GetComponent<TextMeshPro>();
        txt.maxVisibleCharacters = 0;
        //Start Reveal
        StartCoroutine(Go());
    }

    //Reveal
    IEnumerator Go()
    {
        yield return new WaitForSeconds(waitBeforeBegin);

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
            yield return new WaitForSeconds(wait);
        }



    }

}
