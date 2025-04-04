using System.IO;
using System.Web;
using System.Xml;
using System.Xml.Xsl;
using CnSharp.Serialization;

namespace CnSharp.CodeGenerator
{
    public class XsltGenerator : IGenerator
    {
        public string GenerateFromFile(string templateFile, object data)
        {
            var doc = new XmlDocument();
            doc.LoadXml(data is string ? data.ToString() : XmlSerializationHelper.SerializeToXml(data));
            return TransferXmlToStringByXsltFile(doc, templateFile);
        }

        public string GenerateFromText(string templateText, object data)
        {
            var doc = new XmlDocument();
            doc.LoadXml(data is string ? data.ToString() : XmlSerializationHelper.SerializeToXml(data));
            return TransferXmlToStringByXsltText(doc, templateText);
        }

        private static string FormatXml(XmlDocument xmlDoc, XslCompiledTransform xslTran)
        {
            using (var ms = new MemoryStream())
            {
                var nav = xmlDoc.CreateNavigator();
                xslTran.Transform(nav, null, ms);
                ms.Position = 0;
                using (var sr = new StreamReader(ms))
                {
                    var resultStr = sr.ReadToEnd();
                    resultStr = resultStr.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", "");
                    return HttpUtility.HtmlDecode(resultStr);
                }
            }
        }

        private static string TransferXmlToStringByXsltFile(XmlDocument xmlDoc, string xsltPath)
        {
            var xslTran = new XslCompiledTransform();
            var settings = new XsltSettings(true, true);
            xslTran.Load(xsltPath, settings, new XmlUrlResolver());
            return FormatXml(xmlDoc, xslTran);
        }

        private static string TransferXmlToStringByXsltText(XmlDocument xmlDoc, string xsltText)
        {
            var xslTran = new XslCompiledTransform();
            var settings = new XsltSettings(true, true);
            var xsltDoc = new XmlDocument();
            xsltDoc.LoadXml(xsltText);
            xslTran.Load(xsltDoc, settings, new XmlUrlResolver());
            return FormatXml(xmlDoc, xslTran);
        }
    }
}