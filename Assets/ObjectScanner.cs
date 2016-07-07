using UnityEngine;
using System.Collections;

public class ObjectScanner : MonoBehaviour
{
	private bool zoomed = false;
	public float scanProgress = 0;
	private float scanSpeed = 0.5f;
	private Camera cam;
	public InteractiveObject CurrentObject = null;

	void Awake ()
	{
		cam = GetComponent<Camera> ();
	}

	void Update ()
	{
		zoomed = Input.GetButton ("Fire2");

		SetCurrentObject ();
		CheckForIncompleteScan ();
		if (zoomed && CurrentObject != null) {
			ProgressScan ();
		} else {
			ResetScan ();
		}
	
	}

	void CheckForIncompleteScan ()
	{
		if (CurrentObject == null && scanProgress > 0) {
			ResetScan ();
		}
	}

	void SetCurrentObject ()
	{
		RaycastHit hit;
		Ray ray = new Ray (cam.transform.position, cam.transform.forward);

		if (Physics.Raycast (ray, out hit)) {
			InteractiveObject potOBJ = hit.transform.gameObject.GetComponent<InteractiveObject> ();

			if (potOBJ == null)
				return;
			
			if (!potOBJ.interactedWith) {
				CurrentObject = potOBJ;
			} else {
				CurrentObject = null;
			}
		}
	}

	void StartScan ()
	{
		ResetScan ();
		Debug.Log ("Starting Scan...");
	}

	void ProgressScan ()
	{
		scanProgress += scanSpeed * Time.deltaTime;
		Debug.Log (scanProgress);

		if (scanProgress >= 1.0f)
			FinishScan ();
	}

	void FinishScan ()
	{
		Debug.Log ("Scan Completed!");
		CurrentObject.interactedWith = true;
		ResetScan ();
	}

	void ResetScan ()
	{
		scanProgress = 0;
		CurrentObject = null;
	}
}
