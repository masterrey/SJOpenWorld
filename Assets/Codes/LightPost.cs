using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPost : MonoBehaviour
{
    public Light lamp;
    public MeshRenderer lampMat;
    // Start is called before the first frame update
    void Start()
    {
        //busca script de dia e noite no jogo
        DayCicle dayscript = GameObject.FindObjectOfType<DayCicle>();
        //inscreve as funcoes nos eventos de dia e noite
        dayscript.myNightCall += TurnOn;
        dayscript.myMorningCall += TurnOff;
    }

    public void TurnOn()
    {
        //liga a luz
        lamp.enabled = true;
        //liga o emissive do material
        lampMat.materials[1].EnableKeyword("_EMISSION");
    }
    public void TurnOff()
    {
        lamp.enabled = false;
        lampMat.materials[1].DisableKeyword("_EMISSION");
    }

}
