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
        public static void UploadPoster(IFormFile file, int id, bool createOrTruncate)
        {
             UploadImage(file, id, createOrTruncate, true);
        }
        public static void UploadBanner(IFormFile file, int id, bool createOrTruncate)
        {
             UploadImage(file, id, createOrTruncate, false);
        }
        public static void DeleteImages(int id)
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
        private static void UploadImage(IFormFile file, int id, bool createOrTruncate, bool posterOrBanner)
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
                     file.CopyTo(stream);
                }
            }
        }

    }
}
