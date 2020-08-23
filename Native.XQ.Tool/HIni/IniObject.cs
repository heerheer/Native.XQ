using System;
using System.Collections.Generic;
using System.IO;

namespace Native.XQ.HIni.Tool
{
    public class IniObject
    {
        /// <summary>
        /// 文件信息
        /// </summary>
        public FileInfo Fileinfo { get; set; }

        /// <summary>
        /// 节列表
        /// </summary>
        public List<IniSection> Sections { get; set; } = new List<IniSection>();

        public IniObject(string path)
        {
            Fileinfo = new FileInfo(path);
            if (!Fileinfo.Exists)
                Fileinfo.Create().Close();
        }

        /// <summary>
        /// 一行一行解析
        /// </summary>
        public void Load()
        {
            using (var stream = Fileinfo.OpenRead())
            {
                StreamReader reader = new StreamReader(stream);
                var line = reader.ReadLine();

                IniSection section = null;

                while (line != null)
                {
                    //解析这一行

                    line = line.Trim();

                    if (line.StartsWith("#") || line.StartsWith("//") || line.Equals(""))
                    {
                        //注释，直接跳过
                    }

                    if (line.StartsWith("[") && line.EndsWith("]"))
                    {
                        //section标识
                        if (section != null)
                        {
                            //将上一次解析的section存入列表
                            Sections.Add(section);
                            //创建新的Section
                            section = new IniSection(line, true);
                        }
                        else
                        {
                            section = new IniSection(line, true);
                        }
                    }
                    if (line.Contains("="))
                    {
                        var vs = line.Split('=');
                        //创建键值对
                        KeyValuePair<string, string> pair = new KeyValuePair<string, string>(vs[0], vs[1]);

                        if (section != null)
                        {
                            section.Values.Add(pair);
                        }
                        else
                        {
                            throw new Exception("Section不存在但解析到Key-Value对");
                        }
                    }
                    line = reader.ReadLine();
                }
                if (section != null)
                {
                    Sections.Add(section);
                }
                reader.Dispose();
                reader.Close();
            }
        }

        /// <summary>
        /// 将文件保存
        /// </summary>
        public void Save()
        {
            using (var writer = new StreamWriter(Fileinfo.FullName, false))
            {
                foreach (var item in Sections)
                {
                    writer.WriteLine("[" + item.SectionName + "]");

                    foreach (var pair in item.Values)
                    {
                        writer.WriteLine(pair.Key + "=" + pair.Value);
                    }
                }
            }
        }

        /// <summary>
        /// 获取节
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IniSection this[string name]
        {
            get
            {
                var section = Sections.Find(s => s.SectionName == name);
                if (section == null)
                {
                    //若不存在创建新的Section
                    section = new IniSection(name);
                    this.Sections.Add(section);//获取时候会自动创建到实例中
                }

                return section;
            }
        }
    }

    public class IniSection
    {
        /// <summary>
        /// 节名称
        /// </summary>
        public string SectionName { get; set; }

        /// <summary>
        /// 键值对列表
        /// </summary>
        public List<KeyValuePair<string, string>> Values { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="name"></param>
        /// <param name="ex">是否处理[]</param>
        public IniSection(string name, bool ex = false)
        {
            Values = new List<KeyValuePair<string, string>>();
            SectionName = name;
            if (ex)
            {
                SectionName = SectionName.TrimStart('[').TrimEnd(']');//如果没有也不会分割
            }
        }

        /// <summary>
        /// 获取Key对应的Value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public String this[string key]
        {
            get
            {
                var pair = Values.Find(p => p.Key == key);
                if (pair.Equals(default(KeyValuePair<string, string>)))
                {
                    pair = new KeyValuePair<string, string>(key, "");
                    Values.Add(pair);
                }
                return pair.Value;
            }
            set
            {
                var index = Values.FindIndex(p => p.Key == key);
                if (index == -1)
                {
                    var pair = new KeyValuePair<string, string>(key, value);
                    Values.Add(pair);
                }
                else
                {
                    Values[index] = new KeyValuePair<string, string>(key, value);
                }
            }
        }
    }
}