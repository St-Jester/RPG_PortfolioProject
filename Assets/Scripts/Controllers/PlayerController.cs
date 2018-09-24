using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour {

	PlayerMotor motor;
	Camera cam;
	public LayerMask lm;
	[HideInInspector]
	public Interactable focus;
	public float clickDistance = 1000f;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
		motor = GetComponent<PlayerMotor>();

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			if (EventSystem.current.IsPointerOverGameObject())
			{
				
			}
			else
			{
				Ray ray = cam.ScreenPointToRay(Input.mousePosition);

				RaycastHit hit;
				if (Physics.Raycast(ray, out hit, clickDistance, lm))
				{
					//move player
					motor.MoveToPoint(hit.point);
					// stop focus
					RemoveFocus();
					//
				}
			}
		}

		if (Input.GetMouseButtonDown(1))
		{
			if (EventSystem.current.IsPointerOverGameObject())
			{
				
			}
			else
			{
				Ray ray = cam.ScreenPointToRay(Input.mousePosition);

				RaycastHit hit;
				if (Physics.Raycast(ray, out hit, 100))
				{
					Interactable interactable = hit.collider.GetComponent<Interactable>();
					if (interactable != null)
					{
						//focus it
						SetFocus(interactable);
					}
				}
			}
		}
	}

	private void RemoveFocus()
	{
		if(focus != null)
			focus.OnDefocused();

		focus = null;
		motor.StopFolowingTarget();

	}

	private void SetFocus(Interactable newFocus)
	{
		if (newFocus != focus)
		{
			if (focus != null)
				focus.OnDefocused();

			focus = newFocus;
			motor.FollowTarget(newFocus); 
		}

		newFocus.OnFocused(transform);
	}
}
