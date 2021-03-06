﻿using UnityEngine;
using System.Collections;
using Entitas;

public class MoverInitSystem : IInitializeSystem, ISetPool {
	#region ISetPool implementation
	Pool _pool;
	public void SetPool (Pool pool)
	{
		_pool = pool;
	}

	#endregion

	#region IInitializeSystem implementation

	public void Initialize ()
	{
		var nodes = _pool.GetEntities (Matcher.Node);

		CreateMover (nodes,
			Mathf.CeilToInt (_pool.gameSettings.row-1),
			0
		).AddMover (Player.Me).AddGoal(_pool.FindExitNode(Player.Me));

		CreateMover (nodes,
			0, 
			0
		).AddMover (Player.Opponent).AddGoal(_pool.FindExitNode(Player.Opponent));
	}

	#endregion

	Entity CreateMover(Entity[] nodes, int moverX, int moverZ){
		for (int i = 0; i < nodes.Length; i++) {
			if (nodes[i].position.x == moverX && nodes[i].position.z == moverZ) {
				nodes [i].IsBeingStoodOn (true);
				return _pool.CreateEntity ()
					.AddPosition (nodes [i].position.x, nodes [i].position.z)
					.AddStandOn (nodes[i]);
			}
		}
		return null;
	}
}
