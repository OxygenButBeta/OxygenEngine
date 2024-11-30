﻿namespace O2Shaders {
	//Just a text structure for the shaders
	// TODO: Implement a shader loader
    public struct ShaderLoader {
        public static string VertexShader = @"#version 330 core
                layout (location = 0) in vec3 aPosition; // vertex coordinates
                layout (location = 1) in vec2 aTexCoord; // texture coordinates

                out vec2 texCoord;

                // uniform variables
                uniform mat4 view;
                uniform mat4 projection;
				uniform mat4 transform;

                void main() 
                {
	                gl_Position = vec4(aPosition, 1.0) * transform * view * projection ; // coordinates
	                texCoord = aTexCoord;
                }";

        public static string FragmentShader = @"#version 330 core

                in vec2 texCoord;

                out vec4 FragColor;

                uniform sampler2D texture0;

                void main() 
                {
	                FragColor = texture(texture0, texCoord);
                }";
    }
}