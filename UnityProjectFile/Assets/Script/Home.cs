using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Debug
    public void D_Stage1()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void D_Stage2()
    {
        SceneManager.LoadScene("Stage2");
    }

    public void D_Stage3()
    {
        SceneManager.LoadScene("Stage3");
    }
}
