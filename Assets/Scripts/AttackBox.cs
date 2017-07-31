using UnityEngine;
using System.Collections;

public class AttackBox : MonoBehaviour {
	[SerializeField]
	Collider mainCollider;
	[SerializeField]
	public int damage = 0;

    public Animator anim;
	void Start()
	{
		Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), mainCollider);
	}
	void OnTriggerEnter(Collider collision)
	{
		Debug.Log("hit");
		if(collision.tag == "Player")
		{
            if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("Damaged"))
            {
                if (anim.GetCurrentAnimatorStateInfo(0).IsTag("High"))
                    collision.gameObject.GetComponent<player>().TakeDamage(damage, ATTACK_TYPE.HIGH);
                if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Low"))
                    collision.gameObject.GetComponent<player>().TakeDamage(damage, ATTACK_TYPE.LOW);
                else
                    collision.gameObject.GetComponent<player>().TakeDamage(damage);
            }
            gameObject.SetActive(false);
		}
	}
}
