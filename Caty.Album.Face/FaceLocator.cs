using Stepon.FaceRecognizationCore.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Caty.Album.Face
{
    public static class FaceLocator
    {
        public static List<Image> CheckFace(Image image)
        {
            List<Image> list = new List<Image>();
            using (var detection = LocatorFactory.GetDetectionLocator(FaceArgs.API_Key, FaceArgs.FDSecret_Key, 41943040, OrientPriority.OrientHigherExt, 16, 10))
            {
                var bitmap = new Bitmap(image);
                var result = detection.Detect(bitmap, out var localeResult);
                using (localeResult)
                {
                    if (result == ErrorCode.Ok && localeResult.FaceCount > 0)
                    {
                        using (var g = Graphics.FromImage(bitmap))
                        {
                            foreach (var f in localeResult.Faces)
                            {
                                //Form form = new Form();
                                //PictureBox pictureBox = new PictureBox();
                                //pictureBox.Image = Check(AcquireRectangleImage(image, new Rectangle(f.left, f.top, f.right, f.bottom)));
                                //pictureBox.Height = f.bottom - f.top;
                                //pictureBox.Width = f.right - f.left;
                                //pictureBox.Size = form.Size;
                                //pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                                //pictureBox.Parent = form;
                                //form.Show();
                                list.Add(Check(AcquireRectangleImage(image, new Rectangle(f.left, f.top, f.right, f.bottom))));
                            }
                        }
                    }
                }
            }
            return list;
        }

        private static Image Check(Image image)
        {
            using (var detection = LocatorFactory.GetDetectionLocator(FaceArgs.API_Key, FaceArgs.FDSecret_Key, 41943040, OrientPriority.OrientHigherExt, 16, 10))
            {
                var bitmap = new Bitmap(image);
                var result = detection.Detect(bitmap, out var localeResult);
                using (localeResult)
                {
                    if (result == ErrorCode.Ok && localeResult.FaceCount > 0)
                    {
                        using (var g = Graphics.FromImage(bitmap))
                        {
                            var face = localeResult.Faces[0];
                            return AcquireRectangleImage(image, new Rectangle(face.left, face.top, face.right, face.bottom));
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        /// <summary>
        /// 截取图像的矩形区域
        /// </summary>
        /// <param name="source">源图像对应picturebox1</param>
        /// <param name="rect">矩形区域，如上初始化的rect</param>
        /// <returns>矩形区域的图像</returns>
        public static Image AcquireRectangleImage(Image source, Rectangle rect)
        {
            if (source == null || rect.IsEmpty) return null;
            Bitmap bmSmall = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            //Bitmap bmSmall = new Bitmap(rect.Width, rect.Height, source.PixelFormat);

            using (Graphics grSmall = Graphics.FromImage(bmSmall))
            {
                grSmall.DrawImage(source,
                                  new System.Drawing.Rectangle(0, 0, bmSmall.Width, bmSmall.Height),
                                  rect,
                                  GraphicsUnit.Pixel);
                grSmall.Dispose();
            }
            return bmSmall;
        }
    }
}
