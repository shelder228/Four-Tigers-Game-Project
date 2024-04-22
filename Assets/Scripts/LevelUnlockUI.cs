using UnityEngine;
using UnityEngine.UI;

public class LevelUnlockUI : MonoBehaviour
{
    [SerializeField] private Button[] levels;

    private void Start()
    {
        UnlockLevels();
    }

    private void UnlockLevels()
    {
        int index = PlayerPrefs.GetInt(Constants.LEVELS);

        foreach (var child in levels)
        {
            child.interactable = false;
        }
        
        for (int i = 0; i < index; i++)
        {
            levels[i].interactable = true;
        }
    }
}