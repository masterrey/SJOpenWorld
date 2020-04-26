﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrdControl : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rdb;
    Vector3 move, rot;
    Animator anim;
    public float forcemove=1000;
    GameObject dummyCam;
    public AudioSource scream;
    public enum States
    {
        Walk,
        Attack,
        Idle,
        Dead,
        Damage,
    }

    public States state;

    void Start()
    {
        rdb= GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        /*

        Joint[] joints;
        joints = GetComponentsInChildren<Joint>();
        foreach (Joint myjoint in joints)
        {
            Destroy(myjoint);
        }

        Rigidbody[] rdbs;
        rdbs = GetComponentsInChildren<Rigidbody>();
        for(int i=1;i<rdbs.Length;i++)
        {
            Destroy(rdbs[i]);
        }
        */
        rdb.isKinematic=false;
        
        StartCoroutine(Idle());
    }

    public void SetDummyCam(GameObject dummy)
    {
        dummyCam = dummy;
    }

    // Update is called once per frame
    void Update()
    {
        //criacao de vetor de movimento local
        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        if (dummyCam)
            move = dummyCam.transform.TransformDirection(move);

        if (move.magnitude > 0)
        {
            transform.forward = Vector3.Slerp(transform.forward,move,Time.deltaTime*10);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            ChangeState(States.Attack);
        }
    }


    private void FixedUpdate()
    {

        float vel = rdb.velocity.magnitude;

        rdb.AddForce((move * forcemove)/ (vel*2+1));
        anim.SetFloat("Velocity", vel);
    }

    public void ChangeState(States myestate)
    {
        state = myestate;
        StartCoroutine(state.ToString());
    }

    IEnumerator Idle()
    {
        //entrada
        while (state == States.Idle)
        {
            //loop
            yield return new WaitForFixedUpdate();

            if (rdb.velocity.magnitude > 0.1f)
            {
                ChangeState(States.Walk);
            }
        }
        //saida
    }

    IEnumerator Walk()
    {
        //entrada
        
        while (state == States.Walk)
        {
            //loop
            yield return new WaitForFixedUpdate();
            if (rdb.velocity.magnitude < 0.1f)
            {
                ChangeState(States.Idle);
            }
        }
        //saida
    }

    IEnumerator Attack()
    {
        //entrada
        anim.SetTrigger("Atack");
        scream.Play();
        yield return new WaitForSeconds(2);
        
        ChangeState(States.Idle);
        //saida
    }

    IEnumerator Damage()
    {
        //entrada
        while (state == States.Damage)
        {
            //loop
            yield return new WaitForFixedUpdate();
        }
        //saida
    }

    IEnumerator Dead()
    {
        //entrada
        while (state == States.Dead)
        {
            //loop
            yield return new WaitForFixedUpdate();
        }
        //saida
    }
}
