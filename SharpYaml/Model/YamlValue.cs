﻿// Copyright (c) SharpYaml - Alexandre Mutel
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.Generic;
using SharpYaml.Events;
using SharpYaml.Schemas;
using SharpYaml.Serialization.Serializers;

namespace SharpYaml.Model
{
    public class YamlValue : YamlElement {
        private Scalar _scalar;

        YamlValue(Scalar scalar) {
            _scalar = scalar ?? throw new ArgumentNullException(nameof(scalar));
        }

        public YamlValue(object value, IYamlSchema schema = null) {
            var valueString = PrimitiveSerializer.ConvertValue(value);
            if (schema == null)
                schema = new CoreSchema();

            _scalar = new Scalar(schema.GetDefaultTag(value.GetType()), valueString);
        }

        public static YamlValue Load(EventReader eventReader) {
            var scalar = eventReader.Allow<Scalar>();

            return new YamlValue(scalar);
        }

        public override IEnumerable<ParsingEvent> EnumerateEvents() {
            yield return _scalar;
        }

        protected bool Equals(YamlValue other) {
            return Equals(_scalar.Value, other._scalar.Value);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((YamlValue)obj);
        }

        public override int GetHashCode() {
            return _scalar?.Value?.GetHashCode() ?? 0;
        }

        public override YamlNode DeepClone() {
            return new YamlValue(new Scalar(_scalar.Anchor,
                _scalar.Tag,
                _scalar.Value,
                _scalar.Style,
                _scalar.IsPlainImplicit,
                _scalar.IsQuotedImplicit,
                _scalar.Start,
                _scalar.End));
        }

        public override string Anchor {
            get { return _scalar.Anchor; }
            set {
                _scalar = new Scalar(value,
                    _scalar.Tag,
                    _scalar.Value,
                    _scalar.Style,
                    _scalar.IsPlainImplicit,
                    _scalar.IsQuotedImplicit,
                    _scalar.Start,
                    _scalar.End);
            }
        }

        public override string Tag {
            get { return _scalar.Tag; }
            set {
                _scalar = new Scalar(_scalar.Anchor,
                    value,
                    _scalar.Value,
                    _scalar.Style,
                    _scalar.IsPlainImplicit,
                    _scalar.IsQuotedImplicit,
                    _scalar.Start,
                    _scalar.End);
            }
        }

        public ScalarStyle Style {
            get { return _scalar.Style; }
            set {
                _scalar = new Scalar(_scalar.Anchor,
                    _scalar.Tag,
                    _scalar.Value,
                    value,
                    _scalar.IsPlainImplicit,
                    _scalar.IsQuotedImplicit,
                    _scalar.Start,
                    _scalar.End);
            }
        }

        public override bool IsCanonical { get { return _scalar.IsCanonical; } }

        public bool IsPlainImplicit {
            get { return _scalar.IsPlainImplicit; }
            set {
                _scalar = new Scalar(_scalar.Anchor,
                    _scalar.Tag,
                    _scalar.Value,
                    _scalar.Style,
                    value,
                    _scalar.IsQuotedImplicit,
                    _scalar.Start,
                    _scalar.End);
            }
        }

        public bool IsQuotedImplicit {
            get { return _scalar.IsQuotedImplicit; }
            set {
                _scalar = new Scalar(_scalar.Anchor,
                    _scalar.Tag,
                    _scalar.Value,
                    _scalar.Style,
                    _scalar.IsPlainImplicit,
                    value,
                    _scalar.Start,
                    _scalar.End);
            }
        }

        public string Value {
            get { return _scalar.Value; }
            set {
                _scalar = new Scalar(_scalar.Anchor,
                    _scalar.Tag,
                    value,
                    _scalar.Style,
                    _scalar.IsPlainImplicit,
                    _scalar.IsQuotedImplicit,
                    _scalar.Start,
                    _scalar.End);
            }
        }
    }
}