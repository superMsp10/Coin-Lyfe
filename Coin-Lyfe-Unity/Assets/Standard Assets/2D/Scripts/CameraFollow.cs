using System;
using UnityEngine;


namespace UnityStandardAssets._2D
{
    public class CameraFollow : MonoBehaviour
    {
        public Vector3 margins = new Vector3(0,0,0); // Distance in the x axis the player can move before the camera follows.
        public Vector3 smooth = new Vector3(8, 8, 8); // How smoothly the camera catches up with it's target movement in the x axis.
        public Vector3 offset; // The minimum x and y coordinates the camera can have.

        [SerializeField]
        private Transform m_Player; // Reference to the player's transform.



        private bool CheckXMargin()
        {
            // Returns true if the distance between the camera and the player in the x axis is greater than the x margin.
            return Mathf.Abs(transform.position.x - m_Player.position.x) > margins.x;
        }


        private bool CheckYMargin()
        {
            // Returns true if the distance between the camera and the player in the y axis is greater than the y margin.
            return Mathf.Abs(transform.position.y - m_Player.position.y) > margins.y;
        }

        private bool CheckZMargin()
        {
            // Returns true if the distance between the camera and the player in the y axis is greater than the y margin.
            return Mathf.Abs(transform.position.z - m_Player.position.z) > margins.z;
        }


        private void Update()
        {
            TrackPlayer();
        }


        private void TrackPlayer()
        {
            // By default the target x and y coordinates of the camera are it's current x and y coordinates.
            float targetX = transform.position.x;
            float targetY = transform.position.y;
            float targetZ = transform.position.z;

            // If the player has moved beyond the x margin...
            if (CheckXMargin())
            {
                // ... the target x coordinate should be a Lerp between the camera's current x position and the player's current x position.
                targetX = Mathf.Lerp(transform.position.x, m_Player.position.x + offset.x, smooth.x*Time.deltaTime);
            }

            // If the player has moved beyond the y margin...
            if (CheckYMargin())
            {
                // ... the target y coordinate should be a Lerp between the camera's current y position and the player's current y position.
                targetY = Mathf.Lerp(transform.position.y, m_Player.position.y + offset.y, smooth.y*Time.deltaTime);
            }

            if (CheckZMargin())
            {
                // ... the target y coordinate should be a Lerp between the camera's current y position and the player's current y position.
                targetZ = Mathf.Lerp(transform.position.z, m_Player.position.z + offset.z, smooth.z * Time.deltaTime);
            }


            // Set the camera's position to the target position with the same z component.
            transform.position = new Vector3(targetX , targetY , targetZ);
        }
    }
}
