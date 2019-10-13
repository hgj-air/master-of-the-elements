using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class MobSpawnScript : MonoBehaviour
{
    private float _timer = 0.0f;
    private float _timer2 = 0.0f;
    private System.Random rnd = new System.Random();
    private float[] XPositions;
    private float[] ZPositions;

    public float SpawnDelay;
    public GameObject[] Enemies;
    public float MapXSize;
    public float MapZSize;
    public GameObject Plane;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
      if (StateManager.Instance.Lives != 0)
      {
          _timer += Time.deltaTime;
          _timer2 += Time.deltaTime;

          if (_timer2 > 60.0f && SpawnDelay > 3.0f)
          {
              SpawnDelay -= 1.5f;
              _timer2 = 0.0f;
          }

          if (_timer > SpawnDelay)
          {
              _timer -= SpawnDelay;
              float xpos = 0;
              float zpos = 0;
              while (xpos > -10 && xpos < 10 && zpos > -10 && zpos < 10)
              {
                  xpos = (float)(rnd.NextDouble() * MapXSize - MapXSize / 2);
                  zpos = (float)(rnd.NextDouble() * MapZSize - MapZSize / 2);
              }


              Vector3 pos = new Vector3(xpos, 0, zpos);
              GameObject enemy = Instantiate(Enemies[rnd.Next(0, 4)], pos, Quaternion.Euler(0, 0, 0));
              ConstraintSource c = new ConstraintSource();
              c.weight = 1;
              c.sourceTransform = Plane.transform;
              enemy.GetComponent<LookAtConstraint>().AddSource(c);
          }
      }
    }
}


// TODO:
// Correct mob position (face to player)
// Let mobs move to player
