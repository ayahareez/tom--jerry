using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Easy()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void Meduim()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void Hard()
    {
        SceneManager.LoadScene("Level 3");
    }
}
