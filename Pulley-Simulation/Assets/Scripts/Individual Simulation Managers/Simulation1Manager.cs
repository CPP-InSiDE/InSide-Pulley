using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulation1Manager : SimulationManager
{
    [SerializeField] private PhysicsObject inputBlock;

    private void Start()
    {
        defaultPredictionColor = userPredictionBlockSpriteRenderer.color;
    }


    protected override void CalculatePresetBlocks()
    {
        SetBaseBlock();
        solutionBlock.SetVelocityMagnitude((-3f / 2) * inputBlock.velocity.magnitude * inputBlock.CheckOriginalVelocityDirection());
        solutionBlock.SetAccelerationMagnitude((-3f / 2) * inputBlock.acceleration.magnitude * inputBlock.CheckOriginalAccelerationDirection());
    }

    protected virtual void SetBaseBlock()
    {
        float bVelocity;
        float bAcceleration;

        if (float.TryParse(velocityInput.text, out bVelocity) == false)
        {
            bVelocity = defaultBVelocity;
            velocityInput.text = "" + bVelocity;
        }

        if (float.TryParse(accelerationInput.text, out bAcceleration) == false)
        {
            bAcceleration = defaultBAcceleration;
            accelerationInput.text = "" + bAcceleration;
        }


        inputBlock.SetVelocityMagnitude(bVelocity * directionMultiplier);
        inputBlock.SetAccelerationMagnitude(bAcceleration * directionMultiplier);
    }
}
