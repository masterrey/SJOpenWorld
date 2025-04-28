using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMagic : MonoBehaviour
{

    public float bombForce=1000;
    public GameObject fxPrefab;
    public TerrainDeformer terrainDeformer;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Explode", 3);
        GameObject terrain = GameObject.Find("Terrain");
        terrainDeformer = terrain.GetComponent<TerrainDeformer>();
    }

    void Explode()
    {
        print("Boom!");
        Instantiate(fxPrefab, transform.position, transform.rotation);
        
        RaycastHit[] hits;
        hits=Physics.SphereCastAll(transform.position, 5, Vector3.up, 10);

        if (hits.Length > 0)
        {
            foreach (RaycastHit hit in hits)
            {
                if (hit.rigidbody)
                {
                    hit.rigidbody.isKinematic = false;
                    hit.rigidbody.AddExplosionForce(bombForce, transform.position, 10);
                    hit.collider.SendMessage("ExplosionDamage", SendMessageOptions.DontRequireReceiver);
                } 
            }
            terrainDeformer.DestroyTerrain(this.transform.position, 10);
  
            
        }
        Destroy(gameObject);
    }

}
