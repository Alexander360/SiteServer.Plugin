using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SiteServer.Plugin
{
    /// <summary>
    /// ϵͳ֧�ֵ����ݿ���������
    /// </summary>
    [JsonConverter(typeof(DataTypeConverter))]
    public class DataType : IEquatable<DataType>, IComparable<DataType>
    {
        /// <summary>
        /// ����ֵ��������
        /// </summary>
        public static readonly DataType Boolean = new DataType(nameof(Boolean));

        /// <summary>
        /// ������������
        /// </summary>
        public static readonly DataType DateTime = new DataType(nameof(DateTime));

        /// <summary>
        /// С����������
        /// </summary>
        public static readonly DataType Decimal = new DataType(nameof(Decimal));

        /// <summary>
        /// ������������
        /// </summary>
        public static readonly DataType Integer = new DataType(nameof(Integer));

        /// <summary>
        /// ���ı���������
        /// </summary>
        public static readonly DataType Text = new DataType(nameof(Text));

        /// <summary>
        /// �ַ�����������
        /// </summary>
        public static readonly DataType VarChar = new DataType(nameof(VarChar));

        internal DataType(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            Value = value;
        }

        public string Value { get; }

        public override bool Equals(object obj)
        {
            return Equals(obj as DataType);
        }

        public static bool operator ==(DataType a, DataType b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            if ((object) a == null || (object) b == null)
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(DataType a, DataType b)
        {
            return !(a == b);
        }

        public bool Equals(DataType other)
        {
            if (other == null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return
                Value.Equals(other.Value, StringComparison.OrdinalIgnoreCase);
        }

        public int CompareTo(DataType other)
        {
            if (other == null)
            {
                return 1;
            }

            if (ReferenceEquals(this, other))
            {
                return 0;
            }

            return StringComparer.OrdinalIgnoreCase.Compare(Value, other.Value);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<string>.Default.GetHashCode(Value);
        }

        public override string ToString()
        {
            return Value;
        }
    }

    public class DataTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DataType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var dataType = value as DataType;
            serializer.Serialize(writer, dataType != null ? dataType.Value : null);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            return new DataType((string) reader.Value);
        }
    }
}