using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ReplayManager : MonoBehaviour
{

    public bool isRecording = true;

    private bool isPausing = false;
    private float fixedDeltaTime;

    // Use this for initialization
    void Start()
    {
        fixedDeltaTime = Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            isRecording = false;
        }
        else
        {
            isRecording = true;
        }
        
        
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(!isPausing)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    private void OnApplicationPause(bool pause)
    {
        isPausing = pause;
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
        Time.fixedDeltaTime = 0f;
        isPausing = true;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = fixedDeltaTime;
        isPausing = false;
    }
}
