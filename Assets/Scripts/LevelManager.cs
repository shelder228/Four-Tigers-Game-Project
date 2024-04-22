using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject winCanvas;
    [SerializeField] private GameObject loseCanvas;

    private void OnEnable()
    {
        PlayerManager.PlayerWin += WinLevel;
        PlayerManager.PlayerLose += LoseLevel;
    }

    private void OnDisable()
    {
        PlayerManager.PlayerWin -= WinLevel;
        PlayerManager.PlayerLose -= LoseLevel;
    }

    private void Start()
    {
        winCanvas.SetActive(false);
        loseCanvas.SetActive(false);
    }

    public void WinLevel()
    {
        var index = PlayerPrefs.GetInt(Constants.LEVELS);
        
        if(index < SceneManager.GetActiveScene().buildIndex)
            PlayerPrefs.SetInt(Constants.LEVELS, SceneManager.GetActiveScene().buildIndex);
        
        winCanvas.SetActive(true);
    }
    
    public void LoseLevel()
    {
        loseCanvas.SetActive(true);
    }
}