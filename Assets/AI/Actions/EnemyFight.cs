using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class EnemyFight : RAINAction
{

    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
		//ai.Body.GetComponent<Animator>().SetTrigger("Weel");

	}

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}