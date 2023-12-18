using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ImageMagick;

namespace Lab4.Pages
{
    public class UploadModel : PageModel
    {
        [BindProperty]
        public IFormFile UploadedFile { get; set; }

        public UploadModel(IWebHostEnvironment environment)
        {
            imagesDir = Path.Combine(environment.WebRootPath, "images");
        }
        private string imagesDir;

        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (UploadedFile != null)
            {
                string extension = ".jpg";
                switch (UploadedFile.ContentType)
                {
                    case "image/png":
                        extension = ".png";
                        break;
                    case "image/gif":
                        extension = ".gif";
                        break;
                }
                var fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + extension;
                var filePath = Path.Combine(imagesDir, fileName);
                using (var fs = System.IO.File.OpenWrite(Path.Combine(imagesDir, fileName)))
                {
                    UploadedFile.CopyTo(fs);
                }
                using var image = new MagickImage(filePath);
                using var watermark = new MagickImage("watermark.jpg");
                // przezroczystosc znaku wodnego
                watermark.Evaluate(Channels.Alpha, EvaluateOperator.Divide, 4);
                // narysowanie znaku wodnego
                image.Composite(watermark, Gravity.Southeast,
                CompositeOperator.Over);
                image.Write(filePath);
                return RedirectToPage("Single", new { Image = fileName });

            }
            return RedirectToPage("Error");
        }

    }
}