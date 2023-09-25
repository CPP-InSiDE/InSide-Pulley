using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SimulationManager : MonoBehaviour
{
    public float defaultBVelocity;
    public float defaultBAcceleration;

    [SerializeField] private PhysicsObject blockA;
    [SerializeField] private PhysicsObject blockB;
    [SerializeField] private PhysicsObject userPredictionBlock;

    [SerializeField] private SpriteRenderer userPredictionBlockSpriteRenderer;

    [SerializeField] private TMP_InputField velocityB;
    [SerializeField] private TMP_InputField accelerationB;

    [SerializeField] private TMP_InputField velocityPrediction;
    [SerializeField] private TMP_InputField accelerationPrediction;

    private Color defaultPredictionColor;


    private void Start()
    {
        defaultPredictionColor = userPredictionBlockSpriteRenderer.color;    
    }

    public void StartSimulation() {
        SetBBlock();
        CalculateBlocks();
        SetPlayerPrediction();
        blockA.Activate();
        blockB.Activate();
        userPredictionBlock.Activate();
    }

    public void StopSimulation() {
        blockA.Deactivate();
        blockB.Deactivate();
        userPredictionBlock.Deactivate();
    }

    private void CalculateBlocks() {
        blockA.SetVelocityMagnitude((-3f / 2) * blockB.velocity.magnitude);
        blockA.SetAccelerationMagnitude((3f / 2) * blockB.acceleration.magnitude);
       
    }

    private void SetBBlock() {
        float bVelocity;
        float bAcceleration;

        if (float.TryParse(velocityB.text, out bVelocity) == false)
        {
            bVelocity = defaultBVelocity;
            velocityB.text = "" + bVelocity;
        }

        if (float.TryParse(accelerationB.text, out bAcceleration) == false)
        {
            bAcceleration = defaultBAcceleration;
            accelerationB.text = "" + bAcceleration;
        }


        blockB.SetVelocityMagnitude(bVelocity);
        blockB.SetAccelerationMagnitude(bAcceleration);
    }
    private void SetPlayerPrediction() {


        float predictedVelocity = 0;
        if (float.TryParse(velocityPrediction.text, out predictedVelocity) == false) {
            velocityPrediction.text = "" + predictedVelocity;
        }

        float predictedAcceleration = 0;
        if (float.TryParse(accelerationPrediction.text, out predictedAcceleration) == false)
        {
            accelerationPrediction.text = "" + predictedAcceleration;
        }


        userPredictionBlock.SetVelocityMagnitude(predictedVelocity);
        userPredictionBlock.SetAccelerationMagnitude(predictedAcceleration);

        if (userPredictionBlock.velocity == blockA.velocity && userPredictionBlock.acceleration == blockA.acceleration)
        {
            userPredictionBlockSpriteRenderer.color = Color.green;
        }
        else {
            userPredictionBlockSpriteRenderer.color = defaultPredictionColor;
        }
    }
}
