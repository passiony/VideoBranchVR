using System.Collections;
using System.Collections.Generic;
using System.IO;
using RenderHeads.Media.AVProVideo;
using UnityEngine;

public class AdaptAndroid : MonoBehaviour
{
    private MediaPlayer mediaPlayer;
    
    void Start()
    {
#if UNITY_ANDROID &&! UNITY_EDITOR
        mediaPlayer = gameObject.GetComponent<MediaPlayer>();
        string videoPath = Path.Combine(Application.persistentDataPath, mediaPlayer.MediaPath.Path);
        Debug.Log("videoPath: " + videoPath);
        // 直接传递路径给 AVPro
        mediaPlayer.OpenMedia(MediaPathType.RelativeToPersistentDataFolder, mediaPlayer.MediaPath.Path);
#endif
    }
}
