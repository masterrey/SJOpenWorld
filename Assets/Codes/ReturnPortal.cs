using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnPortal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(MyLoadScene());
        }
    }
    IEnumerator MyLoadScene()
    {
        Camera.main.SendMessage("FadeOut");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MainGame");
    }
}
