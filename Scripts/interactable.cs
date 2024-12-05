using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class interactable : MonoBehaviour
{
    public string message;

    public UnityEvent onInteraction;
    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<outlineEffect>().OutlineWidth = 0;
        text.SetActive(false);



    }

    public void DisableOutline()
    {
        this.GetComponent<outlineEffect>().OutlineWidth = 0;
        text.SetActive(false);
    }

    public void EnableOutline()
    {
        this.GetComponent<outlineEffect>().OutlineWidth = 5;
        text.SetActive(true);

    }

    public void Interact()
    {
        onInteraction.Invoke();
    }
}
