using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class blur : MonoBehaviour
{
    public GameObject pp;


    // Start is called before the first frame update
    void Start()
    {
        pp = GameObject.Find("PostProc");
    }

    // Update is called once per frame
    IEnumerator wait(float duration)
    {
        for (int i =0; i < 29; i++) {

            pp.GetComponent<PostProcessVolume>().profile.GetSetting<DepthOfField>().focusDistance.value -= .1f;
            pp.GetComponent<PostProcessVolume>().profile.GetSetting<Grain>().intensity.value += .01f;

            yield return new WaitForSeconds(.3f);
        }
        yield return new WaitForSeconds(4.5f);
        pp.GetComponent<PostProcessVolume>().profile.GetSetting<DepthOfField>().focusDistance.value = 3;
        pp.GetComponent<PostProcessVolume>().profile.GetSetting<Grain>().intensity.value += .5f;


    }

    public void dumbAhFunction()
    {
        StartCoroutine(wait(0));
    }
}
