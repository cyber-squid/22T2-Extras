using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : MonoBehaviour
{
    public int numberOfLines;
    public float lineLength;

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);

        for (int i = 0; i < numberOfLines; i++)
        {
            Gizmos.DrawLine(transform.position + new Vector3(0, (float)i, 0), new Vector3(lineLength, i, 0));
        }
    }
}
