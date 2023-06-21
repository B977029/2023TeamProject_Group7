using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 pos;
    float minxPosition=0;
    float maxxPosition=66;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    [SerializeField]
    float cameraMoveSpeed;
    
    Vector3 cameraPosition = new Vector3(0, 0, -10);
    void FixedUpdate()
    {
        LimitCamera();
    }
    void LimitCamera()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + cameraPosition, Time.deltaTime * cameraMoveSpeed);//플레이어 따라 이동


        pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minxPosition, maxxPosition);
        pos.y = Mathf.Clamp(pos.y, minxPosition, minxPosition);
        transform.position = pos;
    }
}
