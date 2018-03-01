using Stepon.FaceRecognizationCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace Caty.Album.Face
{
    public static class FaceRecognize
    {
        /// <summary>
        /// 获得图像内人脸特征码
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static List<byte[]> MatchFace(Image image)
        {
            using (var proccesor = new FaceProcessor(FaceArgs.API_Key, FaceArgs.FDSecret_Key, FaceArgs.FRSecret_Key, false))
            {
                List<byte[]> list = new List<byte[]> { };
                var result = proccesor.LocateExtract(new Bitmap(image));

                //FaceProcessor是个整合包装类，集成了检测和识别，如果要单独使用识别，可以使用FaceRecognize类
                //这里做演示，假设图片都只有一张脸
                //可以将FeatureData持久化保存，这个即是人脸特征数据，用于后续的人脸匹配
                //File.WriteAllBytes("XXX.data", feature.FeatureData);FeatureData会自动转型为byte数组
                if (result != null)
                {
                    for (var i = 0; i < result.Length; i++)
                    {
                        list.Add(result[i].FeatureData);
                    }
                }
                return list;
            }
        }

        /// <summary>
        /// 两张单人脸图像对比
        /// </summary>
        /// <param name="image1"></param>
        /// <param name="image2"></param>
        /// <returns></returns>
        public static float MatchFace(Image image1,Image image2)
        {
            using (var proccesor = new FaceProcessor(FaceArgs.API_Key, FaceArgs.FDSecret_Key, FaceArgs.FRSecret_Key, false))
            {
                var result1 = proccesor.LocateExtract(new Bitmap(image1));
                var result2 = proccesor.LocateExtract(new Bitmap(image2));
                if ((result1 != null) & (result2 != null))
                {
                    return proccesor.Match(result1[0].FeatureData, result2[0].FeatureData, true);
                }
                return -1;
            }
        }

        public static List<float> MatchFace(List<byte[]> list1, List<byte[]> list2)
        {
            List<float> list = new List<float>();
            using (var proccesor = new FaceProcessor(FaceArgs.API_Key, FaceArgs.FDSecret_Key, FaceArgs.FRSecret_Key, false))
            {
                if ((list1 != null) & (list2 != null))
                {
                    for (var i = 0; i < list1.Count; i++)
                    {
                        for (var j = 0; j < list2.Count; j++)
                        {
                            list.Add(proccesor.Match(list1[i], list2[j], true));
                        }
                    }
                }
                return list;
            }
        }

        /// <summary>
        /// 特征码对比
        /// </summary>
        /// <param name="featureData1"></param>
        /// <param name="featureDatat2"></param>
        /// <returns></returns>
        public static float MatchFace(byte[] featureData1,byte[] featureDatat2)
        {
            using (var proccesor = new FaceProcessor(FaceArgs.API_Key, FaceArgs.FDSecret_Key, FaceArgs.FRSecret_Key, false))
            {
                return proccesor.Match(featureData1, featureDatat2, true);
            }
        }
    }
}
