using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using RAIN.Representation;

[RAINAction]
public class SetPlayerTargetPosition : RAINAction
{
	public Expression PlayerTargetVariable = new Expression();

	private string _playerTargetVariableName = null;

    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);

		_playerTargetVariableName = null;
		if (PlayerTargetVariable.IsValid)
		{
			if (PlayerTargetVariable.IsVariable)
			{
				_playerTargetVariableName = PlayerTargetVariable.VariableName;
			}
		}
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		GameObject player = ai.WorkingMemory.GetItem<GameObject>("player");

		ai.WorkingMemory.SetItem<Vector3>(_playerTargetVariableName, player.transform.position);


		Debug.Log ("player.transform.position = " + player.transform.position);
		Debug.Log ("_moveTargetVariableName = " + _playerTargetVariableName);

        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}