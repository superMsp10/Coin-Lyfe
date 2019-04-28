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
        foreach (var item in FindObjectsOfType<Level>())
        {
            item.gameObject.SetActive(false);
        } 
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        if (player.transform.position.y < levels[currLevel].yMin)
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
        ResetEnemies();
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
        ResetEnemies();
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        player.GetComponent<PlayerMover>().Reset();
        player.transform.position = levels[currLevel].spawnSpot.position;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    public void ResetEnemies()
    {
        Enemy[] enemies = levels[currLevel].GetComponentsInChildren<Enemy>(true);
        foreach (Enemy e in enemies)
        {
            e.Reset();
        }
    }

}
