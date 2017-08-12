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
                //AudioManager.instance.playsound("champion_kick");
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
		
        if (type == ATTACK_TYPE.BLOCKED)
        {
            AudioManager.instance.playsound("block");
            //return;
        }
        if (type == ATTACK_TYPE.HIGH)
        {

            isHitHigh = true;
            if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("GuardHigh"))
            {
                anim.SetBool("damagedHigh", isHitHigh);
                AudioManager.instance.playsound("damage_high",true);
                blockValue = 0;
            }
            else
            {
                AudioManager.instance.playsound("block");
                //return;
            }
        }
        else if (type == ATTACK_TYPE.LOW)
        {
            isHitLow = true;
            if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("GuardLow"))
            {
                anim.SetBool("damagedLow", isHitLow);
                AudioManager.instance.playsound("damage_low",true);
                blockValue = 0;
            }
            else
            {
                AudioManager.instance.playsound("block");
                //return;
            }
        }


        int calculatedDamage = damage - blockValue;
        if (calculatedDamage < 0)
            calculatedDamage = 0;
        health -= calculatedDamage;
        healthBar.fillAmount = ((float)health / 100.0f);

        Debug.Log(healthBar.fillAmount);

        Debug.Log(calculatedDamage);
        if (health < 50 && particleEmitter.activeSelf == false)
        {
            particleEmitter.SetActive(true);
            attack_left.damage = (int)((float)attack_left.damage * 1.5f);
            attack_right.damage = (int)((float)attack_right.damage * 1.5f);
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
                anim.SetBool("guard", false);
				//hardcode to prevent mutiple checks
				Vector3 tempSize = GetComponent<BoxCollider>().size;
				if(tempSize.y < player.playerHeight)
				{
					tempSize.y = player.playerHeight;
					GetComponent<BoxCollider>().size = tempSize;
					Vector3 temp = GetComponent<BoxCollider>().center;
					GetComponent<BoxCollider>().center = new Vector3(temp.x, CenterOfBody, temp.z);
				}
            }
        }
		if (anim.GetCurrentAnimatorStateInfo(0).IsTag("GuardHigh"))
		{
			// isBlock = false;
			blockValue = maxBlockValue;
			Vector3 temp = GetComponent<BoxCollider>().center;
			GetComponent<BoxCollider>().center = new Vector3(temp.x, CenterOfBody, temp.z);
			//anim.SetBool("guard", false);
		}
		else if (anim.GetCurrentAnimatorStateInfo(0).IsTag("GuardLow"))
		{
			blockValue = 0;
			Vector3 tempSize = GetComponent<BoxCollider>().size;
			tempSize.y = 0.9f;
			GetComponent<BoxCollider>().size = tempSize;
			Vector3 temp = GetComponent<BoxCollider>().center;
			GetComponent<BoxCollider>().center = new Vector3(temp.x, CenterOfBody/2.0f, temp.z);
		}
    }

}
