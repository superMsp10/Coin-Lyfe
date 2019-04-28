using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    Rigidbody rigiBod;
    [SerializeField]
    float speed = 10f, jumpSpeed = 5f, airSpeed = .5f;
    [SerializeField]
    CollisionChecker groundCheck, wallCheck;
    int airJumpsLeft = 1;



    // Start is called before the first frame update
    void Start()
    {
        rigiBod = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool grounded = groundCheck.isCollided,
         walled = wallCheck.isCollided;

        Debug.Log(grounded + " " +  walled);
        Vector3 inputVelocity = rigiBod.velocity;

        if (Mathf.Abs(Input.GetAxis("Jump")) > 0.5f)
        {
            if (grounded)
            {
                inputVelocity.y = Input.GetAxis("Jump") * jumpSpeed;
            }
            else if (airJumpsLeft > 0)
            {

                Debug.Log("Hello");
                inputVelocity.y = Input.GetAxis("Jump") * jumpSpeed;
                airJumpsLeft--;
            }


        }

        if (grounded)
        {
            //Grounded
            inputVelocity.x = Input.GetAxis("Horizontal") * speed;
            inputVelocity.z = Input.GetAxis("Vertical") * speed;
        }
        else if (!walled)
        {
            //Airborn
            inputVelocity.x = Input.GetAxis("Horizontal") * speed * airSpeed;
            inputVelocity.z = Input.GetAxis("Vertical") * speed * airSpeed;
        }

        rigiBod.velocity = inputVelocity;
    }
}
