using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI tags;

    private void Start() {
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LeaderBoard()
    {
        tags.text = PlayerPrefs.GetInt("Tags").ToString();
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
