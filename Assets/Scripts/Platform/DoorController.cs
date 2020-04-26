using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Transform[] children;

    [SerializeField] private bool deactivateInStart;
    // Start is called before the first frame update
    void Start()
    {
        children = transform.GetComponentsInChildren<Transform>();
        if (deactivateInStart)
        {
            OpenDoors();
        }
    }

    public void OpenDoors()
    {
        foreach (Transform child in children)
        {
            if (child.CompareTag(Tags.DOOR_TAG))
            {
                child.gameObject.GetComponent<Collider>().isTrigger = true;
            }
        }
    }
}
