using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour {
    [Range(0.25f, 0.75f)]
    public float sphereSize;
    [Space][Range(0.5f, 5.0f)]
    public float arrivalDistance;

    [Space]
    public Vector3[] path;
    private int index;

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

    public void ReachedPoint(Vector3 pos)
    {
        if(Vector3.Distance(pos, path[index]) <= arrivalDistance)
            index++;
    }

    public Vector3 PathFollowing(PlayerBehavior player)
    {
        Vector3 desired_velocity = (path[index] - player.transform.position).normalized * player.maxSpeed;
        Vector3 steering = desired_velocity - player.GetComponent<Rigidbody>().velocity;

        steering = Vector3.ClampMagnitude(steering, player.maxForce);
        steering = steering / player.GetComponent<Rigidbody>().mass;

        return Vector3.ClampMagnitude(player.GetComponent<Rigidbody>().velocity + steering, player.maxSpeed);
    }
}
