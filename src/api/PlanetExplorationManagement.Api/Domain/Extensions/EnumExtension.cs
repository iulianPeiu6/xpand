using System.ComponentModel;

namespace Domain.Extensions
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum @enum)
        {
            if (@enum is null)
            {
                throw new ArgumentNullException(nameof(@enum));
            }

            string description = @enum.ToString();

            var field = @enum.GetType().GetField(@enum.ToString());

            if (field is null)
            {
                throw new ArgumentException($"'{@enum}' enum value is invalid. Does not exist.");
            }

            var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Any())
            {
                description = attributes[0].Description;
            }

            return description;
        }
    }
}
