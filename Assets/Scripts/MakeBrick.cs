using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Rendering;

public class MakeBrick : MonoBehaviour
{
    public GameObject brick;
    public GameObject paddle;

    public int stageCount = 0;

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

        }
    }
    public void EasyLevel()
    {
        camera.orthographicSize = 6;
        string currentStr = stage.stageNumber[stageCount].Replace("\n", "");
        currentStr = currentStr.Replace(" ", "");

        for (int i = 0; i < currentStr.Length; i++)
        {
            GameObject makeBrick = Instantiate(brick, this.transform);

            float x = (i % 11) * 1.55f - 7.5f;
            float y = (i / 11) * 0.7f;

            makeBrick.transform.position = new Vector2(x - 0.25f , y + 0.75f);


            GetOption(makeBrick, i, currentStr);
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
