using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class topLight : MonoBehaviour
{
    Boolean rgb = false;
    Boolean shake = false;

    float duration = 1.0f;
    Color color0 = Color.red;
    Color color1 = Color.blue;

    private GameObject top;
    private GameObject lamp;
    private GameObject radio;
    private GameObject jordans;
    private GameObject buggy;
    private GameObject cone;

    public GameObject ban1;
    public GameObject ban2;
    public GameObject ban3;
    public GameObject ban4;

    private GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("PlayerCamera");

        top = GameObject.Find("room1Light");
        lamp = GameObject.Find("lamp light");
        radio = GameObject.Find("Radio");
        jordans = GameObject.Find("chair:deskChair");
        cone = GameObject.Find("Banana Cone");

    }
    IEnumerator wait(float duration)
    {

        yield return new WaitForSeconds(3.4f);
        lamp.GetComponent<Light>().enabled = false;
        top.GetComponent<Light>().enabled = false;
        yield return new WaitForSeconds(.1f);
        top.GetComponent<Light>().enabled = true;
        yield return new WaitForSeconds(.1f);
        top.GetComponent<Light>().enabled = false;

        yield return new WaitForSeconds(1.3f);

        top.GetComponent<Light>().enabled = true;
        rgb = true;

        cam.GetComponent<camShake>().shake(true); // CAMERA SHAKE

        radio.transform.position = new Vector3(radio.transform.position.x, radio.transform.position.y + 1, radio.transform.position.z);

        shake = true;
        yield return new WaitForSeconds(10);
       
        for (int i = 0; i < 50; i++)
        {
            top.GetComponent<Light>().intensity -= .06f;
            yield return new WaitForSeconds(.1f);
        }
        shake = false;


    }
    private void Update()
    {
        if (rgb)
        {
            float t = Mathf.PingPong(Time.time, duration) / duration;
            top.GetComponent<Light>().color = Color.Lerp(color0, color1, t);
        }

        if (shake)
        {
            radio.transform.Rotate(50 *Vector3.up * Time.deltaTime);
            radio.transform.Rotate(100 * Vector3.left * Time.deltaTime);
            radio.transform.Rotate(75 * Vector3.back * Time.deltaTime);

            jordans.transform.Rotate(150 * Vector3.up * Time.deltaTime);
            jordans.transform.Rotate(150 * Vector3.left * Time.deltaTime);
            jordans.transform.Rotate(150 * Vector3.back * Time.deltaTime);


            cone.transform.Rotate(50 * Vector3.up * Time.deltaTime);
            cone.transform.Rotate(100 * Vector3.left * Time.deltaTime);
            cone.transform.Rotate(75 * Vector3.back * Time.deltaTime);

            ban1.transform.Rotate(120 * Vector3.back * Time.deltaTime);
            ban2.transform.Rotate(120 * Vector3.back * Time.deltaTime);
            ban3.transform.Rotate(120 * Vector3.back * Time.deltaTime);
            ban4.transform.Rotate(120 * Vector3.back * Time.deltaTime);

            ban1.transform.Rotate(120 * Vector3.left * Time.deltaTime);
            ban2.transform.Rotate(120 * Vector3.left * Time.deltaTime);
            ban3.transform.Rotate(120 * Vector3.left * Time.deltaTime);
            ban4.transform.Rotate(120 * Vector3.left * Time.deltaTime);

        }

    }

    public void dumbAhFunction()
    {
        StartCoroutine(wait(0));
    }

}