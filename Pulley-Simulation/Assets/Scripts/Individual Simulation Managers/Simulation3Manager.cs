using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulation3Manager : SimulationManager
{
    [SerializeField] private PhysicsObject inputBlockB;
    [SerializeField] private PhysicsObject inputBlockC;
    [SerializeField] private PhysicsObject pulley;

    private void Start()
    {
        defaultPredictionColor = userPredictionBlockSpriteRenderer.color;
    }


    protected override void CalculateOutputBlocks()
    {
        //SetBaseBlock();
        float velocityMagnitude = (-4f * inputBlockB.velocity.magnitude * inputBlockB.CheckOriginalVelocityDirection())
                                    + (-2f * inputBlockC.velocity.magnitude * inputBlockC.CheckOriginalVelocityDirection());
        solutionBlock.SetVelocityMagnitude(velocityMagnitude);


        float accelerationMagnitude = (-4f * inputBlockB.acceleration.magnitude * inputBlockB.CheckOriginalAccelerationDirection())
                                    + (-2f * inputBlockC.acceleration.magnitude * inputBlockC.CheckOriginalAccelerationDirection());
        solutionBlock.SetAccelerationMagnitude(accelerationMagnitude);


        pulley.SetVelocityMagnitude(-.5f * velocityMagnitude);
        pulley.SetAccelerationMagnitude(-.5f * accelerationMagnitude);
    }

   
}
