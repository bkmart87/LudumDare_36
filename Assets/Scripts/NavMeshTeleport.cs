using UnityEngine;
using System.Collections;


public class NavMeshTeleport : MonoBehaviour 
{
	public NavMeshAgent playerNav;
	public GameObject player; 
	private Ray ray; 
	private RaycastHit hitInfo; 
	private const float SPHERECAST_RADIUS = 7.0f;
	private const float SPHERECAST_DISTANCE = 45.0f;
	private const int LAYER_INTERACTABLE = 8;
	private const int HITMASK = (1 << LAYER_INTERACTABLE);



	void Update ()
	{

		if (LookingAtStuff.getTeleported)
		{
			ray = new Ray (player.transform.position, player.transform.forward);
			Debug.DrawLine(ray.origin, ray.origin + new Vector3(ray.direction.x, ray.direction.y, ray.direction.z) * SPHERECAST_DISTANCE, Color.red);

			if(Physics.Raycast(ray, out hitInfo, SPHERECAST_DISTANCE, HITMASK)) 
			{
				playerNav.destination = hitInfo.point; 
				print("hi");
			}
			LookingAtStuff.getTeleported = false;
		}
	}
//	public void showPrints(bool TrueFalse) 
//	{
//		if (Camera.main.transform.rotation.x > 0.0f )
//		{
//			footprints.SetActive(true);
//			changeZ = holdValZ; 
//		}
//		else if (Camera.main.transform.rotation.x < 0.0f )
//		{
//			footprints.SetActive(false);
////			changeZ =  holdValZ + (maxZ / 90.0f) * -1.0f;
//			print("ran");
//		}
////		else
////		{
////			changeZ = holdValZ; 
////		}
//		footprints.transform.position = new Vector3(footprints.transform.position.x, 0, changeZ);
//	}
}
