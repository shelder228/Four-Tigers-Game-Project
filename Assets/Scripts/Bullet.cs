using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Start()
    {
        speed *= transform.parent.localScale.x;
    }

    private void Update()
    {
        transform.position += Vector3.left * speed;
    }
}