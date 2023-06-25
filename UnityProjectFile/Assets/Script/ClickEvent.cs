using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickEvent : MonoBehaviour
{
    // Start is called before the first frame update
    public void Clicked()
    {
        if (GameObject.Find("CraftHint").transform.Find("complete").gameObject.activeSelf == true)
        {
            GameObject.Find("UI").transform.Find("Craft").gameObject.SetActive(true);
        }
    }
    public void Craft()
    {
        SceneManager.LoadScene("Home");
    }
}
