using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private GameObject radio;
    private GameObject peel1;
    private GameObject peel2;
    private GameObject peel3;
    private GameObject peel4;
    private GameObject door;


    void Start()
    {
        radio = GameObject.Find("Radio");
        peel1 = GameObject.Find("peeled1");
        peel2 = GameObject.Find("peeled2");
        peel3 = GameObject.Find("peeled3");
        peel4 = GameObject.Find("peeled4");
        door = GameObject.Find("FactoryDoor");

        
    }





    public float playerReach = 3f;
    interactable currentInteractable;
    // Update is called once per frame
    void Update()
    {
        CheckInteraction();
        if (Input.GetMouseButtonDown(0) && currentInteractable!=null) {
            currentInteractable.Interact();

       

            if (currentInteractable.name == radio.name)
            {
                
                radio.GetComponent<radio>().radioFunction();

            }


            if (currentInteractable.tag == "banana") { 
            

                peel1.GetComponent<bananaSwitch>().startFunc();

            }

            if (currentInteractable.name == door.name)
            {
                door.GetComponent<CHANGESCENE>().startFunc();
            }

            currentInteractable.enabled = false;



        }
    }
    void CheckInteraction()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        if (Physics.Raycast(ray, out hit, playerReach))
        {
            if (hit.collider.tag == "Interactable" || hit.collider.tag == "banana")
            {
                interactable newInteractable = hit.collider.GetComponent<interactable>();

                if (newInteractable.enabled)
                {
                    SetNewCurrentInteractable(newInteractable);
                }
                else
                {
                    DisableCurrentInteractable();
                }
            }
            else
            {
                DisableCurrentInteractable();
            }
        }
        else
        {
            DisableCurrentInteractable();
        }
    }
    void SetNewCurrentInteractable(interactable newInteractable)
    {
        currentInteractable = newInteractable;
        currentInteractable.EnableOutline();
    }

    void DisableCurrentInteractable()
    {
        if (currentInteractable)
        {
            currentInteractable.DisableOutline();
            currentInteractable = null;
        }
    }
}
