using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishedLevel : MonoBehaviour
{
    [SerializeField]
    private string nextLevelName;
    [SerializeField]
    private float timer = 2f;

    private bool levelFinished;

    private PlatfromSoundFX soundFX;

    private void Awake()
    {
        soundFX = GetComponent<PlatfromSoundFX>();
    }

    void LoadNewLevel()
    {
        SceneManager.LoadScene(nextLevelName);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.PLAYER_TAG))
        {
            if (!levelFinished)
            {
                levelFinished = true;
                soundFX.PlayAudio(true);
                if (!nextLevelName.Equals(""))
                {
                    Invoke("LoadNewLevel", timer);
                }
            }
        }
    }
}
