using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public static AudioClip jumpSound, catDieSound, mouseDieSound, finishSound, collectSound;
    static AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        jumpSound = Resources.Load<AudioClip>("jump");
        catDieSound= Resources.Load<AudioClip>("catDie");
        mouseDieSound= Resources.Load<AudioClip>("mouseDie");
        collectSound= Resources.Load<AudioClip>("collect");
        finishSound= Resources.Load<AudioClip>("finish");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlayeSound(string clip)
    {
        switch (clip)
        {
            case "jump":
                audioSource.PlayOneShot(jumpSound);
                break;

            case "catDie":
                audioSource.PlayOneShot(catDieSound);
                break;
            case "mouseDie":
                audioSource.PlayOneShot(mouseDieSound);
                break;
            case "collect":
                audioSource.PlayOneShot(collectSound);
                break;
            //case "finish":
            //    audioSource.PlayOneShot(finishSound);
            //    break;
        }
    }
}
