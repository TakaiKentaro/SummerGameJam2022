using UnityEngine;

public class Destroy : MonoBehaviour
{
	/// <summary>
	/// è’ìÀÇµÇΩéû
	/// </summary>
	/// <param name="collision"></param>
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			Destroy(gameObject);
		}
	}
}