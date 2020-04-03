using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IADamage : MonoBehaviour
{
    public int lives = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lives < 0)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerProjectile"))
        {
            lives--;
        }
    }
}
