using UnityEngine;
using System.Collections;

public class Challenger_Player : player
{

    public override void Start()
	{
		base.Start();
	}
    public override void Update()
	{
        anim.SetFloat("inputV2", Input.GetAxis("Vertical"));
        Attack();
        Guard();
        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Idle") || anim.GetCurrentAnimatorStateInfo(0).IsTag("Walk"))
        {
            base.Update();
        }
		if (isAttack)
		{
			if (attackTimer < 0)
			{
				isAttack = false;
				attack_left.gameObject.SetActive(false);
				attack_right.gameObject.SetActive(false);
				attackTimer = constAttackTimer;
			}
			else
				attackTimer -= Time.deltaTime;
		}
        if (isHitHigh)
        {
            //if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Damaged"))
			isHitHigh = false;
			anim.SetBool("damagedHigh", isHitHigh);
        }
        if (isHitLow)
        {
            isHitLow = false;
			anim.SetBool("damagedLow",isHitLow);
        }
    }
	public override void TakeDamage(int damage, ATTACK_TYPE type = ATTACK_TYPE.BLOCKED)
	{
		int calculatedDamage = damage - blockValue;
		if (calculatedDamage < 0)
			calculatedDamage = 0;
		health -= calculatedDamage;
		healthBar.fillAmount = ((float)health / 100.0f);
		if(isBlock)
			//run sound
        if(type == ATTACK_TYPE.HIGH)
        {
            isHitHigh = true;
			anim.SetBool("damagedHigh", isHitHigh);
        }
        else if(type == ATTACK_TYPE.LOW)
        {
            isHitLow = true;
			anim.SetBool("damagedLow", isHitLow);
        }
	}

    public override void Attack()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("Guard") )
        {
            if (Input.GetKey(KeyCode.Keypad0))
            {
				if(isAttack == false)
				{
					isAttack = true;
					//attack_left.gameObject.SetActive(true);
					attack_right.gameObject.SetActive(true);
					anim.SetBool("attack", true);
					attackTimer = anim.GetCurrentAnimatorStateInfo(0).length;
                    AudioManager.instance.playsound("challenger_punch");
                }
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
            if (Input.GetKeyDown(KeyCode.KeypadPeriod))
            {
				isBlock = true;
                anim.SetBool("guard", true);
				blockValue = 10;//trash code for now
            }
            else
            {
				isBlock = false;
                anim.SetBool("guard", false);
				blockValue = 0;
            }
        }
    }
}
