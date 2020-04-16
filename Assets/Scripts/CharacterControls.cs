using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControls : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpVelocity = 3f;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        jump();  
    }

    void jump()
    {
        if (Input.GetButton("Fire1"))
        {
            rb.velocity = new Vector2(0f, jumpVelocity);
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        print(c);
    }
}
