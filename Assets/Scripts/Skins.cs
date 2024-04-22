using UnityEngine;

public class Skins : MonoBehaviour
{
    [SerializeField] private GameObject[] Heads;
    [SerializeField] private GameObject[] leftBaloons;
    [SerializeField] private GameObject[] rightBaloons;
    private void Awake()
    {
        var index = PlayerPrefs.GetInt(Constants.SKINS);

        ChangeSkin(index);
    }

    private void ChangeSkin(int index)
    {
        DiseableAll(Heads);
        DiseableAll(leftBaloons);
        DiseableAll(rightBaloons);
        
        Heads[index].SetActive(true);
        leftBaloons[index].SetActive(true);
        rightBaloons[index].SetActive(true);
    }

    private void DiseableAll(GameObject[] list)
    {
        foreach (var child in list)
        {
            child.SetActive(false);
        }
    }
    
}