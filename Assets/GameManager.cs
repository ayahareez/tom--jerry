using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameRestart;
    [SerializeField] private Text rankCat;
    [SerializeField] private Text rankMouse;
    [SerializeField] private Transform checkPoint;
    [SerializeField] private Text dC;
    [SerializeField] private Text dM;
    private float distanceM;
    private float distanceC;
    private float remainM;
    private float remainC;
    public Rigidbody2D camera;
    public bool isActive=false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(checkPoint.transform.position.x);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        

    }

    // Update is called once per frame
    void Update()
    {
        //to calculate the distance
        remainM = (checkPoint.transform.position.x) - GameObject.FindGameObjectWithTag("Mouse").transform.position.x;
        remainC = (checkPoint.transform.position.x) - GameObject.FindGameObjectWithTag("Cat").transform.position.x;
        distanceM = GameObject.FindGameObjectWithTag("Mouse").transform.position.x;
        distanceC = GameObject.FindGameObjectWithTag("Cat").transform.position.x;
        if (gameRestart.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
           
        }

    }
    public void GameRestart()
    {
        camera.bodyType = RigidbodyType2D.Static;
        camera.constraints = RigidbodyConstraints2D.FreezePositionX;
        gameRestart.SetActive(true);
        isActive= true;
        //gameObject.SetActive(false);
        camera.constraints = RigidbodyConstraints2D.FreezePositionX;
        if (distanceM < 235)
        {
            dM.text = "Distance: " + distanceM.ToString("F0");
        }
        else 
        {
            dM.text = "Finish";
        }
        if (distanceC < 236)
        {
            dC.text = "Distance: " + distanceC.ToString("F0");
        }
        else if (distanceC == 236)
        {
            dC.text = "Finish";
        }
        if (distanceM > distanceC)
        {
            rankMouse.text = "1.st";
            rankCat.text = "2.nd";
        }
        else if(distanceC > distanceM)
        {
            rankMouse.text = "2.nd";
            rankCat.text = "1.st"; 
        }
        else
        { 
            rankMouse.text = "1.st";
            rankCat.text = "1.st";
        }
       

    }
    public void Resrart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainManue()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
