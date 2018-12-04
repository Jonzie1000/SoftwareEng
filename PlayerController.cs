using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //float speed=0;
    Animator anim;
    public float moveSpeed;
    public Joystick joystick;
    public int playerHealth = 10;
    int damage = 1;


    void Start()
    {
        
        anim = GetComponent<Animator>();
       
    }

    public void AttackButton()
    { 
            anim.SetTrigger("Attack");
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && playerHealth>0)
        {
            playerHealth -= damage;
        }
    }


    private void FixedUpdate()
    {
        
        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetTrigger("Attack");
        }
        

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        else
        {
            //For Computer use
            if (Input.GetMouseButton(0))
            {
                /*
                var pos = Input.mousePosition;
                pos.z = transform.position.z - Camera.main.transform.position.z;
                pos = Camera.main.ScreenToWorldPoint(pos);
                transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);
                ///
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = 0;

                Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
                mousePos.x = mousePos.x - objectPos.x;
                mousePos.y = mousePos.y - objectPos.y;

                float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                */
            }
        }
        
    }

    void Update()
    {
        Vector3 moveVector = (Vector3.right * joystick.Horizontal + Vector3.up * joystick.Vertical);

        if (moveVector != Vector3.zero)
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
            transform.Translate(moveVector * moveSpeed * Time.deltaTime, Space.World);
            float angle = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }

    }




    void setSpeed()
    {
        //speed = 30;
    }
}

 
