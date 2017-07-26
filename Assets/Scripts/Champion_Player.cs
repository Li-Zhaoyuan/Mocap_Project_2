using UnityEngine;
using System.Collections;

public class Champion_Player : player 
{
	void Start()
	{
		base.Start();
	}
	void Update()
	{
		base.Update();
	}
	public override void TakeDamage(int damage)
	{
		int calculatedDamage = damage - blockValue;
		if (calculatedDamage < 0)
			calculatedDamage = 0;
		health -= calculatedDamage;
	}
}
