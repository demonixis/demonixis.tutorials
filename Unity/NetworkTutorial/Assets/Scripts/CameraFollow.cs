using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	private Transform _transform;
	private Quaternion _rotation;
	public Transform target;
	public Vector3 offset = new Vector3(0, -5, 10);
	public float damping = 5;
	
	void Awake()
	{
		enabled = false;
	}
	
	void Start () 
	{
		_transform = GetComponent<Transform>();
	}
	
	void LateUpdate() 
	{		
		_rotation = Quaternion.Euler(target.transform.eulerAngles.x, target.transform.eulerAngles.y, 0);
		_transform.position = Vector3.Lerp (_transform.position, target.transform.position - (_rotation * offset), Time.deltaTime * damping);
		_transform.LookAt(target.transform);
	}
}
