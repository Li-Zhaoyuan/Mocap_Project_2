using UnityEngine;
using System.Collections;

public class AttackBox : MonoBehaviour {
	[SerializeField]
	Collider mainCollider;
	[SerializeField]
	int damage = 0;
	void Start()
	{
		Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), mainCollider);
	}
	void OnCollisionEnter(Collision collision)
	{
		collision.gameObject.GetComponent<player>().TakeDamage(damage);
	}
}
