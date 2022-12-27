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
        float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
    private void Update()
    {
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
    }
}
