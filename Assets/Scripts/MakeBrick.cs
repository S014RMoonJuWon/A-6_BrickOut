using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class MakeBrick : MonoBehaviour
{
    public GameObject brick;
    public GameObject paddle;

    private string objectTag = "DeleteBrick";
    public string[] stage;
    Camera camera;
    private void Awake()
    {
        camera = Camera.main;

        switch (DataManager.instance.level)
        {
            case 0: EasyLevel();
                break;
            case 1: NormalLevel();
                break;
            case 2: HardLevel();
                break;
        }
        DeleteBrick();
    }
    private void HardLevel()
    {
        camera.orthographicSize = 15;
        paddle.transform.position = new Vector2(0, -12.5f);
        for (int i = 0; i < 372; i++)
        {
            GameObject makeBrick = Instantiate(brick, this.transform);

            float x = (i % 31) * 1.6f - 24.0f;
            float y = (i / 31) * 1.3f;

            makeBrick.transform.position = new Vector2(x, y - 3f);
            makeBrick.GetComponent<Brick>().BrickColor(Random.Range(0,5));
        }
    }
    private void NormalLevel()
    {
        camera.orthographicSize = 10;
        paddle.transform.position = new Vector2(0, -8.0f);
        for (int i = 0; i < 75; i++) 
        {
            GameObject makeBrick = Instantiate(brick, this .transform);

            float x = (i % 15) * 1.4f - 10f;
            float y = (i / 15) * 1.3f;

            makeBrick.transform.position = new Vector2(x, y);

            makeBrick.GetComponent<Brick>().BrickColor(Random.Range(0, 5));
        }
    }

   private  void EasyLevel()
   {
       camera.orthographicSize = 6;
       for (int i = 0; i < 55; i++)
       {
           GameObject makeBrick = Instantiate(brick, this.transform);

           float x = (i % 11) * 1.55f - 7.5f;
           float y = (i / 11) * 0.7f;

           makeBrick.transform.position = new Vector2(x, y + 1.8f);

           if (i < 11) makeBrick.GetComponent<Brick>().BrickColor(0);
           else if (i < 22) makeBrick.GetComponent<Brick>().BrickColor(1);
           else makeBrick.GetComponent<Brick>().BrickColor(2);

           if (i == 8 || i == 19 || i == 35 || i == 46) makeBrick.GetComponent<Brick>().AddTag();
           else if (i >= 24 &&  i <= 30) makeBrick.GetComponent<Brick>().AddTag();
        }
   }
    public void DeleteBrick()
    {
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag(objectTag);

        foreach (GameObject obj in objectsToDestroy)
        {
            Destroy(obj);
        }
    }
}
