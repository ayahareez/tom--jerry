using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] sides;
    private int currentSawIndex=0;
    [SerializeField] private float speed = 6f;

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(sides[currentSawIndex].transform.position, transform.position) < 0.1f)
        {
            currentSawIndex++;
            if (currentSawIndex >= sides.Length)
            {
                currentSawIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, sides[currentSawIndex].transform.position, Time.deltaTime * speed);
        
    }
}
