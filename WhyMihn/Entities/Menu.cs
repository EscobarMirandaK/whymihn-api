﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Menu
    {
        [Key]
        [Column("tenant_id")]
        public string TenantId { get; set; }

        [Key]
        [Column("client_id")]
        public string ClientId { get; set; }

        [Key]
        [Column("menu_id")]
        public string MenuId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("url")]
        public string Url { get; set; }

        [Column("parent_menu_id")]
        public string ParentMenuId { get; set; }
    }
}
