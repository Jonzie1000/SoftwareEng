using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwordScript : MonoBehaviour {

    public GameObject wall;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag!="Wall")
        {
            Score.scoreValue += 50;
            Destroy(other.gameObject);
        }
    }

}
