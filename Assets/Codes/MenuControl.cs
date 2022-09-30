using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    private void Start()
    {
        //PlayerPrefs.DeleteAll();
    }
    public void GoGame()
    {
        int recordLevel = PlayerPrefs.GetInt("record");
        if (recordLevel==0)
        {
            SceneManager.LoadScene(recordLevel+1);

        }
        else
        {
            SceneManager.LoadScene(recordLevel);
        }
        
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
    }

}
