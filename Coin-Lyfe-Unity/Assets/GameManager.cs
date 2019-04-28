using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public LevelManager levManage
    {
        get
        {
            return _levManager;
        }
    }

    [SerializeField]
    LevelManager _levManager;
    [SerializeField]
    int startLevel = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Gamemanager already exists, destroying this one!");
            Destroy(this);
        }
    }

    private void Start()
    {
        _levManager.StartLevels(startLevel);
    }




}
