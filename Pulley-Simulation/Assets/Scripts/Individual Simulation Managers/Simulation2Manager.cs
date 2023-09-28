using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulation2Manager : SimulationManager
{
    [SerializeField] private PhysicsObject inputBlock;
    [SerializeField] private PhysicsObject pulley;

    private void Start()
    {
        defaultPredictionColor = userPredictionBlockSpriteRenderer.color;
    }


    protected override void CalculateOutputBlocks()
    {
        //SetBaseBlock();
        solutionBlock.SetVelocityMagnitude((-4f) * inputBlock.velocity.magnitude * inputBlock.CheckOriginalVelocityDirection());
        solutionBlock.SetAccelerationMagnitude((-4f) * inputBlock.acceleration.magnitude * inputBlock.CheckOriginalAccelerationDirection());

        pulley.SetVelocityMagnitude((2f) * inputBlock.velocity.magnitude * inputBlock.CheckOriginalVelocityDirection());
        pulley.SetAccelerationMagnitude((2f) * inputBlock.acceleration.magnitude * inputBlock.CheckOriginalAccelerationDirection());
    }

    /*protected virtual void SetBaseBlock()
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


        inputBlock.SetVelocityMagnitude(bVelocity);
        inputBlock.SetAccelerationMagnitude(bAcceleration);
    }*/
}
