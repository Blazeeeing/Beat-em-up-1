using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerControler : MonoBehaviour
{  
    [SerializeField]
    private Movement moveScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /*// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ani.SetTrigger("Attack");
        }
    }*/

    private void FixedUpdate()
    {
        float y = Input.GetAxisRaw("Vertical");
        float x = Input.GetAxisRaw("Horizontal");

        moveScript.walk(x, y);
                 
    }
}
