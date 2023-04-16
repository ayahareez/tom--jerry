using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatLife : MonoBehaviour
{
    private SpriteRenderer sp;
    private Animator anim;
    private Rigidbody2D myBody;
    private Vector2 tempos;
    [SerializeField] private AudioSource catDie;
    public GameManager gameManager;
    [SerializeField] private MouseLife mouse;
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
            catDie.Play();
            Die();

        }

    }
    private void Die()
    {
        death.Deads++;
        //myBody.bodyType = RigidbodyType2D.Static;
        Debug.Log(death.Deads);
        anim.SetTrigger("Death");
        StartCoroutine("Death");
        //if (death.Deads == 2)
        //{

        //    // Reload();
        //    gameManager.GameRestart();
        //    Debug.Log(death.Deads + "cat");
        //}
        StartCoroutine("Hurt");

    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(0.2f);
        // Destroy(gameObject);
        myBody.bodyType = RigidbodyType2D.Static;

        sp.enabled = false;
        // gameManager.GameRestart();
        dead = true;
        Debug.Log("inside cat" + dead);


    }

    private void outOfScreen()
    {
        Vector3 mouseScreenPos = Camera.main.WorldToViewportPoint(GameObject.FindGameObjectWithTag("Mouse").transform.position);

        // If the player has left the camera view, kill them
        Vector3 catScreenPos = Camera.main.WorldToViewportPoint(GameObject.FindGameObjectWithTag("Cat").transform.position);

        // If the player has left the camera view, kill them
        Debug.Log("before condition");
        Debug.Log("inside outOfScreen FUNC");
        if (catScreenPos.x < -0.1 || catScreenPos.x > 1.1 || catScreenPos.y < 0 || catScreenPos.y > 1)
        {
            dead = true;
        }

    }
    private void bothDead()
    {
        Debug.Log("inside bothDead FUNC: mouse " + mouse.dead + "/ cat " + dead);
        if (dead && mouse.dead)
        {
            Debug.Log("cat.dead " + dead);
            Debug.Log("mouse.dead " + mouse.dead);
            gameManager.GameRestart();
        }
    }
}

