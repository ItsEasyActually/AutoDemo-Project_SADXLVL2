using SharpDX;
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
	public abstract class DynCol : ObjectDefinition
	{
		protected NJS_OBJECT model;
		protected Mesh[] meshes;

		public override HitResult CheckHit(SETItem item, Vector3 Near, Vector3 Far, Viewport Viewport, Matrix Projection, Matrix View, MatrixStack transform)
		{
			model.Position = item.Position;
			model.Rotation = item.Rotation;
			transform.Push();
			HitResult result = model.CheckHit(Near, Far, Viewport, Projection, View, transform, meshes);
			transform.Pop();
			return result;
		}

		public override List<RenderInfo> Render(SETItem item, Device dev, EditorCamera camera, MatrixStack transform)
		{
			List<RenderInfo> result = new List<RenderInfo>();
			model.Position = item.Position;
			model.Rotation = item.Rotation;
			transform.Push();
			result.AddRange(model.DrawModelTree(dev.GetRenderState<FillMode>(RenderState.FillMode), transform, ObjectHelper.GetTextures("OBJ_WINDY"), meshes));
			if (item.Selected)
				result.AddRange(model.DrawModelTreeInvert(transform, meshes));
			transform.Pop();
			return result;
		}

		public override List<ModelTransform> GetModels(SETItem item, MatrixStack transform)
		{
			List<ModelTransform> result = new List<ModelTransform>();
			model.Position = item.Position;
			model.Rotation = item.Rotation;
			transform.Push();
			result.Add(new ModelTransform(model, transform.Top));
			transform.Pop();
			return result;
		}

		public override BoundingSphere GetBounds(SETItem item)
		{
			MatrixStack transform = new MatrixStack();

			model.Position = item.Position;
			model.Rotation = item.Rotation;

			return ObjectHelper.GetModelBounds(model, transform);
		}

		public override Matrix GetHandleMatrix(SETItem item)
		{
			Matrix matrix = Matrix.Identity;

			MatrixFunctions.Translate(ref matrix, item.Position);

			return matrix;
		}
	}

	public class Sirusi2 : DynCol
	{
		public override void Init(ObjectData data, string name)
		{
			model = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/Sirusi2.sa1mdl");
			meshes = ObjectHelper.GetMeshes(model);
		}
		public override string Name { get { return "Quadruple Blue Arrow Rock Sign"; } }
	}

	public class Sirusi3 : DynCol
	{
		public override void Init(ObjectData data, string name)
		{
			model = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/Sirusi3.sa1mdl");
			meshes = ObjectHelper.GetMeshes(model);
		}
		public override string Name { get { return "Double Blue Arrow Rock Sign"; } }
	}

	public class Sirusi4 : DynCol
	{
		public override void Init(ObjectData data, string name)
		{
			model = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/Sirusi4.sa1mdl");
			meshes = ObjectHelper.GetMeshes(model);
		}
		public override string Name { get { return "Single Blue Arrow Rock Sign"; } }
	}

	public class Sirusi11 : DynCol
	{
		public override void Init(ObjectData data, string name)
		{
			model = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/Siru11.sa1mdl");
			meshes = ObjectHelper.GetMeshes(model);
		}
		public override string Name { get { return "Triple Yellow Arrow Sign"; } }
	}

	public class Sirusi12 : DynCol
	{
		public override void Init(ObjectData data, string name)
		{
			model = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/Siru12.sa1mdl");
			meshes = ObjectHelper.GetMeshes(model);
		}
		public override string Name { get { return "Single Yellow Arrow Sign"; } }
	}

	public class Sirusi13 : DynCol
	{
		public override void Init(ObjectData data, string name)
		{
			model = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/Siru13.sa1mdl");
			meshes = ObjectHelper.GetMeshes(model);
		}
		public override string Name { get { return "Small Rock Bumper"; } }
	}

	public class IHas14 : DynCol
	{
		public override void Init(ObjectData data, string name)
		{
			model = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/I Has14.sa1mdl");
			meshes = ObjectHelper.GetMeshes(model);
		}
		public override string Name { get { return "Large Pillar w/Platform"; } }
	}

	public class IHas15 : DynCol
	{
		public override void Init(ObjectData data, string name)
		{
			model = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/I Has15.sa1mdl");
			meshes = ObjectHelper.GetMeshes(model);
		}
		public override string Name { get { return "Broken Pillar in Rock"; } }
	}

	public class IHas16 : DynCol
	{
		public override void Init(ObjectData data, string name)
		{
			model = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/I Has16.sa1mdl");
			meshes = ObjectHelper.GetMeshes(model);
		}
		public override string Name { get { return "Broken Pillar"; } }
	}

	public class IHas19 : DynCol
	{
		public override void Init(ObjectData data, string name)
		{
			model = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/I Has19.sa1mdl");
			meshes = ObjectHelper.GetMeshes(model);
		}
		public override string Name { get { return "Pillar Top 3"; } }
	}

	public class LRock1 : DynCol
	{
		public override void Init(ObjectData data, string name)
		{
			model = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/LRock1.sa1mdl");
			meshes = ObjectHelper.GetMeshes(model);
		}
		public override string Name { get { return "Large Rock"; } }
	}

	public class Rock1 : DynCol
	{
		public override void Init(ObjectData data, string name)
		{
			model = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/Rock1.sa1mdl");
			meshes = ObjectHelper.GetMeshes(model);
		}
		public override string Name { get { return "Little Rock (Oval)"; } }
	}

	public class IwaB : DynCol
	{
		public override void Init(ObjectData data, string name)
		{
			model = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/IwaB.sa1mdl");
			meshes = ObjectHelper.GetMeshes(model);
		}
		public override string Name { get { return "Small Square Rock"; } }
	}

	public class Ioiwa1 : DynCol
	{
		public override void Init(ObjectData data, string name)
		{
			model = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/Ioiwa01.sa1mdl");
			meshes = ObjectHelper.GetMeshes(model);
		}
		public override string Name { get { return "Hilly Rock"; } }
	}

	public class Ioiwa2 : DynCol
	{
		public override void Init(ObjectData data, string name)
		{
			model = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/Ioiwa02.sa1mdl");
			meshes = ObjectHelper.GetMeshes(model);
		}
		public override string Name { get { return "Hilly Rock (Flattened)"; } }
	}

	public class Ioiwa3 : DynCol
	{
		public override void Init(ObjectData data, string name)
		{
			model = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/Ioiwa03.sa1mdl");
			meshes = ObjectHelper.GetMeshes(model);
		}
		public override string Name { get { return "Hilly Rock (Small)"; } }
	}

	public class SaraB1 : DynCol
	{
		public override void Init(ObjectData data, string name)
		{
			model = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/SaraB1.sa1mdl");
			meshes = ObjectHelper.GetMeshes(model);
		}
		public override string Name { get { return "Big Rock Plate 1"; } }
	}

	public class SaraB2 : DynCol
	{
		public override void Init(ObjectData data, string name)
		{
			model = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/SaraB2.sa1mdl");
			meshes = ObjectHelper.GetMeshes(model);
		}
		public override string Name { get { return "Big Rock Plate 2"; } }
	}

	public class SaraM1 : DynCol
	{
		public override void Init(ObjectData data, string name)
		{
			model = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/SaraM1.sa1mdl");
			meshes = ObjectHelper.GetMeshes(model);
		}
		public override string Name { get { return "Medium Rock Plate 1"; } }
	}

	public class SaraM2 : DynCol
	{
		public override void Init(ObjectData data, string name)
		{
			model = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/SaraM2.sa1mdl");
			meshes = ObjectHelper.GetMeshes(model);
		}
		public override string Name { get { return "Medium Rock Plate 2"; } }
	}

	public class SaraS1 : DynCol
	{
		public override void Init(ObjectData data, string name)
		{
			model = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/SaraS1.sa1mdl");
			meshes = ObjectHelper.GetMeshes(model);
		}
		public override string Name { get { return "Small Rock Plate 1"; } }
	}

	public class SaraS2 : DynCol
	{
		public override void Init(ObjectData data, string name)
		{
			model = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/SaraS2.sa1mdl");
			meshes = ObjectHelper.GetMeshes(model);
		}
		public override string Name { get { return "Small Rock Plate 2"; } }
	}

	public class IBou1 : DynCol
	{
		public override void Init(ObjectData data, string name)
		{
			model = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/IBou01.sa1mdl");
			meshes = ObjectHelper.GetMeshes(model);
		}
		public override string Name { get { return "Rock Pole (Standing)"; } }
	}

	public class IBou2 : DynCol
	{
		public override void Init(ObjectData data, string name)
		{
			model = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/IBou02.sa1mdl");
			meshes = ObjectHelper.GetMeshes(model);
		}
		public override string Name { get { return "Rock Pole (Sideways)"; } }
	}

	public class IBou03 : DynCol
	{
		public override void Init(ObjectData data, string name)
		{
			model = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/IBou03.sa1mdl");
			meshes = ObjectHelper.GetMeshes(model);
		}
		public override string Name { get { return "Rock Pole (Base)"; } }
	}

	public class IHah1 : DynCol
	{
		public override void Init(ObjectData data, string name)
		{
			model = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/IHah01.sa1mdl");
			meshes = ObjectHelper.GetMeshes(model);
		}
		public override string Name { get { return "Large Broken Ruin"; } }
	}

	public class IHah2 : DynCol
	{
		public override void Init(ObjectData data, string name)
		{
			model = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/IHah02.sa1mdl");
			meshes = ObjectHelper.GetMeshes(model);
		}
		public override string Name { get { return "Medium Broken Ruin"; } }
	}

	public class IHah3 : DynCol
	{
		public override void Init(ObjectData data, string name)
		{
			model = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/IHah03.sa1mdl");
			meshes = ObjectHelper.GetMeshes(model);
		}
		public override string Name { get { return "Small Broken Ruin"; } }
	}

	public class IDai1 : DynCol
	{
		public override void Init(ObjectData data, string name)
		{
			model = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/I Dai1.sa1mdl");
			meshes = ObjectHelper.GetMeshes(model);
		}
		public override string Name { get { return "Small Rock Stand (L Shaped)"; } }
	}

	public class IDai2 : DynCol
	{
		public override void Init(ObjectData data, string name)
		{
			model = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/I Dai2.sa1mdl");
			meshes = ObjectHelper.GetMeshes(model);
		}
		public override string Name { get { return "Medium Rock Stand (L Shaped)"; } }
	}

	public class IDai3 : DynCol
	{
		public override void Init(ObjectData data, string name)
		{
			model = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/I Dai3.sa1mdl");
			meshes = ObjectHelper.GetMeshes(model);
		}
		public override string Name { get { return "Large Rock Stand (L Shaped)"; } }
	}

	public class IDai4 : DynCol
	{
		public override void Init(ObjectData data, string name)
		{
			model = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/I Dai4.sa1mdl");
			meshes = ObjectHelper.GetMeshes(model);
		}
		public override string Name { get { return "Flat Rock Stand 1 (Square Shaped)"; } }
	}

	public class IDai5 : DynCol
	{
		public override void Init(ObjectData data, string name)
		{
			model = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/I Dai5.sa1mdl");
			meshes = ObjectHelper.GetMeshes(model);
		}
		public override string Name { get { return "Flat Rock Stand 2 (Square Shaped)"; } }
	}

	public class IDai6 : DynCol
	{
		public override void Init(ObjectData data, string name)
		{
			model = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/I Dai6.sa1mdl");
			meshes = ObjectHelper.GetMeshes(model);
		}
		public override string Name { get { return "Angled Rock Stand 1 (Square Shaped)"; } }
	}

	public class IDai7 : DynCol
	{
		public override void Init(ObjectData data, string name)
		{
			model = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/I Dai7.sa1mdl");
			meshes = ObjectHelper.GetMeshes(model);
		}
		public override string Name { get { return "Angled Rock Stand 2 (Square Shaped)"; } }
	}

	public class IDai8 : DynCol
	{
		public override void Init(ObjectData data, string name)
		{
			model = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/I Dai8.sa1mdl");
			meshes = ObjectHelper.GetMeshes(model);
		}
		public override string Name { get { return "Flat Rock Stand 3 (Square Shaped)"; } }
	}

	public class IDai9 : DynCol
	{
		public override void Init(ObjectData data, string name)
		{
			model = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/I Dai9.sa1mdl");
			meshes = ObjectHelper.GetMeshes(model);
		}
		public override string Name { get { return "Angled Rock Stand 3 (Square Shaped)"; } }
	}

	public class IDai10 : DynCol
	{
		public override void Init(ObjectData data, string name)
		{
			model = ObjectHelper.LoadModel("Objects/Levels/Windy Valley/I Dai10.sa1mdl");
			meshes = ObjectHelper.GetMeshes(model);
		}
		public override string Name { get { return "Flat Rock Stand 4 (Square Shaped)"; } }
	}
}