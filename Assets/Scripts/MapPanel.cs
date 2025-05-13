using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapPanel : MonoBehaviour
{
    public Button closeBtn;
    public static List<string> mapList = new List<string>();
    private Dictionary<string, GameObject> clouds;
    private AudioSource audioSource;

    void Awake()
    {
        closeBtn.onClick.AddListener(() => { gameObject.SetActive(false); });
        audioSource = GetComponent<AudioSource>();
        clouds = new Dictionary<string, GameObject>();
        clouds["201"] = transform.Find("201").gameObject;
        clouds["202"] = transform.Find("202").gameObject;
        clouds["301"] = transform.Find("301").gameObject;
        clouds["302"] = transform.Find("302").gameObject;
        clouds["401"] = transform.Find("401").gameObject;
    }

    private void OnEnable()
    {
        if (audioSource)
            audioSource.Play();
        foreach (var map in mapList)
        {
            if (clouds.ContainsKey(map))
            {
                clouds[map].SetActive(false);
            }
        }
    }

    private void OnDisable()
    {
        if (audioSource)
            audioSource?.Stop();
    }

    public static void LoadedMap(string scene)
    {
        mapList.Add(scene);
    }
}