using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform_Prefab;
    public GameObject spike_Platform_Prefab;
    public GameObject breakable_Platform;
    public GameObject[] moving_Platform;

    public float platform_Spawn_Timer = 1.8f;
    private float current_Platform_Spawn_Timer;

    private int platform_Spawn_Count;

    public float min_X = -2f, max_X = 2f;

    private void Start()
    {
        current_Platform_Spawn_Timer = platform_Spawn_Timer;
    }

    private void Update()
    {
        SpawnPlatforms();
    }

    private void SpawnPlatforms()
    {
        current_Platform_Spawn_Timer += Time.deltaTime;

        if (current_Platform_Spawn_Timer >= platform_Spawn_Timer)
        {
            platform_Spawn_Count++;

            Vector3 temp = transform.position;
            temp.x = Random.Range(min_X, max_X);

            GameObject newPlatform = null;

            if (platform_Spawn_Count < 2)
                newPlatform = Instantiate(platform_Prefab, temp, Quaternion.identity);
            else if (platform_Spawn_Count == 2)
            {
                if (Random.Range(0, 2) > 0)
                    newPlatform = Instantiate(platform_Prefab, temp, Quaternion.identity);
                else
                    newPlatform = Instantiate(moving_Platform[Random.Range(0, moving_Platform.Length)],
                     temp, Quaternion.identity);
            }
            else if (platform_Spawn_Count == 3)
            {
                if (Random.Range(0, 2) > 0)
                    newPlatform = Instantiate(platform_Prefab, temp, Quaternion.identity);
                else
                    newPlatform = Instantiate(spike_Platform_Prefab, temp, Quaternion.identity);
            }
            else if (platform_Spawn_Count == 4)
            {
                if (Random.Range(0, 2) > 0)
                    newPlatform = Instantiate(platform_Prefab, temp, Quaternion.identity);
                else
                    newPlatform = Instantiate(breakable_Platform, temp, Quaternion.identity);
            }
            
            platform_Spawn_Count = 0;

            if (newPlatform != null)
                newPlatform.transform.parent = transform;
            
            current_Platform_Spawn_Timer = 0f;
        } // spawn platforms
    }




} // class
