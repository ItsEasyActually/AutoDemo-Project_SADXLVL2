﻿using SharpDX;
using SharpDX.Direct3D9;
using SonicRetro.SAModel;
using SonicRetro.SAModel.Direct3D;
using SonicRetro.SAModel.SAEditorCommon.DataTypes;
using SonicRetro.SAModel.SAEditorCommon.SETEditing;
using System.Collections.Generic;
using BoundingSphere = SonicRetro.SAModel.BoundingSphere;
using Mesh = SonicRetro.SAModel.Direct3D.Mesh;

namespace SADXObjectDefinitions.WindyValley
{
	public class Dome1 : ObjectDefinition
	{
		protected NJS_OBJECT Base;
		protected Mesh[] BaseMsh;
		protected NJS_OBJECT Fan;
		protected Mesh[] FanMsh;
		protected NJS_OBJECT Cap;
		protected Mesh[] CapMsh;

		public override void Init(ObjectData data, string name)
		{
			Base = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/Dome_Base.sa1mdl");
			BaseMsh = ObjectHelper.GetMeshes(Base);
			Fan = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/Dome_Fan.sa1mdl");
			FanMsh = ObjectHelper.GetMeshes(Fan);
			Cap = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/Dome_Cap.sa1mdl");
			CapMsh = ObjectHelper.GetMeshes(Cap);
		}

		public override HitResult CheckHit(SETItem item, Vector3 Near, Vector3 Far, Viewport Viewport, Matrix Projection, Matrix View, MatrixStack transform)
		{
			HitResult result = HitResult.NoHit;
			transform.Push();
			transform.NJTranslate(item.Position);
			transform.NJRotateY(item.Rotation.Y);
			transform.Push();
			transform.NJTranslate(Base.Position[0], (Base.Position[1]), Base.Position[2]);
			result = HitResult.Min(result, Base.CheckHit(Near, Far, Viewport, Projection, View, transform, BaseMsh));
			transform.Pop();
			transform.Push();
			transform.NJTranslate(Fan.Position[0], (Fan.Position[1] + 30.0f), Fan.Position[2]);
			result = HitResult.Min(result, Fan.CheckHit(Near, Far, Viewport, Projection, View, transform, FanMsh));
			transform.Pop();
			transform.Push();
			transform.NJTranslate(Cap.Position[0], (Cap.Position[1] + 44.0f), Cap.Position[2]);
			result = HitResult.Min(result, Cap.CheckHit(Near, Far, Viewport, Projection, View, transform, CapMsh));
			transform.Pop();
			transform.Pop();
			return result;
		}

		public override List<RenderInfo> Render(SETItem item, Device dev, EditorCamera camera, MatrixStack transform)
		{
			List<RenderInfo> result = new List<RenderInfo>();
			transform.Push();
			transform.NJTranslate(item.Position);
			transform.NJRotateY(item.Rotation.Y);
			transform.Push();
			transform.NJTranslate(Base.Position[0], (Base.Position[1]), Base.Position[2]);
			result.AddRange(Base.DrawModelTree(dev.GetRenderState<FillMode>(RenderState.FillMode), transform, ObjectHelper.GetTextures("OBJ_WINDY"), BaseMsh));
			if (item.Selected)
				result.AddRange(Base.DrawModelTreeInvert(transform, BaseMsh));
			transform.Pop();
			transform.Push();
			transform.NJTranslate(Fan.Position[0], (Fan.Position[1] + 30.0f), Fan.Position[2]);
			result.AddRange(Fan.DrawModelTree(dev.GetRenderState<FillMode>(RenderState.FillMode), transform, ObjectHelper.GetTextures("OBJ_WINDY"), FanMsh));
			if (item.Selected)
				result.AddRange(Fan.DrawModelTreeInvert(transform, FanMsh));
			transform.Pop();
			transform.Push();
			transform.NJTranslate(Cap.Position[0], (Cap.Position[1] + 44.0f), Cap.Position[2]);
			result.AddRange(Cap.DrawModelTree(dev.GetRenderState<FillMode>(RenderState.FillMode), transform, ObjectHelper.GetTextures("OBJ_WINDY"), CapMsh));
			if (item.Selected)
				result.AddRange(Cap.DrawModelTreeInvert(transform, CapMsh));
			transform.Pop();
			transform.Pop();
			return result;
		}

		public override List<ModelTransform> GetModels(SETItem item, MatrixStack transform)
		{
			List<ModelTransform> result = new List<ModelTransform>();
			transform.Push();
			transform.NJTranslate(item.Position);
			transform.NJRotateY(item.Rotation.Y);
			transform.Push();
			transform.NJTranslate(Base.Position[0], (Base.Position[1]), Base.Position[2]);
			result.Add(new ModelTransform(Base, transform.Top));
			transform.Pop();
			transform.Push();
			transform.NJTranslate(Fan.Position[0], (Fan.Position[1] + 30.0f), Fan.Position[2]);
			result.Add(new ModelTransform(Fan, transform.Top));
			transform.Pop();
			transform.Push();
			transform.NJTranslate(Cap.Position[0], (Cap.Position[1] + 44.0f), Cap.Position[2]);
			result.Add(new ModelTransform(Cap, transform.Top));
			transform.Pop();
			transform.Pop();
			return result;
		}

		public override BoundingSphere GetBounds(SETItem item)
		{
			BoundingSphere boxSphere = new BoundingSphere() { Center = new Vertex((item.Position.X), (item.Position.Y + 15f), item.Position.Z), Radius = 100f };

			return boxSphere;
		}

		public override float DefaultXScale { get { return 0; } }

		public override float DefaultYScale { get { return 0; } }

		public override float DefaultZScale { get { return 0; } }

		public override Matrix GetHandleMatrix(SETItem item)
		{
			Matrix matrix = Matrix.Identity;

			MatrixFunctions.Translate(ref matrix, item.Position);
			MatrixFunctions.RotateY(ref matrix, item.Rotation.Y);

			return matrix;
		}

		private readonly PropertySpec[] customProperties = new PropertySpec[] {
			new PropertySpec("Fan Speed", typeof(float), "Extended", null, null, (o) => o.Scale.X, (o, v) => o.Scale.X = (float)v)
		};

		public override PropertySpec[] CustomProperties { get { return customProperties; } }

		public override string Name { get { return "Single Fan Dome"; } }
	}
}