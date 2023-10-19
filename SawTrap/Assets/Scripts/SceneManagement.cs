using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagement : MonoBehaviour
{

    public GameObject pauseMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        Time.timeScale = 1f;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Play()
    {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1f;
    }

    public void Customize()
    {
        SceneManager.LoadScene("Customize");
    }


    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu2");
        Time.timeScale = 1f;
    }
    
    public void NextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        SceneManager.LoadScene(nextSceneIndex);
        Time.timeScale = 1f;
    }

    public void Levels()
    {
        SceneManager.LoadScene("Levels");
        Time.timeScale = 1f;
    }

    public void passLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if(currentLevel >= PlayerPrefs.GetInt("levelsUnlocked"))
        {
            PlayerPrefs.SetInt("levelsUnlocked", currentLevel + 1);
        }

        Debug.Log("level " + PlayerPrefs.GetInt("levelsUnlocked") + " unlocked");
    }

}
