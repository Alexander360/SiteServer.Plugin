﻿namespace SiteServer.Plugin.Models
{
    public class PluginTableColumn
    {
        public string AttributeName { get; set; }

        public string DataType { get; set; }

        public int DataLength { get; set; } = 50;

        public PluginInputStyle InputStyle { get; set; }
    }
}
