using UnityEngine;
using System.Collections;

public class AscentShader : MonoBehaviour {

	// public data
	public float _blurAmount = 0.5f;
	//private data
	private Material mat;
	private Shader shader;


	void Start() 
	{
		shader = Shader.Find( "Custom/PostShader" );
		mat = new Material (shader);
		mat.SetFloat("_blurAmount", _blurAmount);
	}
 
	// Called by the camera to apply the image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination){
	 
	 //mat is the material containing your shader
	 //mat.SetFloat("time", Mathf.Sin(Time.time * Time.deltaTime));
	 Graphics.Blit(source,destination,mat);
	}
}
