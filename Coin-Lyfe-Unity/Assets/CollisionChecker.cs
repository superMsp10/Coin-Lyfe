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
            if(Physics.OverlapSphere(transform.position + checkRadiusCenters[i],checkRadius[i], collisionLayers).Length > 0)
            {
                return true;
            }
        }
        return false;
    }
}
