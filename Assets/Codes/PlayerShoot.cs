using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject[] projectilesPrefab;
    int indexWeapon;
    void Update()
    {
        //movimento de cabeca
        float movx = Input.GetAxis("Mouse Y");
        transform.Rotate(new Vector3(-movx, 0, 0));

        if (Input.GetKey(KeyCode.Alpha1))indexWeapon = 0;

        if (Input.GetKey(KeyCode.Alpha2)) indexWeapon = 1;

        //se aperta tiro instancia o prefab
        if (Input.GetButtonDown("Fire1"))
        {
            //instancia o objeto e guarda a referencia
            GameObject myprojectile=
            Instantiate(projectilesPrefab[indexWeapon], transform.position+transform.forward,
            Quaternion.identity);
            //adiciona uma forca no objeto
            myprojectile.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);

        }
    }
}
