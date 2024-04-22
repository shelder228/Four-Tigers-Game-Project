using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Rigidbody2D rb;

    public static event Action PlayerWin;
    public static event Action PlayerLose;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.mass = Constants.NormalMass;
    }

    private void OnEnable()
    {
        DestroyerObject.BallonsDestroy += DicreaseMass;
    }

    private void OnDisable()
    {
        DestroyerObject.BallonsDestroy -= DicreaseMass;
    }

    private void DicreaseMass()
    {
        rb.mass = Constants.DicreasesMass;
        
        //can Add effects
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        {
            WinLevel();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("BoxDestroyer"))
        {
            gameObject.SetActive(false);

            LoseGame();
        }
    }

    private void WinLevel()
    {
        PlayerWin?.Invoke();
    }
    private void LoseGame()
    {
        PlayerLose?.Invoke();
    }
}