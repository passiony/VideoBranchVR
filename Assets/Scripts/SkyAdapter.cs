using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyAdapter : MonoBehaviour
{
    public int Height = 5;
    private int mirror = -1;

    void Start()
    {
        transform.localPosition = new Vector3(0, Height, 0);
        transform.localEulerAngles = new Vector3(0, -145 * mirror, 0);
        transform.localScale = new Vector3(100 * mirror, 100, 100);
    }
}