using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Finish1 : MonoBehaviour
{
    
    public GameManager gameManager;
    public GameObject finish;
    //[SerializeField] private Scene TheFinish;
    [SerializeField] private Text win;
    //public Sprite catWinSprite;
    //public Sprite mouseWinSprite;
    //public Image imageToChange;
    [SerializeField] private Rigidbody2D catRg;
    [SerializeField] private Rigidbody2D mouseRg;
    [SerializeField] private Animator catAnim;
    [SerializeField] private Animator mouseAnim;
    public bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //public void UpdateWinnerImage(bool player1Wins)
    //{
    //    if (player1Wins)
    //    {
    //        imageToChange.sprite = mouseWinSprite;
    //    }
    //    if (!player1Wins)
    //    {
    //        imageToChange.sprite = catWinSprite;
    //    }
    //}
   
    public void TheFinish()
    {
        isActive = true;
        catRg.bodyType = RigidbodyType2D.Static;
        mouseRg.bodyType = RigidbodyType2D.Static;
        catAnim.SetBool("Idle", true);
        mouseAnim.SetBool("Idle", true);
        finish.SetActive(true);
        if (gameManager.distanceC > gameManager.distanceM)
        {
            win.text = "THE WINNER IS THE CAT";
            // UpdateWinnerImage(GameManager.winNumC > GameManager.winNumM);
        }
        else
        {
            win.text = "THE WINNER IS THE MOUSE";
            // UpdateWinnerImage(GameManager.winNumC > GameManager.winNumM);
        }
    }
    public void MainManue()
    {
        SceneManager.LoadScene("MainMenu");
    }
    //private void flag()
    //{
    //    if (isDead)
    //    {
    //        Debug.Log("inside flag");
    //        SceneManager.LoadScene("TheFinish");
    //    }
    //}

}
