/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DCoreyDuke.CodeBase.Objects.General
{
    /// <summary>
    /// Detailed Hyperlink
    /// </summary>
    [ComplexType, Serializable]
    public class Link
    {
        private readonly RegExValidation _Val = new RegExValidation();

        public Link()
        {
        }

        public Link(string linkName, string linkText, string linkUrl, string linkDescription)
        {
            LinkName = linkName;
            LinkText = linkText;
            LinkUrl = linkUrl;
            LinkDescription = linkDescription;
            LinkType = LinkType.Default;
        }

        public Link(string linkName, string linkText, string linkUrl, string linkDescription, LinkType linkType)
        {
            LinkName = linkName;
            LinkText = linkText;
            LinkUrl = linkUrl;
            LinkDescription = linkDescription;
            LinkType = linkType;
        }

        /// <summary>
        /// Description of the link
        /// </summary>
        public string LinkDescription { get; set; }

        /// <summary>
        /// Name of Link; ex: Homepage
        /// </summary>
        public string LinkName { get; set; }

        /// <summary>
        /// Text Displayed to User
        /// </summary>
        public string LinkText { get; set; }

        /// <summary>
        /// from LinkType enum
        /// </summary>
        public LinkType LinkType { get; set; }

        /// <summary>
        /// The href of the link
        /// </summary>
        public string LinkUrl { get; set; }

        public bool IsValidUrl()
        {
            if (!string.IsNullOrEmpty(this.LinkUrl))
            {
                return _Val.IsValid(_Val.URL, this.LinkUrl);
            }
            else
            {
                throw new ArgumentNullException("LinkUrl", "Value for LinkUrl Must Be Provided!");
            }
        }
    }
}