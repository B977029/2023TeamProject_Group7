using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
	public Text Name;
	public Text Sentence;

	Queue<string> sentences = new Queue<string>();

	public Animator anim;

	public void Begin(Dialogue info)
	{
		anim.SetBool("IsOpen", true);

		Invoke("Test", 5f);

		sentences.Clear();

		Name.text = info.name;

		foreach(var sentence in info.sentences)
		{
			sentences.Enqueue(sentence);
		}

		Next();
	}

	public void Test()
	{

	}

	public void Next()
	{
		if(sentences.Count == 0)
		{
			End();
			return;
		}

		//기본
		//Sentence.text = sentences.Dequeue();

		//글자 하나씩 나오게
		Sentence.text = string.Empty;
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentences.Dequeue()));
	}

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
		Sentence.text = string.Empty;
	}
}
