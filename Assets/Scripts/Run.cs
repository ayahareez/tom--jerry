using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    float speed = 20;
    float speedIncreaseAmount = 0.1f;
    public Transform move;
    public Rigidbody2D myBody;
    public float normalSpeed;
    public float boostSpeed = 23;
    private float speedCoolDown = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        normalSpeed = speed;
        myBody = GetComponent<Rigidbody2D>();
        speed += speedIncreaseAmount * Time.deltaTime;


    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.isActive)
        {
            transform.position += new Vector3(speed, 0f, 0f) * Time.deltaTime;
            
        }
        
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("hhh");

    //    if (collision.gameObject.CompareTag("Fast"))
    //    {
    //        speed = boostSpeed;
    //        StartCoroutine("ApplySpeedBoost");
    //    }
    //}
    //IEnumerator ApplySpeedBoost(MouseMovement playerMovement)
    //{
    //    Debug.Log("the start");
    //    yield return new WaitForSeconds(speedCoolDown);
    //    speed = normalSpeed;
    //    Debug.Log("the end");
    //}
}
