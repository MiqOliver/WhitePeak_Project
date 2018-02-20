using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {


	private Transform target;

    [Range(0, 0.25f)]
	public float smoothSpeed;
    [Range(1, 10)]
    public float distance;
    [Range(0, 5)]
    public float lookForward;
    [Space]
    public Vector2 offset;

    // Use this for initializtion
    private void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    private void FixedUpdate(){
        //cam position
        Vector3 desiredPosition = target.position + target.right * distance;
        desiredPosition.y = target.position.y + offset.y;
        desiredPosition += target.forward * offset.x;

        transform.position = Vector3.Lerp (transform.position, desiredPosition, smoothSpeed);

        //cam lookAt
        transform.LookAt(target.position + target.transform.forward * lookForward);
    }
}
