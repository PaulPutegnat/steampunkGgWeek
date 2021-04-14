using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instructionPanelUI : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject redButton;
    public GameObject blueButton;
    public GameObject greenButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateInstructionUI()
    {
        for (int i = 0; i < gameManager.GetInstructionInputs().Length; i++)
        {
            InputEnum currentInstructionInput = gameManager.GetInstructionInputs()[i];

            Vector3 position = Vector3.zero;
            position.x =  (transform.position.x - 3) + (1.2f * i);
            position.y =  transform.position.y;
            position.z =  1;

            switch (currentInstructionInput)
            {
                case InputEnum.REDBUTTON:
                    Instantiate(redButton, position, transform.rotation);
                    break;
                case InputEnum.BLUEBUTTON:
                    Instantiate(blueButton, position, transform.rotation);
                    break;
                case InputEnum.GREENBUTTON:
                    Instantiate(greenButton, position, transform.rotation);
                    break;
                default:
                    break;
            }
        }
    }
}
