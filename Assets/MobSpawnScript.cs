using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawnScript : MonoBehaviour
{
    private float _timer = 0.0f;
    private System.Random rnd = new System.Random();
    private float[] XPositions;
    private float[] ZPositions;
    
    public float SpawnDelay;
    public GameObject EnemyWater;
    public float MapXSize;
    public float MapZSize;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > SpawnDelay)
        {
            float xpos = 0;
            float zpos = 0;
            while (xpos > -10 && xpos < 10 && zpos > -10 && zpos < 10)
            {
                xpos = (float)(rnd.NextDouble() * MapXSize - MapXSize / 2);
                zpos = (float)(rnd.NextDouble() * MapZSize - MapZSize / 2);
            }
            
            
            Vector3 pos = new Vector3(xpos, 0, zpos);
            GameObject enemy = Instantiate(EnemyWater, pos, Quaternion.Euler(-pos.x, -pos.y, -pos.z));
            _timer -= SpawnDelay;
        }
    }
}
