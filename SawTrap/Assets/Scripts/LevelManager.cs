using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    
    int levelsUnlocked;


    public Button[] buttons;

    


    // Start is called before the first frame update
    void Start()
    {
        levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked", 1); 

        for(int i = 0; i<buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        
        
        for(int i = 0; i<levelsUnlocked; i++)
        {
            buttons[i].interactable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Level1()

    { 
      SceneManager.LoadScene("Level1");
        Time.timeScale = 1f;
        
    }
    public void Level2()

    { 
      SceneManager.LoadScene("Level2");
        Time.timeScale = 1f;
    }
    public void Level3()

    { 
      SceneManager.LoadScene("Level3");
        Time.timeScale = 1f;
    }
    public void Level4()

    { 
      SceneManager.LoadScene("Level4");
        Time.timeScale = 1f;
    }
    public void Level5()

    { 
      SceneManager.LoadScene("Level5");
        Time.timeScale = 1f;
    }
    public void Level6()

    { 
      SceneManager.LoadScene("Level6");
        Time.timeScale = 1f;
    }
    public void Level7()

    { 
      SceneManager.LoadScene("Level7");
        Time.timeScale = 1f;
    }
    public void Level8()

    { 
      SceneManager.LoadScene("Level8");
        Time.timeScale = 1f;
    }
    public void Level9()

    { 
      SceneManager.LoadScene("Level9");
        Time.timeScale = 1f;
    }
    public void Level10()

    { 
      SceneManager.LoadScene("Level10");
        Time.timeScale = 1f;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu2");
        Time.timeScale = 1f;
    }
}
