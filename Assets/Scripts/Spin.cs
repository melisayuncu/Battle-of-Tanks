using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    // Speed of the spin
    public float spinSpeed = 90.0f;
       
    // Update is called once per frame
    void Update()
    {    
        // if the button "E" is pressed
        if(Input.GetKey(KeyCode.E)){      
              transform.Rotate(Vector3.up, spinSpeed*Time.deltaTime);
        }
        // if the button "Q" is pressed
        if(Input.GetKey(KeyCode.Q)){   
                 transform.Rotate(Vector3.up, -spinSpeed*Time.deltaTime);
        }
    }
}
