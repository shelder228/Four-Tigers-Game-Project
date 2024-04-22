using UnityEngine;

public class SoundsController : MonoBehaviour
{
    [SerializeField] private AudioClip boxSound;
    [SerializeField] private AudioClip cactusSound;
    [SerializeField] private AudioClip canonSound;
    [SerializeField] private AudioClip metalSound;
    
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        DestroyerObject.DestroyObj += PlaySound;
    }

    private void OnDisable()
    {
        DestroyerObject.DestroyObj -= PlaySound;
    }

    private void PlaySound(TypeObjToDestroy type)
    {
        switch (type)
        {
            case TypeObjToDestroy.Box:
               
                    audioSource.PlayOneShot(boxSound);
                break;
            
            case TypeObjToDestroy.Cactus:
                
                    audioSource.PlayOneShot(cactusSound);
                break;
            
            case TypeObjToDestroy.Canon:
                
                    audioSource.PlayOneShot(canonSound);
                break;
            
            case TypeObjToDestroy.Metal:
                
                    audioSource.PlayOneShot(metalSound);
                break;
        }
    }
}