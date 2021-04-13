using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InputEnum[] inputs;

        inputs = SequenceGenerator.Generate(5);

        for (int i = 0; i < 5; i++)
        {
            print(inputs[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
