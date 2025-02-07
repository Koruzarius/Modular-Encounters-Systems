﻿using ModularEncountersSystems.Spawning.Procedural.Builder;
using Sandbox.Definitions;
using System;
using System.Collections.Generic;
using System.Text;
using VRage.Game;
using VRageMath;

namespace ModularEncountersSystems.Spawning.Procedural.Hull {
	public abstract class HullTypeBase {

		public ShipConstruct Construct { get { return _construct; } set { _construct = value; } }
		public ShipRules Rules { get { return _rules; } set { _rules = value; } }
		internal ShipConstruct _construct;
		internal ShipRules _rules;

		internal List<LineData> _lineDataCollection;
		internal List<MyObjectBuilder_CubeBlock> _blockCollection;

		internal void BaseSetup(ShipRules rules) {

			_construct = new ShipConstruct(rules);
			_rules = rules;
			_lineDataCollection = new List<LineData>();
			_blockCollection = new List<MyObjectBuilder_CubeBlock>();

		}

		public void SpawnCurrentConstruct(MatrixD matrix) {

			var prefab = MyDefinitionManager.Static.GetPrefabDefinition("MES-Prefab-ProceduralPrefabDebug");

			if (prefab?.CubeGrids == null || prefab.CubeGrids.Length == 0) {

				return;

			}

			prefab.CubeGrids[0] = Construct.CubeGrid;

			PrefabSpawner.PrefabSpawnDebug("MES-Prefab-ProceduralPrefabDebug", matrix);

		}

	}
}
