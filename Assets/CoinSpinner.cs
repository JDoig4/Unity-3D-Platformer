using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoinSpinner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, 60f * Time.deltaTime, Space.Self);
    }
}
