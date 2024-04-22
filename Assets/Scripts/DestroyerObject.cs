using System;
using UnityEngine;
using UnityEngine.Serialization;

public class DestroyerObject : MonoBehaviour, IBreaking
{
    [SerializeField] private bool NotDestroy;
    [SerializeField] private TypeObjToDestroy type;

    public static event Action<TypeObjToDestroy> DestroyObj;
    public static event Action BallonsDestroy;
    
    private void OnMouseDown()
    {
        if(!NotDestroy) 
            DeleteObj();
    }
    
    public void DeleteObj()
    {
        DestroyObj?.Invoke(type);
        gameObject.SetActive(false);
        
        if(NotDestroy)
            BallonsDestroy?.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("BoxDestroyer"))
        {
            gameObject.SetActive(false);
        }
    }
}
