using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("UI").transform.Find("text").gameObject.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject.Find("UI").transform.Find("gosariend").gameObject.SetActive(true);
                GameObject.Find("UI").transform.Find("gosari").gameObject.SetActive(false);
                GameObject.Find("CraftHint").transform.Find("one").gameObject.SetActive(true);
            }
        }
    }

<<<<<<< Updated upstream
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Move1-2")
        {
            
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == GameObject.Find("UI").transform.Find("gosari").name)
        {
            GameObject.Find("UI").transform.Find("text").gameObject.SetActive(true);

        }
=======
    private void OnTriggerStay2D(Collider2D collision)
    {       
        if (collision.gameObject.name == GameObject.Find("UI").transform.Find("gosari").name)
        {           
            GameObject.Find("UI").transform.Find("text").gameObject.SetActive(true);
            
        }       
>>>>>>> Stashed changes
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == GameObject.Find("UI").transform.Find("gosari").name)

        {
            GameObject.Find("UI").transform.Find("text").gameObject.SetActive(false);
        }
    }

    //Debug
    public void D_Home()
    {
        SceneManager.LoadScene("Home");
    }
}
