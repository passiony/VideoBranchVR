using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SeeArea : MonoBehaviour
{
    private Camera mainCamera;

    [SerializeField] private AudioMixerSnapshot defaultShot;
    [SerializeField] private AudioMixerSnapshot lowpassShot;

    // 新增计时器变量
    private float collisionTimer = 0f;
    public bool isColliding = false;
    private bool IsLowpass = true;
    
    public UnityEvent<bool> OnSeeTarget;

    public float DelayTime = 68;
    public float CrossTime = 1;
    public string JumpScene;

    void Start()
    {
        mainCamera = Camera.main;
        lowpassShot.TransitionTo(0);
        StartCoroutine(OnDelayReach());
    }

    private IEnumerator OnDelayReach()
    {
        yield return new WaitForSeconds(DelayTime);
        if (IsLowpass)
        {
            SceneManager.LoadScene(JumpScene);
        }
    }

    void Update()
    {
        Vector3 rayDirection = mainCamera.transform.forward;
        int layerMask = 1 << LayerMask.NameToLayer("Person");
        bool currentHit = Physics.Raycast(mainCamera.transform.position, rayDirection, 200, layerMask);
        
        if (currentHit)
        {
            if (!isColliding)
            {
                collisionTimer = 0f;
                isColliding = true;
            }

            collisionTimer += Time.deltaTime;
            if (collisionTimer >= CrossTime)
            {
                SetToDefault();
            }
        }
        else
        {
            isColliding = false;
            collisionTimer = 0f;
            SetToLowPass();
        }
    }


    void SetToDefault()
    {
        if (IsLowpass)
        {
            IsLowpass = false;
            defaultShot.TransitionTo(1);
            OnSeeTarget?.Invoke(true);
        }
    }

    void SetToLowPass()
    {
        if (!IsLowpass)
        {
            IsLowpass = true;
            lowpassShot.TransitionTo(1);
            OnSeeTarget?.Invoke(false);
        }
    }
}