using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oldPlayerMovemnt : MonoBehaviour
{
    // Start is called before the first frame update

    public float MoveSpeed = 50;

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position += transform.up * MoveSpeed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += transform.right * MoveSpeed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += transform.up * -1 * MoveSpeed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
           transform.position += transform.right * -1 *  MoveSpeed * Time.deltaTime;
        }


    }
}
