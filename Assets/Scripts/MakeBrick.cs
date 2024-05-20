using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBrick : MonoBehaviour
{
    public GameObject brick;
    public GameObject paddle;

    public string[] stage;
    public int[] brickList = {0,1,2,3,4};
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
            makeBrick.GetComponent<Brick>().BrickColor(brickList[Random.Range(0,5)]);
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
            makeBrick.GetComponent<Brick>().BrickColor(brickList[Random.Range(0, 5)]);
        }
    }

   private  void EasyLevel()
    {;
        camera.orthographicSize = 6;
        for (int i = 0; i < 33; i++)
        {
            GameObject makeBrick = Instantiate(brick, this.transform);

            float x = (i % 11) * 1.4f - 7f;
            float y = (i / 11) * 1.3f;

            makeBrick.transform.position = new Vector2(x, y);
            makeBrick.GetComponent<Brick>().BrickColor(brickList[Random.Range(0, 5)]);
        }
    }
}
