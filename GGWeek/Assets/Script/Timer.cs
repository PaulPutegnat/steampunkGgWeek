using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject textDisplay;
    public int timeLeft = 30;
    public bool takingAway = false;
    public bool neverWon;

    [SerializeField] private Health health;

    //Afficher le timer au lancement de la partie
    void Start()
    {
        neverWon = true;
        textDisplay.GetComponent<Text>().text = "02:00";
    }

    //Modifier le timer
    void Update()
    {
        if(takingAway == false && timeLeft > 0) {
            StartCoroutine(ReduceTimer());
        }
        if (health.currentLife >= 1 && timeLeft == 0) {
            Victory();
            neverWon = false;
        }
    }

    IEnumerator ReduceTimer()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        timeLeft -= 1;
        //Correction d'affichage
        if (timeLeft >= 60) {
            textDisplay.GetComponent<Text>().text = "01:" + (timeLeft - 60);
        }
        if (timeLeft >= 60 && timeLeft < 70)
        {
            textDisplay.GetComponent<Text>().text = "01:0" + (timeLeft - 60);
        }
        if (timeLeft < 60) {
            textDisplay.GetComponent<Text>().text = "00:" + timeLeft;
        }
        if (timeLeft < 10) {
            textDisplay.GetComponent<Text>().text = "00:0" + timeLeft;
        }
        takingAway = false;
    }

    void Victory() { 
        Debug.Log("Victoire!");
    }
}
