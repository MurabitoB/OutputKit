using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(DepthRenderer), PostProcessEvent.AfterStack, "Custom/Depth")]
public sealed class Depth : PostProcessEffectSettings
{

}

public sealed class DepthRenderer : PostProcessEffectRenderer<Depth>
{
    public override void Render(PostProcessRenderContext context)
    {
        var sheet = context.propertySheets.Get(Shader.Find("Hidden/Custom/Depth"));

        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }
}