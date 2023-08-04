using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isMoving;
    private Vector2 origPos, targetPos;
    private float timeToMove = 0.1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && !isMoving)
            StartCoroutine(MovePlayer(Vector2.up));

        if (Input.GetKeyDown(KeyCode.RightArrow) && !isMoving)
            StartCoroutine(MovePlayer(Vector2.right));

        if (Input.GetKeyDown(KeyCode.DownArrow) && !isMoving)
            StartCoroutine(MovePlayer(Vector2.down));

        if (Input.GetKeyDown(KeyCode.LeftArrow) && !isMoving)
            StartCoroutine(MovePlayer(Vector2.left));
    }
    private IEnumerator MovePlayer(Vector2 direction)
    {
        isMoving = true;
        float elapsedTime = 0;

        origPos = transform.position;
        targetPos = origPos + direction;
        

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector2.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
    }
}
