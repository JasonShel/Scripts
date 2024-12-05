using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UIElements;

public class caveJump : MonoBehaviour
{
    private GameObject startLight;
    private GameObject staticSound;
    private GameObject player;
    public GameObject pp;
    public float pubInte;

    public Boolean pubOther = false;

    public GameObject banana1;
    public GameObject banana2;
    public GameObject banana3;
    public GameObject banana4;

    public GameObject particles;

    // Start is called before the first frame update
    void Start()
    {
        startLight = GameObject.Find("caveLight1");
        staticSound = GameObject.Find("otherCaveLight");
        player = GameObject.Find("FirstPersonController");
        pp = GameObject.Find("PostProc");
        banana1 = GameObject.Find("peeled1");
        banana2 = GameObject.Find("peeled2");
        banana3 = GameObject.Find("peeled3");
        banana4 = GameObject.Find("peeled4");

        particles = GameObject.Find("particleGroup");

        banana1.SetActive(false);
        banana2.SetActive(false);
        banana3.SetActive(false);
        banana4.SetActive(false);

        particles.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (pubOther)
        {
            startLight.transform.position = player.transform.position;


        }
    }

    public void startFunc(float time, Boolean other, float inte)
    {
        pubOther = other;
        pubInte = inte;

        StartCoroutine(wait(time));
    }
    IEnumerator wait(float duration)
    {
        if (pubOther)
        {

            player.GetComponent<PlayerInteraction>().playerReach = 8;
            startLight.GetComponent<Light>().range = 20;
            banana1.SetActive(true);
            banana2.SetActive(true);
            banana3.SetActive(true);
            banana4.SetActive(true);

            particles.SetActive(true);

            startLight.GetComponent<DistanceTraveled>().activeFunc(false);
            pp.GetComponent<PostProcessVolume>().profile.GetSetting<ColorGrading>().saturation.value = -100;

            staticSound.GetComponent<AudioSource>().Play();
            Vector3 pos = this.transform.position;
            startLight.GetComponent<caveScene>().throbAct(false);
            this.transform.position = new Vector3(-510, this.transform.position.y, 318);
            staticSound.GetComponent<Light>().intensity = 0;
            startLight.GetComponent<Light>().intensity = 25;

        }
        else { 
        
            
            startLight.GetComponent<DistanceTraveled>().activeFunc(false);
            pp.GetComponent<PostProcessVolume>().profile.GetSetting<ColorGrading>().saturation.value = -100;

            staticSound.GetComponent<AudioSource>().Play();
            Vector3 pos = this.transform.position;
            startLight.GetComponent<caveScene>().throbAct(false);
            this.transform.position = new Vector3(-510, this.transform.position.y, 318);
            staticSound.GetComponent<Light>().intensity = pubInte;


            yield return new WaitForSeconds(duration);
            this.transform.position = new Vector3(pos.x, this.transform.position.y, pos.z);
            startLight.GetComponent<caveScene>().throbAct(true);
            staticSound.GetComponent<AudioSource>().Stop();

            pp.GetComponent<PostProcessVolume>().profile.GetSetting<ColorGrading>().saturation.value = 0;

            startLight.GetComponent<DistanceTraveled>().activeFunc(true);
        }
       










    }
}
