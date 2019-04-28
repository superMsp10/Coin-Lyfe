using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    Rigidbody rigiBod;
    [SerializeField]
    float speed = 10f, jumpSpeed = 5f, airSpeed = .5f, wallJumpSpeed = 1.5f;
    [SerializeField]
    CollisionChecker groundCheck, wallCheck;
    int airJumpsLeft = 1;



    // Start is called before the first frame update
    void Start()
    {
        rigiBod = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        bool grounded = groundCheck.isCollided,
         walled = wallCheck.isCollided;
        Vector3 inputVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 targetVelocity = rigiBod.velocity;

       

        if (grounded)
        {
            //Grounded
            targetVelocity.x = inputVelocity.x * speed;
            targetVelocity.z = inputVelocity.z * speed;
        }
        else if (!walled)
        {
            //Airborn
            if (Mathf.Abs(inputVelocity.x) > .1)
            {
                targetVelocity.x = inputVelocity.x * speed * airSpeed;
            }
            if (Mathf.Abs(inputVelocity.z) > .1)
            {
                targetVelocity.z = inputVelocity.z * speed * airSpeed;
            }

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            Debug.Log("Jump try");
            if (grounded)
            {

                Debug.Log("Grounded jump");
                targetVelocity.y = Input.GetAxis("Jump") * jumpSpeed;
            }
            else if (walled)
            {

                Debug.Log("Wall jump");
                targetVelocity.x = -wallJumpSpeed * wallCheck.collisionDirection.x;
                targetVelocity.y = wallJumpSpeed/2;
            }
            else if (airJumpsLeft > 0)
            {
                Debug.Log("Air jump");
                targetVelocity.y = Input.GetAxis("Jump") * jumpSpeed;
                airJumpsLeft--;
            }


        }

        rigiBod.velocity = targetVelocity;
    }
}
