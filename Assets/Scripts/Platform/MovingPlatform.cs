using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform movePoint;

    private Vector3 startPos;

    [SerializeField] private float smoothMovement = .3f;
    [SerializeField]private float initialMovement;
    private bool smoothMovementHalfed, canMove, moveToInitial;
    [SerializeField] private float halfDistance = 15f;
    [SerializeField] private bool activateMovementInStart;
    [SerializeField] private float timer = 1f;
    private DoorController doorController;
    [SerializeField] private bool deactivateDoors;
    private PlatfromSoundFX soundFx;
    private RotatePlatform rotatePlatform;
    [SerializeField] private bool activateRotation;
    private void Awake()
    {
        startPos = transform.position;
        initialMovement = smoothMovement;
        // activate doors
        doorController = GetComponent<DoorController>();
        // add sound
        soundFx = GetComponent<PlatfromSoundFX>();
        if (activateRotation)
            rotatePlatform = GetComponent<RotatePlatform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (activateMovementInStart)
        {
            Invoke("ActivateMovement",timer);
        }
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
        MoveToInitialPosition();
    }

    void MovePlatform()
    {
        if (canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, smoothMovement);
            if (Vector3.Distance(transform.position, movePoint.position) <= halfDistance)
            {
                if (!smoothMovementHalfed)
                {
                    smoothMovement /= 2f;
                    smoothMovementHalfed = true;
                }   
            }

            if (Vector3.Distance(transform.position, movePoint.position) == 0f) // platform reached its destination
            {
                canMove = false;
                if (smoothMovementHalfed)
                {
                    smoothMovement = initialMovement;
                    smoothMovementHalfed = false;
                }
                // deactivate doors
                if (deactivateDoors)
                {
                    doorController.OpenDoors();
                }
                // stop sfx
                soundFx.PlayAudio(false);
            }
        }
    }
    public void ActivateMovement()
    {
        canMove = true;
        // play sfx
        soundFx.PlayAudio(true);
        // rotate player
        if (activateRotation)
        {
            rotatePlatform.ActivateRotation();
        }
    }

    public void ActivateMoveToInitial()
    {
        moveToInitial = true;
        soundFx.PlayAudio(true);
    }

    void MoveToInitialPosition()
    {
        if (moveToInitial)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, smoothMovement);
            if (Vector3.Distance(transform.position, startPos) <= halfDistance)
            {
                if (!smoothMovementHalfed)
                {
                    smoothMovement /= 2f;
                    smoothMovementHalfed = true;
                }
            }

            if (Vector3.Distance(transform.position, startPos) == 0f)
            {
                moveToInitial = false;
                if (smoothMovementHalfed)
                {
                    smoothMovementHalfed = false;
                    smoothMovement = initialMovement;
                }
                soundFx.PlayAudio(false);
            }
        }
    }
}
