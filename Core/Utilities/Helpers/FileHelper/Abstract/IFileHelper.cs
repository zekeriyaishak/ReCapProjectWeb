using Core.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper.Abstract
{
    public interface IFileHelper
    {
        //filePath: 'CarImageManager'dan gelen dosyanın kaydedildiği adres ve adı
        //IFormFile: HttpRequest ile gönderilen bir dosyayı temsil eder.
        //string root: Bu dosyanın kaydedileceği adresi tutar. 
        string Upload(IFormFile file, string root);
        void Delete(string filePath);
        string Update(IFormFile file, string filePath, string root);
    }
}
