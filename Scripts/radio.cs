using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Video;

public class radio : MonoBehaviour
{
    private GameObject music;
    private GameObject trash;
    private GameObject blurRing;


    private GameObject player;
    private GameObject cave;

    private GameObject light;
    private GameObject subAud;


    private GameObject eyeAnimation;
    private GameObject videoPlayer;



    // Start is called before the first frame update
    void Start()

    {

        music = GameObject.Find("music");
        trash = GameObject.Find("TRASH");
        blurRing = GameObject.Find("blurRing");

        subAud = GameObject.Find("subAud");
        light = GameObject.Find("room1Light");
        player = GameObject.Find("FirstPersonController");

        light.GetComponent<Light>().enabled = false;


        cave = GameObject.Find("caveLight1");

        eyeAnimation = GameObject.Find("eyeAnimation");
        videoPlayer = GameObject.Find("videoplayer");

        eyeAnimation.SetActive(false);


        player.GetComponent<FirstPersonController>().enableSprint = false;
        cave.GetComponent<Light>().intensity = 0;

        cave.GetComponent<caveScene>().enabled = false;

    }

    public void radioFunction()
    {
        StartCoroutine(wait(0));
        IEnumerator wait(float duration)
        {

            player.GetComponent<FirstPersonController>().walkSpeed = 3;
            music.GetComponent<AudioSource>().Stop();
            trash.GetComponent<AudioSource>().Play();
            light.GetComponent<topLight>().dumbAhFunction();









            light.GetComponent<Light>().enabled = true;
            light.GetComponent<AudioSource>().Play();


            yield return new WaitForSeconds(.07f);

            light.GetComponent<Light>().enabled = false;
            subAud.GetComponent<AudioSource>().Play();

            yield return new WaitForSeconds(.07f);

            light.GetComponent<Light>().enabled = true;
            light.GetComponent<AudioSource>().Play();


            yield return new WaitForSeconds(8);
            blurRing.GetComponent<blur>().dumbAhFunction();


            yield return new WaitForSeconds(11);

            eyeAnimation.SetActive(true);
            player.GetComponent<subtitles>().startFunc();

            yield return new WaitForSeconds(3);

            blurRing.GetComponent<AudioSource>().Play();





            //glitch
            yield return new WaitForSeconds(6);

            player.transform.position = new Vector3(-503.4f, 32, 44);
            cave.GetComponent<caveScene>().enabled = true;

            cave.GetComponent<caveScene>().caveStart();
            yield return new WaitForSeconds(4);

            for (int i = 0; i < 20; i++) {

                videoPlayer.GetComponent<VideoPlayer>().targetCameraAlpha -= 0.03f;
                yield return new WaitForSeconds(.1f);

            }
            eyeAnimation.SetActive(false);
        }


    }

}
