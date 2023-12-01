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
                throw new NullReferenceException(nameof(field));
            }

            var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Any())
            {
                description = attributes.First().Description;
            }

            return description;
        }
    }
}
