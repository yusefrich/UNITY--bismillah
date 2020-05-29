using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonkeyController : MonoBehaviour
{

    public LayerMask playerLayer;

    GameObject player;


	public float walkSpeed = 2;
	public float runSpeed = 6;

	public float turnSmoothTime = 0.2f;
	float turnSmoothVelocity;

	public float speedSmoothTime = 0.1f;
	float speedSmoothVelocity;
	float currentSpeed;
	CharacterController controller;
	float velocityY;
	public float gravity = -12;


    // Start is called before the first frame update
    void Start()
    {
        var playerPrefs = GameObject.FindGameObjectWithTag("Player");
        if(playerPrefs)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }else
        {
            Debug.Log("*ERROR: Player character needs to be in the player tag");
        }
        controller = GetComponent<CharacterController> ();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2 (CalculateMovementDirection().x, CalculateMovementDirection().z);
		Vector2 inputDir = input.normalized;

		if (inputDir != Vector2.zero) {
			float targetRotation = Mathf.Atan2 (inputDir.x, inputDir.y) * Mathf.Rad2Deg;
			transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
		}

		bool running = !PlayerInRange(10);
		float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
		currentSpeed = Mathf.SmoothDamp (currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

		velocityY += Time.deltaTime * gravity;
		Vector3 velocity = transform.forward * currentSpeed + Vector3.up * velocityY;
		controller.Move (velocity * Time.deltaTime);

		//transform.Translate (transform.forward * currentSpeed * Time.deltaTime, Space.World);

		if (controller.isGrounded) {
			velocityY = 0;
		}

    }
    Vector3 CalculateMovementDirection(){
        
            if(PlayerInRange(3)){
                return Vector3.zero;
            }
            return TargetDirection();
    }

    bool PlayerInRange(int rangeDistance){
        Ray ray = new Ray(transform.position, TargetDirection());
        RaycastHit hitinfo;

        if(Physics.Raycast(ray, out hitinfo, rangeDistance, playerLayer))
        {
            Debug.DrawLine(ray.origin, hitinfo.point, Color.red);
            return true;
        }else 
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * rangeDistance, Color.green);
            return false;
        }
    }

    Vector3 TargetDirection(){
        return (player.transform.position - transform.position).normalized;
    }
    
}
