using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAStarFPS : MonoBehaviour
{
    public GameObject target;
    public NavMeshAgent agent;
    public Animator anim;
  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
            agent.destination = target.transform.position;
            anim.SetFloat("Velocidade", agent.velocity.magnitude);

       
    }

    public void PauseIA(float seconds)
    {
        agent.isStopped = true; 
        Invoke("UnpauseIA", seconds);
    }
    void UnpauseIA()
    {
        agent.isStopped = false; 
    }
}
