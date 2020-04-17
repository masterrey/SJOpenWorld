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
    }

    // Update is called once per frame
    void Update()
    {
        dummy.transform.position = target.transform.position;

        transform.position = dummy.transform.position- dummy.transform.forward*3+Vector3.up*2;

        transform.LookAt(target.transform.position);

        dummy.transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
    }
}
