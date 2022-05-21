﻿using GtRacingNews.Common.Constants;

namespace GtRacingNews.Areas.Admin.ViewModels
{
    public class DeleteFormModel
    {
        public CollectionNames CollectionNames { get; set; } = new CollectionNames();

        public Dictionary<string, int> Teams  = new Dictionary<string, int>();
        public Dictionary<string, int> Drivers  = new Dictionary<string, int>();
        public Dictionary<string, int> Championships  = new Dictionary<string, int>();
        public Dictionary<string, int> News  = new Dictionary<string, int>();
        public Dictionary<string, int> Races  = new Dictionary<string, int>();
        public Dictionary<string, string> Users  = new Dictionary<string, string>();
        public Dictionary<string, string> Roles  = new Dictionary<string, string>();
    }
}