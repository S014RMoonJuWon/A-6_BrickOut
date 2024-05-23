using System.Collections.Generic;
using UnityEngine;

public class MakeBrick : MonoBehaviour
{
    public GameObject brick;
    public GameObject paddle;

    public List<GameObject> brickList = new List<GameObject>();

    private string objectTag = "DeleteBrick";

    Stage stage;
    Camera camera;
    private void Awake()
    {
        camera = Camera.main;
        stage = GetComponent<Stage>();  

        switch (DataManager.instance.level)
        {
            case 0:
                stage.EasyStage();
                EasyLevel();
                break;

            case 1: 
                stage.NormalStage(); 
                NormalLevel();
                break;

            case 2: 
                stage.HardStage();
                HardLevel();
                break;
        }
        DeleteBrick();
    }
    private void HardLevel()
    {
        camera.orthographicSize = 15;
        paddle.transform.position = new Vector2(0, -12.5f);

        string currentStr = stage.stageNumber[DataManager.instance.stageCount].Replace("\n", "");
        currentStr = currentStr.Replace(" ", "");

        for (int i = 0; i < currentStr.Length; i++)
        {
            GameObject makeBrick = Instantiate(brick, this.transform);

            float x = (i % 31) * 1.6f - 24.0f;
            float y = (i / 31) * 0.7f;

            makeBrick.transform.position = new Vector2(x, y - 3f);

            GetOption(makeBrick, i, currentStr);
            if (makeBrick.tag == "brick") brickList.Add(makeBrick);
        }
    }
    private void NormalLevel()
    {
        camera.orthographicSize = 10;
        paddle.transform.position = new Vector2(0, -8.0f);

        string currentStr = stage.stageNumber[DataManager.instance.stageCount].Replace("\n", "");
        currentStr = currentStr.Replace(" ", "");

        for (int i = 0; i < currentStr.Length; i++) 
        {
            GameObject makeBrick = Instantiate(brick, this .transform);

            float x = (i % 21) * 1.55f - 15.5f;
            float y = (i / 21) * 0.65f;

            makeBrick.transform.position = new Vector2(x, y);

            GetOption(makeBrick, i, currentStr);
            if (makeBrick.tag == "brick") brickList.Add(makeBrick);
        }
    }
    public void EasyLevel()
    {
        camera.orthographicSize = 6;
        string currentStr = stage.stageNumber[DataManager.instance.stageCount].Replace("\n", "");
        currentStr = currentStr.Replace(" ", "");

        for (int i = 0; i < currentStr.Length; i++)
        {
            GameObject makeBrick = Instantiate(brick, this.transform);

            float x = (i % 11) * 1.55f - 7.5f;
            float y = (i / 11) * 0.7f;

            makeBrick.transform.position = new Vector2(x - 0.25f , y + 0.75f);


            GetOption(makeBrick, i, currentStr);
            if (makeBrick.tag == "brick") brickList.Add(makeBrick);
        }
    }

    public void GetOption(GameObject makeBrick, int i, string currentStr)
    {
        char A = currentStr[i]; string currentName = "brick"; int currentB = 0;

        currentB = int.Parse(A.ToString());
        makeBrick.gameObject.name = currentName;
        makeBrick.gameObject.GetComponent<Brick>().BrickOption(currentB - 1);

        if (currentB == 0) makeBrick.GetComponent<Brick>().AddTag(0);
        else if (currentB == 6) makeBrick.GetComponent<Brick>().AddTag(6);
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
