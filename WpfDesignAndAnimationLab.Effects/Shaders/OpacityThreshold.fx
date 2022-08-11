sampler2D input : register(s0);

// new HLSL shader
// modify the comment parameters to reflect your shader parameters

/// <summary>Explain the purpose of this variable.</summary>
/// <minValue>0/minValue>
/// <maxValue>1</maxValue>
/// <defaultValue>0.5</defaultValue>
float Thresh : register(C0);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 color;
    color = tex2D(input, uv.xy);
    if (color.a == 0 || color.a == 1 || Thresh == 0)
    {
        return color;
    }
    float4 resultColor = 0;
    float opacity = color.a > Thresh ? 1 : 0;
    if (opacity > 0)
    {
        resultColor.rgb = color.rgb / color.a * opacity;
    }

    resultColor.a = opacity;
    return resultColor;
}