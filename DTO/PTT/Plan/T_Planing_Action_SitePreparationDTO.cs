using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.PTT.Master;

namespace DTO.PTT.Plan
{
    public class T_Planing_Action_SitePreparationDTO : BaseDTO
    {

       
        public string ID  { get; set; }
         public string PID { get; set; }   
        public string AreaOwner { get; set; }   
         public string  North { get; set; }
 public string  East { get; set; }
public string  Brand { get; set; }
public string  Model { get; set; }
public string  SN { get; set; }
public string  PipelineSection { get; set; }
public string  SoildType { get; set; }
public string  BacteriaAPB { get; set; }
public string  BacteriaSRB { get; set; }
public string  PH { get; set; }
public string  DigLength { get; set; }
public string  Underground_Foc { get; set; }
public string  Underground_OtherPipline { get; set; }
public string  Underground_Powerline { get; set; }
public string  Underground_Etc { get; set; }
public string  DepthOfCover { get; set; }
public string MoreDetail { get; set; }
        public string DeleteFiles { get; set; }
        public string DeleteFileNames { get; set; }
        public List<T_Planing_File> UploadFileList { get; set; }
        public List<M_UndergroundDTO> underGroundList { get; set; }
     
    }

 

}
