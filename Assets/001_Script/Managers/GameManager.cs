﻿using UnityEngine;
using System.Collections;
using Entitas;
using Entitas.Unity.VisualDebugging;

public class GameManager : MonoBehaviour {
	public bool showDebug = true;
	Systems _systems;
	void Awake() {
		var pools = Pools.sharedInstance;
		pools.SetAllPools ();
		_systems = CreateSystems (pools);
	}

	void Start(){
		_systems.Initialize ();
	}

	void Update() {
		_systems.Execute ();
	}

	void OnDestroy(){
		_systems.TearDown ();
	}

	Systems CreateSystems(Pools pools) {
		Systems systems;
		if (showDebug) {
			systems = new DebugSystems ();
		} else {
			systems = new Systems ();
		}

		return systems
				//Background systems
				.Add(pools.pool.CreateSystem( new CoroutineSystem () ))
				.Add(pools.pool.CreateSystem( new CoroutineQueueSystem () ))
				.Add(pools.pool.CreateSystem( new UpdatePositionSystem () ))
				//Input systems
				.Add(pools.pool.CreateSystem( new InputCheckSystem () ))
				.Add(pools.pool.CreateSystem( new InputUIListenerSystem () ))
				//Main Game
				.Add(pools.pool.CreateSystem( new GameInitSystem () ))
				.Add(pools.pool.CreateSystem( new PlayerSetBlockSystem () ))
				.Add(pools.pool.CreateSystem( new AISetBlockSystem () ))
				.Add(pools.pool.CreateSystem( new CheckLastBlockedValiditySystem () ))
				.Add(pools.pool.CreateSystem( new MoverSetMoveToSystem () ))
				.Add(pools.pool.CreateSystem( new CheckGameOverSystem () ))
				//Node systems
				.Add(pools.pool.CreateSystem( new BoardInitSystem () ))
				.Add(pools.pool.CreateSystem( new BoardSetNeighborsSystem () ))
				.Add(pools.pool.CreateSystem( new BoardDrawSystem () ))
				//Mover systems
				.Add(pools.pool.CreateSystem( new MoverInitSystem () ))
				.Add(pools.pool.CreateSystem( new MoverDrawSystem () ))
				.Add(pools.pool.CreateSystem( new MoverMoveSystem () ))
				//Path systems
				.Add(pools.pool.CreateSystem( new PathCreateViewSystem () ))
				.Add(pools.pool.CreateSystem( new PathDrawSystem () ))
			;
	}
}
