using UnityEngine;
using System.Collections;
using System.Text;  
using System.Xml;  
using System;  
using System.Collections.Generic;  
using System.IO;  
using System.Runtime.CompilerServices;  
using System.Xml.XPath;  
/// Code By D.S.Qiu  
/* 
 * 具体规则可参考：http://www.w3school.com.cn/xpath/index.asp 
 * 或者：https://msdn.microsoft.com/en-us/library/ms256471(v=vs.110).aspx 
 * https://msdn.microsoft.com/en-us/library/ms256453(v=vs.110).aspx 
 * 
 * 1.节点 
 * a)./author 或 author  当前节点的所有<author>子节点 
 * b)/author             根节点的所有<author>子节点 
 * c)//author            根节点的所有<author>节点   注 .//author 当前节点所有<author>节点 
 * d).                   选取当前节点 
 * e)..                  选取当前节点的父节点 
 * f)@                   选取属性 
 
author/first-name  All <first-name> elements within an <author> element of the current context node. 
bookstore//title  All <title> elements one or more levels deep in the <bookstore> element (arbitrary descendants). 
.//title  All <title> elements one or more levels deep in the current context. Note that this situation is essentially the only one in which the period notation is required. 
 
@style  The style attribute of the current element context. 
price/@exchange The exchange attribute of <price> elements within the current context. 
book/@style The style attribute of all <book> elements. 
Note that the following example is not valid, because an attribute cannot have any children. 
price/@exchange/total 
 * 
 * 2.谓词 
 * a)[]                  谓语被嵌在方括号中 
 *     /bookstore/book[price>35.00]  选取 bookstore 元素的所有 book 元素，且其中的 price 元素的值须大于 35.00。 
*     /bookstore/book[position()<3] 选取最前面的两个属于 bookstore 元素的子元素的 book 元素。 
*     //title[@lang='eng'] 选取所有 title 元素，且这些元素拥有值为 eng 的 lang 属性。 
*     book[excerpt]  All <book> elements that contain at least one <excerpt> element. 
book[excerpt]/title  All <title> elements inside <book> elements that contain at least one <excerpt> element. 
book[excerpt]/author[degree]  All <author> elements that contain at least one <degree> element, and are inside of <book> elements that contain at least one <excerpt> element. 
book[author/degree]  All <book> elements that contain at least one <author> element with at least one <degree> child element. 
book[excerpt][title] All <book> elements that contain at least one <excerpt> element and at least one <title> element. 

* b)*                   匹配任何元素节点 
* c)@*                  匹配任何属性节点 
* d)node()              匹配任何类型的节点 
* 
* 3.轴 
* a)ancestor   选取当前节点的所有先辈（父、祖父等）。 
* b)ancestor-or-self   选取当前节点的所有先辈（父、祖父等）以及当前节点本身。 
* c)attribute  选取当前节点的所有属性。 
* d)child  选取当前节点的所有子元素。 
* e)descendant 选取当前节点的所有后代元素（子、孙等）。 
* f)descendant-or-self 选取当前节点的所有后代元素（子、孙等）以及当前节点本身。 
* g)following  选取文档中当前节点的结束标签之后的所有节点。 
* h)namespace  选取当前节点的所有命名空间节点。 
* i)parent 选取当前节点的父节点。 
* j)preceding  选取文档中当前节点的开始标签之前的所有节点。 
* k)preceding-sibling  选取当前节点之前的所有同级节点。 
* l)self   选取当前节点。 
* 步的语法： 
轴（axis） 
定义所选节点与当前节点之间的树关系 
节点测试（node-test） 
识别某个轴内部的节点 
零个或者更多谓语（predicate） 
更深入地提炼所选的节点集 
轴名称::节点测试[谓语] 
实例 
child::book 选取所有属于当前节点的子元素的 book 节点。 
attribute::lang 选取当前节点的 lang 属性。 
child::*    选取当前节点的所有子元素。   和 * 一致 
child::text()   选取当前节点的所有文本子节点。 和 . 一致 
child::node()   选取当前节点的所有子节点。   和 .. 一致 
* 
* 
Precedence 
Precedence order (from highest precedence to lowest) between Boolean and comparison operators is shown in the following table. 

Precedence  Operators   Description 
1 ( ) Grouping 
2 [ ] Filters 
3 /   Path operations 
// 
4 &lt;  Comparisons 
&lt;= 
    &gt; 
&gt;= 
    5 = Comparisons 
    != 
    6 | Union 
    7 not() Boolean not 
    8 and Boolean and 
    9 or  Boolean or 
    * 
    */ 

    public static class XmlExtension  
    {  


        public static XmlNode UpdateAttribute(this XmlNode node,string name,string value)  
        {  
            XmlAttribute newAttr = node.OwnerDocument.CreateAttribute(name);  
            newAttr.Value = value;  
            //xn.Attributes.RemoveNamedItem(attributeValues[i]);  
            node.Attributes.SetNamedItem(newAttr);     //设置属性  
            return node;  
        }  

        public static XmlNode DeleteAttribute(this XmlNode node, string name)  
        {  
            if (node.Attributes == null)  
            {  
                Debug.Log("This XMLNode have no attribute!");  
            }  
            else  
            {  
                XmlAttribute attribute = node.Attributes[name];  
                node.Attributes.Remove(attribute);  
            }  
            return node;  
        }  

        public static XmlNode DeleteElement(this XmlNode node,string xpath)  
        {  
            XmlNodeList rootNodes = node.SelectNodes(xpath);  
            if(rootNodes == null || rootNodes.Count == 0)  
            {  
                Debug.Log(string.Format("Not Found the node {0} in the XmlNode!",xpath));  
                return node;  
            }  
            //遍历所有子节点  
            foreach (XmlNode xn in rootNodes)  
            {  
                node.RemoveChild(xn);  
            }  
            return node;  
        }  

        /// <summary>  
        ///   
        /// </summary>  
        /// <param name="node"></param>  
        /// <param name="xpath"></param>  
        /// <param name="nodeName"></param>  
        /// <param name="nodeText"></param>  
        /// <returns>方便chain call</returns>  
        public static System.Xml.XmlElement AppendElement(this XmlNode node,string xpath,string nodeName,string nodeText)  
        {  
            XmlNode rootNode = node.SelectSingleNode(xpath);  
            if(rootNode == null )  
            {  
                Debug.Log(string.Format("Not Found the node {0} in the XmlNode!",xpath));  
                return null;  
            }  

            XmlElement sonNode = node.OwnerDocument.CreateElement(nodeName);    //添加子节点  
            sonNode.InnerText = nodeText;  
            rootNode.AppendChild(sonNode);       //添加子节点  
            return sonNode;  
        }  

        public static System.Xml.XmlElement AppendElement(this XmlNode node,  string nodeName, string nodeText = "")  
        {  
            XmlElement sonNode = node.OwnerDocument.CreateElement(nodeName);    //添加子节点  
            sonNode.InnerText = nodeText;  
            node.AppendChild(sonNode);       //添加子节点  
            return sonNode;  
        }  
    }  

    /// <summary>  
    /// 默认把xml的命名工具都去掉，方便使用 XPath 表达式，保存之后再替换回来  
    /// 所有解析必须在Begin 和 End 之间调用  
    /// </summary>  
    public class XmlUtility  
    {  


        /*public class XPath 
    { 
        public const string FilterFormat = "[{0}]"; 
        public const string StepFormat = "{0}::{1}[{2}]"; 
 
 
        private static StringBuilder s_content = new StringBuilder(); 
 
        public XPath Clear() 
        { 
            s_content = new StringBuilder(); 
            return this; 
        } 
 
        public XPath Append(string path) 
        { 
            s_content.Append (path); 
            return this; 
        } 
 
        public XPath AppendFormat(string format,params string[] param) 
        { 
            return Append(string.Format(format, param)); 
        } 
 
        public XPath AppendNode(string nodeName) 
        { 
            return Append("/" + nodeName); 
        } 
 
        public XPath AppendAnyNode(string nodeName) 
        { 
            return Append("//" + nodeName); 
        } 
 
        public XPath AppendFilter(string filter) 
        { 
            return AppendFormat(FilterFormat, filter); 
        } 
 
        public XPath AppendStep(string axis,string nodeTest ="*",string predicate = "*") 
        { 
            return AppendFormat (StepFormat, axis, nodeTest, predicate); 
        } 
 
    }*/  

        public const string Xmlns = "xmlns";  
        public const string XmlnsReplace = "xmlns_replace";  

        private static XmlDocument xmlDoc = null;//new XmlDocument();  
        private static bool replaceXmlns = false;  
        private static string xmlPath;  


        public static void Begin(string xmlPath, bool replaceXmlns = true)  
        {  
            XmlUtility.xmlPath = xmlPath;  
            XmlUtility.replaceXmlns = replaceXmlns;  
            Load(xmlPath, replaceXmlns);  
        }  

        public static void End(bool save = true)  
        {  
            if(save)  
                Save(XmlUtility.xmlPath,XmlUtility.replaceXmlns);  
            xmlDoc = null;  
        }  

        private static void Load(string xmlPath,bool replaceXmlns)  
        {  
            xmlDoc = new XmlDocument ();  
            try  
            {  
                string xmlText = File.ReadAllText(xmlPath);  
                //去掉命名空间  
                if (replaceXmlns)  
                    xmlText = xmlText.Replace(Xmlns, XmlnsReplace);  
                xmlDoc.LoadXml(xmlText);  
            }  
            catch(Exception ex)  
            {  
                Debug.LogError("XmlDocument Load Error: " + ex.ToString());  
            }  
        }  

        private static void Save(string xmlPath, bool replaceXmlns)  
        {  
            if (xmlDoc == null)  
                return ;  
            try  
            {  
                xmlDoc.Save(xmlPath);  
                //恢复默命名空间  
                if (replaceXmlns)  
                {  
                    string xmlText = File.ReadAllText(xmlPath);  
                    xmlText = xmlText.Replace(XmlnsReplace,Xmlns);  
                    File.WriteAllText(xmlPath,xmlText);  
                }  
            }  
            catch (Exception ex)  
            {  
                Debug.LogError("XmlDocument Save Error: " + ex.ToString());  
            }  
        }  


        /// <summary>  
        /// The result of the expression (Boolean, number, string, or node set). This maps to Boolean, Double, String, or  
        /// XPathNodeIterator objects respectively.  
        /// 注意：如果返回的是 XPathNodeIterator 不会获得所有元素，必须帝调用MoveNext()才能取得元素  
        /// 查看：https://msdn.microsoft.com/en-us/library/system.xml.xpath.xpathnodeiterator.aspx 的 Remarks  
        /// </summary>  
        /// <param name="xmlPath">Xml path.</param>  
        /// <param name="xpath">Xpath.</param>  
        public static object Evaluate(string xpath)  
        {  
            //XmlDocument xmlDoc = Load (xmlPath);  
            if (xmlDoc == null)  
                return null;  
            XPathNavigator navigator = xmlDoc.CreateNavigator();  
            try  
            {  
                XPathExpression expression = navigator.Compile(xpath);  
                return navigator.Evaluate(expression);  
            }  
            catch (Exception ex)  
            {  
                Debug.LogError("XPath Evalute Error: " + ex.ToString());  
                return null;  
            }  
        }  


        public static XmlNode FindElement(string xpath)  
        {  
            //XmlDocument xmlDoc = Load (xmlPath);  
            if (xmlDoc == null)  
                return null;  
            var test = xmlDoc.SelectNodes (xpath);  
            return xmlDoc.SelectSingleNode (xpath);  
        }  

        public static XmlNodeList FindElements(string xpath)  
        {  
            //XmlDocument xmlDoc = Load (xmlPath);  
            if (xmlDoc == null)  
                return null;  
            return xmlDoc.SelectNodes (xpath);  
        }  


        public static void AppendElement(string xpath,string nodeName,string nodeText)  
        {  
            //XmlDocument xmlDoc = Load (xmlPath);  
            if (xmlDoc == null)  
                return;  
            xmlDoc.AppendElement (xpath,nodeName,nodeText);  
            //xmlDoc.Save (xmlPath);  
        }  

        public static void DeleteElement(string xpath)  
        {  
            //XmlDocument xmlDoc = Load (xmlPath);  
            if (xmlDoc == null)  
                return;  
            xmlDoc.DeleteElement (xpath);  
            //xmlDoc.Save (xmlPath);  
        }    

    }  
    