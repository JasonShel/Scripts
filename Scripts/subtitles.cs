using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class subtitles : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;

    // Start is called before the first frame update
    void Start()
    {
        text1 = GameObject.Find("subOne");
        text2 = GameObject.Find("subTwo");

        text1.SetActive(false);
        text2.SetActive(false);

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
        yield return new WaitForSeconds(3.4f);
        text1.SetActive(true);
        yield return new WaitForSeconds(2.2f);
        text1.SetActive(false);
        text2.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        text2.SetActive(false);

    }

}
