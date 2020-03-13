using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Explode", 3);
    }

    void Explode()
    {
        print("Boom!");
        Destroy(gameObject);
        RaycastHit[] hits;
        hits=Physics.SphereCastAll(transform.position, 5, Vector3.up, 10);

        if (hits.Length > 0)
        {
            foreach(RaycastHit hit in hits)
            {
                hit.rigidbody.AddExplosionForce(1000, transform.position, 10);
            }
        }
    }
}
