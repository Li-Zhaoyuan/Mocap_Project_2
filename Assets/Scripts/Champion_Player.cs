using UnityEngine;
using System.Collections;

public class Champion_Player : player 
{
    public override void Start()
	{
		base.Start();
	}
    public override void Update()
	{
        anim.SetFloat("inputV2", Input.GetAxis("Vertical_p2"));

        Attack();
        Guard();
        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Idle") || anim.GetCurrentAnimatorStateInfo(0).IsTag("Walk"))
        {
            base.Update();
        }
		if(isAttack)
		{
			if (attackTimer < 0)
			{
				isAttack = false;
				attack_left.gameObject.SetActive(false);
				attack_right.gameObject.SetActive(false);
				attackTimer = constAttackTimer;
                AudioManager.instance.playsound("champion_kick");
            }
			else
				attackTimer -= Time.deltaTime;
		}
        anim.SetBool("damagedLow", isHitLow);
        anim.SetBool("damagedHigh", isHitHigh);
        if (isHitHigh)
        {
            //if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Damaged"))
                isHitHigh = false;
        }
        if (isHitLow)
        {
            //if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Damaged"))
                isHitLow = false;
        }
    }
	public override void TakeDamage(int damage, ATTACK_TYPE type = ATTACK_TYPE.BLOCKED)
	{
		int calculatedDamage = damage - blockValue;
		if (calculatedDamage < 0)
			calculatedDamage = 0;
		health -= calculatedDamage;
		healthBar.fillAmount = ((float)health / 100.0f);
        Debug.Log(type);
        if (type == ATTACK_TYPE.HIGH)
        {
            isHitHigh = true;
        }
        else if (type == ATTACK_TYPE.LOW)
        {
            isHitLow = true;
        }
    }

    public override void Attack()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("Guard") && isAttack == false)
        {
            if (Input.GetKey(KeyCode.F) && isAttack == false)
            {
				isAttack = true;
				//attack_left.gameObject.SetActive(true);
				attack_right.gameObject.SetActive(true);
                anim.SetBool("attack", true);
                AudioManager.instance.playsound("champion_kick");
                Debug.Log("ickk");
				attackTimer = anim.GetCurrentAnimatorStateInfo(0).length - 0.2f;
				Debug.Log(attackTimer);
                //anim.SetFloat("inputV2", Input.GetAxis("Vertical_p2"));
            }
            else
            {
                anim.SetBool("attack", false);
            }
        }
    }

    public override void Guard()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Idle"))
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                anim.SetBool("guard", true);
				blockValue = 10;
                //anim.SetFloat("inputV2" ,Input.GetAxis("Vertical_p2"));
            }
            else
            {
				blockValue = 0;
                anim.SetBool("guard", false);
            }
        }
    }

}
