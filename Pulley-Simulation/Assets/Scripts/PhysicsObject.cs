using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{

    public Vector2 velocity;
    public Vector2 acceleration;

    private float activatedTime;
    private float timeSinceActivation;
    private bool active = false;
    private Vector2 startPosition;

    private void Start()
    {
        startPosition = transform.position;
        active = false;
    }

    public void Activate() {
        activatedTime = Time.time;
        active = true;
    }

    private void FixedUpdate()
    {
        if (active == true) {
            timeSinceActivation = Time.time - activatedTime;

            transform.position = startPosition + velocity * timeSinceActivation + (.5f * acceleration * timeSinceActivation * timeSinceActivation);
        }
    }

    public void SetVelocityMagnitude(float magnitude) {
        velocity = velocity.normalized * magnitude;
    }

    public void SetAccelerationMagnitude(float magnitude)
    {
        acceleration = acceleration.normalized * magnitude;
    }

}
