using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
	public UIManager UIManager;
	public RegionManager RegionManager;

	public UIEventCreator UIEventCreator;

	float horizontalSpeed = 0.1f;
	float verticalSpeed = 0.1f;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

		SelectCheck();

		MoveCheck();


		if (Input.GetKeyDown(KeyCode.Space))
		{
			RegionManager.CreateEventInEachRegion();
		}

	}

	void MoveCheck()
	{
		if (Input.GetMouseButton(1)  &&  UIEventCreator.isActiveAndEnabled == false)
		{

			float h = horizontalSpeed * Input.GetAxis("Mouse X");
			float v = verticalSpeed * Input.GetAxis("Mouse Y");
			Camera.main.transform.Translate(v * Vector3.up + h * Vector3.right);

		}
	}



	void SelectCheck()
	{

		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			if (hit.collider != null)
			{
				Debug.Log("Clicked " + hit.collider.tag);
				if (hit.collider.CompareTag("Region") && UIEventCreator.isActiveAndEnabled == false)
				{
					UIManager.RegionSelected(hit.collider.gameObject.GetComponent<Region>());
				}

			}
			else
			{
				UIManager.RegionSelected(null);
			}

		}
	}
}