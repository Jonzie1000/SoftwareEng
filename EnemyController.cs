using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    // Who we are chasing
    public Transform Player;
    public float speed = 5f;
    public Rigidbody rb;
    public float attackRange;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(3f);
        rb = GetComponent<Rigidbody>();
        Player = GameObject.Find("Player_Sprite").transform;


    }

    void Update()
    {
        float z = Mathf.Atan2((Player.transform.position.y - transform.position.y),
            (Player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;

        transform.eulerAngles = new Vector3(0, 0, z);
        transform.position = Vector3.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
        rb.AddForce(gameObject.transform.up * speed);


    }

}
