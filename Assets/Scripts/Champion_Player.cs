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
		healthBar.fillAmount = ((float)health / 100.0f) * Time.deltaTime;

        Debug.Log(healthBar.fillAmount);
       
        Debug.Log(type);
        if (type == ATTACK_TYPE.BLOCKED)
        {
            AudioManager.instance.playsound("block");
            return;
        }
        if (type == ATTACK_TYPE.HIGH)
        {
            isHitHigh = true;
			anim.SetBool("damagedHigh", isHitHigh);
        }
        else if (type == ATTACK_TYPE.LOW)
        {
            isHitLow = true;
			anim.SetBool("damagedLow", isHitLow);
        }
    }

    public override void Attack()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("Guard"))
        {
            if (Input.GetKey(KeyCode.F))
            {
				if(isAttack == false)
				{
					isAttack = true;
					//attack_left.gameObject.SetActive(true);
					attack_right.gameObject.SetActive(true);
					anim.SetBool("attack", true);
					AudioManager.instance.playsound("champion_kick");
					//Debug.Log("ickk");
					attackTimer = anim.GetCurrentAnimatorStateInfo(0).length - 0.2f;
					Debug.Log(attackTimer);
					//anim.SetFloat("inputV2", Input.GetAxis("Vertical_p2"));
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
            if (Input.GetKeyDown(KeyCode.G))
            {
				isBlock = true;
                anim.SetBool("guard", true);
				blockValue = 10;
                //anim.SetFloat("inputV2" ,Input.GetAxis("Vertical_p2"));
            }
            else
            {
				isBlock = false;
				blockValue = 0;
                anim.SetBool("guard", false);
            }
        }
    }

}
