using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public Transform target;

     void Start() 
    {
        transform.Rotate( 180,0,0 );
    }

    void Update()
    {
        transform.LookAt(target);
    }
}
