using UnityEngine;
using System.Collections;


public class NavMeshTeleport : MonoBehaviour 
{
	public NavMeshAgent playerNav; 
	public static GameObject footprints;
	public float maxX; 
	private float holdValX, changeX;

	void Awake()
	{
		holdValX = footprints.transform.position.x; 
	}
	void Update ()
	{
		if (LookingAtStuff.Showprints)
		{
			showPrints();
		}
		if (LookingAtStuff.getTeleported)
		{
			playerNav.destination = footprints.transform.position;
		}
	}
	public void showPrints() 
	{
		if (transform.rotation.x < 0.0f )
		{
			footprints.SetActive(false);
			changeX = holdValX; 
		}
		else if (transform.rotation.x > 0.0f )
		{
			footprints.SetActive(true);
			changeX =  holdValX + (maxX / 90.0f);
		}
		else
		{
			changeX = holdValX; 
		}
		footprints.transform.position = new Vector3(footprints.transform.position.x, 0, footprints.transform.position.z);
	}
}
