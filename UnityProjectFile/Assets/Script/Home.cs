using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    public bool tutorial;
    public bool Stage1_clear;
    public bool Stage2_clear;
    public bool Stage3_clear;

    //public GameObject Dialogue_0 =  GameObject.Find("Dialogue_0");
    public GameObject Dialogue_0;
    public GameObject Dialogue_1;
    public GameObject Dialogue_2;
    public GameObject Dialogue_3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
	{
        Dialogue();
    }

    void Dialogue()
	{
        if (tutorial)
            Dialogue_0.SetActive(true);
        else
            Dialogue_0.SetActive(false);

        if (Stage1_clear)
            Dialogue_1.SetActive(true);
        else
            Dialogue_1.SetActive(false);

        if (Stage2_clear)
            Dialogue_2.SetActive(true);
        else
            Dialogue_2.SetActive(false);

        if (Stage3_clear)
            Dialogue_3.SetActive(true);
        else
            Dialogue_3.SetActive(false);
    }

    public void Clearinit()
	{
        tutorial = false;
        Stage1_clear = false;
        Stage2_clear = false;
        Stage3_clear = false;
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

    public void D_Stage1Clear()
    {
        Clearinit();
        Stage1_clear = true;
    }

    public void D_Stage2Clear()
    {
        Clearinit();
        Stage2_clear = true;
    }

    public void D_Stage3Clear()
    {
        Clearinit();
        Stage3_clear = true;
    }
}
