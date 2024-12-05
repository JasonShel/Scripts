using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CHANGESCENE : MonoBehaviour
{
    public GameObject destroy;

    // Start is called before the first frame update
    void Start()
    {

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
        this.GetComponent<AudioSource>().Play();
        Destroy(destroy);
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene("JTscene1");

    }
}
