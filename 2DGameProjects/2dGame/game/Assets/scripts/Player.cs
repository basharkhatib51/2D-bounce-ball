using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    float movespeed = 20f;
    public Rigidbody2D bombprefab;
    public Transform bombp;
    public Text OldScore;


    
    void Update()
    {
        float Moveaxis = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(1, 0) * Moveaxis * movespeed;

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            shoot();
            
        }
    }

    private void shoot()
    {
        var bomb  = Instantiate(bombprefab, bombp.position, Quaternion.identity);
        bomb.AddForce(bombp.up * 1000);
    }
}
