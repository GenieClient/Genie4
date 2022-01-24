using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenieClient.Models
{
    public class BaseSettings
    {
        public string ListValues()
        {
            //TODO My thought here is we should not be doing any formatting logic at this level of the code.
            //We should let what ever frontend code handle formatting text and we should just pass this as maybe a key value pair.
            var properties = this.GetType().GetProperties().ToList();
            StringBuilder list = new StringBuilder($"\n{this.GetType().Name}\n");
            list.Append("----------------------------------------------------\n");

            foreach (var property in properties)
            {
                Type baseType = property.PropertyType.BaseType;
                if(baseType == typeof(BaseSettings)){
                    var nestedProperties = property.PropertyType.GetProperties().ToList();
                    var nestedValues = property.GetValue(this);
                    foreach( var p in nestedProperties)
                    {
                        list.Append($"{p.Name}:\t {p.GetValue(nestedValues)}\n");
                    }
                }
                else
                {
                    list.Append($"{property.Name}:\t {property.GetValue(this)}\n");
                }
            }
            return list.ToString();
        }
    }
}
