using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool isGrounded {
        get
        {
            return _grounded;
        }
    }

    bool _grounded = false;

    private void OnTriggerEnter(Collider other)
    {
        _grounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _grounded = false;
    }
}
