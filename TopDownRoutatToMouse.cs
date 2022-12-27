using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    private Vector2 move;
    [Header("mouse")]
    private Vector2 mouse;
    
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
        rb.velocity = move * speed;

        Vector2 look = mouse - rb.position;
        Vector2 angle = new Vector2(mouse.x - transform.position.x, mouse.y - transform.position.y);
        //if have problems with routat replac transform.up to transform.right
        transform.up = angle;
    }
    private void Update()
    {
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
    }
}
