using Caty.Album.BLL.Interface;
using Caty.Album.Face;
using Microsoft.AspNetCore.Mvc;
using Stepon.FaceRecognizationCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Caty.Album.Api.Controllers
{ 
    [Route("api/[controller]")]
    public class FaceController:Controller
    {
        private IFaceService _faceService;

        public FaceController(IFaceService faceService)
        {
            _faceService = faceService;
        }

        [HttpGet]
        public int GetAll()
        {
            var face = _faceService.LoadEntities(f => true);
            return face.Count();
        }

        [HttpPost("UploadImage")]
        public bool UploadImage()
        {
            long size = 0;
            var files = Request.Form.Files;
            foreach(var file in files)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                fileName = "D:" + $@"\{fileName}";
                size += file.Length;
                using (FileStream fs = System.IO.File.Create(fileName))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
            }
            return true;
        }

        [HttpPost("MatchImage")]
        public List<float> MatchImage()
        {
            var files = Request.Form.Files;
            Image staticImage = Image.FromFile("D:\\1.jpg");
            List<float> list = new List<float>();
            //foreach (var file in files)
            //{
                var fileName = ContentDispositionHeaderValue.Parse(files[0].ContentDisposition).FileName.Trim('"');
                string str = fileName.Split('.').Last();
                fileName = "D:" + $@"\{fileName}";
                using (FileStream fs = System.IO.File.Create(fileName))
                {
                    files[0].CopyTo(fs);
                    fs.Flush();
                }
                Image image = Image.FromFile(fileName);
                using (var proccesor = new FaceProcessor(FaceArgs.API_Key, FaceArgs.FDSecret_Key, FaceArgs.FRSecret_Key, false))
                {
                    var result1 = proccesor.LocateExtract(new Bitmap(image));
                    var result2 = proccesor.LocateExtract(new Bitmap(staticImage));
                    if ((result1 != null) & (result2 != null))
                    {
                        list.Add(proccesor.Match(result1[0].FeatureData, result2[0].FeatureData, true));
                    }
                }
                //list.Add(FaceRecognize.MatchFace(image,staticImage));
            //}
            return list;
        }
    }
}
