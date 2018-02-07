using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour {
    [Range(0.25f, 0.75f)]
    public float sphereSize;
    [Space][Range(1.0f, 3.0f)]
    public float arrivalDistance;

    [Space]
    public Vector3[] path;
    public static int index;

    private void Awake()
    {
        index = 0;
    }

    //Function to draw the path in the scene when the GameObject is selected
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        foreach (Vector3 v in path)
        {
            Gizmos.DrawSphere(v, sphereSize);
            Gizmos.DrawWireSphere(v, arrivalDistance);
        }
        for(int i = 1; i < path.Length; i++)
            Gizmos.DrawLine(path[i - 1], path[i]);
    }
}
