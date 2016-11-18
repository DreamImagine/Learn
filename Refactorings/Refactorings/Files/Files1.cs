using System;
using System.IO;
using System.Text;

namespace Refactorings.Files
{
    public class Files1
    {
        public void Test()
        {
            //读取文件.txt

            //读取内容流

            //新建文件.html
            //yptoopman.html
            using (FileStream fs = File.Create(@"E:\yptoopman.html"))
            {

                AddText(fs, "<<!DOCTYPE html>>");
                AddText(fs, "<html>");
                AddText(fs, "<head>");
                AddText(fs, "  <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />");
                AddText(fs, "<meta charset=\"utf-8\" />");
                AddText(fs, "<title>YPTopMan");
                AddText(fs, "</title>");
                AddText(fs, "</head>");
                AddText(fs, "<body>");
                AddText(fs, "<table>");

                using (FileStream fs2 = File.OpenRead(@"E:\EV5y8xmj.txt"))
                {
                    byte[] b = new byte[1024];
                    UTF8Encoding temp = new UTF8Encoding(true);
                    while (fs2.Read(b, 0, b.Length) > 0)
                    {
                        var val = temp.GetString(b);
                       var vals= val.Split('h');
                        //int startIndex = 0;
                        //for (int i = 0; i < 15; i++)
                        //{
                        //    AddText(fs, "<tr>");


                        //    //长度
                        //    int len = val.IndexOf('h', startIndex);
                        //    string title = val.Substring(startIndex, len);                      
                        //    startIndex = len;

                        //    string url = val.Substring(startIndex, 50);
                        //    AddText(fs, "<td>");
                        //    AddText(fs, title);
                        //    AddText(fs, "</td>");
                        //    AddText(fs, "<td>");

                        //    AddText(fs, "<a  href=\"" + url + "\">" + title + "</a>");
                        //    AddText(fs, "</td>");
                        //    AddText(fs, "</tr>");
                        //}


                    }
                }

                AddText(fs, "</table>");
                AddText(fs, "</body>");
                AddText(fs, "</html>");
            }


            //输出文件保存
        }

        //EV5y8xmj.txt
        public void Read()
        {
            using (FileStream fs = File.OpenRead(@"E:\yptoopman.html"))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
                while (fs.Read(b, 0, b.Length) > 0)
                {
                    Console.WriteLine(temp.GetString(b));
                }
            }
        }

        public void ReadTxt()
        {
            using (FileStream fs = File.OpenRead(@"E:\EV5y8xmj.txt"))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
                while (fs.Read(b, 0, b.Length) > 0)
                {
                    Console.WriteLine(temp.GetString(b));
                }
            }
        }


        public void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
    }
}
