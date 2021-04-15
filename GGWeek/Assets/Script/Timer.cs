using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject textDisplay;
    public int timeLeft = 30;
    public bool takingAway = false;

    //Afficher le timer au lancement de la partie
    void Start()
    {
        textDisplay.GetComponent<Text>().text = "00:" + timeLeft;
    }

    //Modifier le timer
    void Update()
    {
        if(takingAway == false && timeLeft > 0) {
            StartCoroutine(ReduceTimer());
        }
    }

    IEnumerator ReduceTimer()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        timeLeft -= 1;
        //Rajouter un zéro si il reste moins de 10 secondes
        if (timeLeft < 10) {
            textDisplay.GetComponent<Text>().text = "00:0" + timeLeft;
        } else {
            textDisplay.GetComponent<Text>().text = "00:" + timeLeft;
        }
        takingAway = false;
    }

}
