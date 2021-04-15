using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPanelUI : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject redButton;
    public GameObject blueButton;
    public GameObject greenButton;

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
                gameObject = Instantiate(redButton, position, transform.rotation);
                break;
            case InputEnum.BUTTON_2:
                gameObject = Instantiate(blueButton, position, transform.rotation);
                break;
            case InputEnum.BUTTON_3:
                gameObject = Instantiate(greenButton, position, transform.rotation);
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
