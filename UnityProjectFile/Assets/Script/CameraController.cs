using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 pos;
    public float minxposition;
    float minyposition = 0;
    public float maxposition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LimitCamera();
    }

    void LimitCamera()
    {
        transform.position = player.transform.position + new Vector3(4, 0, -10);
        pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minxposition, maxposition);
        pos.y = Mathf.Clamp(pos.y, minyposition, minyposition);
        transform.position = pos;
    }
}
