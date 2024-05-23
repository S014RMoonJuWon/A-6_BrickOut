using UnityEngine;

public class DataManager : MonoBehaviour
{
    public string playerName;
    public int level;
    public int stageCount = 0;
    public int saveScoreData;
    public static DataManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
