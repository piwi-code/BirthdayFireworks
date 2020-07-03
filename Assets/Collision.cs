using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        foreach(var contact in collision.contacts)
        {
            Debug.Log("Collision: " + contact);
        }
    }
}
