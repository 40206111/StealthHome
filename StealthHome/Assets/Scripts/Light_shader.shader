Shader "Custom/Light_shader"
{
	Properties
	{
		_MainTex("Image", 2D) = "white" {}
		_colour("Tint colour", Color) = (0.0, 0.121, 0.246, 0.8)
	}

	SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag

			#include "UnityCG.cginc"

			sampler2D _MainTex;
			float4 _colour;

			uniform Vector light_pos[1];

			float4 frag(v2f_img im) : COLOR
			{
				float4 c = tex2D(_MainTex, im.uv);
				float alpha = _colour.a;
				for (int i = 0; i < 1; i++)
				{
					if (distance(light_pos[i].xy, im.pos.xy) < 550.8)
					{
						alpha = distance(light_pos[i].xy, im.pos.xy);
					}
				}

				float4 result = lerp(c, _colour, alpha);
				//result.r = 1.0;
				result.a = 1.0;
				return result;
			}
			ENDCG
		}
	}
}