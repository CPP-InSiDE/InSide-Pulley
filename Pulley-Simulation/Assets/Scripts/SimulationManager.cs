using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


[System.Serializable]
public class BlockInputs
{
    public PhysicsObject affectedBlock;
    [SerializeField] protected TMP_InputField blockVelocity;
    [SerializeField] protected TMP_InputField blockAcceleration;
}

public class SimulationManager : MonoBehaviour
{
    public float defaultBVelocity;
    public float defaultBAcceleration;

    [SerializeField] protected List<PhysicsObject> movingBlocks;
    [SerializeField] protected PhysicsObject solutionBlock;
    //[SerializeField] protected PhysicsObject blockB;
    [SerializeField] protected PhysicsObject userPredictionBlock;

    [SerializeField] protected SpriteRenderer userPredictionBlockSpriteRenderer;

    [SerializeField] protected TMP_InputField velocityInput;
    [SerializeField] protected TMP_InputField accelerationInput;

    [SerializeField] protected BlockInputs predictionBlock;
    [SerializeField] protected List<BlockInputs> inputBlocks; 

    [SerializeField] protected TMP_InputField velocityPrediction;
    [SerializeField] protected TMP_InputField accelerationPrediction;

    protected Color defaultPredictionColor;

    [SerializeField] protected int directionMultiplier = 1;
    [SerializeField] private RectTransform directionArrow;


    private void Start()
    {
        defaultPredictionColor = userPredictionBlockSpriteRenderer.color;    
    }

    public void StartSimulation() {
        CalculatePresetBlocks();
        SetPlayerPrediction();
        foreach (PhysicsObject block in movingBlocks) {
            block.Activate();
        }
        /*blockA.Activate();
        blockB.Activate();
        userPredictionBlock.Activate();*/
    }

    public void StopSimulation() {
        Debug.Log("Stop Simulation");
        foreach (PhysicsObject block in movingBlocks)
        {
            block.Deactivate();
        }
        /*blockA.Deactivate();
        blockB.Deactivate();
        userPredictionBlock.Deactivate();*/
    }

    protected virtual void CalculatePresetBlocks() {
        /*blockA.SetVelocityMagnitude((-3f / 2) * blockB.velocity.magnitude);
        blockA.SetAccelerationMagnitude((3f / 2) * blockB.acceleration.magnitude);*/
       
    }

    
    protected virtual void SetPlayerPrediction() {


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

        if (userPredictionBlock.velocity == solutionBlock.velocity && userPredictionBlock.acceleration == solutionBlock.acceleration)
        {
            userPredictionBlockSpriteRenderer.color = Color.green;
        }
        else {
            userPredictionBlockSpriteRenderer.color = defaultPredictionColor;
        }
    }

    public void FlipDirection() {
        directionMultiplier *= -1;
        directionArrow.Rotate(new Vector3(0, 0, 180f));
    }
}
