using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapUI : MonoBehaviour
{
    public int mapId;
    private Button m_Button;

    void Start()
    {
        m_Button = GetComponentInChildren<Button>();
        m_Button.onClick.AddListener(OnMapClick);
    }
    
    private void OnMapClick()
    {
        Debug.Log("点击了Map:" + mapId);
    }
}