using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class caveScene : MonoBehaviour
{
    private GameObject music;
    private GameObject startLight;
    private GameObject startPoint;
    private GameObject player;
    Boolean throbActive = false;

    IEnumerator wait(float duration)
    {
        yield return new WaitForSeconds(2);
        

      
           







    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("FirstPersonController");
        startLight = GameObject.Find("caveLight1");
        startPoint = GameObject.Find("startPoint");






    }


    // Update is called once per frame
    void Update()
    {
        if (throbActive)
        {
            startLight.transform.position = player.transform.position;
            startLight.GetComponent<Light>().intensity = 5 + (Vector3.Distance(startPoint.transform.position, startLight.transform.position)) / 5;
        }
           
    }

    public void caveStart()
    {
        startLight.GetComponent<Light>().intensity = 0;
        StartCoroutine(wait(0));


        player.GetComponent<FirstPersonController>().enableSprint = true;
        startLight.GetComponent<AudioSource>().Play();
        throbActive = true;
        this.GetComponent<DistanceTraveled>().first();
        this.GetComponent<DistanceTraveled>().activeFunc(true);
    }

    public void throbAct(Boolean ahhhhhhh)
    {
        throbActive = ahhhhhhh;
    }
    
}
