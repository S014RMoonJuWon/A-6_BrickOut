using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public string[] stageNumber;
    public void EasyStage()
    {
        stageNumber[0] =
            "12021111111\n" +
            "12022222221\n" +
            "12000000021\n" +
            "12222222021\n" +
            "11111112021";

        stageNumber[1] =
            "22222022222\n" +
            "21111011112\n" +
            "21111011112\n" +
            "20000000002\n" +
            "33333333333";

        stageNumber[2] =
            "16662126661\n" +
            "11112121111\n" +
            "11112121111\n" +
            "12222222221\n" +
            "11111111111";
    }
}
