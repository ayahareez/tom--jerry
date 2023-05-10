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
    [SerializeField] private CatLife cat;
    [SerializeField] private MouseLife mouse;
    [SerializeField] private SpriteRenderer catsp;
    [SerializeField] private SpriteRenderer mousesp;
    [SerializeField] private Rigidbody2D catRg;
    [SerializeField] private Rigidbody2D mouseRg;
    [SerializeField] private Animator catAnim;
    [SerializeField] private Animator mouseAnim;
    [SerializeField] private Text win;
    [SerializeField] private Image winner;
    public Sprite catWinSprite;
    public Sprite mouseWinSprite;
    public Image imageToChange;
    public float distanceM;
    public float distanceC;
    private float remainM;
    private float remainC;
    public bool isActive = false;
    public bool isdead = false;
    public static int winNumC;
    public static int winNumM;
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
        gameRestart.SetActive(true);
        isActive = true;
        isdead = true;
        catsp.enabled = false;
        mousesp.enabled = false;
        //catsp.size=new Vector2(0f,0f) ;
        //mousesp.size = new Vector2(0f, 0f);
        catRg.bodyType = RigidbodyType2D.Static;
        mouseRg.bodyType = RigidbodyType2D.Static;
        catAnim.SetBool("Idle", true);
        mouseAnim.SetBool("Idle", true);
        //gameObject.SetActive(false);
        dC.text = "Distance :   " + distanceC.ToString("F0");
        dM.text = "Distance  :   " + distanceM.ToString("F0");

        if (distanceM > distanceC)
        {
            rankMouse.text = "1.st";
            rankCat.text = "2.nd";
            win.text = "THE WINNER IS THE MOUSE";
            winNumM++;
            // winner.sprite = "2mouse";
            //ChangeImage("2mouse");
            UpdateWinnerImage(distanceM > distanceC);
        }
        else if (distanceC > distanceM)
        {
            rankMouse.text = "2.nd";
            rankCat.text = "1.st";
            win.text = "THE WINNER IS THE CAT";
            winNumC++;
            //ChangeImage("6cat");
            UpdateWinnerImage(distanceM > distanceC);
        }
        else
        {
            rankMouse.text = "1.st";
            rankCat.text = "1.st";
        }


    }
    //public void ChangeImage(string imageName)
    //{
    //    // Load the new texture
    //    Texture2D newTexture = Resources.Load<Texture2D>(imageName);
    //    if (newTexture == null)
    //    {
    //        Debug.LogError("Failed to load texture: " + imageName);
    //        return;
    //    }

    //    // Create a new sprite from the texture
    //    Sprite newSprite = Sprite.Create(newTexture, new Rect(0, 0, newTexture.width, newTexture.height), Vector2.zero);

    //    // Set the Image component's sprite to the new sprite
    //    winner.sprite = newSprite;
    //}
    public void UpdateWinnerImage(bool player1Wins)
    {
        if (player1Wins)
        {
            imageToChange.sprite = mouseWinSprite;
        }
        if (!player1Wins)
        {
            imageToChange.sprite = catWinSprite;
        }
    }
    public void level()
    {
        if(SceneManager.GetActiveScene().name=="Level 1")
        {
            Next();
        }
        if(SceneManager.GetActiveScene().name == "Level 2")
        {
            Next2();
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
    public void Next2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }

    public void Previous()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
