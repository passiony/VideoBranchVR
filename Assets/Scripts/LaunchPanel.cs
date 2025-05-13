using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LaunchPanel : MonoBehaviour
{
    public Button startBtn;
    public Button mapBtn;

    public GameObject mapPanel;

    private void Awake()
    {
        startBtn.onClick.AddListener(() => { SceneManager.LoadScene(1); });
        mapBtn.onClick.AddListener(() => { mapPanel.SetActive(true); });
    }
}