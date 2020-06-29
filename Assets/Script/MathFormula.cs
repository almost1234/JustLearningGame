using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class MathFormula: MonoBehaviour
{
    public static float DotProductAngle(Vector2 originCord, Vector2 aCord, Vector2 bCord )
    {
        Vector2 aCordChanged = aCord - originCord;
        Vector2 bCordChanged = bCord - originCord;
        float someCombination = (Vector2.Dot(aCordChanged, bCordChanged)) / (aCordChanged.magnitude * bCordChanged.magnitude);
        return Mathf.Acos(someCombination) * Mathf.Rad2Deg;
    }

    public static Vector2 Vector3Converter(Vector3 convertedVector) 
    {
        Vector2 conversion = new Vector2();
        conversion.x = convertedVector.x;
        conversion.y = convertedVector.y;
        return conversion;
    }
}
