using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxBoundaryDestory : MonoBehaviour
{

    void OnCollisionEnter2D()
    {
        Destroy(gameObject);
    }

}
