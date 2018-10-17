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

        /// <summary>
        /// �������͵�ֵ��
        /// </summary>
        public string Value { get; }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return Equals(obj as DataType);
        }

        /// <summary>
        /// �Ƚ��������������Ƿ�һ�¡�
        /// </summary>
        /// <param name="a">��Ҫ�Ƚϵ��������͡�</param>
        /// <param name="b">��Ҫ�Ƚϵ��������͡�</param>
        /// <returns>���һ�£���Ϊtrue������Ϊfalse��</returns>
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

        /// <summary>
        /// �Ƚ��������������Ƿ�һ�¡�
        /// </summary>
        /// <param name="a">��Ҫ�Ƚϵ��������͡�</param>
        /// <param name="b">��Ҫ�Ƚϵ��������͡�</param>
        /// <returns>�����һ�£���Ϊtrue������Ϊfalse��</returns>
        public static bool operator !=(DataType a, DataType b)
        {
            return !(a == b);
        }

        /// <summary>
        /// �Ƚ��������������Ƿ�һ�¡�
        /// </summary>
        /// <param name="other">��Ҫ�Ƚϵ��������͡�</param>
        /// <returns>���һ�£���Ϊtrue������Ϊfalse��</returns>
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

        /// <summary>
        /// �Ƚ��������������Ƿ�һ�¡�
        /// </summary>
        /// <param name="other">��Ҫ�Ƚϵ��������͡�</param>
        /// <returns>���һ�£���Ϊ0������Ϊ1��</returns>
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

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return EqualityComparer<string>.Default.GetHashCode(Value);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return Value;
        }
    }

    /// <summary>
    /// �ַ�����DataTypeת���ࡣ
    /// </summary>
    public class DataTypeConverter : JsonConverter
    {
        /// <summary>
        /// ȷ����ʵ���Ƿ����ת��ָ���Ķ������͡�
        /// </summary>
        /// <param name="objectType">����ʵ��</param>
        /// <returns>
        /// <c>true</c> ������ʵ������ת��ָ���Ķ�������; ����, <c>false</c>��
        /// </returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DataType);
        }

        /// <summary>
        /// ��д�����JSON��ʾ��
        /// </summary>
        /// <param name="writer">JsonWriter</param>
        /// <param name="value">ֵ</param>
        /// <param name="serializer">���л���</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var dataType = value as DataType;
            serializer.Serialize(writer, dataType != null ? dataType.Value : null);
        }

        /// <summary>
        /// ��ȡ�����JSON��ʾ��
        /// </summary>
        /// <param name="reader">JsonReader</param>
        /// <param name="objectType">��������</param>
        /// <param name="existingValue">���ڶ�ȡ�Ķ��������ֵ</param>
        /// <param name="serializer">���л���</param>
        /// <returns>���ض���</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var value = (string)reader.Value;
            return string.IsNullOrEmpty(value) ? null : new DataType(value);
        }
    }
}