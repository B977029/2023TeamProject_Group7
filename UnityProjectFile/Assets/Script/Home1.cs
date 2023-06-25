using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home1 : MonoBehaviour
{
    public GameObject StageTrigger;
    public GameObject item;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        StageTrigger.SetActive(false);
        item.SetActive(true);
        Invoke("offitem", 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Done()
    {
        StageTrigger.SetActive(true);
    }

    public void offitem()
    {
        item.SetActive(false);
    }

    public void Stage_Trigger()
    {
        animator.SetTrigger("entry");
        Invoke("Stage2", 1);
    }

    public void Stage2()
    {
        SceneManager.LoadScene("Stage2");
    }


}
