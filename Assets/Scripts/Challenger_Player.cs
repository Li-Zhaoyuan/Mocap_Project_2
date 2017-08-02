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
        anim.SetBool("damagedLow",isHitLow);
        anim.SetBool("damagedHigh", isHitHigh);
        if (isHitHigh)
        {
            //if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Damaged"))
                isHitHigh = false;
        }
        if (isHitLow)
        {
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
        if(type == ATTACK_TYPE.HIGH)
        {
            isHitHigh = true;
        }
        else if(type == ATTACK_TYPE.LOW)
        {
            isHitLow = true;
        }
	}

    public override void Attack()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("Guard") && isAttack == false)
        {
            if (Input.GetKey(KeyCode.Keypad0) && isAttack == false)
            {
				isAttack = true;
				//attack_left.gameObject.SetActive(true);
				attack_right.gameObject.SetActive(true);
				anim.SetBool("attack", true);
				attackTimer = anim.GetCurrentAnimatorStateInfo(0).length;
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
                anim.SetBool("guard", true);
				blockValue = 10;//trash code for now
            }
            else
            {
                anim.SetBool("guard", false);
				blockValue = 0;
            }
        }
    }
}
