using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLimit : MonoBehaviour
{
    public int targetFrameRate = 60;
    public bool vSync = false;

    void Update()
    {
        if (vSync)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
        Application.targetFrameRate = targetFrameRate;

    }
}
