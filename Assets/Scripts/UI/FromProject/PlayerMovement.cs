using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    public Rigidbody2D body;
	public bool rotateToDirection = true;
    
    // Use this for initialization
    void Start()
    {
        if (body == null)
            body = GetComponent<Rigidbody2D>();
    }

	public float applyExternalRotation(Vector2 newInput)
	{
		appliedExternalRotation = true;
		lastInput = newInput;

		var rotation = body.rotation = Vector2.Angle(Vector2.up, lastInput) * (lastInput.x > 0 ? -1 : 1);
		transform.rotation = Quaternion.Euler(0, 0, body.rotation);

		return rotation;
	}
	public float applyExternalRotation(float newRotation)
	{
		appliedExternalRotation = true;
		lastInput = ( transform.rotation = Quaternion.Euler(0, 0, newRotation) ) * Vector2.up;

		var rotation = body.rotation = newRotation;
		return rotation;
	}

	public float applyRotationToMouse()
	{
		Vector2 newInput = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;

		appliedExternalRotation = true;
		lastInput = newInput;

		return body.rotation = Vector2.Angle(Vector2.up, lastInput) * (lastInput.x > 0 ? -1 : 1);
	}

	bool appliedExternalRotation;
    Vector2 lastInput;

	private void LateUpdate()
	{
		if (rotateToDirection && !appliedExternalRotation)
		{
			body.rotation = Vector2.Angle(Vector2.up, lastInput) * (lastInput.x > 0 ? -1 : 1);
		}
		appliedExternalRotation = false;
	}

	// Update is called once per frame
	void FixedUpdate()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        if ( (input.x != 0 || input.y != 0) && !appliedExternalRotation )
            lastInput = input;

		body.AddForce(input * movementSpeed * Time.fixedDeltaTime);
    }
}