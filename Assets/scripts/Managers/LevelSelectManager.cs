using UnityEngine;

public class LevelSelectManager : MonoBehaviour
{
    [SerializeField] private GameObject levelSelectGameObject;
    void Start()
    {
        int totalLevels = LevelManager.levels.Length;
        int unlockedLevels = LevelManager.GetUnlockedLevelIndex();
        for (int level = 0; level < totalLevels; level++)
        {
            GameObject localObject = Instantiate(levelSelectGameObject, transform);
            if (level <= unlockedLevels)
            {
                localObject.GetComponent<LevelSelectButton>().SetLevelNumber(level);
            }
            else
            {
                localObject.GetComponent<LevelSelectButton>().SetLevelNumber(-1);
            }
        }
    }
}
