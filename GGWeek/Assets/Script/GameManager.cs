using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int instructionNumbers = 6;

    [SerializeField] private InstructionPanelUI instructtionPanelUI;
    [SerializeField] private PlayerPanelUI PlayerPanelUI;

    [SerializeField] private InputEnum[] currentInstuctionInputs;
    [SerializeField] private InputEnum[] currentPlayerInputs;
    private int currentPlayerIndex = 0;

   
    // Start is called before the first frame update
    void Start()
    {
        currentPlayerInputs = new InputEnum[instructionNumbers];
        currentInstuctionInputs = SequenceGenerator.Generate(instructionNumbers);
        instructtionPanelUI.UpdateInstructionUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            string keyPressed = Input.inputString;
            //print(keyPressed);
            InputManagement(keyPressed);
        }

        if (currentPlayerIndex >= instructionNumbers)
        {
            instructtionPanelUI.Clear();
            PlayerPanelUI.Clear();
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

    public int GetCurrentPlayerIndex()
    {
        return currentPlayerIndex;
    }
    
    private void InputManagement(string keyToProcess)
    {
        InputEnum inputToAdd;
        switch (keyToProcess) //Trouve l'input corespondent 
        {
            case "e":
                inputToAdd = InputEnum.BUTTON_1;
                break;            
            case "r":
                inputToAdd = InputEnum.BUTTON_2;
                break;            
            case "t":
                inputToAdd = InputEnum.BUTTON_3;
                break;
            case "y":
                inputToAdd = InputEnum.SLIDER_1;
                break;
            case "u":
                inputToAdd = InputEnum.SLIDER_2;
                break;
            case "i":
                inputToAdd = InputEnum.GEAR_1;
                break;
            case "o":
                inputToAdd = InputEnum.GEAR_2;
                break;
            case "p":
                inputToAdd = InputEnum.GEAR_3;
                break;
            case "5":
                inputToAdd = InputEnum.JOYSTICK_UP;
                break;
            case "2":
                inputToAdd = InputEnum.JOYSTICK_DOWN;
                break;
            case "3":
                inputToAdd = InputEnum.JOYSTICK_RIGHT;
                break;
            case "1":
                inputToAdd = InputEnum.JOYSTICK_LEFT;
                break;
            default:
                inputToAdd = InputEnum.NULL;
                break;
        }

        if (inputToAdd != InputEnum.NULL && currentPlayerIndex < instructionNumbers)
        {
            
            currentPlayerInputs[currentPlayerIndex] = inputToAdd;
            PlayerPanelUI.UpdatePlayerUI();

            if (currentInstuctionInputs[currentPlayerIndex] != currentPlayerInputs[currentPlayerIndex])
            {
                print("Erreur");
                //PlayerPanelUI.Clear();
            }
            else
            {
                print("Bon");
            }

            ++currentPlayerIndex;
        }
    }

}
