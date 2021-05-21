using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ball : MonoBehaviour
{
    public Rigidbody2D rb2;
    public float movespeed;
    public Text Score;
    public Text oldScore;
    public Transform player;
    int score = 0;
    AudioSource audioSource;


   
    void Start()
    {
        Invoke("LaunchProjectile", 2.0f);
        audioSource=GetComponent<AudioSource>();

       

        if (SaveLoadManager.control==0)
        {

           
            int oldscore = SaveLoadManager.Load("mydata.kbu").score;
            float position = SaveLoadManager.Load("mydata.kbu").p;
            player.transform.position = new Vector2(0, position);
            oldScore.text = oldscore.ToString();
            score = oldscore;
        }
    }
    public void LaunchProjectile() 
    {
        rb2.velocity = new Vector2(1, 0) * movespeed;
    }



        private void OnCollisionEnter2D(Collision2D collision)
        {
            audioSource.Play();
            if (collision.gameObject.tag == "ball") 
            {
                 rb2.velocity = new Vector2(1, 0) * movespeed;
                 Destroy(collision.gameObject);
                 Makescoreandsave();
             }
         }

    private void Makescoreandsave()
    {
        
        score++;
        
        Score.text = score.ToString();
       
        if (score % 5 ==0) 
        {
            player.position = new Vector2(player.position.x, player.position.y + 1);
            
            if (player.position.y>= 1.48f) 
            {
                player.position = new Vector2(-0.11f, -4.54f);
                
            }
            SaveLoadManager.Save("mydata.kbu", new GameData(score, player.position.y));
        }
        SaveLoadManager.Save("mydata.kbu", new GameData(score, player.position.y));
    }
}