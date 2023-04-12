using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class death : MonoBehaviour
{
    public static int Deads = 0;
    private bool isDead = false; // flag to prevent repeated deaths
    private bool isDone = false;
    public GameManager gameManager;
    [SerializeField] private GameObject cat;
    [SerializeField] private GameObject mouse;
    private Camera camera;
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    private void Update()
    {
        // Get the position of the player relative to the camera's viewport
        Vector3 mouseScreenPos = Camera.main.WorldToViewportPoint(GameObject.FindGameObjectWithTag("Mouse").transform.position);

        // If the player has left the camera view, kill them
        Vector3 catScreenPos = Camera.main.WorldToViewportPoint(GameObject.FindGameObjectWithTag("Cat").transform.position);

        // If the player has left the camera view, kill them
        
        if ((mouseScreenPos.x < -0.1 || mouseScreenPos.x > 1.1 || mouseScreenPos.y < 0 || mouseScreenPos.y > 1)&&!isDead&& (catScreenPos.x < -0.1 || catScreenPos.x > 1.1 || catScreenPos.y < 0 || catScreenPos.y > 1) && !isDead)
        {
            KillPlayer();
            gameManager.GameRestart();
            camera.transform.position = new Vector3(0f, 0f, 0f);
            //StartCoroutine("ReloadScene");
        }
        // Check if either player is inside the camera view frustum

        //if ((catScreenPos.x < -0.1 || catScreenPos.x > 1.1 || catScreenPos.y < 0 || catScreenPos.y > 1) && !isDead)
        //{
        //    KillPlayer();
        //    gameManager.GameRestart();
        //    //StartCoroutine("ReloadScene");
        //}

        ReloadInUpdate();
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
        isDead = true;
        // Play death animation or sound effect here
        //if (GameObject.FindGameObjectWithTag("Mouse"))
        //{
        //    Destroy(GameObject.FindGameObjectWithTag("Mouse"));
        //}
        //if (GameObject.FindGameObjectWithTag("Cat"))
        //{
        //    Destroy(GameObject.FindGameObjectWithTag("Cat"));
        //}
        if ((!cat.activeSelf) || (!mouse.activeSelf))
        {
            // Destroy the camera object
            Destroy(camera.gameObject);
            Debug.Log("dead");
        }

        // Optionally, handle game over or reset logic here
    }
}
