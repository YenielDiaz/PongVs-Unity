using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //configuration parameters
    [SerializeField] float minY = -6f;
    [SerializeField] float maxY = 3.7f;
    [SerializeField] float speed = 0.2f;
    [SerializeField] string PlayerID;

    private Ball ball;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    protected void HandleMovement()
    {
        Vector2 playerPos = new Vector2(transform.position.x, transform.position.y);
        //player 1 controls
        if (tag.Equals("Player1"))
        {
            if (Input.GetKey(KeyCode.W))
            {
                playerPos.y = Mathf.Clamp(playerPos.y + speed, minY, maxY);
                //playerPos.y += speed;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                playerPos.y = Mathf.Clamp(playerPos.y - speed, minY, maxY);
                //playerPos.y -= speed;
            }

        }

        //player 2 controls
        else if (!tag.Equals("Player1"))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                playerPos.y = Mathf.Clamp(playerPos.y + speed, minY, maxY);
                //playerPos.y += speed;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                playerPos.y = Mathf.Clamp(playerPos.y - speed, minY, maxY);
                // playerPos.y -= speed;
            }

        }

        transform.position = playerPos;
    }

    public void SetCharacter(Player player)
    {
        
    }

}
