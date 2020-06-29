using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSanity : MonoBehaviour
{
    public float sanityMeter = 100.0f; // A terrible way to implement the sanity meter system. Need to remake this in the future
    public bool enemyFollow; //  Due to the fact that enemy need to reference. Player may not need this depending on future negative effects ( decreased camera etc)
    public int enemyDamage;

    public void FixedUpdate()
    {
        if( sanityMeter < 100 && !enemyFollow )
        {
            RegainSanity();
        }

        Debug.Log("SANITY NOW IS " + sanityMeter.ToString());
    }
    public void DecreaseSanity(int amountDecrease) 
    {
        sanityMeter -= amountDecrease * Time.deltaTime;
    }

    public void RegainSanity() 
    {
        sanityMeter += 20 * Time.deltaTime;
    }
}
