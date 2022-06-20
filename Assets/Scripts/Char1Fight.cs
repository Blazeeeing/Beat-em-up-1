using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char1Fight : MonoBehaviour
{
    private bool blocking, parrying, attacking;

    private Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        blocking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            if (Data.currnetState == State.Idle || Data.currnetState == State.Blocking || Data.currnetState == State.Moving)
            {
                ani.SetBool("Walking", false);
                Data.currnetState = State.Blocking;
                ani.SetBool("Blocking", true);
            }            
        }
        else
        {            
            ani.SetBool("Blocking", false);
            if(Data.currnetState == State.Blocking)
            {
                blockEnd();
            }
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            if (Data.currnetState == State.Idle || Data.currnetState == State.Moving)
            {
                ani.SetBool("Walking", false);
                Data.currnetState = State.Attacking;
                ani.SetTrigger("Jab");
            }
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            if (Data.currnetState == State.Idle || Data.currnetState == State.Moving)
            {
                ani.SetBool("Walking", false);
                Data.currnetState = State.Attacking;
                ani.SetTrigger("Uppercut");
            }
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            if (Data.currnetState == State.Idle || Data.currnetState == State.Moving)
            {
                ani.SetBool("Walking", false);
                Data.currnetState = State.Attacking;
                ani.SetTrigger("Kick");
            }
        }
    }

    private void stopAttack()
    {
        Data.currnetState = State.Idle;
    }

    private void block()
    {
        blocking = true;        
    }

    private void unBlock()
    {       
        blocking = false;
    }

    private void blockEnd()
    {
        Data.currnetState = State.Idle;
    }

    private void Jab()
    {

    }

    private void UpperCut()
    {

    }

    private void Kick()
    {

    }

    private void LowSweep()
    {

    }

}
