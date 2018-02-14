using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {


	private Transform target;

    [Range(0, 1)]
	public float smoothSpeed;
    [Range(1, 10)]
    public float distance;
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
        //transform.LookAt(target.position + new Vector3(0, 0.5f, 0) + target.forward * 1.5f);
        transform.LookAt(target.position);
    }
}
