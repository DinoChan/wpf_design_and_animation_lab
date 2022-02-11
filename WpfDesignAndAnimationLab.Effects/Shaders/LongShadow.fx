sampler2D input : register(s0);

/// <summary>ShadowLength.</summary>
/// <minValue>0</minValue>
/// <maxValue>255</maxValue>
/// <defaultValue>100</defaultValue>
float ShadowLength : register(C0);

/// <summary>Opacity.</summary>
/// <minValue>0</minValue>
/// <maxValue>1</maxValue>
/// <defaultValue>1</defaultValue>
float Opacity : register(C1);

/// <summary>Opacity.</summary>
/// <minValue>0</minValue>
/// <maxValue>800</maxValue>
/// <defaultValue>800</defaultValue>
float Width : register(C2);

/// <summary>Opacity.</summary>
/// <minValue>0</minValue>
/// <maxValue>600</maxValue>
/// <defaultValue>600</defaultValue>
float Height : register(C3);

/// <summary>Color.</summary>
/// <defaultValue>Black</defaultValue>
float4 Color : register(C4);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 srcColor = tex2D(input, uv);
    if (srcColor.a == 1)
    {
        return srcColor;
    }

    float4 tempColor = 0;
    float2 offset = 0;
    int maxDepth = 400;
    //maxDepth=min(maxDepth, ShadowLength);
    float a = 0;
    for (float i = 1; i < maxDepth; i++)
    {
        if (i < ShadowLength)
        {
            if (a == 0)
            {
                offset = uv.xy - float2(i / Width, i / Height);
                if (offset.x > 0 && offset.y > 0)
                {
                    tempColor = tex2D(input, offset);
                    if (tempColor.a == 1)
                    {
                        a = (1 - i / max(1,ShadowLength));
                    }
                }
            }
        }
    }

    if (a == 0)
    {
        return srcColor;
    }

    a = min(1,a);
    tempColor.rgb = Color.rgb * a * Opacity;
    tempColor.a = a * Opacity;
    float4 outColor = (1 - srcColor.a) * tempColor + srcColor;
    return outColor;
}
