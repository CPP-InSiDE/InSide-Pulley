using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulation6Manager : SimulationManager
{
    [SerializeField] private PhysicsObject inputBlockA;
    [SerializeField] private PhysicsObject inputBlockB;
    [SerializeField] private PhysicsObject inputBlockC;
    [SerializeField] private PhysicsObject pulleyD;
    [SerializeField] private PhysicsObject pulleyC;

    private void Start()
    {
        defaultPredictionColor = userPredictionBlockSpriteRenderer.color;
    }


    protected override void CalculateOutputBlocks()
    {
        //SetBaseBlock();
        float velocityMagnitude = (   (-.25f * inputBlockA.velocity.magnitude * inputBlockA.CheckOriginalVelocityDirection())
                                    + (-2f * inputBlockB.velocity.magnitude * inputBlockB.CheckOriginalVelocityDirection())
                                    + (-1f * inputBlockC.velocity.magnitude * inputBlockC.CheckOriginalVelocityDirection()) );
        solutionBlock.SetVelocityMagnitude(velocityMagnitude);


        float accelerationMagnitude = (    (-.25f * inputBlockA.acceleration.magnitude * inputBlockA.CheckOriginalAccelerationDirection())
                                         + (-2f * inputBlockB.acceleration.magnitude * inputBlockB.CheckOriginalAccelerationDirection())
                                         + (-1f * inputBlockC.acceleration.magnitude * inputBlockC.CheckOriginalAccelerationDirection()));
        solutionBlock.SetAccelerationMagnitude(accelerationMagnitude);


        /*pulleyD.SetVelocityMagnitude(-.5f * velocityMagnitude);
        pulleyD.SetAccelerationMagnitude(-.5f * accelerationMagnitude);

        pulleyC.SetVelocityMagnitude(2f * inputBlockB.velocity.magnitude * inputBlockB.CheckOriginalVelocityDirection());
        pulleyC.SetAccelerationMagnitude(2f * inputBlockB.acceleration.magnitude * inputBlockB.CheckOriginalAccelerationDirection());*/

        float rightPulleyMagnitude = inputBlockC.velocity.magnitude * inputBlockC.CheckOriginalVelocityDirection() +
                                     -2f * inputBlockB.velocity.magnitude * inputBlockB.CheckOriginalVelocityDirection() +
                                     inputBlockA.velocity.magnitude * inputBlockA.CheckOriginalVelocityDirection();

        float leftPulleyMagnitude = velocityMagnitude + 2f * rightPulleyMagnitude +
                                    -2f * inputBlockC.velocity.magnitude * inputBlockC.CheckOriginalVelocityDirection() +
                                    2f * inputBlockB.velocity.magnitude * inputBlockB.CheckOriginalVelocityDirection();

        /*pulleyD.SetVelocityMagnitude(-.5f * velocityMagnitude );
        pulleyD.SetAccelerationMagnitude(-.5f * accelerationMagnitude);

        pulleyC.SetVelocityMagnitude(2f * inputBlockB.velocity.magnitude * inputBlockB.CheckOriginalVelocityDirection());
        pulleyC.SetAccelerationMagnitude(2f * inputBlockB.acceleration.magnitude * inputBlockB.CheckOriginalAccelerationDirection());*/

        pulleyD.SetVelocityMagnitude(leftPulleyMagnitude);
        pulleyD.SetAccelerationMagnitude(leftPulleyMagnitude);

        pulleyC.SetVelocityMagnitude(rightPulleyMagnitude);
        pulleyC.SetAccelerationMagnitude(rightPulleyMagnitude);
    }

   
}
