using UnityEngine;

public class SequenceGenerator 
{
    private SequenceGenerator()
    {
    }

    public static InputEnum[] Generate(int NbInputsToGenerate)
    {
        InputEnum[] inputs = new InputEnum[NbInputsToGenerate];

        for (int i = 0; i < NbInputsToGenerate; i++)
        {
            int rand = Random.Range(0, ControlerManager.NB_INPUTS);
            InputEnum inputToAdd;

            switch (rand)
            {
                case 0:
                    inputToAdd = InputEnum.REDBUTTON;
                    break;
                case 1:
                    inputToAdd = InputEnum.BLUEBUTTON;
                    break;
                case 2:
                    inputToAdd = InputEnum.GREENBUTTON;
                    break;
                default:
                    inputToAdd = InputEnum.REDBUTTON;
                    break;
            }

            inputs[i] = inputToAdd;
        }
        
        return inputs;
    }
    
}
