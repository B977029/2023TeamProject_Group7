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
        SceneManager.LoadScene("Home");
    }
    
    public void ClickOption()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
