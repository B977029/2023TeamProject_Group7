using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueSystem : MonoBehaviour
{
	public Text Name;
	public Text Sentence;

	Queue<string> names = new Queue<string>();
	Queue<string> sentences = new Queue<string>();

	public Animator anim;

	private int type;

	Home0 script0;
	Home1 script1;
	Home2 script2;
	Stage3 script3;

	//이름이 바뀌도 않아도 되는 경우 이 함수 사용
	/*public void Begin(Dialogue info)
	{
		anim.SetBool("IsOpen", true);

		sentences.Clear();

		Name.text = info.name;

		foreach(var sentence in info.sentences)
		{
			sentences.Enqueue(sentence);
		}

		Next();
	}*/

	public void Begin(Dialogue info, int Type)
	{
		type = Type;

		anim.SetBool("IsOpen", true);

		names.Clear();
		sentences.Clear();


		foreach (var name in info.names)
		{
			names.Enqueue(name);
		}

		foreach (var sentence in info.sentences)
		{
			sentences.Enqueue(sentence);
		}

		Next();
	}

	public void Next()
	{
		if(sentences.Count == 0)
		{
			End();
			EndEvent();
			return;
		}

		//기본
		//Sentence.text = sentences.Dequeue();

		Name.text = names.Dequeue();

		//글자 하나씩 나오게
		Sentence.text = string.Empty;
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentences.Dequeue()));
	}

	//글자 하나씩 나오게 하는거
	IEnumerator TypeSentence(string sentence)
	{
		foreach(var letter in sentence)
		{
			Sentence.text += letter;
			yield return new WaitForSeconds(0.1f);
		}

	}

	private void End()
	{
		anim.SetBool("IsOpen", false); ;
		Name.text = string.Empty;
		Sentence.text = string.Empty;
	}

	private void EndEvent()
	{
		switch (type)
		{
			case 0:
				break;
			case 1:
				SceneManager.LoadScene("Stage1");
				break;
			case 2:
				SceneManager.LoadScene("Stage2");
				break;
			case 3:
				SceneManager.LoadScene("Stage3");
				break;
			case 4:
				SceneManager.LoadScene("Home0");
				break;
			case 5:
				script0 = GameObject.Find("MainSystem_Home0").GetComponent<Home0>();
				script0.Done();
				break;
			case 6:
				script1 = GameObject.Find("MainSystem_Home1").GetComponent<Home1>();
				script1.Done();
				break;
			case 7:
				script2 = GameObject.Find("MainSystem_Home2").GetComponent<Home2>();
				script2.Done();
				break;
			case 8:
				script3 = GameObject.Find("MainSystem_Stage3").GetComponent<Stage3>();
				script3.clear = true;
				break;
		}


	}
}
