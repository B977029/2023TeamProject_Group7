using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIalogueTrigger : MonoBehaviour
{
	public Dialogue info;
	public int Type;
	GameObject stage2_obj;
	GameObject stage1_obj;

    private void Start()
    {
        stage1_obj = GameObject.Find("MainSystem_Stage1");
        stage2_obj = GameObject.Find("MainSystem_Stage2");
    }
    public void Trigger()
	{
		var system = FindAnyObjectByType<DialogueSystem>();
		system.Begin(info, Type);
	}
	public void stage1click()
	{
		GameObject.Find("CraftHint").transform.Find("two").gameObject.SetActive(true);
		GameObject.Find("npc").transform.Find("npc1").gameObject.SetActive(false);
		GameObject.Find("npc").transform.Find("npc1end").gameObject.SetActive(true);
		stage1_obj.GetComponent<Stage1>().is_two = true;
	}
	public void stage1bossclick()
	{
        GameObject.Find("CraftHint").transform.Find("three").gameObject.SetActive(true);
		stage1_obj.GetComponent<Stage1>().is_three = true;
    }
    public void stage2clicked()
    {	
        GameObject.Find("CraftHint").transform.Find("two").gameObject.SetActive(true);
		stage2_obj.GetComponent<Stage2>().is_two = true;
    }

	public void stage2bossclick()
	{
		GameObject.Find("CraftHint").transform.Find("three").gameObject.SetActive(true);
		stage2_obj.GetComponent<Stage2>().is_three = true;
	}
}
