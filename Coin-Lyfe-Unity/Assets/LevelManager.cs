using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Level[] levels;
    
    int currLevel = 0;
    GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        if(player.transform.position.y < levels[currLevel].yMin)
        {
            ResetCurrentLevel();
        }
    }

    public void StartLevels(int level)
    {
        currLevel = level;
        levels[level].OnLevelStart();
        SpawnPlayer();
    }

    public void ResetCurrentLevel()
    {
        levels[currLevel].OnLevelReset();
        SpawnPlayer();
    }

    public void ProgressToNextLevel()
    {
        levels[currLevel].OnLevelEnd();
        if (currLevel == levels.Length - 1)
        {
            currLevel = 0;
        }
        else
        {
            currLevel++;
        }
        levels[currLevel].OnLevelStart();
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        player.transform.position = levels[currLevel].spawnSpot.position;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

}
