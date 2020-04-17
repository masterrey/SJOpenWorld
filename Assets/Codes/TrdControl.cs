using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrdControl : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rdb;
    Vector3 move, rot;
    Animator anim;
    public float forcemove=1000;
    void Start()
    {
        rdb= GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //criacao de vetor de movimento local
        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (move.magnitude > 0)
        {
            transform.forward = Vector3.Slerp(transform.forward,move,Time.deltaTime*10);
        }
    }

    private void FixedUpdate()
    {
        rdb.AddForce(move * forcemove);
        anim.SetFloat("Velocity", rdb.velocity.magnitude);
    }

}
