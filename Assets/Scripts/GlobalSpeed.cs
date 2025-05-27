using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalSpeed : MonoBehaviour
{
    private float globalSpeed = 0f;
    public bool speedOverride = false;
    private float speedBoost = 0.5f;
    private float speedBoostTimer = 0f;

    public float GetGlobalSpeed()
    {
        return globalSpeed;
    }

    public void SetGlobalSpeed(float playerSpeed)
    {
        if (!speedOverride)
        {
            globalSpeed = playerSpeed;
        }
        else
        {
            globalSpeed = 0;
        }
    }


    public void SetOverride(bool speedOverrideCommand)
    {
        speedOverride = speedOverrideCommand;
    }

    void OnEnable()
    {
        Debug.Log("OnEnable called in GlobalSpeed");
        //SceneManager.sceneLoaded += OnSceneLoaded;
    }
}
