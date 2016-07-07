using UnityEngine;
using System.Collections;

public class ObjectScanner : MonoBehaviour
{
	private bool zoomed = false;
	public float scanProgress = 0;
	private float scanSpeed = 0.5f;
	private Camera cam;

	void Awake ()
	{
		cam = GetComponent<Camera> ();
	}

	void Update ()
	{
		zoomed = Input.GetButton ("Fire2");

		if (zoomed && LookingAtInteractiveObject ()) {
			ProgressScan ();
		} else {
			ResetScan ();
		}
	}

	bool LookingAtInteractiveObject ()
	{
		RaycastHit hit;
		Ray ray = new Ray (cam.transform.position, cam.transform.forward);

		if (Physics.Raycast (ray, out hit)) {
			if (hit.transform.gameObject.GetComponent<InteractiveObject> ()) {
				return true;
			} else {
				return false;
			}
		}

		return false;
	}

	void ProgressScan ()
	{
		if (scanProgress >= 1.0f)
			FinishScan ();
		
		scanProgress += scanSpeed * Time.deltaTime;
		Debug.Log (scanProgress);
	}

	void FinishScan ()
	{
		Debug.Log ("Scan Completed!");
		ResetScan ();
	}

	void ResetScan ()
	{
		scanProgress = 0;
	}
}
