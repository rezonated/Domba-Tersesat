using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatform : MonoBehaviour
{
    [SerializeField] private Vector3 rotationAngles;

    private Quaternion initialRotation;

    [SerializeField] private float smoothRotate = 1f;

    [SerializeField] private bool canRotate;

    private bool backToInitialRotation;

    [SerializeField] private float deactivateTimer = 5f;

    private PlatfromSoundFX soundFx;

    private void Awake()
    {
        initialRotation = transform.rotation;
        soundFx = GetComponent<PlatfromSoundFX>();
    }

    // Update is called once per frame
    void Update()
    {
        RotatingPlatform();
    }

    void RotatingPlatform()
    {
        if (canRotate)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(rotationAngles.x,rotationAngles.y,rotationAngles.z),smoothRotate * Time.deltaTime);
        }
    }

    public void ActivateRotation()
    {
        if (!canRotate)
        {
            canRotate = true;
            soundFx.PlayAudio(true);
            // deactivate rotation
            Invoke("DeactivateRotation",deactivateTimer);
        }
    }

    void DeactivateRotation()
    {
        canRotate = false;
        soundFx.PlayAudio(false);
    }
}
