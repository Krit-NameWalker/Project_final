using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coinCollect : MonoBehaviour
{
    int scoresCount = 0;

    public TMP_Text scoretext;

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Pick Up")
        {
            scoresCount ++;
            scoretext.SetText(scoresCount.ToString());

        }
        
    }
}
