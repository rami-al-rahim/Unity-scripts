using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public float speed;
    public float Jamp;
    private void FixedUpdate()
    {
       
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(speed * Time.fixedDeltaTime, transform.position.y);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.position += new Vector3(-1 * speed * Time.fixedDeltaTime, transform.position.y);
            }
            else if (Input.GetKey(KeyCode.W) && Mathf.Abs(rb.velocity.y) < 0.0001)
            {
                transform.position += new Vector3(speed * Time.fixedDeltaTime, transform.position.y);
            }
    }
}
