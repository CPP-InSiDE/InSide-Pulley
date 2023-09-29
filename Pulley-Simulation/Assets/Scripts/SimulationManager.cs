using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


[System.Serializable]
public class BlockInputs
{
    public PhysicsObject affectedBlock;
    [SerializeField] public TMP_InputField blockVelocity;
    [SerializeField] public GravityArrow velocityDirection;
    [SerializeField] public TMP_InputField blockAcceleration;
    [SerializeField] public GravityArrow accelerationDirection;
}

public class SimulationManager : MonoBehaviour
{
    //public float defaultBVelocity;
    //public float defaultBAcceleration;

    [SerializeField] protected List<PhysicsObject> movingObjects;
    [SerializeField] protected PhysicsObject solutionBlock;
    //[SerializeField] protected PhysicsObject blockB;
    //[SerializeField] protected PhysicsObject userPredictionBlock;

    [SerializeField] protected SpriteRenderer userPredictionBlockSpriteRenderer;

    //[SerializeField] protected TMP_InputField velocityInput;
    //[SerializeField] protected TMP_InputField accelerationInput;

    [SerializeField] protected BlockInputs predictionBlock;
    [SerializeField] protected List<BlockInputs> inputBlocks; 

    //[SerializeField] protected TMP_InputField velocityPrediction;
    //[SerializeField] protected TMP_InputField accelerationPrediction;

    protected Color defaultPredictionColor;

    //[SerializeField] protected int directionMultiplier = 1;
    //[SerializeField] private RectTransform directionArrow;


    private void Start()
    {
        defaultPredictionColor = userPredictionBlockSpriteRenderer.color;    
    }

    public void StartSimulation() {
        foreach (BlockInputs block in inputBlocks) {
            SetBlockKinematics(block);
        }
        CalculateOutputBlocks();
        SetPlayerPrediction();
        foreach (PhysicsObject block in movingObjects) {
            block.Activate();
        }
        /*blockA.Activate();
        blockB.Activate();
        userPredictionBlock.Activate();*/
    }

    public void StopSimulation() {
        Debug.Log("Stop Simulation");
        foreach (PhysicsObject block in movingObjects)
        {
            block.Deactivate();
        }
        /*blockA.Deactivate();
        blockB.Deactivate();
        userPredictionBlock.Deactivate();*/
    }

    protected virtual void CalculateOutputBlocks() {
        /*blockA.SetVelocityMagnitude((-3f / 2) * blockB.velocity.magnitude);
        blockA.SetAccelerationMagnitude((3f / 2) * blockB.acceleration.magnitude);*/
       
    }


    protected void SetBlockKinematics(BlockInputs block) {
        float setVelocity = 0;

        float.TryParse(block.blockVelocity.text, out setVelocity);
        
        block.blockVelocity.text = "" + Mathf.Abs(setVelocity);
        setVelocity = Mathf.Abs(setVelocity) * block.velocityDirection.GetDirectionMultiplier();
        

        float setAcceleration = 0;
        float.TryParse(block.blockAcceleration.text, out setAcceleration);
        
        block.blockAcceleration.text = "" + Mathf.Abs(setAcceleration);
        setAcceleration = Mathf.Abs(setAcceleration) * block.accelerationDirection.GetDirectionMultiplier();


        block.affectedBlock.SetVelocityMagnitude(setVelocity);
        block.affectedBlock.SetAccelerationMagnitude(setAcceleration);

        
    }
    protected virtual void SetPlayerPrediction() {


        SetBlockKinematics(predictionBlock);

        if (predictionBlock.affectedBlock.velocity == solutionBlock.velocity && predictionBlock.affectedBlock.acceleration == solutionBlock.acceleration)
        {
            userPredictionBlockSpriteRenderer.color = Color.green;
        }
        else {
            userPredictionBlockSpriteRenderer.color = defaultPredictionColor;
        }
    }

    /*public void FlipDirection() {
        if((directionArrow) == null) return;
        directionMultiplier *= -1;
        directionArrow.Rotate(new Vector3(0, 0, 180f));
    }*/
}
