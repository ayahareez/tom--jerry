using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MouseMovement : MonoBehaviour
{

    [SerializeField] private GameManager gameManager;
    Transform player;
    float count = 0;
    float y;
    private SpriteRenderer sr;
    private Animator anim;
    private string JUMP_ANIMATION = "IsJump";
    float jumpForce;
    float speedIncreaseAmount = 0.1f;
    float speed = 18;
    public Transform move;
    public Rigidbody2D myBody;
    public float normalSpeed;
    public float boostSpeed=24;
    private float speedCoolDown=4;
    private bool isGrounded=true;
    private bool isFast = false;
    private string Ground_Tag = "Ground";
    [SerializeField] private AudioSource jump;
    //[SerializeField] private Transform checkPoint;
    //[SerializeField] private Text diamondTextM ;
    //private float distance;



    // Start is called before the first frame update
    void Start()
    {
        normalSpeed = speed;
        speed += speedIncreaseAmount * Time.deltaTime;
        jumpForce = 30;
        y = 1;
        player = GameObject.FindWithTag("Mouse").transform;
        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //to calculate the distance
        //distance = (checkPoint.transform.position.x) - transform.position.x;
        //diamondTextM.text = "distannce: " + distance.ToString("F1");
        //if (distance <= 0)
        //{
        //    diamondTextM.text = "finish";
        //}
        //transform.position += new Vector3(speed, 0f, 0f) * Time.deltaTime;
        if (!gameManager.isActive&&SceneManager.GetActiveScene().name=="Level 1")
        {
            myBody.velocity = new Vector2(speed, myBody.velocity.y);
        }
        else if (!gameManager.isActive && SceneManager.GetActiveScene().name == "Level 2")
        {
            myBody.velocity = new Vector2(25, myBody.velocity.y);
        }
        PlayerJumpKeyboard();


    }
    void PlayerJumpKeyboard()
    {
        if (Input.GetButtonDown("Jump")&& (isGrounded||isFast))
        {
            jump.Play();
            isGrounded = false;
            anim.SetBool(JUMP_ANIMATION, true);
            count++;
            if (count % 2 != 0)
            {
                myBody.gravityScale = -myBody.gravityScale;
                // myBody.velocity = new Vector2(0f, movementY);
                myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                sr.flipY = true;
                move.localScale = new Vector3(1, -y, 1);
            }
            else
            {
                myBody.gravityScale = (-myBody.gravityScale) ;
                // myBody.velocity = new Vector2(0f, movementY);
                myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Force);
                sr.flipY = false;
                move.localScale = new Vector3(1, y, 1);
            }
            
        }
        anim.SetBool(JUMP_ANIMATION, false);


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hhh");
        //بنقارن اللي خبط بالتاج
        if (collision.gameObject.CompareTag(Ground_Tag))//if it returns trueهل حصل كوليشن للاعب مع اي اوبجيكت التاج بتاعه جراوند؟
        {
            isGrounded = true;
        }
        
        if (collision.gameObject.CompareTag("Fast"))
        {
            if (!gameManager.isActive && SceneManager.GetActiveScene().name == "Level 1")
            {
                speed = boostSpeed;
            }
            else if (!gameManager.isActive && SceneManager.GetActiveScene().name == "Level 2")
            {
                boostSpeed = 27;
                speed = boostSpeed;
            }
            StartCoroutine("ApplySpeedBoost");
            isFast = true;
        }
        if (collision.gameObject.CompareTag("Flip"))
        {

        }

    }

    IEnumerator ApplySpeedBoost()
    {
        Debug.Log("the start");
        yield return new WaitForSeconds(speedCoolDown);
        speed = normalSpeed;
        Debug.Log("the end");
    }
}
