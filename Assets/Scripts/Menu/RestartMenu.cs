using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartMenu : MonoBehaviour
{
    public GameObject restartMenuUI;
    private int restartGame = 0;

    private void Update() 
    {
       restartGame = PlayerPrefs.GetInt("Restart");

       if(restartGame == 1)
       {
           Cursor.lockState = CursorLockMode.None;
           Cursor.visible = true;
           restartMenuUI.SetActive(true);
        //    Time.timeScale = 0f;
       }
    }


    public void RestartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ToMenu()
    {
        
        SceneManager.LoadScene("MainMenu");
    }
    
}
