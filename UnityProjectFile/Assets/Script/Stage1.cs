using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1 : MonoBehaviour
{
    GameObject playerobj;
    GameObject cameraobj;

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

    private bool is_second;

    public GameObject Dialogue_d_0;
    public GameObject Dialogue_d_1;

    // Start is called before the first frame update
    void Start()
    {
        clear = false;

        is_one = false;
        is_two = false;
        is_three = false;

        is_second = false;
    }

    // Update is called once per frame
    void Update()
    {
        Interaction();

        if (IS_Complete())
		{
            Complete_Sprite_Switch();
		}

        if (clear)
            Invoke("Clear", 2);
    }

    void Interaction()
    {
        if (GameObject.Find("UI").transform.Find("text").gameObject.activeSelf == true)
        {
            if (GameObject.Find("CraftHint").transform.Find("two").gameObject.activeSelf == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {

                }
            }
            if (GameObject.Find("CraftHint").transform.Find("one").gameObject.activeSelf == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameObject.Find("second").transform.Find("secondend").gameObject.SetActive(true);
                    GameObject.Find("second").transform.Find("secondi").gameObject.SetActive(false);
                }
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject.Find("go").transform.Find("gosariend").gameObject.SetActive(true);
                GameObject.Find("go").transform.Find("gosari").gameObject.SetActive(false);
                Get_ingredient(1);
            }
        }
    }

    //재료 추가 함수
    public void Get_ingredient(int num)
    {
        if(num == 1)
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
    public void Dialogue_d()
    {
        if (!is_second)
            Dialogue_d_0.SetActive(true);
        else
            Dialogue_d_0.SetActive(true);
    }



    //맵 이동
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name=="move1-2")
        {
            playerobj = GameObject.Find("Player");
            playerobj.transform.position = new Vector3(25, -7, -1);
            cameraobj = GameObject.Find("Main Camera");
            cameraobj.GetComponent<CameraController>().maxposition = (float)38.53;
            cameraobj.GetComponent<CameraController>().minxposition = (float)29.47;            
        }
        if(collision.gameObject.name=="move1-1")
        {
            playerobj = GameObject.Find("Player");
            playerobj.transform.position = new Vector3((float)18.4, -7, -1);
            cameraobj = GameObject.Find("Main Camera");
            cameraobj.GetComponent<CameraController>().maxposition = 14;
            cameraobj.GetComponent<CameraController>().minxposition = -14;
        }
        if(collision.gameObject.name=="move1-3")
        {
            playerobj = GameObject.Find("Player");
            playerobj.transform.position = new Vector3((float)48.55, -7, -1);
            cameraobj = GameObject.Find("Main Camera");
            cameraobj.GetComponent<CameraController>().maxposition = (float)62.01;
            cameraobj.GetComponent<CameraController>().minxposition = (float)53.98;
        }
        if (collision.gameObject.name == "move2")
        {
            playerobj = GameObject.Find("Player");
            playerobj.transform.position = new Vector3((float)42.51, -7, -1);
            cameraobj = GameObject.Find("Main Camera");
            cameraobj.GetComponent<CameraController>().maxposition = (float)38.53;
            cameraobj.GetComponent<CameraController>().minxposition = (float)29.47;
        }
        if(collision.gameObject.name==GameObject.Find("d").name)
        {
            GameObject.Find("Canvas").transform.Find("Dialogue_0").gameObject.SetActive(true);
        }
        if(collision.gameObject.name==GameObject.Find("d").name)
        {
            if (GameObject.Find("second").transform.Find("secondend").gameObject.activeSelf == true)
            { 
                GameObject.Find("Canvas").transform.Find("Dialogue_1").gameObject.SetActive(true);
            }
        }
    }

    //충돌판정(UI on/off)
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == GameObject.Find("go").transform.Find("gosari").name)
        {
            GameObject.Find("UI").transform.Find("text").gameObject.SetActive(true);
           
        }

        if(collision.gameObject.name==GameObject.Find("second").transform.Find("secondi").name)
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
        if (collision.gameObject.name == GameObject.Find("go").transform.Find("gosari").name)
        {
            GameObject.Find("UI").transform.Find("text").gameObject.SetActive(false);
        }

        if (collision.gameObject.name == GameObject.Find("second").transform.Find("secondi").name)
        {
            GameObject.Find("UI").transform.Find("text").gameObject.SetActive(false);
        }
        if (collision.gameObject.name == GameObject.Find("d").name)
        {
            GameObject.Find("Canvas").transform.Find("Dialogue_0").gameObject.SetActive(false);
        }
        if (collision.gameObject.name == GameObject.Find("d").name)
        {
            if (GameObject.Find("second").transform.Find("secondend").gameObject.activeSelf == true)
            {
                GameObject.Find("Canvas").transform.Find("Dialogue_1").gameObject.SetActive(false);
            }
        }
    }

    public void Clear()
	{
        SceneManager.LoadScene("Home1");
    }

    //Debug
    public void D_Clear()
    {
        SceneManager.LoadScene("Home1");
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
