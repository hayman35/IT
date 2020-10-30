using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class ITManager : MonoBehaviour
{ 
    public TextMeshProUGUI itUI,hit,tags,highscore;
    public Bullet bullet;
    public EnemyMovement enemy;
    public CountDownTimer timer;
    public Gun player;
    private int score = 0;
    public int player_IT = 0;
    public bool hit_Enemy = false ,hit_Player = false;
    private void Update() 
    {
        Time.timeScale = 1f;
        if (player_IT == 0)
        {
            itUI.text = "YOU ARE IT";
            if(hit_Enemy)
            {
                Score();
                hit_Enemy = false;
                player_IT = 1;
                hit.text = "You Tagged The Enemy";
            }
        }
        if (player_IT == 1)
        {
            itUI.text = "Run Away";
            if(hit_Player)
            {
                hit_Player = false;
                player_IT = 0;
                hit.text = "You were Tagged";
            }
            
        }

        if(timer.currentTime == 0)
        {
            EndGame();
        }
    }


    private void EndGame()
    {
        Time.timeScale = 0f;
        if (score >= PlayerPrefs.GetInt("Tags",0))
        {
            savedata();
        }
        StartCoroutine(Restart());
        SceneManager.LoadScene("MainMenu");
    }

    private void Score()
    {
        score++;
        tags.text = "Tags: " + score;
    }


public void savedata()
{
    PlayerPrefs.SetInt("Tags", score);
    PlayerPrefs.Save();
}

IEnumerator Restart()
{
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
    highscore.text = "Game Over";
    yield return new WaitForSeconds(4);
}

}
