using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class MapPanel : MonoBehaviour
{
    public Button closeBtn;
    private AudioSource audioSource;
    private Image m_Image;

    private Dictionary<string, string> clouds;
    static List<string> mapList = new() { "101" };

    void Awake()
    {
        m_Image = gameObject.GetComponent<Image>();
        closeBtn.onClick.AddListener(() => { gameObject.SetActive(false); });
        audioSource = GetComponent<AudioSource>();
        clouds = new Dictionary<string, string>();
        clouds["101"] = "剧情1";
        clouds["101-201"] = "剧情2.1";
        clouds["101-201-301"] = "剧情2.1-3.1";
        clouds["101-201-301-403"] = "剧情2.1-3.1-4.3";
        clouds["101-201-302"] = "剧情2.1-3.2";
        clouds["101-201-302-403"] = "剧情2.1-3.2-4.3";
        clouds["101-201-401"] = "剧情2.1-4.1";
        clouds["101-201-401-1"] = "剧情2.1-4.1-1"; //换酒成功
        clouds["101-201-401-2"] = "剧情2.1-4.1-2"; //换酒失败
        clouds["101-202"] = "剧情2.2.png";
        clouds["101-202-301"] = "剧情2.2-3.1";
        clouds["101-202-301-403"] = "剧情2.2-3.1-4.3";
        clouds["101-202-302"] = "剧情2.2-3.2";
        clouds["101-202-302-403"] = "剧情2.2-3.2-4.3";
        clouds["101-202-402"] = "剧情2.2-4.2";
    }

    private void OnEnable()
    {
        if (audioSource)
            audioSource.Play();

        var sb = new StringBuilder();
        foreach (var map in mapList)
        {
            sb.Append(map + "-");
        }

        var text = sb.ToString().Remove(sb.Length - 1, 1);
        Debug.Log(text);
        if (clouds.TryGetValue(text, out var value))
        {
            var sp = Resources.Load<Sprite>("Maps/" + value);
            if (sp != null)
            {
                m_Image.sprite = sp;
            }
        }
    }

    private void OnDisable()
    {
        if (audioSource)
            audioSource.Stop();
    }

    public static void LoadedMap(string scene)
    {
        if (scene.Contains("-"))
        {
            var arr = scene.Split('-');
            if (!mapList.Contains(arr[0]))
                mapList.Add(arr[0]);
            if (arr[1] == "32" || arr[1] == "42" || arr[1] == "52")
            {
                mapList.Add("402");
            }
        }
        else
        {
            mapList.Add(scene);
        }
    }
}