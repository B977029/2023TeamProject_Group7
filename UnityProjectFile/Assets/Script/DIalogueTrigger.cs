using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIalogueTrigger : MonoBehaviour
{
    public Dialogue info;

	public void Trigger()
	{
		var system = FindAnyObjectByType<DialogueSystem>();
		system.Begin(info);
	}
}
