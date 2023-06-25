using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage2 : MonoBehaviour
{
    GameObject cameraobj;
    GameObject playerobj;

    private bool clear;

    public GameObject one;
    public GameObject two;
    public GameObject three;
    public bool is_one;
    public bool is_two;
    public bool is_three;

    public GameObject incomplete;
    public GameObject complete;

    public GameObject mix_trigger;
    public GameObject mix_animation;

    // Start is called before the first frame update
    void Start()
    {
        
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
            if(GameObject.Find("CraftHint").transform.Find("one").gameObject.activeSelf == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameObject.Find("NPC").transform.Find("NPC1").gameObject.SetActive(false);
                }
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject.Find("po").transform.Find("potion").gameObject.SetActive(false);
                Get_ingredient(1);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "move1")
        {
            playerobj = GameObject.Find("Player");
            playerobj.transform.position = new Vector3((float)15.21, -7, -1);
            cameraobj = GameObject.Find("Main Camera");
            cameraobj.GetComponent<CameraController>().maxposition = (float)31.51;
            cameraobj.GetComponent<CameraController>().minxposition = (float)19.96;
        }
        if(collision.gameObject.name =="move2-1")
        {
            playerobj = GameObject.Find("Player");
            playerobj.transform.position = new Vector3(11, -7, -1);
            cameraobj = GameObject.Find("Main Camera");
            cameraobj.GetComponent<CameraController>().maxposition = (float)6.56;
            cameraobj.GetComponent<CameraController>().minxposition = (float)-31.45;
        }
        if (collision.gameObject.name == "move2floor")
        {
            playerobj = GameObject.Find("Player");
            playerobj.transform.position = new Vector3((float)42.32, -7, -1);
            cameraobj = GameObject.Find("Main Camera");
            cameraobj.GetComponent<CameraController>().maxposition = (float)84.7;
            cameraobj.GetComponent<CameraController>().minxposition = (float)47.3;
        }
        if (collision.gameObject.name == "move1floor")
        {
            playerobj = GameObject.Find("Player");
            playerobj.transform.position = new Vector3((float)34.06, -7, -1);
            cameraobj = GameObject.Find("Main Camera");
            cameraobj.GetComponent<CameraController>().maxposition = (float)31.51;
            cameraobj.GetComponent<CameraController>().minxposition = (float)19.96;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name ==GameObject.Find("po").transform.Find("potion").name)
        {
            GameObject.Find("UI").transform.Find("text").gameObject.SetActive(true);
        }
        if(collision.gameObject.name==GameObject.Find("NPC").transform.Find("NPC1").name)
        {
            GameObject.Find("UI").transform.Find("text").gameObject.SetActive(true);
        }
        if(collision.gameObject.name==GameObject.Find("collider").name)
        {
            GameObject.Find("Canvas").transform.Find("Dialogue_0").gameObject.SetActive(true);
        }    
        if(collision.gameObject.name==GameObject.Find("bosscollider").name)
        {
            GameObject.Find("Boss_Canvas").transform.Find("Boss_Dialogue_0").gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == GameObject.Find("po").transform.Find("potion").name)
        {
            GameObject.Find("UI").transform.Find("text").gameObject.SetActive(false);
        }
        if (collision.gameObject.name == GameObject.Find("NPC").transform.Find("NPC1").name)
        {
            GameObject.Find("UI").transform.Find("text").gameObject.SetActive(false);
        }
        if (collision.gameObject.name == GameObject.Find("collider").name)
        {
            GameObject.Find("Canvas").transform.Find("Dialogue_0").gameObject.SetActive(false);
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
            GameObject.Find("Boss_Canvas").transform.Find("Boss_Dialogue_0").gameObject.SetActive(false);
            mix_trigger.SetActive(true);
        }

    }

    public void Mix_Animation()
    {
        if (IS_Complete())
        {
            mix_trigger.SetActive(false);
            mix_animation.SetActive(true);

            clear = true;
        }

    }

    public void Clear()
    {
        SceneManager.LoadScene("Home2");
    }

    //Debug
    public void D_Clear()
    {
        SceneManager.LoadScene("Home2");
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
