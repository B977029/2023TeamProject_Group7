using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PlayerMove : MonoBehaviour
{
    int speed;
    float xMove;
    bool isfront;
    float minposition=-20;
    float maxposition=20;
    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10; 
        isfront = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
	{
        //up, down ���Խ� float yMove �߰�
        //float xMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        //float yMove = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        //this.transform.Translate(new Vector3(xMove, yMove, 0));

        Turn();

        xMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        this.transform.Translate(new Vector3(xMove, 0, 0));
        transform.rotation = Quaternion.Euler(0, 0, 0);
        pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minposition, maxposition);   
        transform.position = pos;
    }

    void Turn()
	{
        if(Isfront())
            this.transform.localScale = new Vector3(1, 1, 1);
        else
            this.transform.localScale = new Vector3(-1, 1, 1);
    }

    bool Isfront()
	{
        if (xMove > 0)
            isfront = true;

        if (xMove < 0)
            isfront = false;

        return isfront;
	}

}
