using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromButton : MonoBehaviour
{
    private RotatePlatform rotatePlatform;

    private void Awake()
    {
        rotatePlatform = GetComponentInParent<RotatePlatform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.PLAYER_TAG))
        {
            rotatePlatform.ActivateRotation();
        }
    }
}
