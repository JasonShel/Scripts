using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using System;

public class camShake : MonoBehaviour
{
    Boolean shaking = false;
    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public Transform camTransform;

    
    // How long the object should shake for.
    public float shakeDuration = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;

    void Awake()
    {
        camTransform = this.transform;
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    void Update()
    {
        if (shaking)
        {
            if (shakeDuration > 0)
            {
                camTransform.localPosition = originalPos + UnityEngine.Random.insideUnitSphere * shakeAmount;

                shakeDuration -= Time.deltaTime * decreaseFactor;
            }
            else
            {
                shakeDuration = 0f;
                camTransform.localPosition = originalPos;
            }

        }
      
    }
    public void shake(Boolean onOff)
    {
        shaking = onOff;
    }
}