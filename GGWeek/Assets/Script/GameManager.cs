using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int instructionNumbers = 5;

    private InputEnum[] currentInstuctionInputs;
    private InputEnum[] currentPlayerInputs;
    private int currentPlayerIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        currentPlayerInputs = new InputEnum[instructionNumbers];
        currentInstuctionInputs = SequenceGenerator.Generate(instructionNumbers);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            string keyPressed = Input.inputString;
            InputManagement(keyPressed);
        }
    }
    
    private void InputManagement(string keyToProcess)
    {
        InputEnum inputToAdd;
        switch (keyToProcess) //Trouve l'input corespondent 
        {
            case "q":
                inputToAdd = InputEnum.REDBUTTON;
                break;            
            case "s":
                inputToAdd = InputEnum.BLUEBUTTON;
                break;            
            case "d":
                inputToAdd = InputEnum.GREENBUTTON;
                break;
            default:
                inputToAdd = InputEnum.NULL;
                break;
        }

        if (inputToAdd != InputEnum.NULL && currentPlayerIndex < instructionNumbers)
        {
            currentPlayerInputs[currentPlayerIndex] = inputToAdd;

            if (currentInstuctionInputs[currentPlayerIndex] != currentPlayerInputs[currentPlayerIndex])
            {
                print("Erreur");
            }
            else
            {
                print("Bon");
            }

            ++currentPlayerIndex;
        }
    }

}
