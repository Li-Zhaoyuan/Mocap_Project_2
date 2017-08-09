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
        anim.SetFloat("inputH2", Input.GetAxis("Horizontal"));
        Attack();
        Guard();
        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Idle") || anim.GetCurrentAnimatorStateInfo(0).IsTag("Walk"))
        {
            base.Update();
        }
        else
        {
            movementValue = 0;
        }
		if (isAttack)
		{
			float atkState = anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
			if (atkState + 0.05f >= (float)((int)atkState + 1))
			{
				isAttack = false;
				attack_left.gameObject.SetActive(false);
				attack_right.gameObject.SetActive(false);
			}
		}
       
    }

    private void LateUpdate()
    {
        if (isHitHigh)
        {
            //if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Damaged"))
            isHitHigh = false;
            anim.SetBool("damagedHigh", isHitHigh);
        }
        if (isHitLow)
        {
            //if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Damaged"))
            isHitLow = false;
            anim.SetBool("damagedLow", isHitLow);
        }
    }
    public override void TakeDamage(int damage, ATTACK_TYPE type = ATTACK_TYPE.BLOCKED)
	{
		int calculatedDamage = damage - blockValue;
		if (calculatedDamage < 0)
			calculatedDamage = 0;
		health -= calculatedDamage;
		healthBar.fillAmount = ((float)health / 100.0f);
        //if(isBlock)
        //run sound
        if (type == ATTACK_TYPE.HIGH)
        {

            isHitHigh = true;
            if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("Guard"))
            {
                anim.SetBool("damagedHigh", isHitHigh);
            }
        }
        else if (type == ATTACK_TYPE.LOW)
        {
            isHitLow = true;
            if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("Guard"))
            {
                anim.SetBool("damagedLow", isHitLow);
            }
        }
    }

    public override void Attack()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("Guard")
             && !anim.GetCurrentAnimatorStateInfo(0).IsTag("Walk"))
        {
            if (Input.GetKey(KeyCode.Keypad0))
            {
				if(isAttack == false)
				{
					isAttack = true;
					//attack_left.gameObject.SetActive(true);
					attack_right.gameObject.SetActive(true);
					anim.SetBool("attack", true);
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
