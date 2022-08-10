sampler2D input : register(s0);

// new HLSL shader
// modify the comment parameters to reflect your shader parameters

/// <summary>Explain the purpose of this variable.</summary>
/// <minValue>0/minValue>
/// <maxValue>1</maxValue>
/// <defaultValue>0.52</defaultValue>
float UpperThresh : register(C0);

/// <summary>Explain the purpose of this variable.</summary>
/// <minValue>0/minValue>
/// <maxValue>1</maxValue>
/// <defaultValue>0.5</defaultValue>
float LowerThresh : register(C1);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 color;
    color = tex2D(input, uv.xy);
    if (color.a == 0 || color.a == 1 || LowerThresh == 0)
    {
        return color;
    }

    if (UpperThresh < LowerThresh)
    {
        return color;
    }

    float4 resultColor = 0;
    float opacity = 1;
    if (color.a < LowerThresh)
    {
        opacity = 0;
    }
    if (color.a > LowerThresh && color.a < UpperThresh)
    {
        opacity = (color.a - LowerThresh) / (UpperThresh - LowerThresh);
    }

    if (opacity > 0)
    {
        resultColor.rgb = color.rgb / color.a * opacity;
    }

    resultColor.a = opacity;
    return resultColor;
}
