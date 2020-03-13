using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject spherePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject myprojectile=
            Instantiate(spherePrefab, transform.position+transform.forward,
            Quaternion.identity);

            myprojectile.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);

        }
    }
}
