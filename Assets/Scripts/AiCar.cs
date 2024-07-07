using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AiCar : MonoBehaviour
{
    public PrometeoCarController controller;
    public Transform checkpoints;
    int checkpointCounter;
    Ray rayFWD;
    public LayerMask layerMask;
    bool hitWall = false;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        checkpointCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        rayFWD.direction = transform.forward;
        rayFWD.origin = transform.position;
        if (checkpointCounter != checkpoints.childCount)
        {
            if (Physics.Raycast(rayFWD, out RaycastHit hit, 4, layerMask, QueryTriggerInteraction.Ignore))
            {
                if (hit.distance < 2)
                {
                    controller.GoReverse();
                    hitWall = true;
                }
                if (hitWall)
                {
                    controller.TurnTowardsDirection(checkpoints.GetChild(checkpointCounter), true);
                }
            }
            else
            {

                controller.TurnTowardsDirection(checkpoints.GetChild(checkpointCounter), false);
                controller.GoForward();
                if (((2 * Mathf.PI * controller.frontLeftCollider.radius * controller.frontLeftCollider.rpm * 60) / 1000) > 75)
                {
                    try
                    {
                        controller.DecelerateCar();
                    }
                    catch
                    {

                    }

                }
            }
            controller.ResetSteeringAngle();
            if (rb.velocity.magnitude < 0.1f && !VictoryBlock.enemyWon)
            {
                StartCoroutine(CheckStuck());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "CheckPoint")
        {
            if(checkpoints.childCount-1 > checkpointCounter)
            {
                checkpointCounter = other.transform.GetSiblingIndex()+1;
            }
            
        }
    }

    private IEnumerator CheckStuck()
    {
        yield return new WaitForSeconds(3);

        if (rb.velocity.magnitude < 0.1f && !VictoryBlock.enemyWon)
        {
            transform.position = checkpoints.GetChild(checkpointCounter-1).transform.position;
            transform.rotation = checkpoints.GetChild(checkpointCounter-1).transform.rotation;
        }
    }
}
