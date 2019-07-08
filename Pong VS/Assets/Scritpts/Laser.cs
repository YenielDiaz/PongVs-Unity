using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    //config parameters
    [SerializeField] float laserSpeed = 0.4f;
    [SerializeField] Player[] players;
    [SerializeField] Player owner;

    //unused for now
    [SerializeField] float maxDistance = 0;

    //cached references
    Rigidbody2D rigidBody;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        players = FindObjectsOfType<Player>();

        SetDirection();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    //un-used
    private void DestroyAfterMaxDistance()
    {
        if(transform.position.x == 0)
        {
            Destroy(gameObject);
        }
    }

    //utility method to find closest player to Object
    private Player FindClosestPlayer()
    {
        Player closestPlayer = players[0];
        float closestX = transform.position.x - closestPlayer.transform.position.x;
        for (int i = 1; i < players.Length; i++)
        {
            float newX = transform.position.x - players[i].transform.position.x;
            if (Mathf.Abs(newX) < Mathf.Abs(closestX))
            {
                closestX = newX;
                closestPlayer = players[i];

            }
        }

        return closestPlayer;
    }

    //utility methd to make laser move towards oppoing player
    private void SetDirection()
    {
        owner = FindClosestPlayer();
        if(owner.tag.Equals("Player1"))
        {
            rigidBody.velocity = new Vector2(laserSpeed,0);
        }
        else
        {
            rigidBody.velocity = new Vector2(-laserSpeed, 0);
        }
    }

    //un-used
    public Rigidbody2D GetRigidBody()
    {
        return rigidBody;
    }

    //un-used
    public float GetLaserSpeed()
    {
        return laserSpeed;
    }
}
