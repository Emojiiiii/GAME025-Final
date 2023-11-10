using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D player;
    public float speed = 10.0f;
    private BoxCollider2D coll;
    public float jump = 10.0f;

    [SerializeField] private LayerMask jumpableGround;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        player.AddForce(Input.GetAxis("Horizontal") * speed * transform.right);
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            player.AddForce(transform.up * jump, ForceMode2D.Impulse);
        }

    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
