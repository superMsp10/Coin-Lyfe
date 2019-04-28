using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    Vector3 startPos;
    Quaternion startRot;
    NavMeshAgent pf;
    GameObject player;


    private void Awake()
    {
        startPos = transform.position;
        startRot = transform.rotation;

        Debug.Log(startPos);
        pf = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    public void End()
    {
        gameObject.SetActive(false);
    }

    public void Reset()
    {
        gameObject.SetActive(true);
        pf.enabled = false;
        transform.position = startPos;
        transform.rotation = startRot;
        pf.enabled = true;
        pf.ResetPath();

    }

    private void FixedUpdate()
    {
        pf.destination = player.transform.position;
    }
}
