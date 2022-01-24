sampler2D input : register(s0);
sampler2D blend : register(s1);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 inputColor = tex2D(input, uv);
    float4 blendColor = tex2D(blend, uv);
    float4 resultColor = 0;
    float opacity = inputColor.a - blendColor.a;
    resultColor.rgb = inputColor.rgb * opacity;
    resultColor.a = opacity;

    return resultColor;
}
