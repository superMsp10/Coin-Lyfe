using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    Rigidbody rigiBod;
    [SerializeField]
    float speed = 10f, jumpSpeed = 5f;
    [SerializeField]
    GroundChecker groundCheck;
    // Start is called before the first frame update
    void Start()
    {
        rigiBod = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float yVelo = rigiBod.velocity.y;
        if(Mathf.Abs(Input.GetAxis("Jump")) > 0.5f)
        {
            yVelo = Input.GetAxis("Jump") * jumpSpeed;
        }
        Vector3 inputVelocity = (new Vector3(Input.GetAxis("Horizontal") * speed, yVelo, Input.GetAxis("Vertical") * speed));
        if (groundCheck.isGrounded)
            rigiBod.velocity = inputVelocity;
    }
}
