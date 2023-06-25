using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.PlayerSettings;

public class PlayerMove : MonoBehaviour
{
    int speed;
    float xMove;
    bool isfront;

    public float minposition=-20;
    public float maxposition=(float)66.34;
    public double minyposition;
    private Vector3 pos;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5; 
        isfront = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
	{
        //up, down 포함시 float yMove 추가
        //float xMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        //float yMove = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        //this.transform.Translate(new Vector3(xMove, yMove, 0));

        Turn();

        xMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        this.transform.Translate(new Vector3(xMove, 0, 0));
        animator.SetFloat("Speed", Mathf.Abs(xMove));

        pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minposition, maxposition);
        pos.y = Mathf.Clamp(pos.y, (float)minyposition, (float)minyposition);
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
