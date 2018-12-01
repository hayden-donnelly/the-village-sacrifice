using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState : MonoBehaviour 
{
	protected bool looping;
	protected EnemyAIController motor;

	protected void Start()
	{
		motor = GetComponent<EnemyAIController>();
	}

	public virtual void Construct()
	{
		looping = true;
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
