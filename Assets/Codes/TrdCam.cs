using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrdCam : MonoBehaviour
{
    public GameObject target;

    GameObject dummy;



    // Start is called before the first frame update
    void Start()
    {

        dummy = new GameObject("DummyCam");
        target.GetComponent<TrdControl>().SetDummyCam(dummy);
        dummy.transform.parent = gameObject.transform;
        dummy.transform.localPosition = Vector3.zero;
        dummy.transform.localRotation = Quaternion.identity;

    }

    
}
