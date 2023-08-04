using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float MoveSpeed = 50;
    public LayerMask Collidable;

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.UpArrow)  && !Physics2D.OverlapCircle(transform.position + new Vector3(0f, 1f, 0f), 0.4f, Collidable))
        {
            //transform.position += transform.right * MoveSpeed * Time.deltaTime;
            transform.position += new Vector3(0f, 1f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && !Physics2D.OverlapCircle(transform.position + new Vector3(1f, 0f, 0f), 0.4f, Collidable))
        {
            // transform.position += transform.right * MoveSpeed * Time.deltaTime;
            transform.position += new Vector3(1f, 0f, 0f);
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow) && !Physics2D.OverlapCircle(transform.position + new Vector3(0f, -1f, 0f), 0.4f, Collidable))
        {
            //transform.position += transform.up * -1 * MoveSpeed * Time.deltaTime;
            transform.position += new Vector3(0f, -1f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && !Physics2D.OverlapCircle(transform.position + new Vector3(-1f, 0f, 0f), 0.4f, Collidable))
        {
            // transform.position += transform.right * -1 *  MoveSpeed * Time.deltaTime;
            transform.position += new Vector3(-1f, 0f, 0f);
        }


    }
}
