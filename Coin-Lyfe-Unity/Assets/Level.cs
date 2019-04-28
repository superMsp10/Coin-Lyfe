using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] Transform _spawnSpot;
    [SerializeField] int _yMin = -10;

    public int yMin
    {
        get
        {
            return _yMin;
        }
    }

    public Transform spawnSpot {
        get
        {
            return _spawnSpot;
        }
    }

    public void OnLevelStart()
    {

    }

    public void OnLevelReset()
    {

    }

    public void OnLevelEnd()
    {

    }


}
