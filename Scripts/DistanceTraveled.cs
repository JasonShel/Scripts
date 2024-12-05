using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTraveled : MonoBehaviour
{
    Boolean onOff = false;

    float distanceTraveled = 0;
    Vector3 lastPosition;

    private GameObject player;


    Boolean ready1 = true;
    Boolean ready2 = true;
    Boolean ready3 = true;
    Boolean ready4 = true;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("FirstPersonController");

    }

    // Update is called once per frame
    void Update()
    {
        if (onOff){
            distanceTraveled += Vector3.Distance(player.transform.position, lastPosition);
            lastPosition = player.transform.position;
        }

        // Conditionals

        if (distanceTraveled >= 35 && ready1) 
        {
            player.GetComponent<caveJump>().startFunc(.5f,false, .5f);
            ready1 = false;
        }

        if (distanceTraveled >= 60 && ready2)
        {
            player.GetComponent<caveJump>().startFunc(1.5f,false,1);
            ready2 = false;
        }

        if (distanceTraveled >= 90 && ready3)
        {
            player.GetComponent<caveJump>().startFunc(1,false,2);
            ready3 = false;
        }

        if (distanceTraveled >= 100 && ready4)
        {

            player.GetComponent<caveJump>().startFunc(70,true,0);
            ready4 = false;
        }



    }
    public void activeFunc(Boolean active)
    {
        onOff = active;
    }

    public void first()
    {
        lastPosition = player.transform.position;
    }
}
