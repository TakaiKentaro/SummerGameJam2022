using UnityEngine;

public class Destroy : MonoBehaviour
{
	/// <summary>
	/// �Փ˂�����
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