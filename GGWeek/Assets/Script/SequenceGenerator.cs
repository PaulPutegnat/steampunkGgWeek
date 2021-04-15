using UnityEngine;

public class SequenceGenerator 
{
    private SequenceGenerator()
    {
    }

    /// <summary>
    /// Génere une suite d'inputs aléatoire.
    /// </summary>
    public static InputEnum[] Generate(int length)
    {
        InputEnum[] inputs = new InputEnum[length];

        for (int i = 0; i < length; ++i)
        {
            InputEnum inputToAdd = RandomInput(); //assignation de securité
            
            if (i == 0) //premier index donc pas de soucie de doublon
            {
                inputToAdd = RandomInput();
            }
            else
            {
                while (inputToAdd == inputs[i -1]) //change d'input si le precedent est le même
                {
                    inputToAdd = RandomInput();
                }
            }          
            inputs[i] = inputToAdd;
        }
        return inputs;
    }

    /// <summary>
    /// Choisie un Input aléatoire.
    /// </summary>
    private static InputEnum RandomInput()
    {
        int rand = Random.Range(0, ControlerManager.NB_INPUTS);
        InputEnum randInput;
        switch (rand) 
        {
            case 0:
                randInput = InputEnum.BUTTON_1;
                break;
            case 1:
                randInput = InputEnum.BUTTON_2;
                break;
            case 2:
                randInput = InputEnum.BUTTON_3;
                break;
            case 3:
                randInput = InputEnum.SLIDER_1;
                break;
            case 4:
                randInput = InputEnum.SLIDER_2;
                break;
            case 5:
                randInput = InputEnum.GEAR_1;
                break;
            case 6:
                randInput = InputEnum.GEAR_2;
                break;
            case 7:
                randInput = InputEnum.GEAR_3;
                break;
            case 8:
                randInput = InputEnum.JOYSTICK_UP;
                break;
            case 9:
                randInput = InputEnum.JOYSTICK_DOWN;
                break;
            case 10:
                randInput = InputEnum.JOYSTICK_RIGHT;
                break;
            case 11:
                randInput = InputEnum.JOYSTICK_LEFT;
                break;
            default:
                randInput = InputEnum.NULL;
                break;
        }

        return randInput;
    }
    
}
