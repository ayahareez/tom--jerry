using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MouseMovement : MonoBehaviour
{
    

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
    float originalSpeed;
    public float normalSpeed;
    public float boostSpeed=24;
    private float speedCoolDown=1;
    private bool isGrounded=true;
    private string Ground_Tag = "Ground";
    private GameObject flag;
   // [SerializeField] private AudioSource finish;
    [SerializeField] private AudioSource jump;
    //[SerializeField] private Transform checkPoint;
    //[SerializeField] private Text diamondTextM ;
    //private float distance;



    // Start is called before the first frame update
    void Start()
    {
        
        flag = GameObject.FindGameObjectWithTag("NewStage");
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
        myBody.velocity = new Vector2(speed, myBody.velocity.y);
        PlayerJumpKeyboard();


    }
    void PlayerJumpKeyboard()
    {
        if (Input.GetButtonDown("Jump")&& isGrounded)
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
            speed = boostSpeed;
            StartCoroutine("ApplySpeedBoost");
        }
        //if (collision.gameObject.CompareTag("Kill"))
        //{
        //    Destroy(gameObject);
        //}

    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("NewStage"))//if it returns trueهل حصل كوليشن للاعب مع اي اوبجيكت التاج بتاعه جراوند؟
    //    {
    //        finish.Play();
    //        Destroy(collision.gameObject);
    //    }
    //}

    IEnumerator ApplySpeedBoost(MouseMovement playerMovement)
    {
        Debug.Log("the start");
        yield return new WaitForSeconds(speedCoolDown);
        speed = normalSpeed;
        Debug.Log("the end");
    }
}
