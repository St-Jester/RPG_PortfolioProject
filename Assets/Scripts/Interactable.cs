using UnityEngine;

public class Interactable : MonoBehaviour {

	public float radius = 3f;
	public Transform interactionTransform;
	bool isFocus = false;
	bool hasInteracted = false;

	Transform player;


	public virtual void Interact()
	{
		
	}

	public void OnFocused(Transform playertransform)
	{
		isFocus = true;

		player = playertransform;

		hasInteracted = false;
		
	}

	public void OnDefocused()
	{
		isFocus = false;
		player = null;

		hasInteracted = false;
	}

	private void OnDrawGizmosSelected()
	{
		if (interactionTransform == null)
			interactionTransform = transform;
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(interactionTransform.position, radius);
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(isFocus && !hasInteracted)
		{
			float distance = Vector3.Distance(player.position, interactionTransform.position);
			if(distance <= radius)
			{
				Interact();
				hasInteracted = true;
			}
		}
	}
}
