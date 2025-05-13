using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static GameObject menuPrefab;

    private static GameObject MenuPrefab
    {
        get
        {
            if (menuPrefab == null)
            {
                menuPrefab = Resources.Load<GameObject>("Forms/Dialog3DForm");
            }

            return menuPrefab;
        }
    }
    private static GameObject GamePanel;

    public static void ShowDialog1(string title, string content, string yes, Action callback)
    {
        GameObject menu = Instantiate(MenuPrefab, Vector3.zero, Quaternion.identity);
        menu.GetComponent<Dialog3DForm>().ShowDialog(title, content, yes, callback);
    }

    public static void ShowDialog2(string title, string content, string yes, string no, Action yesCallback,
        Action noCancel)
    {
        GameObject menu = Instantiate(MenuPrefab, Vector3.zero, Quaternion.identity);
        menu.GetComponent<Dialog3DForm>().ShowDialog(title, content, yes, no, yesCallback, noCancel);
    }

    public static void ShowDialog3(string title, string content, string menu1, string menu2, string menu3,
        Action callback1,
        Action callback2, Action callback3)
    {
        GameObject menu = Instantiate(MenuPrefab, Vector3.zero, Quaternion.identity);
        menu.GetComponent<Dialog3DForm>()
            .ShowDialog(title, content, menu1, menu2, menu3, callback1, callback2, callback3);
    }
    
    public static void ShowDialog(string title, string content, string[] menus,Action[] callbacks)
    {
        GameObject menu = Instantiate(MenuPrefab, Vector3.zero, Quaternion.identity);
        menu.GetComponent<Dialog3DForm>()
            .ShowDialog(title, content, menus, callbacks);
    }

    public static void ShowArchive(string name)
    {
        GameObject menu = Instantiate(Resources.Load<GameObject>("Forms/ArchiveForm"), Vector3.zero, Quaternion.identity);
        menu.GetComponent<ArchiveForm>().ShowArchive(name);
    }

    public static void ShowGamePanel()
    {
        if (GamePanel)
        {
            Destroy(GamePanel);
        }
        else
        {
            GamePanel = Instantiate(Resources.Load<GameObject>("Forms/GamePanel"), Vector3.zero, Quaternion.identity);
        }
    }
}