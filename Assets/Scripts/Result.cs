using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    public GameObject stageClearImage;
    public GameObject nextBtn;
    public void Winner()
    {
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("ball");

        foreach (GameObject obj in objectsToDestroy)
        {
            Destroy(obj);
        }

        stageClearImage.SetActive(true);
        Invoke("NextBtn", 1.5f);
    }
    private void NextBtn()
    {
        nextBtn.SetActive(true);
    }
}