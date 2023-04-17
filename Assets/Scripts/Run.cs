using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Run : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Finish1 finish;
    float speed = 20;
    float speedIncreaseAmount = 0.1f;
    public Transform move;
    public Rigidbody2D myBody;
    public float normalSpeed;
    public float boostSpeed = 23;
    
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
        if (!gameManager.isActive&& SceneManager.GetActiveScene().name == "Level 1")
        {
            transform.position += new Vector3(speed, 0f, 0f) * Time.deltaTime;
            
        }
        if (!gameManager.isActive&& SceneManager.GetActiveScene().name == "Level 2")
        {
            transform.position += new Vector3(22, 0f, 0f) * Time.deltaTime;

        }

    }
}
