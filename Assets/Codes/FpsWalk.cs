using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsWalk : MonoBehaviour
{
    public CharacterController chtr;
    Vector3 move,rot;
    void Start()
    {
        if(!chtr)
        chtr = GetComponent<CharacterController>();
    }

   
    void Update()
    {
        //float ang = transform.rotation.eulerAngles.y;
       
        
        if (Input.GetKey(KeyCode.W))
        {
            //move = new Vector3(Mathf.Sin( ang*Mathf.Deg2Rad),
            //0, Mathf.Cos(ang * Mathf.Deg2Rad));
            move=transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //move = new Vector3(0, 0, -1);
            move = -transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            move = transform.right;

        }
        if (Input.GetKey(KeyCode.A))
        {
            move = -transform.right;

        }

        rot.y = Input.GetAxis("Mouse X");


        chtr.SimpleMove(move);
        transform.Rotate(rot);
        move = Vector3.zero;
        rot = Vector3.zero;
    }
}
