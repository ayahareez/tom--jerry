using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MouseLife : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sp;
    private Animator anim;
    private Rigidbody2D myBody;
    private Vector2 tempos;
    [SerializeField] private AudioSource mouseDie;
    public GameManager gameManager;
    [SerializeField] private GameObject cat;
    
    // Start is called before the first frame update
    private void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        tempos = transform.position;
    }
    private void Update()
    {
        // Get the position of the player relative to the camera's viewport
        //Vector3 playerScreenPos = Camera.main.WorldToViewportPoint(GameObject.FindGameObjectWithTag("Player").transform.position);

        //// If the player has left the camera view, kill them
        //if (playerScreenPos.x < -0.1 || playerScreenPos.x > 1.1 || playerScreenPos.y < 0 || playerScreenPos.y > 1)
        //{

        //    //StartCoroutine("ReloadScene");
        //    //Reload();
        //    gameManager.GameRestart();
        //}

    }
    //IEnumerator ReloadScene()
    //{
    //    yield return new WaitForSeconds(2f);
    //    Reload();
    //}
    //private void Reload()
    //{

    //    //loadscene wait for name of the scene
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}


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
        sp.enabled = false;
        gameManager.GameRestart();
    }
    IEnumerator Hurt()
    {
        yield return new WaitForSeconds(1f);
        //if (gameObject==null&&cat==null)
        //{

        //    // Reload();
        //    gameManager.GameRestart();
        //}
        if (!gameObject && !cat)
        {

            // Reload();
            gameManager.GameRestart();
        }
    }
}
