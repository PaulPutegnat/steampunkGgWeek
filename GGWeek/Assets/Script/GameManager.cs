using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int instructionNumbers = 6;

    [SerializeField] private InstructionPanelUI instructionPanelUI;
    [SerializeField] private PlayerPanelUI PlayerPanelUI;
    [SerializeField] private Health health;
    [SerializeField] private Text textRobots;
    [SerializeField] private Text textJours;
    [SerializeField] private Timer timer;


    [SerializeField] private InputEnum[] currentInstuctionInputs;
    [SerializeField] private InputEnum[] currentPlayerInputs;
    private int currentPlayerIndex = 0;

    public int robotFinish;
    public int goodInputSerie;
    public int robotToDo;
    public int day = 1;

    public GameObject music;

   
    // Start is called before the first frame update
    void Start()
    {
        Init();
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }

        if(robotFinish == robotToDo) {
            //Victoire
            print("Victoire");
            DayWin();
        }
        //Debug.Log(goodInputSerie);
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

    private void Init()
    {
        music.SetActive(true);
        currentPlayerInputs = new InputEnum[instructionNumbers];
        currentInstuctionInputs = SequenceGenerator.Generate(instructionNumbers);
        instructionPanelUI.UpdateInstructionUI();
        goodInputSerie = 0;
        robotFinish = 0;
        robotToDo = 4 + day * 2;
        textJours.text = day.ToString();
        textRobots.text = robotToDo.ToString();
        timer.ResetTime();
    }
    private void DayWin()
    {
        health.victoryPanel.SetActive(true);
        music.SetActive(false);
        instructionPanelUI.Clear();
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

        if (inputToAdd != InputEnum.NULL)
        {
            
            currentPlayerInputs[currentPlayerIndex] = inputToAdd;
            PlayerPanelUI.UpdatePlayerUI();

            if (currentInstuctionInputs[currentPlayerIndex] != currentPlayerInputs[currentPlayerIndex])
            {
                print("Erreur");
                goodInputSerie = 0;
                health.TakeDamage(1);
                currentPlayerIndex = 0;
                PlayerPanelUI.Clear();
                instructionPanelUI.Clear();
                NewInstructions();

                if (health.currentLife == 0) {
                    PlayerPanelUI.Clear();
                    instructionPanelUI.Clear();
                }
            }
            else
            {
                print("Bon");
                goodInputSerie = goodInputSerie + 1;
                ++currentPlayerIndex;

                if(goodInputSerie == instructionNumbers) {
                    robotFinish++;

                    PlayerPanelUI.Clear();
                    instructionPanelUI.Clear();
                    currentPlayerIndex = 0;
                    goodInputSerie = 0;
                    NewInstructions();
                }
            }
        }
    }

    void NewInstructions() {
        currentInstuctionInputs = SequenceGenerator.Generate(instructionNumbers);
        instructionPanelUI.UpdateInstructionUI();
    }

    public void NextDay()
    {
        ++day;
        Init();
    }

    public void Lost()
    {
        PlayerPanelUI.Clear();
        instructionPanelUI.Clear();
    }
}
