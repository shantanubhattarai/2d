using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private float waitTime;
    private float initTime;
    private float nextTime;
    private int nextBulletIndex = 0;
    private GameObject[] bulletPool;

    // Start is called before the first frame update
    void Start()
    {
        bulletPool = new GameObject[10];
        initTime = Time.time;
        nextTime = initTime;
        for(int i = 0; i < 10; i++)
        {
            bulletPool[i] = (GameObject)Instantiate(bulletPrefab,bulletSpawn.position,bulletSpawn.rotation);
            bulletPool[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextTime)
        {
            SpawnBullet();
        }
    }

    private void SpawnBullet()
    {
        nextTime = Time.time + waitTime;
        bulletPool[nextBulletIndex].transform.position = bulletSpawn.position;
        bulletPool[nextBulletIndex].SetActive(true);

        if (nextBulletIndex < 9)
        {
            nextBulletIndex++;
        }
        else
        {
            nextBulletIndex = 0;
        }
    }
}
