using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace yyc
{
	
	public class RadarChart : MaskableGraphic {


		[Range(3, 6)]
		public int sidesNum = 6;
		public Vector2[] vertices = new Vector2[7];		//public Vector2[] vertices = new Vector2[sidesNum + 1];
		public Color graphColor = Color.blue;

		[Range(0, 360)]
		public float rotation = 0;

		[Range(0, 1)]
		public float[] VerticesDistance = new float[6];
		public float size = 0;

		void Update ()
		{
			size = rectTransform.rect.width;
			if (rectTransform.rect.width > rectTransform.rect.height)
				size = rectTransform.rect.height;
			else
				size = rectTransform.rect.width;
		}

		protected override void OnPopulateMesh (VertexHelper vh)
		{
			vh.Clear ();

			Vector2 pos;

			float degree = 360f / sidesNum;
			int verticesNum = sidesNum + 1;

			if (VerticesDistance.Length != verticesNum) 
			{
				VerticesDistance = new float[verticesNum];
				for (int i = 0; i < verticesNum - 1; i++)
					VerticesDistance [i] = 1;
			}
			VerticesDistance [verticesNum - 1] = VerticesDistance [0];

			for (int i = 0; i < verticesNum; i++) 
			{
				float outer = -rectTransform.pivot.x * size * VerticesDistance [i];
				float rad = Mathf.Deg2Rad * (i * degree + rotation);
				float c = Mathf.Cos (rad);
				float s = Mathf.Sin (rad);

				pos = new Vector2 (outer * c, outer * s);

				vertices [i] = pos;
			}

			vh.AddVert (new Vector2(0, 0), graphColor, new Vector2(0f, 0f));

			for (int i = 0; i < sidesNum; i++) 
			{
				vh.AddVert (vertices[i], graphColor, new Vector2(1f, 1f));
			}

			vh.AddTriangle (0, 1, 2);
			vh.AddTriangle (0, 2, 3);
			vh.AddTriangle (0, 3, 4);
			vh.AddTriangle (0, 4, 5);
			vh.AddTriangle (0, 5, 6);
			vh.AddTriangle (0, 1, 6);

			//Color32 color32 = Color.red;
			//vh.AddVert(new Vector3(0, 0), color32, new Vector2(0f, 0f));
			//vh.AddVert(new Vector3(0, yyc), color32, new Vector2(0f, 1f));
			//vh.AddVert(new Vector3(100, 100), color32, new Vector2(1f, 1f));
			//vh.AddVert(new Vector3(100, 0), color32, new Vector2(1f, 0f




			//vh.AddUIVertexQuad (SetVbo(new[] {pos0, pos1, pos2, pos3}));
			//vh.AddTriangle(0, 1, 2);
			//vh.AddTriangle(2, 3, 0);
			//vh.FillMesh(m);

		}

	//	protected UIVertex[] SetVbo(Vector2[] )
	}

}