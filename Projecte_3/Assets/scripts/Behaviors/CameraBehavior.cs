using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {


	public Transform target;//we want get position, rotation and scale information about the target which will be followed by the cam

	public float smoothSpeed = .05f;//highest value = speed mes alta de la camara sobre el target
	public Vector3 offset;//variable que te com objectiu moure la camara en els 3 eixos(des de l'engine) perque no sigi com en primera persona
                          //en un futur ja fixarem els valors finals de la cam, tant si son fixes, com si son certs intervals

    private Vector3 desiredTarget;
     
    private void Start()
    {
        desiredTarget = target.position;
        desiredTarget += target.right * (Screen.width / 6);
    }

    private void FixedUpdate(){//es millor no utilitzar Update() perque estaries fent que la cam llegis la posicio del target al mateix temps
		//que aquest esta actualitzan la funcio Update() provocan que hi hagi una especie de "competencia" entre els 2 updates
		//que esdeve en un comparten extrañ 
	
		Vector3 desiredPosition = target.position + offset;//suma de vectors, pot pasar que la camara sen vagi molt lluny i a mes es desenfoqui
		Vector3 smoothedPosition = Vector3.Lerp (transform.position, desiredPosition, smoothSpeed);//fem una interpolacio linear per trobar
								//el punt intermig quan el target canvia de pos, es per millorar la posicio de la camara
								//el valor de smoothedPosition depen el valor smoothSpeed si sacosta mes a 0 sacostara mes a t.position i amb 1 la dPosition
								//si no saps del que parlo millor mirat "interpolacion lineal" i sera mes facil dentendre de que com tu explico xD

		transform.position = smoothedPosition; //assignem la posicio fnial a la camara

		transform.LookAt(target.position + new Vector3(0, 0.5f, 0) + target.forward * 1.5f);//i per encarar al target aquest linea parida
	}
}
