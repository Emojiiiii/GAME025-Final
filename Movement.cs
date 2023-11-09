using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D player;
    public float speed = 10.0f;
    public bool flipX;
    private SpriteRenderer playerFlip;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        playerFlip = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    { 
            // adds force to move player sprite
            player.AddForce(Input.GetAxis("Horizontal") * speed * transform.right);
    }
}
