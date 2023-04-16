using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MouseLife : MonoBehaviour
{
    public SpriteRenderer sp;
    private Animator anim;
    private Rigidbody2D myBody;
    private Vector2 tempos;
    [SerializeField] private AudioSource mouseDie;
    public GameManager gameManager;
    [SerializeField] private CatLife cat;
    public bool dead = false;
    // Start is called before the first frame update
    private void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        tempos = transform.position;
    }
    private void Update()
    {

        outOfScreen();
        bothDead();
    }
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Kill"))
        {
            
            Die();
            

        }

    }
    private void Die()
    {
    //    death.Deads++;
    //    myBody.bodyType = RigidbodyType2D.Static;
    //    Debug.Log(death.Deads);
        anim.SetTrigger("Death");
        mouseDie.Play();
        StartCoroutine("Death");
        StartCoroutine("Hurt");
    }
    IEnumerator Death()
    {
        yield return new WaitForSeconds(0.2f);
        //Destroy(gameObject);

        myBody.bodyType = RigidbodyType2D.Static;
        //Debug.Log(gameObject.activeSelf);
        //gameManager.GameRestart();
        sp.enabled = false;
        dead = true;
        Debug.Log("inside mouse" + dead);

        //if (!gameObject.activeSelf && !cat.activeSelf)
        //{
        //    gameManager.GameRestart();
        //}
    }
    private void outOfScreen()
    {
        Vector3 mouseScreenPos = Camera.main.WorldToViewportPoint(GameObject.FindGameObjectWithTag("Mouse").transform.position);

        // If the player has left the camera view, kill them
        Vector3 catScreenPos = Camera.main.WorldToViewportPoint(GameObject.FindGameObjectWithTag("Cat").transform.position);

        // If the player has left the camera view, kill them
        Debug.Log("before condition");
        Debug.Log("inside outOfScreen FUNC");
        if ((mouseScreenPos.x < -0.1 || mouseScreenPos.x > 1.1 || mouseScreenPos.y < 0 || mouseScreenPos.y > 1))
        {
            dead = true;

        }
        
    }
    private void bothDead()
    {
        Debug.Log("inside bothDead FUNC: cat "+ cat.dead + "/ mouse "+ dead);
        if (cat.dead && dead)
        {
            Debug.Log("cat.dead " + cat.dead);
            Debug.Log("mouse.dead " + dead);
            gameManager.GameRestart();
        }
    }
}
