using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCicle : MonoBehaviour
{
    public float daytime; //passagem de tempo
    float lightdegrees = 0;
    public float timeScale = 1;
    public TimeSpan mytime;
    public Light sun;
    Color fogcolor;
    public Gradient ambientGradient; //variavel da gradiente de iluminaçao ambiente

    //delegates para criar as chamadas de funçao
    public delegate void MorningCall();
    public delegate void NightCall();
    //declaraçao das funcoes
    public MorningCall myMorningCall;
    public NightCall myNightCall;

    public string timespan;
    bool day = false;
    void Start()
    {
        //guarda a cor do fog
        fogcolor = RenderSettings.fogColor;
        daytime = CommomValues.currenttime;
    }

    void Update()
    {
        //incrementa o tempo do dia baseado em segundos
        daytime += Time.deltaTime* timeScale;

        //cria um timespan pra referencia da hora do dia
        mytime = TimeSpan.FromSeconds(daytime);
        timespan=mytime.ToString();

        CommomValues.currenttime = daytime;

        //coloca o sol no lugar apropriado para o dia regra de 3 86400segundo para um dia por 360 graus pra um dia
        lightdegrees = 360 * (daytime/ 86400);
        //aplica os graus na rotaçao da luz
        transform.rotation = Quaternion.Euler(lightdegrees -90, -45, -19);
        //calcula o produto vetorial da direçao da luz pra descobrir sua intensidade
        float normalsun = Vector3.Dot(transform.forward, Vector3.down);
        //adiciona 0.2 para o sol brilhar mais forte
        sun.intensity = normalsun * 1.2f;

        //utiliza o gradiente pra fazer a luz de entardecer (ambiente) ganhar um tom diferenciado
        RenderSettings.ambientLight = ambientGradient.Evaluate(normalsun+0.4f);
        //só tem brilho no fog durante o dia
        RenderSettings.fogColor = fogcolor * normalsun;

        //verifica se é dia ou noite e chama as funçoes adequadas
        if (normalsun > 0)
        {
            //utiliza uma bolleana para nao chamar mais de uma vez
            if (!day)
            {
                myMorningCall();
                day = true;
            }
        }
        else
        {
            if (day)
            {
                myNightCall();
                day = false;
            }
        }

    }
}
