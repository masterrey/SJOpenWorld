using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrdCam : MonoBehaviour
{
    public GameObject target;

    GameObject dummy;

    public float ajustY=1,ajustD=3;

    // Start is called before the first frame update
    void Start()
    {
        dummy = new GameObject("DummyCam");
        target.GetComponent<TrdControl>().SetDummyCam(dummy);
    }

    // Update is called once per frame
    void Update()
    {
        dummy.transform.position = target.transform.position;

        transform.position = dummy.transform.position- dummy.transform.forward* ajustD + Vector3.up*2;

        transform.LookAt(target.transform.position+Vector3.up* ajustY);

        dummy.transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
    }
}
