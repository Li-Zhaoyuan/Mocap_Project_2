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
        anim.SetFloat("inputH2", Input.GetAxis("Horizontal_p2"));

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
                AudioManager.instance.playsound("champion_kick");
            }
		}
        Attack();
        Guard();
       
       
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

        Debug.Log(healthBar.fillAmount);
       
        Debug.Log(calculatedDamage);

        if (type == ATTACK_TYPE.BLOCKED)
        {
            AudioManager.instance.playsound("block");
            return;
        }
        if (type == ATTACK_TYPE.HIGH)
        {

            isHitHigh = true;
            if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("Guard"))
            {
                anim.SetBool("damagedHigh", isHitHigh);
            }
            else
            {
                AudioManager.instance.playsound("block");
                return;
            }
        }
        else if (type == ATTACK_TYPE.LOW)
        {
            isHitLow = true;
            if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("Guard"))
            {
                anim.SetBool("damagedLow", isHitLow);
            }
            else
            {
                AudioManager.instance.playsound("block");
                return;
            }
        }
    }

    public override void Attack()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("Guard") 
            && !anim.GetCurrentAnimatorStateInfo(0).IsTag("Walk")
            && anim.GetFloat("inputH") <0.1f
            && anim.GetFloat("inputH") > -0.1f)
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
        if (anim.GetBool("guard"))
        {
            anim.SetBool("guard", false);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Idle"))
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
				isBlock = true;
                anim.SetBool("guard", true);
				//blockValue = 50;
                //anim.SetFloat("inputV2" ,Input.GetAxis("Vertical_p2"));
            }
            else
            {
				isBlock = false;
// blockValue = 0;
                anim.SetBool("guard", false);
            }
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Guard"))
        {
           // isBlock = false;
            blockValue = maxBlockValue;
            //anim.SetBool("guard", false);
        }
        else
        {
            blockValue = 0;
        }
    }

}
