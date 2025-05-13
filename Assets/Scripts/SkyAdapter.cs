using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyAdapter : MonoBehaviour
{
    public int Height = 5;

    void Start()
    {
        transform.localPosition = new Vector3(0, Height, 0);
    }

}