using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public Transform ghost;
    public Transform ghostEye;
    private void FixedUpdate()
    {
        Debug.DrawRay(ghostEye.position, (ghostEye.position - ghost.position), Color.yellow);
        RaycastHit2D hit = Physics2D.Raycast(ghostEye.position, (ghostEye.position - ghost.position), Mathf.Infinity);
        if (hit == true) 
        {
            Debug.Log("It hit " + hit.collider.name);
        }
    }
}
