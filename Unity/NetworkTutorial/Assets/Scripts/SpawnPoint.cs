using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour
{
	public Color color = new Color(0.0f, 0.8f, 0.8f, 0.3f);
	
	void OnDrawGizmos()
	{
		Gizmos.color = color;
		Gizmos.DrawCube(transform.position, transform.localScale);
	}
}
