using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    private float time;

    [SerializeField]
    private float delay, speed;

    [SerializeField]
    private Transform leftLimit, rightLimit;

    [SerializeField]
    private Rigidbody2D rb;

    private bool right = false, left = false;

    // Start is called before the first frame update
    void Start()
    {
        time = delay;
        rb.useFullKinematicContacts = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(right || left)
        {
            time -= Time.deltaTime;
        }
        else
        {
            time = delay;
        }
    }

    private void FixedUpdate()
    {
        Vector3 vl = Vector3.left, vr = Vector3.right;

        if (transform.position.x >= rightLimit.position.x - (Camera.main.orthographicSize * Camera.main.aspect) + 0.5f) 
        {
            vr = Vector3.zero;
        }

        if (transform.position.x <= leftLimit.position.x + (Camera.main.orthographicSize * Camera.main.aspect) - 0.5f) 
        {
            vl = Vector3.zero;
        }

        if (right)
        {
            if (time <= 0)
            {
                rb.velocity = vr * speed;
                time = 0;
            }
        }
        else if (left)
        {
            if (time <= 0)
            {
                rb.velocity = vl * speed;
                time = 0;
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.otherCollider.gameObject.name == "CamRight")
        {
            right = true;
            left = false;
        }
        if (collision.gameObject.tag == "Player" && collision.otherCollider.gameObject.name == "CamLeft")
        {
            right = false;
            left = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        right = false;
        left = false;
    }
}
