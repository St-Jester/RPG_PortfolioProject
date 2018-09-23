using UnityEngine;

public class ConvertToRegularMesh : MonoBehaviour {
	[ContextMenu("Convert To Regular Mesh")]
	public void Convert()
	{
		SkinnedMeshRenderer skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
		MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
		MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();

		meshFilter.sharedMesh = skinnedMeshRenderer.sharedMesh;
		meshRenderer.sharedMaterials = skinnedMeshRenderer.sharedMaterials;

		DestroyImmediate(skinnedMeshRenderer);
		DestroyImmediate(this);
	}
}
