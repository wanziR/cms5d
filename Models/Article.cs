using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Models
{
   public class Article
    {
        //acId, acName, acImg, acPid, acOrder
        public int acId { get; set; }
        public int acPid { get; set; }
        public int acOrder { get; set; }
        public string acName { get; set; }
        public string acImg { get; set; }
        //artId, artName, artImg, artContent, artAuthor, artPV, artAddtime, artIsTuiJian, artIsReMen, artIsZhiDing, artType, artLink
        public int artId { get; set; }
        public int artIsTuiJian { get; set; }
        public int artIsReMen { get; set; }
        public int artIsZhiDing { get; set; }
        public string artName { get; set; }
        public string artImg { get; set; }
        public string artContent { get; set; }
        public string artAuthor { get; set; }
        public string artPV { get; set; }
        public string artType { get; set; }
        public string artLink { get; set; }
        public DateTime artAddtime { get; set; }
        //++
        public string acPName { get; set; }



    }
}
