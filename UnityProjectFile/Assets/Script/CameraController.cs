using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 pos;
    float minxposition=-13;
    float minyposition = 0;
    float maxposition=13;
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
        transform.position = player.transform.position + new Vector3(5, 0, -10);
        pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minxposition, maxposition);
        pos.y = Mathf.Clamp(pos.y, minyposition, minyposition);
        transform.position = pos;
    }
}
