using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformButtonController : MonoBehaviour
{
    public MovingPlatform[] movingPlatforms;

    [SerializeField] private bool movedPlatformsToPoint;
    [SerializeField] private bool isWhiteButton, isRedButton;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.PLAYER_TAG))
        {
            if (isWhiteButton)
            {
                if (!other.GetComponent<PlayerColorController>().PLAYER_COLOR.Equals(Tags.WHITE_COLOR))
                {
                    return;
                }
            }// if is whilte color

            if (isRedButton)
            {
                if (!other.GetComponent<PlayerColorController>().PLAYER_COLOR.Equals(Tags.RED_COLOR))
                {
                    return;
                }
            } // if is red color

            if (!movedPlatformsToPoint)
            {
                movedPlatformsToPoint = true;
                for (int i = 0; i < movingPlatforms.Length; i++)
                {
                    movingPlatforms[i].ActivateMovement();
                }
            }
            else
            {
                movedPlatformsToPoint = false;
                for (int i = 0; i < movingPlatforms.Length; i++)
                {
                    movingPlatforms[i].ActivateMoveToInitial();
                }
            }
        } // if collided with player
    }
}
