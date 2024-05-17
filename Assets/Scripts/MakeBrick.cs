using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBrick : MonoBehaviour
{
    public GameObject brick;
    void Start()
    {
        for (int i = 0; i < 33; i++) 
        {
            GameObject makeBrick = Instantiate(brick, this .transform);

            float x = (i % 11) * 1.4f - 7f;
            float y = (i / 11) * 1.3f;

            makeBrick.transform.position = new Vector2(x, y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
