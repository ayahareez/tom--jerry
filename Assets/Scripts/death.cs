using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class death : MonoBehaviour
{
    public static int Deads = 0;
    public GameManager gameManager;
    [SerializeField] private CatLife cat;
    [SerializeField] private MouseLife mouse;
    
    void Start()
    {
        
    }

    private void Update()
    {
        bothDead();
        // Get the position of the player relative to the camera's viewport
        //Vector3 mouseScreenPos = Camera.main.WorldToViewportPoint(GameObject.FindGameObjectWithTag("Mouse").transform.position);

        //// If the player has left the camera view, kill them
        //Vector3 catScreenPos = Camera.main.WorldToViewportPoint(GameObject.FindGameObjectWithTag("Cat").transform.position);

        //// If the player has left the camera view, kill them
        //Debug.Log("before condition");

        //if ((mouseScreenPos.x < -0.1 || mouseScreenPos.x > 1.1 || mouseScreenPos.y < 0 || mouseScreenPos.y > 1)&& (catScreenPos.x < -0.1 || catScreenPos.x > 1.1 || catScreenPos.y < 0 || catScreenPos.y > 1) )
        //{
        //    Debug.Log("cat bool" + cat.dead);
        //    Debug.Log("mouse bool" + mouse.dead);
        //    KillPlayer();
        //    gameManager.GameRestart();
        //    camera.transform.position = new Vector3(0f, 0f, 0f);
        //    //StartCoroutine("ReloadScene");
        //}
        // Check if either player is inside the camera view frustum

        //if ((catScreenPos.x < -0.1 || catScreenPos.x > 1.1 || catScreenPos.y < 0 || catScreenPos.y > 1) && !isDead)
        //{
        //    KillPlayer();
        //    gameManager.GameRestart();
        //    //StartCoroutine("ReloadScene");
        //}

        
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player") && !isDead)
    //    {
    //        KillPlayer();
    //    }
    //}
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
    private void bothDead()
    {
        Debug.Log("inside bothDead FUNC");
        if(cat.dead&&mouse.dead) {
            Debug.Log("cat.dead " + cat.dead);
            Debug.Log("mouse.dead " + mouse.dead);
            gameManager.GameRestart();
        }
    }

    




    private void ReloadInUpdate()
    {
        //Debug.Log(cat.gameObject);
        //if ((cat == null && mouse == null)&&!isDone)
        //{
        //    gameManager.GameRestart();
        //}
    }


    private void KillPlayer()
    {

        // Play death animation or sound effect here
        //if (GameObject.FindGameObjectWithTag("Mouse"))
        //{
        //    Destroy(GameObject.FindGameObjectWithTag("Mouse"));
        //}
        //if (GameObject.FindGameObjectWithTag("Cat"))
        //{
        //    Destroy(GameObject.FindGameObjectWithTag("Cat"));
        //}
        //if ((!cat.activeSelf) || (!mouse.activeSelf))
        //{
        //    // Destroy the camera object
        //    Destroy(camera.gameObject);
        //    Debug.Log("dead");
        //}

        // Optionally, handle game over or reset logic here
    }
}
