using System.ComponentModel.DataAnnotations;

namespace LancerPartsShop.Service
{
	public class AllowedExtensionsAttribute
	{
		private readonly string[] _extensions;
		public AllowedExtensionsAttribute(string[] extensions)
		{
			_extensions = extensions;
		}

		public bool IsImage(IFormFile file)
		{
			if (file != null)
			{
				var extension = Path.GetExtension(file.FileName);
				if (!_extensions.Contains(extension.ToLower()))
				{
					return false;
				}
			}

			return true;
		}
	}
}
