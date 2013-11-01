//  This file is part of YamlDotNet - A .NET library for YAML.
//  Copyright (c) 2008, 2009, 2010, 2011, 2012, 2013 Antoine Aubry
	
//  Permission is hereby granted, free of charge, to any person obtaining a copy of
//  this software and associated documentation files (the "Software"), to deal in
//  the Software without restriction, including without limitation the rights to
//  use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies
//  of the Software, and to permit persons to whom the Software is furnished to do
//  so, subject to the following conditions:
	
//  The above copyright notice and this permission notice shall be included in all
//  copies or substantial portions of the Software.
	
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//  SOFTWARE.

namespace SharpYaml.Serialization
{
	/// <summary>
	/// Allows an object to customize how it is serialized and deserialized.
	/// </summary>
	public interface IYamlSerializable
	{
		/// <summary>
		/// Reads this object's state from a YAML parser.
		/// </summary>
		/// <param name="context">The context.</param>
		/// <param name="value">The value.</param>
		/// <param name="typeDescriptor">The type descriptor.</param>
		/// <returns>A instance of the object deserialized from Yaml.</returns>
		ValueOutput ReadYaml(SerializerContext context, object value, ITypeDescriptor typeDescriptor);

		/// <summary>
		/// Writes this object's state to a YAML emitter.
		/// </summary>
		/// <param name="context">The context.</param>
		/// <param name="value">The value.</param>
		/// <param name="typeDescriptor"></param>
		void WriteYaml(SerializerContext context, ValueInput input, ITypeDescriptor typeDescriptor);
	}
}