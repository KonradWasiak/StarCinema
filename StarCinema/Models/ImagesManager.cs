using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels
{
    public static class ImagesManager
    {
        public static async Task UploadPoster(IFormFile file, int id, bool createOrTruncate)
        {
            await UploadImage(file, id, createOrTruncate, true);
        }
        public static async Task UploadBanner(IFormFile file, int id, bool createOrTruncate)
        {
            await UploadImage(file, id, createOrTruncate, false);
        }
        public static async Task DeleteImages(int id)
        {
            var posterFileName = id.ToString() + ".jpg";
            var bannerFileName = id.ToString() + "Index" + ".jpg";

            var pathPoster = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot\\images\\MoviesPosters",
                posterFileName
                );

            var pathBanner = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot\\images\\MoviesPosters",
                bannerFileName
                );
            File.Delete(pathBanner);
            File.Delete(pathPoster);
        }
        private static async Task UploadImage(IFormFile file, int id, bool createOrTruncate, bool posterOrBanner)
        {
            var mode = createOrTruncate ? FileMode.Create : FileMode.Truncate;
            var fileName = posterOrBanner ? id.ToString() + ".jpg" : id.ToString() + "Index" + ".jpg";
            if ((file != null) && (file.Length != 0))
            {
                var path = Path.Combine(
                            Directory.GetCurrentDirectory(), "wwwroot\\images\\MoviesPosters",
                           fileName);

                using (var stream = new FileStream(path, mode))
                {
                    await file.CopyToAsync(stream);
                }
            }
        }

    }
}
