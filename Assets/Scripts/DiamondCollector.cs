using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DiamondCollector : MonoBehaviour
{
    private int diamond = 0;
    [SerializeField] private Text diamondText;
    [SerializeField] private AudioSource collect;
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
        if (collision.gameObject.CompareTag("Diamond"))
        {
            collect.Play();
            Destroy(collision.gameObject);
            diamond++;
            Debug.Log(diamond);
            diamondText.text = "Mouse's Diamonds: " + diamond;
        }
    }
}
