using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper.Concrete
{
    public class FileHelper : IFileHelper
    {
        public IResult Delete(string filePath)
        {
            var result = CheckIfFileExists(filePath);
            if (!result.Success)
            {
                return result;
            }
            File.Delete(filePath);
            return new SuccessResult();
        }

        public IResult Update(IFormFile file, string filePath, string root)
        {
            var resultOfDelete = Delete(filePath);
            if (!resultOfDelete.Success)
            {
                return resultOfDelete;
            }

            var resultOfUpload = Upload(file, root);
            if (!resultOfUpload.Success)
            {
                return resultOfUpload;
            }

            return new SuccessResult(resultOfUpload.Message);
        }

        public IResult Upload(IFormFile file, string root)
        {
            var result = BusinessRules.Run(CheckIfFileEnter(file),
              CheckIfFileExtensionValid(Path.GetExtension(file.FileName)));

            if (result != null)
            {
                return result;
            }

            //Guid ile benzersiz bir isim oluşturup dosyanın uzantısı ile birleştirdik.
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            //Dosyayı koyacağımız klasör yolu var mı yok mu diye kontrol ettik. Yoksa oluşturduk.
            CheckIfDirectoryExists(root);

            CreateFile(root + fileName, file);

            return new SuccessResult(fileName);
        }



        //BusinessRules
        private IResult CheckIfFileExists(string filePath)
        {
            if (File.Exists(filePath))
            {
                return new SuccessResult();
            }
            return new ErrorResult("Böyle bir dosya mevcut değil");
        }

        private IResult CheckIfFileEnter(IFormFile file)
        {
            if (file.Length < 0)
            {
                return new ErrorResult("Dosya girilmemiş");
            }
            return new SuccessResult();
        }

        private IResult CheckIfFileExtensionValid(string extension)
        {
            if (extension == ".jpg" || extension == ".png" || extension == ".jpeg" || extension == ".webp")
            {
                return new SuccessResult();
            }
            return new ErrorResult("Dosya uzantısı geçerli değil");
        }

        private void CheckIfDirectoryExists(string root)
        {
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
        }

        private void CreateFile(string directory, IFormFile file)
        {
            //Yeni bir dosya oluşturulur ve eğer aynı isimde bir dosya bulunuyorsa üzerine yazılır.
            using (FileStream fileStream = File.Create(directory))
            {
                file.CopyTo(fileStream); //Oluşturduğumuz dosyanın içine resmi kopyaladık.
                fileStream.Flush(); //Tampondaki bilgilerin boşaltılmasını ve stream dosyasının güncellenmesini sağlar.
            }
        }
    }
}
