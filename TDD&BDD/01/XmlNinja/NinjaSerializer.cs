
using System.Reflection;
using System.Text;

namespace XmlNinja
{
    public static class NinjaSerializer
    {
        public static string Serialize(object target)
        {
            if (target is null)
            {
                return string.Empty;
            }

            var xmlBuilder = new StringBuilder();

            var nameOfClass = target.GetType().Name;

            xmlBuilder.Append(OpenTagFor(nameOfClass));

            var properties = target.GetType().GetProperties();

            foreach (var property in properties)
            {
                xmlBuilder.Append(GetTag(property.Name, property.GetValue(target)));
            }

            xmlBuilder.Append(CloseTagFor(nameOfClass));


            return xmlBuilder.ToString();
        }

        private static string GetTag(string tag, object value)
        {
            return $"{OpenTagFor(tag)}{value}{CloseTagFor(tag)}";
        }

        private static string CloseTagFor(string tagName)
        {
            return $"</{tagName}>";
        }

        private static string OpenTagFor(string tagName)
        {
            return $"<{tagName}>";
        }
    }
}
