using System.ComponentModel.DataAnnotations;

namespace Malek_wafik.Validations
{
    public class AllowedAudioExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _extensions = { ".mp3",".mp4"};

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

                if (!_extensions.Contains(extension))
                {
                    return new ValidationResult($"Only audio files ({string.Join(", ", _extensions)}) are allowed.");
                }

            }
            return ValidationResult.Success!;
        }

    }
}
