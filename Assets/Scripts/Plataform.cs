using System.Collections.Generic;
using UnityEngine;

public class Plataform : MonoBehaviour
{

    public static int amount;
    public bool yesorno;
    //Start is called once before the first execution of Update after

    void Start()
    {
        amount++;
        Animacion.singleton = null;
        //Player myplayer = new Player();
        //myplayer.singleton = null;
    }

    //Update is called once per frame

    void Update() { }
}