using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class MusicPlay : MonoBehaviour
{
    public AudioSource music;
    public AudioClip nightsound;
    public DayCicle daycontrol;
    // Start is called before the first frame update
    void Start()
    {
        daycontrol.myMorningCall += MorningPlay;
        daycontrol.myNightCall += NightPlay;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MorningPlay()
    {
        music.Play();
    }

    public void NightPlay()
    {
        music.PlayOneShot(nightsound);
    }
}
