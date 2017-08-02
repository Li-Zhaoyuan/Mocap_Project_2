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

        if (collision.tag == "Player")
        {
            //if ( collision.gameObject.GetComponent<player>().isBlock)
            //{
            //    AudioManager.instance.playsound("block");
            //    return;
            //}

            Debug.Log("hit");
            AudioManager.instance.playsound("hit_high" , true);
            if (anim.GetCurrentAnimatorStateInfo(0).IsTag("High")|| anim.GetCurrentAnimatorStateInfo(0).IsTag("Idle"))
            {
                AudioManager.instance.playsound("hit_high");
                collision.gameObject.GetComponent<player>().TakeDamage(damage * 2, ATTACK_TYPE.HIGH);
            }
            else if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Low"))
            {
                collision.gameObject.GetComponent<player>().TakeDamage((int)(damage * 0.5f), ATTACK_TYPE.LOW);
                AudioManager.instance.playsound("hit_low");
            }

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
