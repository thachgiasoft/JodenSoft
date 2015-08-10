using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml;

namespace SAF.Foundation.Security
{
    /// <summary>
    /// xml签名及验证类
    /// </summary>
    public static class RSASignatureHelper
    {
        private static int keyLength = 4096;

        private static string FormatXml(System.Xml.XmlDocument xmlDoc)
        {
            try
            {
                System.IO.StringWriter sw = new System.IO.StringWriter();
                using (System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(sw))
                {
                    //与xml序列化返回相同的encoding
                    writer.Indentation = 2;  // the Indentation
                    writer.Formatting = System.Xml.Formatting.Indented;
                    xmlDoc.WriteContentTo(writer);
                    writer.Close();
                }
                return sw.ToString();
            }
            catch
            {
                throw;
            }

        }

        private static XmlDocument LoadXml(string xmlString)
        {
            if (string.IsNullOrWhiteSpace(xmlString))
                throw new ArgumentException("传入的XML为空");
            xmlString = xmlString.Trim();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlString);
            return doc;
        }

        /// <summary>
        /// 对传入xml文档对象进行签名
        /// </summary>
        /// <param name="privateKey">私钥</param>
        /// <param name="signXmlDoc">待签名的xml文档对象</param>
        /// <returns>返回签名后的xml文本</returns>
        public static string Signature(string privateKey, string xmlString)
        {
            var _RSAProvider = new RSACryptoServiceProvider(keyLength);
            _RSAProvider.FromXmlString(privateKey);

            XmlDocument signXmlDoc = LoadXml(xmlString);

            // Create a SignedXml object.
            SignedXml signedXml = new SignedXml(signXmlDoc);
            // Add the key to the SignedXml document. 
            signedXml.SigningKey = _RSAProvider;

            // Create a reference to be signed.
            Reference reference = new Reference();
            reference.Uri = "";

            // Add an enveloped transformation to the reference.
            XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
            reference.AddTransform(env);

            // Add the reference to the SignedXml object.
            signedXml.AddReference(reference);

            // Compute the signature.
            signedXml.ComputeSignature();

            // Get the XML representation of the signature and save
            // it to an XmlElement object.
            XmlElement xmlDigitalSignature = signedXml.GetXml();

            // Append the element to the XML document.
            signXmlDoc.DocumentElement.AppendChild(signXmlDoc.ImportNode(xmlDigitalSignature, true));

            if (signXmlDoc.FirstChild is XmlDeclaration)
            {
                signXmlDoc.RemoveChild(signXmlDoc.FirstChild);
            }
            return FormatXml(signXmlDoc);
        }

        /// <summary>
        /// 对传入xml文档对象进行签名验证
        /// </summary>
        /// <param name="verifyXmlDoc">待验证的xml文档对象</param>
        /// <returns>验证成功，返回true,否则返回false</returns>
        public static bool Verify(string publicKey, string verifyXmlString)
        {
            XmlDocument verifyXmlDoc = LoadXml(verifyXmlString);
            try
            {
                // Create a new SignedXml object and pass it
                // the XML document class.
                SignedXml signedXml = new SignedXml(verifyXmlDoc);

                // Find the "Signature" node and create a new
                // XmlNodeList object.
                XmlNodeList nodeList = verifyXmlDoc.GetElementsByTagName("Signature");
                if (nodeList.Count < 1)
                    return false;

                // Load the signature node.
                signedXml.LoadXml((XmlElement)nodeList[0]);

                var _RSAProvider = new RSACryptoServiceProvider(keyLength);
                _RSAProvider.FromXmlString(publicKey);

                // Check the signature and return the result.
                return signedXml.CheckSignature(_RSAProvider);
            }
            catch
            {
                return false;
            }
        }

    }
}
