using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState : MonoBehaviour 
{
	protected EnemyAIController motor;

	protected void Start()
	{
		motor = GetComponent<EnemyAIController>();
	}

	public virtual void Construct()
	{
		StartCoroutine(Behaviour());
	}

	public virtual void Destruct()
	{

	}

	public virtual IEnumerator Behaviour()
	{
		yield return null;
	}
}