using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SimulationManager : MonoBehaviour
{
    [SerializeField] private PhysicsObject blockA;
    [SerializeField] private PhysicsObject blockB;
    [SerializeField] private PhysicsObject userPredictionBlock;

    [SerializeField] private TMP_InputField velocityPrediction;
    [SerializeField] private TMP_InputField accelerationPrediction;


    public void StartSimulation() {
        CalculateBlocks();
        SetPlayerPrediction();
        blockA.Activate();
        blockB.Activate();
        userPredictionBlock.Activate();
    }

    private void CalculateBlocks() {
        blockA.SetVelocityMagnitude((-3f / 2) * blockB.velocity.magnitude);
        blockA.SetAccelerationMagnitude((3f / 2) * blockB.acceleration.magnitude);
       // blockA.velocity =  blockA.velocity.normalized * (-3/2f) * blockB.velocity.magnitude;
        //blockA.acceleration = blockA.acceleration.normalized * (-3 / 2f) * blockB.acceleration.magnitude;
    }

    private void SetPlayerPrediction() {
        userPredictionBlock.SetVelocityMagnitude(float.Parse(velocityPrediction.text));
        userPredictionBlock.SetAccelerationMagnitude(float.Parse(accelerationPrediction.text));
    }
}
