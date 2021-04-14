using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int instructionNumbers = 6;
    public GameObject instructtionPanelUI;

    private InputEnum[] currentInstuctionInputs;
    private InputEnum[] currentPlayerInputs;
    private int currentPlayerIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        currentPlayerInputs = new InputEnum[instructionNumbers];
        currentInstuctionInputs = SequenceGenerator.Generate(instructionNumbers);
        instructtionPanelUI.GetComponent<instructionPanelUI>().UpdateInstructionUI();
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
    public InputEnum[] GetInstructionInputs()
    {
        return currentInstuctionInputs;
    }
    
    public InputEnum[] GetPlayerInputs()
    {
        return currentPlayerInputs;
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
