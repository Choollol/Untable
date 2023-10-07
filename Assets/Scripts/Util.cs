using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util
{
    public static void SetZ(this Transform transform, float z)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, z);
    }
}
