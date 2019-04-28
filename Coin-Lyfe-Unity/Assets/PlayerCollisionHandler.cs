using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Finish":
                GameManager.instance.levManage.ProgressToNextLevel();
                break;
            case "Enemy":
                GameManager.instance.levManage.ResetCurrentLevel();
                break;
            default:
                break;
        }
    }
}
