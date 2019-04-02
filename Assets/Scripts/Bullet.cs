using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Vector2 initPosition;
    private Transform player;
    [SerializeField] private float bulletSpeed;
    private bool hasBeenDisabled = false;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player1").transform;
        initPosition = transform.position;
        rb2D = GetComponent<Rigidbody2D>();
        print(player);
    }

    // Update is called once per frame
    void Update()
    {
        if (rb2D.velocity.x == 0)
        {
            float moveDir = Mathf.Sign(player.localScale.x);
            rb2D.velocity = new Vector2(moveDir * bulletSpeed, 0f);
        }
    }

    private void OnDisable()
    {
        hasBeenDisabled = true;
    }

    private void OnEnable()
    {       
        if (hasBeenDisabled == true)
            Invoke("Despawn", 2f);
    }


    private void Despawn()
    {
        transform.position = initPosition;
        gameObject.SetActive(false);
    }

}
