using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public AstarPath graph;
    private void FixedUpdate()
    {
        graph.Scan();
    }
}
