using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public GameObject brick;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
<<<<<<< HEAD
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(brick);
=======

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
>>>>>>> MJW_BrickOut
    }
}
