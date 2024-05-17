using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBrick : MonoBehaviour
{
    public GameObject panel;
    public GameObject brick;
    public Camera camera;
    public void ChooseLevel()
    {
        panel.SetActive(false);
        camera.orthographicSize = 10;
        for (int i = 0; i < 75; i++) 
        {
            GameObject makeBrick = Instantiate(brick, this .transform);

            float x = (i % 15) * 1.4f - 10f;
            float y = (i / 15) * 1.3f;

            makeBrick.transform.position = new Vector2(x, y);
        }
    }

   public  void ChooseLevel2()
    {
        panel.SetActive(false);
        camera.orthographicSize = 6;
        for (int i = 0; i < 33; i++)
        {
            GameObject makeBrick = Instantiate(brick, this.transform);

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
