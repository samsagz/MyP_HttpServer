using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HttpServer.Enums
{
    static class EnumUtils
    {
        /// <summary>
        /// Obtienes el valor del String de un valor de Enums, esto solo funciona
        /// si asignas el valor del string asociado al items de tu enum
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetStringValue(this Enum value)
        {
            // Obtener tipo
            Type type = value.GetType();

            // Obtener la informacion del campo del Enum para este tipo 
            FieldInfo fieldInfo = type.GetField(value.ToString());

            // Obtiene el StringValue atributos 
            StringValueAttribute[] attribs = fieldInfo.GetCustomAttributes(
                typeof(StringValueAttribute), false) as StringValueAttribute[];

            // Retorna el primer atributo si existe una coincidencia
            return attribs.Length > 0 ? attribs[0].StringValue : null;
        }
    }

    /// <summary>
    /// El atributo es usado para representar un stringValue por un enum
    /// </summary>
    public class StringValueAttribute : Attribute
    {

        #region Properties

        /// <summary>
        /// Mantiene el stringValue para un valor de un ENum
        /// </summary>
        public string StringValue { get; protected set; }

        #endregion

        #region Constructor

        /// <summary>
        /// El constructor usado para inicializar el StringValue
        /// </summary>
        /// <param name="value"></param>
        public StringValueAttribute(string value)
        {
            this.StringValue = value;
        }

        #endregion

    }
}
