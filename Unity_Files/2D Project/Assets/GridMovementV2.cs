using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovementV2 : MonoBehaviour
{
    //How "Snappy" the head moves
    public float moveSpeed = 7f;
    
    //The point that the head moves to
    public Transform movePoint;
    
    //A Layer for static objects like walls and such.
    public LayerMask Collidable;
   
    //A collision layer for the body so the snake supports its self
    public LayerMask CollidableBody;
    
    //A collison layer so the snake can stand on fruit without eating it
    public LayerMask FruitCollider;
   
    //The Body that gets duplicated whenever food is eatem
    public Transform bodyPartTransforms;
    //The point that is used to decide where the body goes
    public Transform bodyPartPoint;


    //Lists that constain bodyPartTransforms's and bodyPartPoint's
    private List<Transform> snakeSegments;
    private List<Transform> snakeSegmentPoints;
    private List<Transform> snakeUndoStorage;
    private Transform movePointStorage;


    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        snakeSegments = new List<Transform>();
        snakeSegmentPoints = new List<Transform>();
       
        snakeUndoStorage = new List<Transform>();


        snakeSegmentPoints.Add(this.transform);

        snakeSegments.Add(this.transform);
        Grow();
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(snakeSegments[0].position, movePoint.position, moveSpeed * Time.deltaTime);

        //A boolean to check if there is currently a floor/collidable object below any of the body
        bool hasFloor = false;
        
        if (Vector3.Distance(transform.position, movePoint.position) == 0f)
        {

          //Gravity
            for (int i = snakeSegments.Count-1; i > 0; i--)
            {


                if (Physics2D.OverlapCircle(snakeSegments[i].GetChild(0).position, 0.4f, Collidable) || Physics2D.OverlapCircle(snakeSegments[i].position + new Vector3(0f, -1f, 0f), 0.4f, Collidable) || Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -1f, 0f), 0.4f, Collidable) || Physics2D.OverlapCircle(snakeSegments[i].position + new Vector3(0f, -1f, 0f), 0.4f, FruitCollider) || Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -1f, 0f), 0.4f, FruitCollider))
                {
                    hasFloor = true;
                }
               

            }
           
           
           if (!hasFloor)
            {
                movePoint.position += new Vector3(0f, -1f, 0f);

                for (int s = snakeSegments.Count - 1; s > 0; s--)
                {
                    snakeSegmentPoints[s].position += new Vector3(0f, -1f, 0f);
                }

            }

            //Normal Movement
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.1f, Collidable) && !Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.1f, CollidableBody))
                {
                    for (int i = snakeSegmentPoints.Count - 1; i > 0; i--)
                    {
                        snakeUndoStorage[i].position = snakeSegmentPoints[i].position;
                        movePointStorage.position = movePoint.transform.position;
                    }

                    for (int i = snakeSegmentPoints.Count - 1; i > 0; i--)
                    {
                        snakeSegmentPoints[i].position = snakeSegmentPoints[i - 1].position;

                    }

                    //Moves the head in the direction which the player presses
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                    
                }
            }

            if (Input.GetKeyDown(KeyCode.Semicolon))
            {
                for (int i = 0; i < snakeSegmentPoints.Count; i++)
                {
                    snakeSegmentPoints[i].position = snakeUndoStorage[i].position;
                    movePoint.position = movePointStorage.position;

                }
 
            }


            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), 0.1f, Collidable) && !Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), 0.1f, CollidableBody))
                {
                    
                    for (int i = snakeSegmentPoints.Count - 1; i > 0; i--)
                    {
                        snakeSegmentPoints[i].position = snakeSegmentPoints[i - 1].position;

                    }
                    
                    //Moving the head where you enter
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }

            }

        }

       
        //How the body moves
        for (int i = snakeSegments.Count - 1; i > 0; i--)
        {
            snakeSegments[i].position = snakeSegmentPoints[i - 1].position;

        }

    }

   //Method that checks if you collide with a fruit and then calls the grow method... ONCE!!!!! I FIXED IT I FIXED THE BUG OH MY GOSH I AM A GENIUS
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Fruit")
        {
           
            Destroy(other.gameObject); 
            Grow();
        }
    }
    
    //Grows half of a new body part dont ask me why
    private void Grow()
    {
        new WaitForSeconds(1f);
        Transform segment = Instantiate(this.bodyPartTransforms);
        Transform segmentPoint = Instantiate(this.bodyPartPoint);

        snakeSegments.Add(segment);
        snakeSegmentPoints.Add(segmentPoint);
        if (segment.transform.position == bodyPartPoint.transform.position) ;

    }
}
