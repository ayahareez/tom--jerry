using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    
    // Start is called before the first frame update
   

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
    public void med()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +2);
    }
    public void Home()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
