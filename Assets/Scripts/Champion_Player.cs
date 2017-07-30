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
       
	}
	public override void TakeDamage(int damage)
	{
		int calculatedDamage = damage - blockValue;
		if (calculatedDamage < 0)
			calculatedDamage = 0;
		health -= calculatedDamage;
	}

    public override void Attack()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsTag("Guard"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                anim.SetBool("attack", true);
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
                //anim.SetFloat("inputV2" ,Input.GetAxis("Vertical_p2"));
            }
            else
            {
                anim.SetBool("guard", false);
            }
        }
    }

}
