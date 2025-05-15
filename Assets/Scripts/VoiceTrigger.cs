using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class VoiceTrigger : MonoBehaviour
{
    public float sensitivity = 0.01f;           // ������ֵ
    public float silenceDuration = 1.0f;        // ������ú���Ϊ˵������

    private AudioClip micRecord;
    private string micDevice;
    private float lastTalkingTime;
    private bool isTalking = false;

    public UnityEvent OnEndEvent;
    
    void Start()
    {
        micDevice = Microphone.devices[0];
        micRecord = Microphone.Start(micDevice, true, 10, 44100);
    }

    void Update()
    {
        float volume = GetMicVolume();

        if (volume > sensitivity)
        {
            isTalking = true;
            lastTalkingTime = Time.time;
            Debug.Log("Talking...");
        }
        else if (isTalking && Time.time - lastTalkingTime > silenceDuration)
        {
            isTalking = false;
            OnSpeechEnd(); // ��������
        }
    }

    float GetMicVolume()
    {
        int sampleSize = 128;
        float[] samples = new float[sampleSize];
        int micPosition = Microphone.GetPosition(micDevice) - sampleSize + 1;
        if (micPosition < 0) return 0;

        micRecord.GetData(samples, micPosition);

        float levelMax = 0;
        for (int i = 0; i < sampleSize; i++)
        {
            float wavePeak = samples[i] * samples[i];
            if (wavePeak > levelMax) levelMax = wavePeak;
        }

        return Mathf.Sqrt(levelMax);
    }

    void OnSpeechEnd()
    {
        Debug.Log("Speech ended. Activating object.");
        OnEndEvent?.Invoke();
    }
}
