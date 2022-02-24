/// <class>DirectionalBlurEffect</class>
/// <description>An effect that blurs in a single direction.</description>
sampler2D  Texture1Sampler : register(S0);
//-----------------------------------------------------------------------------------------
// Shader constant register mappings (scalars - float, double, Point, Color, Point3D, etc.)
//-----------------------------------------------------------------------------------------

/// <summary>The direction of the blur (in degrees).</summary>
/// <minValue>0</minValue>
/// <maxValue>360</maxValue>
/// <defaultValue>0</defaultValue>
float Angle : register(C0);

/// <minValue>0</minValue>
/// <maxValue>1</maxValue>
/// <defaultValue>0.0</defaultValue>
float Depth : register(C1);

/// <summary>Opacity.</summary>
/// <minValue>0</minValue>
/// <maxValue>1</maxValue>
/// <defaultValue>1</defaultValue>
float Opacity : register(C2);

/// <summary>Color.</summary>
/// <defaultValue>Black</defaultValue>
float4 Color : register(C3);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 c = 0;
    float rad = Angle * 0.0174533f;
    float xOffset = cos(rad) * Depth;
    float yOffset = sin(rad) * Depth;

    uv.x += xOffset;
    uv.y += yOffset;
    c = tex2D(Texture1Sampler, uv);
    c.rgb = Color.rgb * c.a * Opacity;
    c.a = c.a * Opacity;
    return c;
}
