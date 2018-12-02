using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScript : MonoBehaviour {
    Quaternion rotation;
    void Start()
    {
        rotation = transform.rotation;
    }

    void LateUpdate() { 
        transform.position = transform.parent.position + new Vector3(0f, 1.2f);
        transform.rotation = rotation;
    }



}
