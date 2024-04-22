using System.Collections.Generic;
using UnityEngine;

public class ShootPool : MonoBehaviour
{
    [SerializeField] private float timeForShoot;
    [SerializeField] private int startPoolSize;
    [SerializeField] private GameObject prefabShoot;
    [SerializeField] private Transform posToShoot;

    private List<GameObject> listPool = new List<GameObject>();
    private float currentTimeShoot;
    
    private void Awake()
    {
        for (int i = 0; i < startPoolSize; i++)
        {
            var bullet = Instantiate(prefabShoot, posToShoot.position, Quaternion.identity, transform);
            
            listPool.Add(bullet);
            listPool[i].SetActive(false);
        }
    }

    private void Update()
    {
        currentTimeShoot -= Time.deltaTime;
        if (currentTimeShoot <= 0)
        {
            Shoot();
            currentTimeShoot = timeForShoot;
        }
        
        
    }

    private void Shoot()
    {
        bool InstanceNewBullet = true;
        
        foreach (var bullet in listPool)
        {
            if (!bullet.gameObject.activeSelf)
            {
                InstanceNewBullet = false;
                bullet.transform.position = posToShoot.position;
                bullet.SetActive(true);
                break;
            }
        }

        if (InstanceNewBullet)
        {
            var bullet = Instantiate(prefabShoot, posToShoot.position, Quaternion.identity, transform);
            
            listPool.Add(bullet);
        }
    }
}
