using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightVision : MonoBehaviour
{
    public Shader PostEffect_NightVision;

    [Range(0.0f, 1.0f)] //waaay reduced
    public float BlurOffSet = 0.5f;

    public Texture2D Vignette;
   
    public Color Color;

    private Material material;

	void Start()
	{
		this.material = new Material(this.PostEffect_NightVision);
	}

    //source is cntent of screen
    //Postprocesses the image
	void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
        // => "Source + material = destination"
        material.SetTexture("VignetteTex", this.Vignette); //nnombre entre comillas es el enviado al shader
      
        material.SetColor("Color", this.Color);
        Graphics.Blit(source, destination, this.material);
	}
}
