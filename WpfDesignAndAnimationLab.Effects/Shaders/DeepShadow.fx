sampler2D input : register(s0);

// new HLSL shader
// modify the comment parameters to reflect your shader parameters

/// <summary>Explain the purpose of this variable.</summary>
/// <minValue>05/minValue>
/// <maxValue>10</maxValue>
/// <defaultValue>3.5</defaultValue>
float SampleInputParam : register(C0);

float4 main(float2 uv : TEXCOORD) : COLOR 
{ 
	
	float4 color; 
	color= tex2D( input , uv.xy); 

	return color; 
}