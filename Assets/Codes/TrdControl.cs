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
    GameObject dummyCam;

   
    void Start()
    {
        rdb= GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();


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
        rdb.isKinematic=false;
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
    }

    private void FixedUpdate()
    {

        float vel = rdb.velocity.magnitude;

        rdb.AddForce((move * forcemove)/ (vel*2+1));
        anim.SetFloat("Velocity", vel);
    }

}
