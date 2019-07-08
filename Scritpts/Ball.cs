using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour

{
    //cached reference
    Rigidbody2D rigidBody;
    GameStatus gameStatus;

    //config parameters
    [SerializeField] float ballSpeed = 0.2f;
    [SerializeField] float randomFactor = 0.2f;
    [SerializeField] Player player1;
    [SerializeField] Player player2;
    private Vector2 player1ToBallVector;
    private Vector2 player2ToBallVector;
    private Vector3 offSet = new Vector3(8.2f, 0f, 0f);

    //State parameters
    //parameter to ID the last player that touched the ball
    [SerializeField] Player lastPlayerTouched;
    [SerializeField] Player servingPlayer;
    private bool Scored = false;
    //determines whether game has started
    private bool hasStarted = false;
    


    // Start is called before the first frame update
    void Start()
    {

        rigidBody = GetComponent<Rigidbody2D>();
        gameStatus = FindObjectOfType<GameStatus>();

        //start ball with random player
        Player[] choices = { player1, player2 };
        int randomPlayer = Random.Range(0, choices.Length);
        servingPlayer = choices[randomPlayer];
        
        //distances between player and ball
        player1ToBallVector = player1.transform.position + offSet;
        player2ToBallVector = player2.transform.position - offSet;

    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void FixedUpdate()
    {
        StickBallToPlayer(servingPlayer);
        LaunchBallOnPush(servingPlayer);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //prevent ball going straight all the time
        Vector2 randomVector = new Vector2(Random.Range(0, randomFactor), Random.Range(0, randomFactor));
        rigidBody.velocity += randomVector;

        if (collision.gameObject.tag.Equals("Player1")){
            lastPlayerTouched = player1;
        }
        else if (collision.gameObject.tag.Equals("Player2"))
        {
            lastPlayerTouched = player2;
        }

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
           if (collision.gameObject.name.Equals("LeftDetector"))
        {
            servingPlayer = player1;
            gameStatus.AddToScore(false); //raise player2 score

        }
        else if (collision.gameObject.name.Equals("RightDetector"))
        {
            servingPlayer = player2;
            gameStatus.AddToScore(true); //raise player1 score

        }
        //reset ball configuration
        transform.position = new Vector2(0, 0);
        rigidBody.velocity = new Vector2(0f, 0f);

        Scored = true;
    }


    private void StickBallToPlayer(Player player)
    {
        if(Scored || !hasStarted)
        {
            
            //where player is
            Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
            if (player.tag.Equals("Player1"))
            {
                //where ball will be
                transform.position = playerPos + player1ToBallVector;
            }
            else if (player.tag.Equals("Player2"))
            {
                //where ball will be
                transform.position = playerPos + player2ToBallVector;
            }
            
        }
    }

    private void LaunchBallOnPush(Player player)
    {
        if(!hasStarted || Scored)
        {
            if (player.tag.Equals("Player1"))
            {
                if (Input.GetKey(KeyCode.D))
                {
                    //accessing velociy of rigidbody2d component and giving it a new vector
                    rigidBody.velocity = new Vector2(ballSpeed, 0f) * 1;
                    hasStarted = true;
                    Scored = false;
                }

            }
            else if (player.tag.Equals("Player2"))
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    //accessing velociy of rigidbody2d component and giving it a new vector
                    rigidBody.velocity = new Vector2(ballSpeed, 0f) * -1;
                    hasStarted = true;
                    Scored = false;

                }
            }
            
            
        }
    
    }

    public Player GetLastPlayerTouched()
    {
        return lastPlayerTouched;
    }

    public bool GetHasStarted()
    {
        return hasStarted;
    }

}
