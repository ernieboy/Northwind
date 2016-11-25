using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Core.Common.Extensions;

namespace Northwind.Web.ViewModels
{
    public abstract class BaseViewModel
    {
        public string SearchTerms { get; set; }
        public string SortCol { get; set; }

        public string SortDir { get; set; }
        public bool SearchTermsExist => !SearchTerms.IsNullOrWhiteSpace();

        public void ClearSearchTerms()
        {
            SearchTerms = string.Empty;
        }

        public List<SelectListItem> SortDirections
        {
            get
            {
                var list = new List<SelectListItem>
                {
                    new SelectListItem {Text = "Ascending", Value = "ASC"},
                    new SelectListItem {Text = "Descending", Value = "DESC"}
                };
                return list;
            }
        }

        public virtual List<SelectListItem> SortColumns { get; set; }
    }
}
