using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public Button[] buttons;
    public void LoadNextLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex + 1;

        if (index > SceneManager.sceneCountInBuildSettings)
        {
            index = 0;
        }

        SceneManager.LoadScene(index);
    }

    public void Reloadlevel()
    {
        UnpauseGame();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        UnpauseGame();

        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLevel(string level)
    {
        UnpauseGame();
        SceneManager.LoadScene(level);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    
    public void UnpauseGame()
    {
        Time.timeScale = 1;
    }
    
    public void SetSkin(int index)
    {
        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = true;
        }
        buttons[index].interactable = false;
        PlayerPrefs.SetInt(Constants.SKINS, index);
    }
}