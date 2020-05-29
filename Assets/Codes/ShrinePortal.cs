using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShrinePortal : MonoBehaviour
{
    public string levelToLoad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CommomValues.ShrinePlayerPosition = other.transform.position-other.transform.forward*3;
            
            StartCoroutine(MyLoadScene());
        }
    }

    IEnumerator MyLoadScene()
    {
        Camera.main.SendMessage("FadeOut");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(levelToLoad);
    }
}
