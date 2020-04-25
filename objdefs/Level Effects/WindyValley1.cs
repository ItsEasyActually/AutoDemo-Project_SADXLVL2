﻿using SA_Tools;
using SharpDX;
using SharpDX.Direct3D9;
using SonicRetro.SAModel;
using SonicRetro.SAModel.Direct3D;
using SonicRetro.SAModel.SAEditorCommon;
using SonicRetro.SAModel.SAEditorCommon.SETEditing;
using System.Collections.Generic;
using System.Globalization;
using Mesh = SonicRetro.SAModel.Direct3D.Mesh;

namespace SADXObjectDefinitions.Level_Effects
{
	class WindyValley1 : LevelDefinition
	{
		readonly NJS_OBJECT[] models = new NJS_OBJECT[5];
		readonly Mesh[][] meshes = new Mesh[5][];
		Vector3 Skybox_Scale;

		public override void Init(IniLevelData data, byte act)
		{
			SkyboxScale[] skyboxdata = SkyboxScaleList.Load("Levels/Windy Valley/Skybox Data.ini");
			if (skyboxdata.Length > act)
				Skybox_Scale = skyboxdata[act].Far.ToVector3();
			for (int i = 0; i < 5; i++)
			{
				models[i] = ObjectHelper.LoadModel("Levels/Windy Valley/Act 1/Skybox model " + (i + 1).ToString(NumberFormatInfo.InvariantInfo) + ".sa1mdl");
				meshes[i] = ObjectHelper.GetMeshes(models[i]);
			}
		}

		public override void Render(Device dev, EditorCamera cam)
		{
			List<RenderInfo> result = new List<RenderInfo>();
			MatrixStack transform = new MatrixStack();
			transform.Push();
			transform.NJTranslate(cam.Position.X, 0, cam.Position.Z);
			transform.NJScale(Skybox_Scale);
			Texture[] texs = ObjectHelper.GetTextures("WINDY_BACK");
			for (int i = 0; i < 5; i++)
				result.AddRange(models[i].DrawModelTree(dev.GetRenderState<FillMode>(RenderState.FillMode), transform, texs, meshes[i]));
			transform.Pop();
			RenderInfo.Draw(result, dev, cam);
		}
	}
}
