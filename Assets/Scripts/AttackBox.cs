using UnityEngine;
using System.Collections;

public class AttackBox : MonoBehaviour {
	[SerializeField]
	Collider mainCollider;
	[SerializeField]
	public int damage = 0;
	void Start()
	{
		Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), mainCollider);
	}
	void OnTriggerEnter(Collider collision)
	{
		Debug.Log("hit");
		if(collision.tag == "Player")
		{
			collision.gameObject.GetComponent<player>().TakeDamage(damage);
			gameObject.SetActive(false);
		}
	}
}
