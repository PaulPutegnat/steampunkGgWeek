using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPanelUI : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject button_1;
    public GameObject button_2;
    public GameObject button_3;
    public GameObject slider_1;
    public GameObject slider_2;
    public GameObject gear_1;
    public GameObject gear_2;
    public GameObject gear_3;
    public GameObject joystick_up;
    public GameObject joystick_down;
    public GameObject joystick_right;
    public GameObject joystick_left;

    private List<GameObject> gameObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdatePlayerUI()
    {
        int currentIndex = gameManager.GetCurrentPlayerIndex();
        InputEnum currentInstructionInput = gameManager.GetPlayerInputs()[currentIndex];

        Vector3 position = transform.TransformPoint(transform.position);
        position.x = position.x + (((-2.0f * position.x) / gameManager.instructionNumbers) / 2.0f) + (((-2.0f * position.x) / gameManager.instructionNumbers) * currentIndex);
        position.z = 1;

        GameObject gameObject = null;

        switch (currentInstructionInput)
        {
            case InputEnum.BUTTON_1:
                gameObject = Instantiate(button_1, position, transform.rotation);
                break;
            case InputEnum.BUTTON_2:
                gameObject = Instantiate(button_2, position, transform.rotation);
                break;
            case InputEnum.BUTTON_3:
                gameObject = Instantiate(button_3, position, transform.rotation);
                break;
            case InputEnum.SLIDER_1:
                gameObject = Instantiate(slider_1, position, transform.rotation);
                break;
            case InputEnum.SLIDER_2:
                gameObject = Instantiate(slider_2, position, transform.rotation);
                break;
            case InputEnum.GEAR_1:
                gameObject = Instantiate(gear_1, position, transform.rotation);
                break;
            case InputEnum.GEAR_2:
                gameObject = Instantiate(gear_2, position, transform.rotation);
                break;
            case InputEnum.GEAR_3:
                gameObject = Instantiate(gear_3, position, transform.rotation);
                break;
            case InputEnum.JOYSTICK_UP:
                gameObject = Instantiate(joystick_up, position, transform.rotation);
                break;
            case InputEnum.JOYSTICK_DOWN:
                gameObject = Instantiate(joystick_down, position, transform.rotation);
                break;
            case InputEnum.JOYSTICK_RIGHT:
                gameObject = Instantiate(joystick_right, position, transform.rotation);
                break;
            case InputEnum.JOYSTICK_LEFT:
                gameObject = Instantiate(joystick_left, position, transform.rotation);
                break;
            default:
                break;
        }
        gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 1f);
        gameObjects.Add(gameObject);
    }

    public void Clear()
    {
        foreach (var item in gameObjects)
        {
            Destroy(item);
        }
    }
}
