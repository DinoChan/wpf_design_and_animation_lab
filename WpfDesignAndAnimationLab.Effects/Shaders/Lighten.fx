// Copyright (c) 2014 Marcus Schweda
// This file is licensed under the MIT license (see LICENSE)

sampler2D input : register(s0);

float delta : register(c0);

// RGB -> HSL
float4 hsl(float4 c) {
    float4 c2 = c.a;
    float M = max(c.r, max(c.g, c.b)),
          m =  min(c.r, min(c.g, c.b));
    float chroma = M - m;
    // Lightness
    c2[2] = (M + m) / 2;
    // Hue
    if (chroma != 0) {
        if (M == c.r)
            c2[0] = ((c.g - c.b) / chroma) % 6;
        else if (M == c.g)
            c2[0] = (c.b - c.r) / chroma + 2;
        else
            c2[0] = (c.r - c.g) / chroma + 4;
        if (c2[0] < 0)
            c2[0] += 6;
        // Saturation
        c2[1] = chroma / (1 - abs(2 * c2[2] - 1));
    } else {
        c2[0] = c2[1] = 0;
    }
    return c2;
}

float4 rgb(float4 c) {
    float4 c2 = c[3];
    float chroma = c[1] * (1 - abs(2 * c[2] - 1));
    float X = chroma * (1 - abs(c[0] % 2 - 1));
    
    if (0 <= c[0] && c[0] < 1)
        c2.rgb = float3(chroma, X, 0);
    else if (1 <= c[0] && c[0] < 2)
        c2.rgb = float3(X, chroma, 0);
    else if (2 <= c[0] && c[0] < 3)
        c2.rgb = float3(0, chroma, X);
    else if (3 <= c[0] && c[0] < 4)
        c2.rgb = float3(0, X, chroma);
    else if (4 <= c[0] && c[0] < 5)
        c2.rgb = float3(X, 0, chroma);
    else if (5 <= c[0] && c[0] < 6)
        c2.rgb = float3(chroma, 0, X);
        
    c2.rgb += c[2] - chroma / 2;
    return c2;
}

float4 main(float2 uv : TEXCOORD) : COLOR {
    float4 hcyin = hsl(tex2D(input, uv));
    if( delta>0)
    { 
    	hcyin[2] = saturate(hcyin[2] + (1-hcyin[2])* delta);
    }else
    {
    	hcyin[2] = saturate(hcyin[2] + hcyin[2] * delta);
    }
    
    return rgb(hcyin);
}