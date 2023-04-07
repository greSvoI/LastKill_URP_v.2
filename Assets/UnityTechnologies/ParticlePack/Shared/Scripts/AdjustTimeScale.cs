﻿using UnityEngine;
using System.Collections;
using TMPro;
using LastKill;

public class AdjustTimeScale : MonoBehaviour
{
    TextMeshProUGUI textMesh;
    IInput input;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        input = GameObject.FindGameObjectWithTag("Player").GetComponent<IInput>();
    }

    void Update()
    {
        if (input.Scroll > 0f)
        {
            if (Time.timeScale < 1.0F)
            {
                Time.timeScale += 0.1f;
            }
               
            Time.fixedDeltaTime = 0.02F * Time.timeScale;

            if (textMesh != null)
            {
                textMesh.text = "Time Scale : " + System.Math.Round(Time.timeScale, 2);
            }
          
        }
        else if (input.Scroll < 0f)
        {
            if (Time.timeScale >= 0.2F)
            {
                Time.timeScale -= 0.1f;
            }
                
            Time.fixedDeltaTime = 0.02F * Time.timeScale;

            if (textMesh != null)
            {
                textMesh.text = "Time Scale : " + System.Math.Round(Time.timeScale, 2);
            }
        }
    }

    void OnApplicationQuit()
    {
        Time.timeScale = 1.0F;
        Time.fixedDeltaTime = 0.02F;
    }
}