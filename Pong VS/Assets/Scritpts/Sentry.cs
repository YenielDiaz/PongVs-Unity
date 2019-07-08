using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentry : MonoBehaviour
{

    [SerializeField] Player owner;
    [SerializeField] Ball ball;
    [SerializeField] Player[] players;
    [SerializeField] int coolDown;

    
    private Vector2 zeroVector = new Vector2(0, 0);
    private Vector2 tempLocation = new Vector2(300f,300f);

    //cached references
    private SpriteRenderer sprite;
    private BoxCollider2D sentryCollider;

    // Start is called before the first frame update
    void Start()
    {
        players = FindObjectsOfType<Player>();
        ball = FindObjectOfType<Ball>();
        sentryCollider = GetComponent<BoxCollider2D>();
        sprite = GetComponent <SpriteRenderer>();
        owner = FindClosestPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        evadeOwner();
    }

    private void evadeOwner()
    {
        if (ball.GetLastPlayerTouched().Equals(owner))
        {
            sentryCollider.offset = tempLocation;
            sprite.color = Color.blue;
        }
        else
        {
            sentryCollider.offset = zeroVector;
            sprite.color = Color.white;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("ball")){
            Destroy(gameObject);
        }
    }

    //unused
    public void SetOwner(Player player)
    {
        owner = player;
    }

    //utility method to find closest player to Object
    private Player FindClosestPlayer()
    {
        Player closestPlayer = players[0];
        float closestX = transform.position.x - closestPlayer.transform.position.x;
        for(int i=1; i<players.Length; i++)
        {
            float newX = transform.position.x - players[i].transform.position.x;
            if( Mathf.Abs(newX) < Mathf.Abs(closestX))
            {
                closestX = newX;
                closestPlayer = players[i];
                
            }
        }

        return closestPlayer;
    }

}
