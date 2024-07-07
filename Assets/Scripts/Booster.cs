using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    [SerializeField] GameObject boosters;
    [SerializeField] Rigidbody rb;
    private void OnTriggerStay(Collider other)
    {
        for (int i = 0; i < boosters.transform.childCount; i++)
        {
            if(other.gameObject == boosters.transform.GetChild(i).gameObject)
            {
                rb.AddForce(boosters.transform.GetChild(i).forward * 20, ForceMode.Acceleration);
            }
        }

    }
}
