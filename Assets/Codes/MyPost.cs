using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPost : MonoBehaviour
{
    public Material postmaterial;
    Color myfade = Color.black;
    float color = 0;
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, postmaterial);
        
    }

    private void Start()
    {
        postmaterial.SetColor("_Color", Color.black);
        StartCoroutine(FadeIn());
    }

    public void FadeOut()
    {
        StartCoroutine(MyFadeOut());
    }

    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(1);

        while (color<1)
        {
            yield return new WaitForEndOfFrame();
            color += Time.deltaTime;
            myfade = new Color(color, color, color);
            postmaterial.SetColor("_Color", myfade);
        }
    }
    IEnumerator MyFadeOut()
    {
        while (color>0)
        {
            yield return new WaitForEndOfFrame();
            color -= Time.deltaTime*2;
            myfade = new Color(color, color, color);
            postmaterial.SetColor("_Color", myfade);
        }
    }
}
