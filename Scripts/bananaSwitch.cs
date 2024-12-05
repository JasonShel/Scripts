using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class bananaSwitch : MonoBehaviour
{
    public GameObject sound;
    public GameObject startLight;
    public GameObject buzzBeat;
    public GameObject teleport;
    public GameObject player;
    public GameObject quicktp;
    public GameObject door;
    public GameObject glitchAnim;

    public GameObject pOne;
    public GameObject pp;



    public Vector3 save;

    // Start is called before the first frame update
    void Start()
    {
        pp = GameObject.Find("PostProc");

        sound = GameObject.Find("glitchFactory");
        startLight = GameObject.Find("caveLight1");
        buzzBeat = GameObject.Find("otherCaveLight");
        teleport = GameObject.Find("teleport");
        player = GameObject.Find("FirstPersonController");
        glitchAnim.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startFunc()
    {
        
        StartCoroutine(wait(0));

    }

    IEnumerator wait(float duration)
    {


        glitchAnim.SetActive(true);
        startLight.GetComponent<Light>().intensity = 0;
        startLight.GetComponent<AudioSource>().Stop();
        buzzBeat.GetComponent<AudioSource>().Stop();

        sound.GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(1.2f);
        glitchAnim.SetActive(false);
        pp.GetComponent<PostProcessVolume>().profile.GetSetting<ColorGrading>().saturation.value = 0;

        save = player.transform.position;
        player.transform.position = quicktp.transform.position;
        player.transform.rotation = quicktp.transform.rotation;

        yield return new WaitForSeconds(2.2f);
        glitchAnim.SetActive(true);

        player.transform.position = save;

        yield return new WaitForSeconds(1.8f);
        glitchAnim.SetActive(false);

        pp.GetComponent<PostProcessVolume>().profile.GetSetting<ColorGrading>().saturation.value = -100;

        player.transform.position = teleport.transform.position;
        player.transform.rotation = teleport.transform.rotation;
        player.GetComponent<PlayerInteraction>().playerReach = 5;
        door.GetComponent<BoxCollider>().enabled = true; 

    }

}