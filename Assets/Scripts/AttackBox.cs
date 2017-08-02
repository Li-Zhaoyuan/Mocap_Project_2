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
		if(collision.tag == "Player")
		{
			Debug.Log("hit");
            if (anim.GetCurrentAnimatorStateInfo(0).IsTag("High") || anim.GetCurrentAnimatorStateInfo(0).IsTag("Idle"))
                collision.gameObject.GetComponent<player>().TakeDamage(damage*2, ATTACK_TYPE.HIGH);
            else if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Low"))
                collision.gameObject.GetComponent<player>().TakeDamage((int)(damage*0.5f), ATTACK_TYPE.LOW);
            else
                collision.gameObject.GetComponent<player>().TakeDamage(damage);
			//if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("Damaged"))
			//{
			//}
			//collision.gameObject.GetComponent<player>().AttackFinished(false);
            gameObject.SetActive(false);
		}
	}
}
