using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    
    void Start()
    {
        Cursor.visible = true;
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Cursor.visible = false;
    }
    public void Quit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }

    public void NewGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Controls()
    {
        SceneManager.LoadScene("ControlsScene");
        
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenuScene");
        
    }




    
}
