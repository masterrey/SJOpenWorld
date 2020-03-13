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
        //movimento de cabeca
        float movx = Input.GetAxis("Mouse Y");
        transform.Rotate(new Vector3(-movx, 0, 0));
        //se aperta tiro instancia o prefab
        if (Input.GetButtonDown("Fire1"))
        {
            //instancia o objeto e guarda a referencia
            GameObject myprojectile=
            Instantiate(spherePrefab, transform.position+transform.forward,
            Quaternion.identity);
            //adiciona uma forca no objeto
            myprojectile.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);

        }
    }
}
