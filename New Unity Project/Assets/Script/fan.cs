using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fan : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 moveingSpeed;

    private void FixedUpdate() 
    {
        rb.transform.Rotate(moveingSpeed);
    }

}
