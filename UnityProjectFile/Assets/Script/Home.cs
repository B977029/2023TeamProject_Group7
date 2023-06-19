using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    public Dialogue info;

    // Start is called before the first frame update
    void Start()
    {
        var system = FindAnyObjectByType<DialogueSystem>();
        system.Begin(info);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
