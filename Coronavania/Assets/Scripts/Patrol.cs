using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{

    public float speed = 1;
    public float distance= 2f;
    public bool movingRight = true;
    //public Transform leftDetection;
    public Transform rightDetection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo;
        RaycastHit2D sideInfo;

        if (movingRight == true) {
            groundInfo = Physics2D.Raycast(rightDetection.position, Vector2.down, distance);
            sideInfo = Physics2D.Raycast(rightDetection.position, Vector2.right, 0.1f);
        } else {
            groundInfo = Physics2D.Raycast(rightDetection.position, Vector2.down, distance);
            sideInfo = Physics2D.Raycast(rightDetection.position, Vector2.left, 0.1f);
        }

        if (groundInfo.collider == false) {
            makeTurn();
        } else if(sideInfo.collider == true)  {
            Debug.Log(sideInfo.collider.GetComponent<PlayerMovement>());
            PlayerMovement player = sideInfo.collider.GetComponent<PlayerMovement>();
            if (player == null) {
                makeTurn();
                
            } else {
                player.TakeDamage(1000, 0);
            }//

        }
    }

    void makeTurn() {
        if(movingRight == true) {
            Debug.Log("TURN LEFT");
		    transform.Rotate(0f,180f,0f);
            movingRight = false;
        } else {
            Debug.Log("TURN right");
            transform.Rotate(0f,180f,0f);
            movingRight = true;
        }
    }
}
