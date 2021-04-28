using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    public AudioSource goodInput;

    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            goodInput.Play();
        }
    }
}
