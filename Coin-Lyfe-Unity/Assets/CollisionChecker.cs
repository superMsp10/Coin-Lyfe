using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    [SerializeField]
    public Vector3[] checkRadiusCenters;
    [SerializeField]
    public float[] checkRadius;
    [SerializeField]
    LayerMask collisionLayers;

    Vector3 _collisionDirection = Vector3.zero;
    public Vector3 collisionDirection
    {
        get{
            return _collisionDirection;
        }
    }

    public bool isCollided {
        get
        {
            return checkCollision();
        }
    }

   
   bool checkCollision()
    {
        for (int i = 0; i < checkRadius.Length; i++)
        {
            Collider[] collisions = Physics.OverlapSphere(transform.position + checkRadiusCenters[i], checkRadius[i], collisionLayers);
            if (collisions.Length > 0)
            {
                Vector3 diff = (collisions[0].transform.position - transform.position);
                if(diff.x > 0)
                {
                    _collisionDirection.x = 1;
                }
                else if (Mathf.Abs(diff.x) < .1)
                {
                    _collisionDirection.x = 0;
                }
                else
                {
                    _collisionDirection.x = -1;
                }

                if (diff.y > 0)
                {
                    _collisionDirection.y = 1;
                }
                else if (Mathf.Abs(diff.y) < .1)
                {
                    _collisionDirection.y = 0;
                }
                else
                {
                    _collisionDirection.y = -1;
                }

                if (diff.z > 0)
                {
                    _collisionDirection.z = 1;
                }
                else if (Mathf.Abs(diff.z) < .1)
                {
                    _collisionDirection.z = 0;
                }
                else
                {
                    _collisionDirection.z = -1;
                }
                return true;
            }
        }
        return false;
    }
}
