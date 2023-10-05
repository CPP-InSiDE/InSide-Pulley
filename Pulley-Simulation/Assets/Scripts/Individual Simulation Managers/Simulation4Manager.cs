using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulation4Manager : SimulationManager
{
    [SerializeField] private PhysicsObject inputBlock;

    private void Start()
    {
        defaultPredictionColor = userPredictionBlockSpriteRenderer.color;
    }


    protected override void CalculateOutputBlocks()
    {
        //SetBaseBlock();
        solutionBlock.SetVelocityMagnitude((-1/6f) * inputBlock.velocity.magnitude * inputBlock.CheckOriginalVelocityDirection());
        solutionBlock.SetAccelerationMagnitude((-1/6f) * inputBlock.acceleration.magnitude * inputBlock.CheckOriginalAccelerationDirection());

        
    }

    
}
