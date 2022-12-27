using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    private Vector2 move;
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
    }
    private void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
    }
}
