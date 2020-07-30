using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(SpecularRenderer), PostProcessEvent.AfterStack, "Custom/Specular")]
public sealed class Specular : PostProcessEffectSettings
{
    [Range(1f, 10f)]
    public FloatParameter threshold = new FloatParameter { value = 1.0f };
    [Range(1f, 10f)]

    public FloatParameter maxValue = new FloatParameter { value = 1.0f };
}

public sealed class SpecularRenderer : PostProcessEffectRenderer<Specular>
{
    public override void Render(PostProcessRenderContext context)
    {
        var sheet = context.propertySheets.Get(Shader.Find("Hidden/Custom/Specular"));
        float maxValue = settings.threshold > settings.maxValue ? settings.threshold : settings.maxValue;
        sheet.properties.SetFloat("_Threshold", settings.threshold);
        sheet.properties.SetFloat("_MaxValue", maxValue);
        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }
}