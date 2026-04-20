using UnityEditor;
using UnityEngine;
using UnityEngine.U2D;

[InitializeOnLoad]
public static class ShapeMatchSync {
	static ShapeMatchSync() {
		EditorApplication.update += OnUpdate;
	}

	private static void OnUpdate() {
		if (EditorApplication.isPlayingOrWillChangePlaymode) return;

		foreach (var match in Object.FindObjectsByType<ShapeMatch>(FindObjectsInactive.Include, FindObjectsSortMode.None)) {
			if (match.source == null) continue;
			var target = match.GetComponent<SpriteShapeController>();
			if (target == null || target == match.source) continue;
			Sync(match.source, target);
		}
	}

	private static void Sync(SpriteShapeController src, SpriteShapeController dst) {
		var srcSpline = src.spline;
		var dstSpline = dst.spline;

		if (SplineHash(srcSpline) == SplineHash(dstSpline)) return;

		dstSpline.Clear();
		int count = srcSpline.GetPointCount();
		for (int i = 0; i < count; i++) {
			dstSpline.InsertPointAt(i, srcSpline.GetPosition(i));
			dstSpline.SetTangentMode(i, srcSpline.GetTangentMode(i));
			dstSpline.SetLeftTangent(i, srcSpline.GetLeftTangent(i));
			dstSpline.SetRightTangent(i, srcSpline.GetRightTangent(i));
			dstSpline.SetHeight(i, srcSpline.GetHeight(i));
			dstSpline.SetCorner(i, srcSpline.GetCorner(i));
			dstSpline.SetSpriteIndex(i, srcSpline.GetSpriteIndex(i));
		}
		dstSpline.isOpenEnded = srcSpline.isOpenEnded;

		dst.RefreshSpriteShape();
		if (dst.autoUpdateCollider) dst.BakeCollider();
		EditorUtility.SetDirty(dst);
	}

	private static int SplineHash(Spline spline) {
		unchecked {
			int h = spline.isOpenEnded ? 1 : 0;
			int count = spline.GetPointCount();
			h = h * 31 + count;
			for (int i = 0; i < count; i++) {
				h = h * 31 + spline.GetPosition(i).GetHashCode();
				h = h * 31 + spline.GetLeftTangent(i).GetHashCode();
				h = h * 31 + spline.GetRightTangent(i).GetHashCode();
				h = h * 31 + (int)spline.GetTangentMode(i);
				h = h * 31 + spline.GetHeight(i).GetHashCode();
				h = h * 31 + spline.GetCorner(i).GetHashCode();
				h = h * 31 + spline.GetSpriteIndex(i);
			}
			return h;
		}
	}
}
