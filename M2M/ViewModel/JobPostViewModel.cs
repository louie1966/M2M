﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace M2M.ViewModel {
    public class JobPostViewModel {
        public JobPost JobPost { get; set; }
        public IEnumerable<SelectListItem> AllJobTags { get; set; }

        private List<int> _selectedJobTags;
        public List<int> SelectedJobTags {
            get {
                if (_selectedJobTags == null) {
                    _selectedJobTags = JobPost.JobTags.Select(m => m.Id).ToList();
                }
                return _selectedJobTags;
            }
            set { _selectedJobTags = value; }
        }
    }
}