using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondFlag : MonoBehaviour
{
    
    [SerializeField] private AudioSource finishSound;
    public Finish1 finish;
    private bool isDead = false;
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
        if (collision.gameObject.CompareTag("Mouse") || collision.gameObject.CompareTag("Cat"))//if it returns trueهل حصل كوليشن للاعب مع اي اوبجيكت التاج بتاعه جراوند؟
        {
            isDead = true;
            finishSound.Play();
            //StartCoroutine("WaitFlag");
            finish.TheFinish();
            flag();
            //Destroy(collision.gameObject);

        }
    }
    IEnumerator WaitFlag()
    {
        Debug.Log("inside waitFlag");
        yield return new WaitForSeconds(1f);
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        

    }
    private void flag()
    {
        if (isDead)
        {
            Debug.Log("inside flag");
            finish.TheFinish();
        }
    }
}
