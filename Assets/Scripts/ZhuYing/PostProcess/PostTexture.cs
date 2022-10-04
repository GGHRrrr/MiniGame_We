using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostTexture : MonoBehaviour
{
    public Shader postTextureShader;
    private Material postTextureMat;

    public Material material
    {
        get
        {
            postTextureMat = CheckShaderAndCreateMaterial(postTextureShader,postTextureMat);
            return postTextureMat;
        }
    }

    [SerializeField] private Texture2D texture2D;
    [Range(0.0f,1.0f)] public float alpha;

    private int textureID = Shader.PropertyToID("_Canvastex");
    private int alphaID = Shader.PropertyToID("_Alpha");

    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (material != null)
        {
            material.SetFloat(alphaID,alpha);
            material.SetTexture(textureID,texture2D);
            Graphics.Blit(src,dest,material);
        }
        else
        {
            Graphics.Blit(src, dest);
        }
    }
    
    protected Material CheckShaderAndCreateMaterial(Shader shader, Material material)
    {
        if(!shader) return null; // ��shader������

        // material�ѹ���ͬshader
        if(shader.isSupported && material && material.shader == shader) return material;

        if(!shader.isSupported) return null; // shader��֧��
        else // ����material
        {
            material = new Material(shader);
            material.hideFlags = HideFlags.DontSave; // ���󲻱���
            if(material) return material;
            else return null;
        }
    }
}
