sampler2D input : register(s0);

/// <summary>Amount.</summary>
/// <minValue>0</minValue>
/// <maxValue>10</maxValue>
/// <defaultValue>1</defaultValue>
float Amount : register(C0);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 srcColor = tex2D(input, uv);

    srcColor.rgb *= Amount;
    srcColor.a *= Amount;
    //srcColor.a=min(1,srcColor.a);
    return srcColor;
}