using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.MODEL
{
    public class MenuModel
    {
        public int MenuId { get; set; }


        [Display(Name = "Select Menu")]
        [Required]
        public int ParentId { get; set; }
        [Required]
        [Display(Name = "Menu Name")]
        public string MenuName { get; set; }
        [Required]
        [Display(Name = "Controller Name")]
        public string ControllerName { get; set; }
        [Required]
        [Display(Name = "Action Name")]
        public string ActionName { get; set; }
        [Required]
        [Display(Name = "Level")]
        public int Level { get; set; }
        [Required]
        [Display(Name = "Position")]
        public int Position { get; set; }
        [Display(Name = "Menu Icon")]
        public string MenuIcon { get; set; }
        [Display(Name = "Title")]
        public string MenuTitle { get; set; }
        public bool SDView { get; set; }
        public bool MDView { get; set; }
        public bool DTView { get; set; }
        public bool RTView { get; set; }
        public bool CSView { get; set; }
        public bool RSView { get; set; }
        public List<MenuModel> listMenu { get; set; }
        public bool IsChecked { get; set; }
        public string ClassName { get; set; }
        public string SidebarClass { get; set; }

    }

    public class MenuResponse
    {
        public int Id { get; set; }
        public int SrNo { get; set; }

        public string MenuName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string MenuTitle { get; set; }
        public string Action { get; set; }
    }
}
