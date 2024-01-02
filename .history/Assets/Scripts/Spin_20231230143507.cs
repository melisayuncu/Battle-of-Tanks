using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPin : MonoBehaviour
{
    public float spinSpeed = 90.0f;
       
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Q))
        transform.Rotate(Vector);
    }
}
