using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ballons") && other.gameObject.TryGetComponent(out IBreaking breaking))
        {
            breaking.DeleteObj();
        }


        if (other.gameObject.CompareTag("BoxDestroyer"))
        {
            gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Rock"))
        {
            gameObject.SetActive(false);
        }
    }
}