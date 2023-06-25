using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home0 : MonoBehaviour
{
    public GameObject StageTrigger;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        StageTrigger.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Done()
	{
        StageTrigger.SetActive(true);
    }

    public void Stage_Trigger()
	{
        animator.SetTrigger("entry");
        Invoke("Stage1", 1);
    }

    public void Stage1()
    {
        SceneManager.LoadScene("Stage1");
    }


}
