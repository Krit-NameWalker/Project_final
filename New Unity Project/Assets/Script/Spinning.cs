using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinning: MonoBehaviour
{

    
    private void Update()
    {
        transform.Rotate(new Vector3(45, 30, 15) * Time.deltaTime * 3);
    }
}
