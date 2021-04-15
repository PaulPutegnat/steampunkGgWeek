using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int currentLife;
    public int numOfLifes;

    public Image[] lifes;
    public Sprite fullLife;
    public Sprite emptyLife;

    void Update()
    {
        //Set la vie actuelle au nombre max de vies
        if(currentLife > numOfLifes){
            currentLife = numOfLifes;
        }

        //Pour tester la Fonction TakeDamage
        if (Input.GetKeyDown(KeyCode.P)) {
            TakeDamage(1);
        }

        //Affichage du bon sprite en fonction de la vie actuelle
        for (int i = 0; i < lifes.Length; i++)
        {
            if(i < currentLife) {
                lifes[i].sprite = fullLife;
            } else {
                lifes[i].sprite = emptyLife;
            }

            if(i < numOfLifes) {
                lifes[i].enabled = true;
            } else {
                lifes[i].enabled = false;
            }
        }
    }

    //Fonction pour enlever de la vie
    void TakeDamage(int damage)
    {
        currentLife -= damage;
        SoundManager.PlaySound("missed");
    }
}
