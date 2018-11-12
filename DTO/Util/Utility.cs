using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Reflection;

namespace DTO.Util
{
	/// <summary>
	/// Summary description for Utility.
	/// </summary>
	public class Utility
	{
		public Utility()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static string FillZero(string number,int totalZero) 
		{
			string result = "";

			for(int i=0;i<totalZero;i++) 
			{
				result+="0";
			}

			return result+number;
		}

		public static string FillZero(int number,int totalZero) 
		{
			return FillZero(Convert.ToString(number),totalZero);
		}

        public static int ConvertToInt(string value)
        {

            int nResult = 0;

            try
            {
                nResult = Convert.ToInt32(value);
            }
            catch
            { }
            finally
            {
            }
            return nResult;
        }

        public static decimal ConvertToDecimal(string value)
        {

            decimal nResult = 0;

            try
            {
                nResult = Convert.ToDecimal(value);
            }
            catch
            { }
            finally
            {
            }
            return nResult;
        }

        public static string GetLangCode(string lang) 
		{
			return null;//NokAirWeb.Utility.ConfigXMLManager.getConfigValue("configs/global/LangCodes/LangCode[Lang='"+lang+"']/Code");
		}

        public static MemoryStream Response2Stream(string fullPathName)
        {
            FileStream fStream = null;
            MemoryStream mStream = null;

            try
            {
                FileInfo myFile;

                myFile = new FileInfo(fullPathName);

                if (myFile.Exists == true)
                {
                    //string strDirectory = string.Format("{0}Upload\\{1}\\EXCEL\\", HttpContext.Current.Request.PhysicalApplicationPath, R3OID);

                    fStream = new FileStream(fullPathName, FileMode.Open);
                    byte[] Data = new Byte[fStream.Length];
                    fStream.Read(Data, 0, Data.Length);
                    mStream = new MemoryStream(Data);
                }
                else
                {
                    return null;
                }

                myFile = null;

                return mStream;
            }
            finally
            {
                if (mStream != null)
                {
                    mStream.Close();
                    mStream.Flush();
                    mStream.Dispose();
                }

                if (fStream != null)
                {
                    fStream.Close();
                    //fstream.Flush();
                    fStream.Dispose();
                }

            }
        }


        public static bool HaveDirectory(string dirName)
        {
            if (dirName == null) return false;
            try
            {
                if (!System.IO.Directory.Exists(dirName))
                {
                    System.IO.Directory.CreateDirectory(dirName);
                }
            }
            catch (Exception ex)
            {
                // throw io exception
            }
            return true;
        }

        public static bool HaveDirectory2(string dirName)
        {
            System.IO.DirectoryInfo myInfo = null;
           
            if (dirName == null) return false;
            try
            {
                myInfo = new DirectoryInfo(dirName);
                if (!myInfo.Exists)
                {

                  
                    myInfo.Create();
                  
                  
                  
                  
                }
                myInfo.Attributes = FileAttributes.Normal;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public static bool HaveFile(string fileName)
        {
            bool bResult = false;
            System.IO.FileInfo myFile = null;
         
            if (fileName == null) bResult= false;
            try
            {
                if (System.IO.File.Exists(fileName))
                {
                    bResult = true;
                    //myFile = new FileInfo(fileName);
                    //myFile.Attributes= FileAttributes.Normal;
                    //myFile.Delete();
                }
            }
            catch (Exception ex)
            {
                // throw io exception
            }
            return bResult;
        }

        public static bool DeleteAllFile(string pathName)
        {
            bool bResult = false;
            System.IO.FileInfo myFile = null;

            string[] filesAll = Directory.GetFiles(pathName, "*.pdf");

            if (filesAll == null) bResult = false;
            try
            {
                foreach (string file in filesAll)
                {
                    DeleteFile(file);
                }

            }
            catch (Exception ex)
            {
                // throw io exception
            }
            return bResult;
        }



        public static bool DeleteFile(string fileName)
        {
            bool bResult = false;
            if (fileName == null) bResult = false;
            try
            {
                if (System.IO.File.Exists(fileName))
                {
                    System.IO.File.Delete(fileName);
                    bResult = true;
                }
                   
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return bResult;
        }

        public static byte[] GetByteArray(String strFileName)
        {
            System.IO.FileStream fs=null;
            System.IO.BinaryReader br;
            byte[] imgbyte = null;
            try
            {
                fs = new System.IO.FileStream(strFileName, System.IO.FileMode.Open);
                // initialise the binary reader from file streamobject
               br = new System.IO.BinaryReader(fs);
                // define the byte array of filelength

               imgbyte = new byte[fs.Length + 1];
                // read the bytes from the binary reader

                imgbyte = br.ReadBytes(Convert.ToInt32((fs.Length)));

                br.Close();
            }
            catch (Exception ex)
            { }
            finally
            { }
            // add the image in bytearray

       
            // close the binary reader
            if (fs != null)
            {
                fs.Close();
            }
            // close the file stream
            return imgbyte;
        }


        public static string convertFileToBase64(string filePath)
        {
            try
            {
                byte[] imageArray = System.IO.File.ReadAllBytes(filePath);
                return Convert.ToBase64String(imageArray);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static void saveBase64File(string filePath, string fileBase64)
        {
            var bytes = Convert.FromBase64String(fileBase64);
            using (var imageFile = new FileStream(filePath, FileMode.Create))
            {
                imageFile.Write(bytes, 0, bytes.Length);
                imageFile.Flush();
            }
        }
        
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }


    }
}
