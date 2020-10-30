using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ITManager : MonoBehaviour
{
    
    public TextMeshProUGUI itUI,hit,tags;
    public Bullet bullet;
    public EnemyMovement enemy;
    public Gun player;
    private int score;
    public bool player_IT = true;
    public bool hit_Enemy = false ,hit_Player = false;
    private void Update() 
    {
        if (player_IT)
        {
            itUI.text = "YOU ARE IT";
            if(hit_Enemy)
        {
           Score();
           hit_Enemy = false;
           hit.text = "You Tagged The Enemy";
           
        }
            playerIT();
        }
        else
        {
            itUI.text = "RUN AWAY";
            enemyIT();
        }
        
    }

    private void Score()
    {
        score++;
        PlayerPrefs.SetInt("HighScore",score); 
        tags.text = ("Tags: " + PlayerPrefs.GetInt("HighScore")).ToString();
    }

    private void enemyIT()
    {
        
    }

    public void playerIT()
    {
       player_IT = true;
    }
}
