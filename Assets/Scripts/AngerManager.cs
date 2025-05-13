using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AngerManager : MonoBehaviour
{
    public static AngerManager Instance;

    public int Anger { get; set; }
    public int AngerMax = 2;
    public int TriggerScene;
    
    public void Awake()
    {
        Instance = this;
    }
    
    public void AddAnger()
    {
        Anger++;
        if (Anger >= AngerMax)
        {
            SceneManager.LoadScene(TriggerScene);
        }
    }
}
