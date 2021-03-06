﻿using UnityEngine;
using System.Collections;
using Entitas;
using Priority_Queue;
using System.Collections.Generic;
using System.Linq;

public class CheckLastBlockedValiditySystem : IReactiveSystem, ISetPool {
	#region ISetPool implementation
	Group _groupMover;
	Group _groupUnblockable;
	Pool _pool;
	public void SetPool (Pool pool)
	{
		_pool = pool;
		_groupMover = pool.GetGroup (Matcher.Mover);
		_groupUnblockable = pool.GetGroup (Matcher.Unblockable);
	}
	#endregion

	#region IReactiveExecuteSystem implementation
	Queue<Entity> path;
	public void Execute (System.Collections.Generic.List<Entity> entities)
	{
		var lastBlocked = entities.SingleEntity ();

		Entity m;
		var movers = _groupMover.GetEntities ();
		for (int i = 0; i < movers.Length; i++) {
			m = movers [i];

			path = Pathfinding.FindPath (m.standOn.node, m.goal.node, _pool.nodeDistance.D, _pool.nodeDistance.D2);
			if (path == null) { // can not find path
				lastBlocked.RemoveLastBlocked ().IsUnblockable(true);
				return;
			}
		}

		lastBlocked.lastBlocked.node.ReplaceNode(true).IsBlocked(true).RemoveLastBlocked ();

		var uns = _groupUnblockable.GetEntities();
		for (int i = 0; i < uns.Length; i++) {
			uns [i].IsUnblockable(false);
		}
		_pool.NextPhase ();
	}

	#endregion

	#region IReactiveSystem implementation

	public TriggerOnEvent trigger {
		get {
			return Matcher.LastBlocked.OnEntityAdded ();
		}
	}

	#endregion
}
