using UnityEngine;
using System.Collections;

public class TankController : MonoBehaviour 
{	
	private Transform _transform;
	private Vector3 _translation;
	private Vector3 _rotation;
	private float _velocity = 0.95f;
	private NetworkView _ntView;
	
	public float moveSpeed = 15.0f;
	public float rotationSpeed = 65.0f;
	
	void Start ()
	{
		_transform = GetComponent<Transform>();
		_ntView = GetComponent<NetworkView>();
	}
	
	void Update () 
	{
		if (_ntView.isMine)
		{
			_translation.z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
			
			if (Input.GetKey(KeyCode.A))
				_translation.x = -moveSpeed * Time.deltaTime;
			else if (Input.GetKey(KeyCode.E))
				_translation.x = moveSpeed * Time.deltaTime;
			
			_rotation.y = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
			
			_transform.Translate(_translation);
			_transform.Rotate(_rotation);
			
			_translation.x *= _velocity;
			_translation.z *= _velocity;
			_rotation.y *= _velocity;
		}
	}
}
