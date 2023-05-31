using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Airplane : MonoBehaviour
{

    
    public FixedJoystick Joystick;  // Reference to the joystick object
    public float movespeed;   // The movement speed of the plane

   
    public static bool pionterdown = false;

     Rigidbody2D rb;
    Vector2 move;
    private AudioSource au;
    public ParticleSystem partial;
    public TimeSurvived tttt;


  

    private void Start()
    {
       rb = GetComponent<Rigidbody2D>();
        au = GetComponent<AudioSource>();
    }

    private void Update()
    {
        move.x = Joystick.Horizontal;
        move.y = Joystick.Vertical;

        float haxis = move.x;
        float vaxis = move.y;
        float zaxis = Mathf.Atan2(haxis, vaxis) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0f, 0f, -zaxis);
      
    }

    private void FixedUpdate()
    {
        if (pionterdown)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.MovePosition(rb.position + move * movespeed * Time.fixedDeltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.CompareTag("Enemy"))
        {
            au.Play();
            partial.Emit(1);
           
            Destroy(collision.gameObject);
            Destroy(gameObject);
            tttt.isGameRunning = false;
           tttt. gameoverpanel.SetActive(true);

        }



    }


   

}
