using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwitchController : MonoBehaviour
{
    [SerializeField] private bool redColor, whiteColor;
    [SerializeField] private Material redMaterial;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.PLAYER_TAG))
        {
            if (redColor)
            {
                other.GetComponent<PlayerColorController>().PLAYER_COLOR = Tags.RED_COLOR;
                other.GetComponent<MeshRenderer>().material = redMaterial;
            }

            if (whiteColor)
            {
                other.GetComponent<PlayerColorController>().PLAYER_COLOR = Tags.WHITE_COLOR;
            }
        }
    }
}
