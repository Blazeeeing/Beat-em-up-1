using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class Movement : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;

    [SerializeField]
    private Transform upLimit, downLimit, leftLimit, rightLimit;

    private Animator ani;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    public void walk(float x, float y)
    {
        if (Data.currnetState == State.Idle || Data.currnetState == State.Moving)
        {
            if (y > 0 && transform.position.y >= upLimit.position.y)
            {
                y = 0;
            }

            if (y < 0 && transform.position.y <= downLimit.position.y)
            {
                y = 0;
            }

            if (x > 0 && transform.position.x >= rightLimit.position.x)
            {
                x = 0;
            }

            if (x < 0 && transform.position.x <= leftLimit.position.x)
            {
                x = 0;
            }

            if (x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            if (x > 0)
            {
                transform.localScale = Vector3.one;
            }

            rb.velocity = (new Vector3(x, y, 0).normalized) * speed;

            if (rb.velocity.magnitude > 0)
            {
                GetComponent<Animator>().SetBool("Walking", true);
                Data.currnetState = State.Moving;
            }
            else
            {
                GetComponent<Animator>().SetBool("Walking", false);
                Data.currnetState = State.Idle;
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}
