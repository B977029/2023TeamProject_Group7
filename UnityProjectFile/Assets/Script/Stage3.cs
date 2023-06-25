using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage3 : MonoBehaviour
{
    public bool clear;

    public GameObject one;
    public GameObject two;
    public GameObject three;
    private bool is_one;
    private bool is_two;
    private bool is_three;

    public GameObject incomplete;
    public GameObject complete;

    public GameObject mix_trigger;
    public GameObject mix_animation;

    //public Sprite 

    // Start is called before the first frame update
    void Start()
    {
        one.SetActive(true); 
        two.SetActive(true);
        is_one = true;
        is_two = true;
    }

    // Update is called once per frame
    void Update()
    {
        interaction();        

        if (IS_Complete())
        {
            Complete_Sprite_Switch();
        }

        if (clear)
            Invoke("Clear", 2);
    }

    void interaction()
    {
        if (GameObject.Find("UI").transform.Find("text").gameObject.activeSelf == true)
        {
            if (GameObject.Find("bridge").transform.Find("stagebridge").gameObject.activeSelf == false)
            {
                if (Input.GetKeyUp(KeyCode.E))
                {
                    GameObject.Find("wreck").transform.Find("stage3prop").gameObject.SetActive(false);
                    Get_ingredient(3);
                    GameObject.Find("CraftHint").transform.Find("complete").gameObject.SetActive(true);
                }
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                GameObject.Find("bridge").transform.Find("stagebridge").gameObject.SetActive(false);
                GameObject.Find("UI").transform.Find("text").gameObject.SetActive(false);
            }
        }
        if (GameObject.Find("UI").transform.Find("text2").gameObject.activeSelf == true)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                GameObject.Find("Background").transform.Find("stage3repair").gameObject.SetActive(true);
                GameObject.Find("wall").transform.Find("bridgewall").gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == GameObject.Find("bridge").transform.Find("stagebridge").name)
        {
            GameObject.Find("UI").transform.Find("text").gameObject.SetActive(true);
        }
        if(collision.gameObject.name==GameObject.Find("bridge").transform.Find("buildbridge").name)
        {
            GameObject.Find("UI").transform.Find("text2").gameObject.SetActive(true);
        }
        if(collision.gameObject.name==GameObject.Find("wreck").transform.Find("stage3prop").name)
        {
            GameObject.Find("UI").transform.Find("text").gameObject.SetActive(true);    
        }
        if(collision.gameObject.name==GameObject.Find("collider").transform.Find("bosscollider").name)
        {
            GameObject.Find("Boss_Canvas").transform.Find("Boss_Dialogue_0").gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == GameObject.Find("bridge").transform.Find("stagebridge").name)
        {
            GameObject.Find("UI").transform.Find("text").gameObject.SetActive(false);
        }
        if (collision.gameObject.name == GameObject.Find("bridge").transform.Find("buildbridge").name)
        {
            GameObject.Find("UI").transform.Find("text2").gameObject.SetActive(false);
        }
        if (collision.gameObject.name == GameObject.Find("wreck").transform.Find("stage3prop").name)
        {
            GameObject.Find("UI").transform.Find("text").gameObject.SetActive(false);
        }
    }
    //재료 추가 함수
    public void Get_ingredient(int num)
    {
        if (num == 1)
        {
            one.SetActive(true);
            is_one = true;
        }

        if (num == 2)
        {
            two.SetActive(true);
            is_two = true;
        }

        if (num == 3)
        {
            three.SetActive(true);
            is_three = true;
        }

    }

    //재료 다 모은거 판단하는 함수
    public bool IS_Complete()
    {
        if (is_one && is_two && is_three)
            return true;
        else
            return false;
    }

    //CraftHint sprite 바꾸는 함수
    public void Complete_Sprite_Switch()
    {
        incomplete.SetActive(false);
        complete.SetActive(true);
    }

    public void Mix()
    {
        if (IS_Complete())
        {
            mix_trigger.SetActive(true);
        }

    }

    public void Mix_Animation()
    {
        if (IS_Complete())
        {
            mix_trigger.SetActive(false);
            mix_animation.SetActive(true);
        }

        Invoke("Stop_Animation", 2);

    }

    public void Stop_Animation()
    {
        mix_animation.SetActive(false);

        //
        one.SetActive(false);
        is_one = false; 

        two.SetActive(false);
        is_two = false;

        three.SetActive(false);
        is_three = false;

        incomplete.SetActive(true);
        complete.SetActive(false);
    }

    public void Clear()
    {
        SceneManager.LoadScene("Home3");
    }

    //Debug
    public void D_Clear()
    {
        SceneManager.LoadScene("Home3");
    }

    public void D_Get_One()
    {
        one.SetActive(true);
        is_one = true;
    }

    public void D_Get_two()
    {
        two.SetActive(true);
        is_two = true;
    }

    public void D_Get_three()
    {
        three.SetActive(true);
        is_three = true;
    }
}
