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
        Cursor.lockState = CursorLockMode.Locked;
    }

   
    void Update()
    {
        //criacao de vetor de movimento local
        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //captura de rotacao do corpo
        rot.y = Input.GetAxis("Mouse X");
        //conversao de direcao local pra global 
        Vector3 globalmove = transform.TransformDirection(move);
        chtr.SimpleMove(globalmove * 5);
        transform.Rotate(rot);
       
    }
}
