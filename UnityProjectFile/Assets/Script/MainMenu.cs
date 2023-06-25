using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ClickExit()
    {
        Application.Quit();
    }
    public void ClickStart()
    {
        SceneManager.LoadScene("Tutorial");
    }
    
    public void ClickOption()
    {
        
    }
}
