using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float fallSpeed;
    [SerializeField] private Transform groundCheck;
    private float groundCheckRadius = 0.5f;
    private bool isFacingRight;

    // Start is called before the first frame update
    void Start()
    {
        isFacingRight = true;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");

        if (CheckGround() == true)
        {
            Move(h);
        }
        else
        {
            rb2d.AddForce(fallSpeed * Vector2.down);
        }
        Flip(h);
    }
    private void Flip(float h)
    {
        if (h > 0 && !isFacingRight || h < 0 && isFacingRight)
        {
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector2(-1 * transform.localScale.x, transform.localScale.y);
            
        }
    }
    private void Move(float h)
    {
        rb2d.velocity = new Vector2(h * movementSpeed, 0);
    }

    private bool CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.layer == 9)
            {
                return true;
            }
        }
        return false;
    }

}
