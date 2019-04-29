using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    public AudioSource sud;
    public AudioClip die, handDie, win;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Finish":
                GameManager.instance.levManage.ProgressToNextLevel();
                sud.PlayOneShot(win, .5f);
                break;
            case "Enemy":
                sud.PlayOneShot(die, .1f);
                GameManager.instance.levManage.ResetCurrentLevel();
                break;
            case "EnemyEnd":
                sud.PlayOneShot(handDie, .8f);
                other.GetComponent<Enemy>().End();
                break;
            default:
                break;
        }
    }
}
