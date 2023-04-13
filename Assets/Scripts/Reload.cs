using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour
{
    public GameObject cat;
    public GameObject mouse;
    public GameManager gameManager;

    void Update()
    {
        if (!cat.activeSelf && !mouse.activeSelf)
        {
            gameManager.GameRestart();
        }
    }
}
