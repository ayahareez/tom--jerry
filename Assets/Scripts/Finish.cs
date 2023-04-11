using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private AudioSource finishSound;
    public GameManager gameManager;
    private bool isDead;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Mouse") || collision.gameObject.CompareTag("Cat")&!isDead)//if it returns trueهل حصل كوليشن للاعب مع اي اوبجيكت التاج بتاعه جراوند؟
        {
            isDead = true;
            finishSound.Play();
            StartCoroutine("Wait");
            //Destroy(collision.gameObject);

        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        gameManager.GameRestart();
        
    }

}
